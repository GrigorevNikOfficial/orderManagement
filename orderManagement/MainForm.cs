using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using Microsoft.EntityFrameworkCore;
using Spreadsheet = DocumentFormat.OpenXml.Spreadsheet;
using orderManagement.Data;
using orderManagement.Forms;
using orderManagement.Models;

namespace orderManagement;

public partial class MainForm : Form
{
    private static readonly CultureInfo ReportCulture = CultureInfo.GetCultureInfo("ru-RU");
    private readonly OrderManagementContext dbContext;
    private bool customerFilterActive;
    private bool itemFilterActive;
    private bool orderFilterActive;

    public MainForm()
    {
        InitializeComponent();
        dbContext = new OrderManagementContext();
        Load += MainForm_Load;
        FormClosing += MainForm_FormClosing;
    }

    private void MainForm_Load(object? sender, EventArgs e)
    {
        try
        {
            dbContext.Customers.Load();
            customerBindingSource.DataSource = dbContext.Customers.Local.ToBindingList();

            dbContext.Items.Load();
            itemBindingSource.DataSource = dbContext.Items.Local.ToBindingList();

            dbContext.Orders.Include(o => o.Customer).Include(o => o.Item).Load();
            orderBindingSource.DataSource = dbContext.Orders.Local.ToBindingList();

            ConfigureOrderLookups();

            comboBoxItemDelivery.SelectedIndex = 0;
            comboBoxOrderCustomer.SelectedIndex = -1;
            comboBoxOrderItem.SelectedIndex = -1;

            dateTimePickerOrderDate.Checked = false;
            dateTimePickerOrderDate.Value = DateTime.Today;
            orderDateColumn.DefaultCellStyle.Format = "d";
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Ошибка при загрузке данных: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void ConfigureOrderLookups()
    {
        comboBoxOrderCustomer.DataSource = dbContext.Customers.Local.ToList();
        comboBoxOrderCustomer.DisplayMember = nameof(Customer.Name);
        comboBoxOrderCustomer.ValueMember = nameof(Customer.CustomerId);
        comboBoxOrderCustomer.SelectedIndex = -1;

        comboBoxOrderItem.DataSource = dbContext.Items.Local.ToList();
        comboBoxOrderItem.DisplayMember = nameof(Item.Description);
        comboBoxOrderItem.ValueMember = nameof(Item.ItemId);
        comboBoxOrderItem.SelectedIndex = -1;
    }

    private void MainForm_FormClosing(object? sender, FormClosingEventArgs e)
    {
        dbContext.Dispose();
    }

    private void buttonCustomerAdd_Click(object? sender, EventArgs e)
    {
        using var form = new CustomerAddForm(dbContext);
        if (form.ShowDialog(this) == DialogResult.OK)
        {
            RefreshCustomersView();
            ConfigureOrderLookups();
        }
    }

    private void buttonCustomerEdit_Click(object? sender, EventArgs e)
    {
        if (GetSelectedCustomer() is not Customer customer)
        {
            MessageBox.Show("Выберите клиента для редактирования.");
            return;
        }

        using var form = new CustomerEditForm(customer, dbContext);
        if (form.ShowDialog(this) == DialogResult.OK)
        {
            dbContext.Entry(customer).Reload();
            RefreshCustomersView();
            ConfigureOrderLookups();
        }
    }

    private void buttonCustomerDelete_Click(object? sender, EventArgs e)
    {
        if (GetSelectedCustomer() is not Customer customer)
        {
            MessageBox.Show("Выберите клиента для удаления.");
            return;
        }

        var confirm = MessageBox.Show($"Удалить клиента: {customer.Name}?", "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
        if (confirm != DialogResult.Yes)
        {
            return;
        }

        try
        {
            dbContext.Customers.Remove(customer);
            dbContext.SaveChanges();
            RefreshCustomersView();
            ConfigureOrderLookups();
            RefreshOrdersView();
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Ошибка при удалении: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void buttonCustomerApplyFilter_Click(object? sender, EventArgs e)
    {
        customerFilterActive = true;
        ApplyCustomerFilterInternal();
    }

    private void buttonCustomerClearFilter_Click(object? sender, EventArgs e)
    {
        customerFilterActive = false;
        textBoxCustomerName.Clear();
        textBoxCustomerContact.Clear();
        textBoxCustomerPhone.Clear();
        textBoxCustomerAddress.Clear();
        dataGridViewCustomers.DataSource = customerBindingSource;
        customerBindingSource.ResetBindings(false);
    }

    private void ApplyCustomerFilterInternal()
    {
        var nameFilter = textBoxCustomerName.Text.Trim();
        var contactFilter = textBoxCustomerContact.Text.Trim();
        var phoneFilter = textBoxCustomerPhone.Text.Trim();
        var addressFilter = textBoxCustomerAddress.Text.Trim();

        var filtered = dbContext.Customers.Local.Where(customer =>
            MatchesFilter(customer.Name, nameFilter) &&
            MatchesFilter(customer.ContactPerson, contactFilter) &&
            MatchesFilter(customer.Phone, phoneFilter) &&
            MatchesFilter(customer.Address, addressFilter)
        ).ToList();

        dataGridViewCustomers.DataSource = new BindingList<Customer>(filtered);
    }

    private void RefreshCustomersView()
    {
        customerBindingSource.DataSource = dbContext.Customers.Local.ToBindingList();
        customerBindingSource.ResetBindings(false);

        if (customerFilterActive)
        {
            ApplyCustomerFilterInternal();
        }
        else
        {
            dataGridViewCustomers.DataSource = customerBindingSource;
        }
    }

    private Customer? GetSelectedCustomer()
    {
        return dataGridViewCustomers.CurrentRow?.DataBoundItem as Customer;
    }

    private void buttonItemAdd_Click(object? sender, EventArgs e)
    {
        using var form = new ItemAddForm(dbContext);
        if (form.ShowDialog(this) == DialogResult.OK)
        {
            RefreshItemsView();
            ConfigureOrderLookups();
        }
    }

    private void buttonItemEdit_Click(object? sender, EventArgs e)
    {
        if (GetSelectedItem() is not Item item)
        {
            MessageBox.Show("Выберите товар для редактирования.");
            return;
        }

        using var form = new ItemEditForm(item, dbContext);
        if (form.ShowDialog(this) == DialogResult.OK)
        {
            dbContext.Entry(item).Reload();
            RefreshItemsView();
            ConfigureOrderLookups();
            RefreshOrdersView();
        }
    }

    private void buttonItemDelete_Click(object? sender, EventArgs e)
    {
        if (GetSelectedItem() is not Item item)
        {
            MessageBox.Show("Выберите товар для удаления.");
            return;
        }

        var confirm = MessageBox.Show($"Удалить товар: {item.Description}?", "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
        if (confirm != DialogResult.Yes)
        {
            return;
        }

        try
        {
            dbContext.Items.Remove(item);
            dbContext.SaveChanges();
            RefreshItemsView();
            ConfigureOrderLookups();
            RefreshOrdersView();
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Ошибка при удалении: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void buttonItemApplyFilter_Click(object? sender, EventArgs e)
    {
        itemFilterActive = true;
        if (!ValidatePriceFilter())
        {
            return;
        }

        ApplyItemFilterInternal();
    }

    private bool ValidatePriceFilter()
    {
        var min = numericItemPriceMin.Value;
        var max = numericItemPriceMax.Value;

        if (max > 0 && max < min)
        {
            MessageBox.Show("Значение 'До' не может быть меньше 'От'.", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return false;
        }

        return true;
    }

    private void buttonItemClearFilter_Click(object? sender, EventArgs e)
    {
        itemFilterActive = false;
        textBoxItemDescription.Clear();
        numericItemPriceMin.Value = 0;
        numericItemPriceMax.Value = 0;
        comboBoxItemDelivery.SelectedIndex = 0;
        dataGridViewItems.DataSource = itemBindingSource;
        itemBindingSource.ResetBindings(false);
    }

    private void ApplyItemFilterInternal()
    {
        var description = textBoxItemDescription.Text.Trim();
        var minPrice = (int)numericItemPriceMin.Value;
        var maxPrice = (int)numericItemPriceMax.Value;
        var deliveryFilter = comboBoxItemDelivery.SelectedIndex;

        var filtered = dbContext.Items.Local.Where(item =>
            MatchesFilter(item.Description, description) &&
            (!HasLowerBound(minPrice) || item.Price >= minPrice) &&
            (!HasUpperBound(maxPrice) || item.Price <= maxPrice) &&
            MatchesDeliveryFilter(item.Delivery, deliveryFilter)
        ).ToList();

        dataGridViewItems.DataSource = new BindingList<Item>(filtered);
    }

    private void RefreshItemsView()
    {
        itemBindingSource.DataSource = dbContext.Items.Local.ToBindingList();
        itemBindingSource.ResetBindings(false);

        if (itemFilterActive)
        {
            ApplyItemFilterInternal();
        }
        else
        {
            dataGridViewItems.DataSource = itemBindingSource;
        }
    }

    private Item? GetSelectedItem()
    {
        return dataGridViewItems.CurrentRow?.DataBoundItem as Item;
    }

    private bool MatchesDeliveryFilter(bool delivery, int filterIndex)
    {
        return filterIndex switch
        {
            1 => delivery,
            2 => !delivery,
            _ => true
        };
    }

    private static bool HasLowerBound(int value) => value > 0;
    private static bool HasUpperBound(int value) => value > 0;

    private void buttonOrderAdd_Click(object? sender, EventArgs e)
    {
        using var form = new OrderAddForm(dbContext);
        if (form.ShowDialog(this) == DialogResult.OK)
        {
            RefreshOrdersView();
        }
    }

    private void buttonOrderEdit_Click(object? sender, EventArgs e)
    {
        if (GetSelectedOrder() is not Order order)
        {
            MessageBox.Show("Выберите заказ для редактирования.");
            return;
        }

        using var form = new OrderEditForm(order, dbContext);
        if (form.ShowDialog(this) == DialogResult.OK)
        {
            dbContext.Entry(order).Reference(o => o.Customer).Load();
            dbContext.Entry(order).Reference(o => o.Item).Load();
            RefreshOrdersView();
        }
    }

    private void buttonOrderDelete_Click(object? sender, EventArgs e)
    {
        if (GetSelectedOrder() is not Order order)
        {
            MessageBox.Show("Выберите заказ для удаления.");
            return;
        }

        var confirm = MessageBox.Show($"Удалить заказ №{order.OrderId}?", "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
        if (confirm != DialogResult.Yes)
        {
            return;
        }

        try
        {
            dbContext.Orders.Remove(order);
            dbContext.SaveChanges();
            RefreshOrdersView();
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Ошибка при удалении: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void buttonOrderApplyFilter_Click(object? sender, EventArgs e)
    {
        orderFilterActive = true;
        if (!ValidateQuantityFilter())
        {
            return;
        }

        ApplyOrderFilterInternal();
    }

    private bool ValidateQuantityFilter()
    {
        var min = numericOrderQuantityMin.Value;
        var max = numericOrderQuantityMax.Value;

        if (max > 0 && max < min)
        {
            MessageBox.Show("Значение 'До' не может быть меньше 'От'.", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return false;
        }

        return true;
    }

    private void buttonOrderClearFilter_Click(object? sender, EventArgs e)
    {
        orderFilterActive = false;
        comboBoxOrderCustomer.SelectedIndex = -1;
        comboBoxOrderItem.SelectedIndex = -1;
        dateTimePickerOrderDate.Checked = false;
        numericOrderQuantityMin.Value = 0;
        numericOrderQuantityMax.Value = 0;
        dataGridViewOrders.DataSource = orderBindingSource;
        orderBindingSource.ResetBindings(false);
    }

    private void ApplyOrderFilterInternal()
    {
        var selectedCustomer = comboBoxOrderCustomer.SelectedItem as Customer;
        var selectedItem = comboBoxOrderItem.SelectedItem as Item;
        var useDate = dateTimePickerOrderDate.Checked;
        var selectedDate = DateOnly.FromDateTime(dateTimePickerOrderDate.Value.Date);
        var minQuantity = (int)numericOrderQuantityMin.Value;
        var maxQuantity = (int)numericOrderQuantityMax.Value;

        var filtered = dbContext.Orders.Local.Where(order =>
            (selectedCustomer == null || order.CustomerId == selectedCustomer.CustomerId) &&
            (selectedItem == null || order.ItemId == selectedItem.ItemId) &&
            (!useDate || DateOnly.FromDateTime(order.OrderDate.ToLocalTime().Date) == selectedDate) &&
            (!HasLowerBound(minQuantity) || order.Quantity >= minQuantity) &&
            (!HasUpperBound(maxQuantity) || order.Quantity <= maxQuantity)
        ).ToList();

        dataGridViewOrders.DataSource = new BindingList<Order>(filtered);
    }

    private void RefreshOrdersView()
    {
        dbContext.Orders.Include(o => o.Customer).Include(o => o.Item).Load();
        orderBindingSource.DataSource = dbContext.Orders.Local.ToBindingList();
        orderBindingSource.ResetBindings(false);

        if (orderFilterActive)
        {
            ApplyOrderFilterInternal();
        }
        else
        {
            dataGridViewOrders.DataSource = orderBindingSource;
        }
    }

    private Order? GetSelectedOrder()
    {
        return dataGridViewOrders.CurrentRow?.DataBoundItem as Order;
    }

    private void buttonOrderGenerateInvoice_Click(object? sender, EventArgs e)
    {
        if (GetSelectedOrder() is not Order order)
        {
            MessageBox.Show("Выберите заказ для формирования документа.");
            return;
        }

        try
        {
            dbContext.Entry(order).Reference(o => o.Customer).Load();
            dbContext.Entry(order).Reference(o => o.Item).Load();
            var filePath = CreateInvoiceDocument(order);
            OpenFile(filePath);
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Ошибка при формировании документа: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void buttonOrderGenerateReport_Click(object? sender, EventArgs e)
    {
        using var periodForm = new PeriodSelectorForm();
        if (periodForm.ShowDialog(this) != DialogResult.OK)
        {
            return;
        }

        var from = periodForm.DateFrom;
        var to = periodForm.DateTo;

        try
        {
            var orders = dbContext.Orders
                .Include(o => o.Customer)
                .Include(o => o.Item)
                .Where(o =>
                    DateOnly.FromDateTime(o.OrderDate.Date) >= from &&
                    DateOnly.FromDateTime(o.OrderDate.Date) <= to)
                .ToList();

            if (orders.Count == 0)
            {
                MessageBox.Show("Нет заказов за выбранный период.");
                return;
            }

            var filePath = CreateOrdersReportDocument(orders, from, to);
            OpenFile(filePath);
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Ошибка при формировании отчета: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void buttonOrderExportExcel_Click(object? sender, EventArgs e)
    {
        try
        {
            var orders = dbContext.Orders
                .Include(o => o.Customer)
                .Include(o => o.Item)
                .OrderBy(o => o.OrderDate)
                .ThenBy(o => o.Customer.Name)
                .ToList();

            if (orders.Count == 0)
            {
                MessageBox.Show("Нет данных для экспорта.", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var filePath = CreateOrdersExcelReport(orders);
            MessageBox.Show($"Файл сохранен: {filePath}", "Экспорт завершен", MessageBoxButtons.OK, MessageBoxIcon.Information);
            OpenFile(filePath);
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Ошибка при экспорте: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void buttonOrderExportExcelByDate_Click(object? sender, EventArgs e)
    {
        if (!dateTimePickerOrderDate.Checked)
        {
            MessageBox.Show("Отметьте флажок около поля даты перед экспортом.", "Экспорт по дате", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        var targetDate = DateOnly.FromDateTime(dateTimePickerOrderDate.Value.Date);

        try
        {
            var allOrders = dbContext.Orders
                .Include(o => o.Customer)
                .Include(o => o.Item)
                .ToList();

            var ordersForDate = allOrders
                .Where(o => DateOnly.FromDateTime(o.OrderDate.ToLocalTime().Date) == targetDate)
                .OrderBy(o => o.Customer.Name)
                .ThenBy(o => o.OrderDate)
                .ToList();

            if (ordersForDate.Count == 0)
            {
                MessageBox.Show("Заказов на выбранную дату нет.", "Экспорт по дате", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var filePath = CreateOrdersExcelReport(ordersForDate, targetDate);
            MessageBox.Show($"Файл сохранен: {filePath}", "Экспорт завершен", MessageBoxButtons.OK, MessageBoxIcon.Information);
            OpenFile(filePath);
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Ошибка при экспорте: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void buttonOrderExportHtmlDetailed_Click(object? sender, EventArgs e)
    {
        try
        {
            var orders = dbContext.Orders
                .Include(o => o.Customer)
                .Include(o => o.Item)
                .OrderBy(o => o.OrderDate)
                .ThenBy(o => o.Customer.Name)
                .ToList();

            if (orders.Count == 0)
            {
                MessageBox.Show("Нет данных для экспорта.", "Экспорт HTML", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            using var dialog = new SaveFileDialog
            {
                Filter = "HTML файлы (*.html)|*.html",
                Title = "Сохранение подробного HTML отчета",
                FileName = $"Orders_{DateTime.Now:yyyyMMdd_HHmm}.html"
            };

            if (dialog.ShowDialog(this) != DialogResult.OK)
            {
                return;
            }

            var htmlContent = BuildOrdersDetailedHtml(orders);
            File.WriteAllText(dialog.FileName, htmlContent, Encoding.UTF8);

            MessageBox.Show($"Файл сохранен: {dialog.FileName}", "Экспорт завершен", MessageBoxButtons.OK, MessageBoxIcon.Information);
            OpenFile(dialog.FileName);
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Ошибка при формировании HTML отчета: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void buttonOrderExportHtmlByCustomer_Click(object? sender, EventArgs e)
    {
        try
        {
            var customers = dbContext.Customers
                .Include(c => c.Orders)
                .ThenInclude(o => o.Item)
                .OrderBy(c => c.Name)
                .ToList();

            var customersWithOrders = customers.Where(c => c.Orders.Any()).ToList();

            if (customersWithOrders.Count == 0)
            {
                MessageBox.Show("Нет заказов для формирования отчета.", "Экспорт HTML", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            using var dialog = new SaveFileDialog
            {
                Filter = "HTML файлы (*.html)|*.html",
                Title = "Сохранение HTML отчета по клиентам",
                FileName = $"OrdersByCustomer_{DateTime.Now:yyyyMMdd_HHmm}.html"
            };

            if (dialog.ShowDialog(this) != DialogResult.OK)
            {
                return;
            }

            var htmlContent = BuildOrdersByCustomerHtml(customersWithOrders);
            File.WriteAllText(dialog.FileName, htmlContent, Encoding.UTF8);

            MessageBox.Show($"Файл сохранен: {dialog.FileName}", "Экспорт завершен", MessageBoxButtons.OK, MessageBoxIcon.Information);
            OpenFile(dialog.FileName);
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Ошибка при формировании HTML отчета: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void buttonOrderImportExcel_Click(object? sender, EventArgs e)
    {
        using var dialog = new OpenFileDialog
        {
            Filter = "Excel (*.xlsx)|*.xlsx",
            Title = "Выберите документ для загрузки данных"
        };

        if (dialog.ShowDialog(this) != DialogResult.OK)
        {
            return;
        }

        try
        {
            var summary = ImportDataFromExcel(dialog.FileName);
            RefreshCustomersView();
            RefreshItemsView();
            RefreshOrdersView();
            MessageBox.Show(summary, "Импорт завершен", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Ошибка импорта: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private string CreateOrdersExcelReport(IReadOnlyCollection<Order> orders, DateOnly? filterDate = null)
    {
        var folderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "orderManagementReports");
        Directory.CreateDirectory(folderPath);
        var fileName = filterDate.HasValue
            ? $"Orders_{filterDate:yyyyMMdd}_{DateTime.Now:HHmm}.xlsx"
            : $"Orders_{DateTime.Now:yyyyMMdd_HHmm}.xlsx";
        var filePath = Path.Combine(folderPath, fileName);

        using var document = SpreadsheetDocument.Create(filePath, SpreadsheetDocumentType.Workbook);
        var workbookPart = document.AddWorkbookPart();
        workbookPart.Workbook = new Spreadsheet.Workbook();

        var worksheetPart = workbookPart.AddNewPart<WorksheetPart>();
        var sheetData = new Spreadsheet.SheetData();
        var columns = new Spreadsheet.Columns(
            new Spreadsheet.Column { Min = 1, Max = 1, Width = 28, CustomWidth = true },
            new Spreadsheet.Column { Min = 2, Max = 2, Width = 20, CustomWidth = true },
            new Spreadsheet.Column { Min = 3, Max = 3, Width = 18, CustomWidth = true },
            new Spreadsheet.Column { Min = 4, Max = 4, Width = 30, CustomWidth = true },
            new Spreadsheet.Column { Min = 5, Max = 5, Width = 28, CustomWidth = true },
            new Spreadsheet.Column { Min = 6, Max = 6, Width = 12, CustomWidth = true },
            new Spreadsheet.Column { Min = 7, Max = 7, Width = 12, CustomWidth = true },
            new Spreadsheet.Column { Min = 8, Max = 8, Width = 12, CustomWidth = true },
            new Spreadsheet.Column { Min = 9, Max = 9, Width = 16, CustomWidth = true }
        );

        worksheetPart.Worksheet = new Spreadsheet.Worksheet(columns, sheetData);

        var sheets = workbookPart.Workbook.AppendChild(new Spreadsheet.Sheets());
        var sheet = new Spreadsheet.Sheet
        {
            Id = workbookPart.GetIdOfPart(worksheetPart),
            SheetId = 1,
            Name = "Orders"
        };
        sheets.Append(sheet);

        var styles = CreateStylesheet(document);

        sheetData.Append(CreateHeaderRow(styles.HeaderStyleIndex,
            "CustomerName",
            "ContactPerson",
            "Phone",
            "Address",
            "ItemDescription",
            "Price",
            "Delivery",
            "Quantity",
            "OrderDate"));

        foreach (var order in orders)
        {
            var row = new Spreadsheet.Row();
            row.Append(
                CreateTextCell(order.Customer.Name, styles.TextStyleIndex),
                CreateTextCell(order.Customer.ContactPerson, styles.TextStyleIndex),
                CreateTextCell(order.Customer.Phone, styles.TextStyleIndex),
                CreateTextCell(order.Customer.Address, styles.TextStyleIndex),
                CreateTextCell(order.Item.Description, styles.TextStyleIndex),
                CreateNumberCell(order.Item.Price, styles.CurrencyStyleIndex),
                CreateTextCell(order.Item.Delivery ? "TRUE" : "FALSE", styles.TextStyleIndex),
                CreateNumberCell(order.Quantity, styles.NumberStyleIndex),
                CreateDateCell(order.OrderDate.ToLocalTime(), styles.DateStyleIndex));
            sheetData.Append(row);
        }

        workbookPart.Workbook.Save();
        return filePath;
    }

    private static string BuildOrdersDetailedHtml(IReadOnlyCollection<Order> orders)
    {
        var totalQuantity = orders.Sum(o => o.Quantity);
        var totalAmount = orders.Sum(o => o.TotalCost);

        var sb = new StringBuilder();
        AppendHtmlProlog(sb, "Список заказов");
        sb.AppendLine($"<p>Дата формирования: {DateTime.Now.ToString("dd.MM.yyyy HH:mm", ReportCulture)}</p>");
        sb.AppendLine("<table>");
        sb.AppendLine("<thead>");
        sb.AppendLine("<tr>");
        sb.AppendLine("<th>ID</th>");
        sb.AppendLine("<th>Дата</th>");
        sb.AppendLine("<th>Клиент</th>");
        sb.AppendLine("<th>Контактное лицо</th>");
        sb.AppendLine("<th>Телефон</th>");
        sb.AppendLine("<th>Адрес</th>");
        sb.AppendLine("<th>Товар</th>");
        sb.AppendLine("<th>Количество</th>");
        sb.AppendLine("<th>Доставка</th>");
        sb.AppendLine("<th>Цена</th>");
        sb.AppendLine("<th>Сумма</th>");
        sb.AppendLine("</tr>");
        sb.AppendLine("</thead>");
        sb.AppendLine("<tbody>");

        foreach (var order in orders)
        {
            sb.AppendLine("<tr>");
            sb.AppendLine($"<td>{order.OrderId}</td>");
            sb.AppendLine($"<td>{FormatDateTime(order.OrderDate)}</td>");
            sb.AppendLine($"<td>{HtmlEncode(order.Customer.Name)}</td>");
            sb.AppendLine($"<td>{HtmlEncode(order.Customer.ContactPerson)}</td>");
            sb.AppendLine($"<td>{HtmlEncode(order.Customer.Phone)}</td>");
            sb.AppendLine($"<td>{HtmlEncode(order.Customer.Address)}</td>");
            sb.AppendLine($"<td>{HtmlEncode(order.Item.Description)}</td>");
            sb.AppendLine($"<td>{FormatNumber(order.Quantity)}</td>");
            sb.AppendLine($"<td>{(order.Item.Delivery ? "Да" : "Нет")}</td>");
            sb.AppendLine($"<td>{FormatNumber(order.Item.Price)} руб.</td>");
            sb.AppendLine($"<td>{FormatNumber(order.TotalCost)} руб.</td>");
            sb.AppendLine("</tr>");
        }

        sb.AppendLine("</tbody>");
        sb.AppendLine("</table>");
        sb.AppendLine($"<p class=\"summary\">Всего заказов: {orders.Count}</p>");
        sb.AppendLine($"<p class=\"summary\">Общий объем: {FormatNumber(totalQuantity)} шт.</p>");
        sb.AppendLine($"<p class=\"summary\">Общая стоимость: {FormatNumber(totalAmount)} руб.</p>");
        AppendHtmlEpilog(sb);

        return sb.ToString();
    }

    private static string BuildOrdersByCustomerHtml(IEnumerable<Customer> customers)
    {
        var grouped = customers
            .Select(customer => new
            {
                Customer = customer,
                Orders = customer.Orders
                    .OrderBy(o => o.OrderDate)
                    .ThenBy(o => o.Item.Description)
                    .ToList()
            })
            .Where(group => group.Orders.Count > 0)
            .ToList();

        var totalCustomers = grouped.Count;
        var totalOrders = grouped.Sum(g => g.Orders.Count);
        var totalQuantity = grouped.Sum(g => g.Orders.Sum(o => o.Quantity));
        var totalAmount = grouped.Sum(g => g.Orders.Sum(o => o.TotalCost));

        var sb = new StringBuilder();
        AppendHtmlProlog(sb, "Заказы по клиентам");
        sb.AppendLine($"<p>Дата формирования: {DateTime.Now.ToString("dd.MM.yyyy HH:mm", ReportCulture)}</p>");

        foreach (var group in grouped)
        {
            var customer = group.Customer;
            var orders = group.Orders;
            var customerQuantity = orders.Sum(o => o.Quantity);
            var customerAmount = orders.Sum(o => o.TotalCost);

            sb.AppendLine("<section class=\"customer\">");
            sb.AppendLine($"<h2>{HtmlEncode(customer.Name)}</h2>");
            sb.AppendLine("<div class=\"customer-info\">");
            sb.AppendLine($"<p><strong>Контактное лицо:</strong> {HtmlEncode(customer.ContactPerson)}</p>");
            sb.AppendLine($"<p><strong>Телефон:</strong> {HtmlEncode(customer.Phone)}</p>");
            sb.AppendLine($"<p><strong>Адрес:</strong> {HtmlEncode(customer.Address)}</p>");
            sb.AppendLine("</div>");
            sb.AppendLine("<table>");
            sb.AppendLine("<thead>");
            sb.AppendLine("<tr><th>Дата</th><th>Товар</th><th>Количество</th><th>Цена</th><th>Сумма</th></tr>");
            sb.AppendLine("</thead>");
            sb.AppendLine("<tbody>");

            foreach (var order in orders)
            {
                sb.AppendLine("<tr>");
                sb.AppendLine($"<td>{FormatDate(order.OrderDate)}</td>");
                sb.AppendLine($"<td>{HtmlEncode(order.Item.Description)}</td>");
                sb.AppendLine($"<td>{FormatNumber(order.Quantity)}</td>");
                sb.AppendLine($"<td>{FormatNumber(order.Item.Price)} руб.</td>");
                sb.AppendLine($"<td>{FormatNumber(order.TotalCost)} руб.</td>");
                sb.AppendLine("</tr>");
            }

            sb.AppendLine("</tbody>");
            sb.AppendLine("</table>");
            sb.AppendLine($"<p class=\"summary\">Всего заказов: {orders.Count}, товаров: {FormatNumber(customerQuantity)} шт., сумма: {FormatNumber(customerAmount)} руб.</p>");
            sb.AppendLine("</section>");
        }

        sb.AppendLine("<hr />");
        sb.AppendLine($"<p class=\"summary\">Клиентов с заказами: {totalCustomers}</p>");
        sb.AppendLine($"<p class=\"summary\">Всего заказов: {totalOrders}</p>");
        sb.AppendLine($"<p class=\"summary\">Всего товаров: {FormatNumber(totalQuantity)} шт.</p>");
        sb.AppendLine($"<p class=\"summary\">Общая сумма: {FormatNumber(totalAmount)} руб.</p>");
        AppendHtmlEpilog(sb);

        return sb.ToString();
    }

    private static void AppendHtmlProlog(StringBuilder sb, string title)
    {
        sb.AppendLine("<!DOCTYPE html>");
        sb.AppendLine("<html lang=\"ru\">");
        sb.AppendLine("<head>");
        sb.AppendLine("<meta charset=\"utf-8\" />");
        sb.AppendLine($"<title>{HtmlEncode(title)}</title>");
        sb.AppendLine("<style>");
        sb.AppendLine("body { font-family: Arial, sans-serif; margin: 32px; background-color: #f7f9fb; color: #1f2933; }");
        sb.AppendLine("h1 { margin-bottom: 16px; }");
        sb.AppendLine("h2 { margin-top: 32px; }");
        sb.AppendLine("table { border-collapse: collapse; width: 100%; margin-bottom: 16px; }");
        sb.AppendLine("th, td { border: 1px solid #cbd5e1; padding: 8px 12px; text-align: left; }");
        sb.AppendLine("th { background-color: #d9e8fc; }");
        sb.AppendLine("tbody tr:nth-child(even) { background-color: #eef2f7; }");
        sb.AppendLine(".summary { font-weight: bold; }");
        sb.AppendLine(".customer-info { margin-bottom: 12px; }");
        sb.AppendLine("section.customer { margin-bottom: 32px; }");
        sb.AppendLine("</style>");
        sb.AppendLine("</head>");
        sb.AppendLine("<body>");
        sb.AppendLine($"<h1>{HtmlEncode(title)}</h1>");
    }

    private static void AppendHtmlEpilog(StringBuilder sb)
    {
        sb.AppendLine("</body>");
        sb.AppendLine("</html>");
    }

    private static string HtmlEncode(string? value)
    {
        return WebUtility.HtmlEncode(value ?? string.Empty);
    }

    private static string FormatNumber(int value)
    {
        return value.ToString("N0", ReportCulture);
    }

    private static string FormatDate(DateTime value)
    {
        return value.ToLocalTime().ToString("dd.MM.yyyy", ReportCulture);
    }

    private static string FormatDateTime(DateTime value)
    {
        return value.ToLocalTime().ToString("dd.MM.yyyy HH:mm", ReportCulture);
    }

    private string ImportDataFromExcel(string filePath)
    {
        using var document = SpreadsheetDocument.Open(filePath, false);
        var workbookPart = document.WorkbookPart ?? throw new InvalidOperationException("Некорректный файл Excel.");

        var sheet = workbookPart.Workbook.Sheets?.Elements<Spreadsheet.Sheet>()
                       .FirstOrDefault(s => string.Equals(s.Name?.Value, "Orders", StringComparison.InvariantCultureIgnoreCase))
                   ?? workbookPart.Workbook.Sheets?.Elements<Spreadsheet.Sheet>().FirstOrDefault();

        if (sheet == null)
        {
            throw new InvalidOperationException("В книге отсутствуют листы.");
        }

        var worksheetPart = (WorksheetPart)workbookPart.GetPartById(sheet.Id!);
        var rows = worksheetPart.Worksheet.Descendants<Spreadsheet.Row>().ToList();
        if (rows.Count < 2)
        {
            return "Файл не содержит данных для импорта.";
        }

        var headers = GetRowValues(workbookPart, rows[0]);
        var headerCount = headers.Count;

        var addedCustomers = 0;
        var addedItems = 0;
        var addedOrders = 0;
        var skippedOrders = 0;
        var skippedOrdersMissingData = 0;

        for (var index = 1; index < rows.Count; index++)
        {
            var row = rows[index];
            var values = GetRowValues(workbookPart, row, headerCount);
            if (values.All(string.IsNullOrWhiteSpace))
            {
                continue;
            }

            var record = new Dictionary<string, string>(StringComparer.InvariantCultureIgnoreCase);
            for (var i = 0; i < headerCount; i++)
            {
                var header = headers[i];
                if (string.IsNullOrWhiteSpace(header))
                {
                    continue;
                }

                record[header.Trim()] = values[i];
            }

            record.TryGetValue("CustomerName", out var customerName);
            record.TryGetValue("ContactPerson", out var contactPerson);
            record.TryGetValue("Phone", out var phone);
            record.TryGetValue("Address", out var address);
            record.TryGetValue("ItemDescription", out var itemDescription);
            record.TryGetValue("Price", out var priceText);
            record.TryGetValue("Delivery", out var deliveryText);
            record.TryGetValue("Quantity", out var quantityText);
            record.TryGetValue("OrderDate", out var orderDateText);

            if (string.IsNullOrWhiteSpace(customerName) ||
                string.IsNullOrWhiteSpace(itemDescription) ||
                string.IsNullOrWhiteSpace(quantityText) ||
                string.IsNullOrWhiteSpace(orderDateText))
            {
                skippedOrdersMissingData++;
                continue;
            }

            if (!TryParseIntValue(quantityText, out var quantity) || quantity <= 0)
            {
                skippedOrders++;
                continue;
            }

            var orderDate = ParseExcelDate(orderDateText);
            if (orderDate == null)
            {
                skippedOrders++;
                continue;
            }

            var customer = dbContext.Customers.Local.FirstOrDefault(c => string.Equals(c.Name, customerName, StringComparison.InvariantCultureIgnoreCase));
            if (customer == null)
            {
                customer = new Customer
                {
                    Name = customerName.Trim(),
                    ContactPerson = contactPerson ?? string.Empty,
                    Phone = phone ?? string.Empty,
                    Address = address ?? string.Empty
                };
                dbContext.Customers.Add(customer);
                addedCustomers++;
            }
            else
            {
                if (!string.IsNullOrWhiteSpace(contactPerson) && string.IsNullOrWhiteSpace(customer.ContactPerson))
                {
                    customer.ContactPerson = contactPerson!;
                }

                if (!string.IsNullOrWhiteSpace(phone) && string.IsNullOrWhiteSpace(customer.Phone))
                {
                    customer.Phone = phone!;
                }

                if (!string.IsNullOrWhiteSpace(address) && string.IsNullOrWhiteSpace(customer.Address))
                {
                    customer.Address = address!;
                }
            }

            var item = dbContext.Items.Local.FirstOrDefault(i => string.Equals(i.Description, itemDescription, StringComparison.InvariantCultureIgnoreCase));
            if (item == null)
            {
                if (string.IsNullOrWhiteSpace(priceText) || !TryParseIntValue(priceText, out var price) || price < 0)
                {
                    skippedOrdersMissingData++;
                    continue;
                }

                var delivery = ParseExcelBoolean(deliveryText ?? string.Empty);
                item = new Item
                {
                    Description = itemDescription.Trim(),
                    Price = price,
                    Delivery = delivery
                };
                dbContext.Items.Add(item);
                addedItems++;
            }
            else
            {
                if (!string.IsNullOrWhiteSpace(priceText) && TryParseIntValue(priceText, out var parsedPrice) && parsedPrice >= 0)
                {
                    item.Price = parsedPrice;
                }

                if (!string.IsNullOrWhiteSpace(deliveryText))
                {
                    item.Delivery = ParseExcelBoolean(deliveryText ?? string.Empty);
                }
            }

            var normalizedDate = DateTime.SpecifyKind(orderDate.Value.Date, DateTimeKind.Utc);

            var duplicateOrder = dbContext.Orders.Local.FirstOrDefault(o =>
                string.Equals(o.Customer.Name, customer.Name, StringComparison.InvariantCultureIgnoreCase) &&
                string.Equals(o.Item.Description, item.Description, StringComparison.InvariantCultureIgnoreCase) &&
                o.OrderDate.Date == normalizedDate.Date &&
                o.Quantity == quantity);

            if (duplicateOrder != null)
            {
                skippedOrders++;
                continue;
            }

            var newOrder = new Order
            {
                Customer = customer,
                CustomerId = customer.CustomerId,
                Item = item,
                ItemId = item.ItemId,
                Quantity = quantity,
                OrderDate = normalizedDate
            };

            dbContext.Orders.Add(newOrder);
            addedOrders++;
        }

        dbContext.SaveChanges();

        return $"Импорт завершен.\nКлиенты: добавлено {addedCustomers}.\nТовары: добавлено {addedItems}.\nЗаказы: добавлено {addedOrders}.\nПропущено заказов (дубликаты/ошибки): {skippedOrders}.\nПропущено строк из-за отсутствующих данных: {skippedOrdersMissingData}.";
    }

    private ExcelStyles CreateStylesheet(SpreadsheetDocument document)
    {
        var stylesPart = document.WorkbookPart!.AddNewPart<WorkbookStylesPart>();

        var fonts = new Spreadsheet.Fonts(
            new Spreadsheet.Font(),
            new Spreadsheet.Font(new Spreadsheet.Bold()));

        var headerFill = new Spreadsheet.PatternFill
        {
            PatternType = Spreadsheet.PatternValues.Solid,
            ForegroundColor = new Spreadsheet.ForegroundColor { Rgb = new HexBinaryValue { Value = "FFDDEBF7" } },
            BackgroundColor = new Spreadsheet.BackgroundColor { Indexed = 64U }
        };

        var fills = new Spreadsheet.Fills(
            new Spreadsheet.Fill(new Spreadsheet.PatternFill { PatternType = Spreadsheet.PatternValues.None }),
            new Spreadsheet.Fill(new Spreadsheet.PatternFill { PatternType = Spreadsheet.PatternValues.Gray125 }),
            new Spreadsheet.Fill(headerFill));

        var bordered = new Spreadsheet.Border(
            new Spreadsheet.LeftBorder { Style = Spreadsheet.BorderStyleValues.Thin },
            new Spreadsheet.RightBorder { Style = Spreadsheet.BorderStyleValues.Thin },
            new Spreadsheet.TopBorder { Style = Spreadsheet.BorderStyleValues.Thin },
            new Spreadsheet.BottomBorder { Style = Spreadsheet.BorderStyleValues.Thin },
            new Spreadsheet.DiagonalBorder());

        var borders = new Spreadsheet.Borders(
            new Spreadsheet.Border(),
            bordered);

        var cellFormats = new Spreadsheet.CellFormats(
            new Spreadsheet.CellFormat(),
            new Spreadsheet.CellFormat { FontId = 1, FillId = 2, BorderId = 1, ApplyFont = true, ApplyFill = true, ApplyBorder = true },
            new Spreadsheet.CellFormat { BorderId = 1, ApplyBorder = true },
            new Spreadsheet.CellFormat { NumberFormatId = 4, BorderId = 1, ApplyNumberFormat = true, ApplyBorder = true },
            new Spreadsheet.CellFormat { NumberFormatId = 14, BorderId = 1, ApplyNumberFormat = true, ApplyBorder = true },
            new Spreadsheet.CellFormat { NumberFormatId = 1, BorderId = 1, ApplyNumberFormat = true, ApplyBorder = true });

        stylesPart.Stylesheet = new Spreadsheet.Stylesheet(fonts, fills, borders, cellFormats);
        stylesPart.Stylesheet.Save();

        return new ExcelStyles(1u, 2u, 3u, 4u, 5u);
    }

    private readonly record struct ExcelStyles(uint HeaderStyleIndex, uint TextStyleIndex, uint CurrencyStyleIndex, uint DateStyleIndex, uint NumberStyleIndex);

    private static Spreadsheet.Row CreateHeaderRow(uint headerStyleIndex, params string[] headers)
    {
        var row = new Spreadsheet.Row();
        foreach (var header in headers)
        {
            row.Append(CreateTextCell(header, headerStyleIndex));
        }

        return row;
    }

    private static Spreadsheet.Cell CreateTextCell(string? value, uint? styleIndex = null)
    {
        var cell = new Spreadsheet.Cell
        {
            DataType = Spreadsheet.CellValues.String,
            CellValue = new Spreadsheet.CellValue(value ?? string.Empty)
        };

        if (styleIndex.HasValue)
        {
            cell.StyleIndex = styleIndex.Value;
        }

        return cell;
    }

    private static Spreadsheet.Cell CreateNumberCell(int value, uint? styleIndex = null)
    {
        return CreateNumberCell((double)value, styleIndex);
    }

    private static Spreadsheet.Cell CreateNumberCell(double value, uint? styleIndex = null)
    {
        var cell = new Spreadsheet.Cell
        {
            DataType = Spreadsheet.CellValues.Number,
            CellValue = new Spreadsheet.CellValue(value.ToString(CultureInfo.InvariantCulture))
        };

        if (styleIndex.HasValue)
        {
            cell.StyleIndex = styleIndex.Value;
        }

        return cell;
    }

    private static Spreadsheet.Cell CreateNumberCell(decimal value, uint? styleIndex = null)
    {
        return CreateNumberCell((double)value, styleIndex);
    }

    private static Spreadsheet.Cell CreateDateCell(DateTime value, uint styleIndex)
    {
        var cell = new Spreadsheet.Cell
        {
            DataType = Spreadsheet.CellValues.Number,
            CellValue = new Spreadsheet.CellValue(value.ToOADate().ToString(CultureInfo.InvariantCulture)),
            StyleIndex = styleIndex
        };

        return cell;
    }

    private static List<string> GetRowValues(WorkbookPart workbookPart, Spreadsheet.Row row, int expectedColumns = 0)
    {
        var values = expectedColumns > 0
            ? Enumerable.Repeat(string.Empty, expectedColumns).ToList()
            : new List<string>();

        foreach (var cell in row.Elements<Spreadsheet.Cell>())
        {
            var index = GetColumnIndex(cell.CellReference?.Value ?? string.Empty);
            if (index < 0)
            {
                continue;
            }

            var value = GetCellValue(workbookPart, cell);

            if (expectedColumns > 0)
            {
                if (index < values.Count)
                {
                    values[index] = value;
                }
            }
            else
            {
                while (values.Count <= index)
                {
                    values.Add(string.Empty);
                }

                values[index] = value;
            }
        }

        return values.Select(v => v?.Trim() ?? string.Empty).ToList();
    }

    private static string GetCellValue(WorkbookPart workbookPart, Spreadsheet.Cell cell)
    {
        if (cell == null)
        {
            return string.Empty;
        }

        var value = cell.CellValue?.InnerText ?? string.Empty;

        if (cell.DataType == null && cell.CellValue != null)
        {
            return cell.CellValue.InnerText;
        }

        var dataType = cell.DataType?.Value;

        if (dataType == Spreadsheet.CellValues.SharedString)
        {
            var sharedStringTable = workbookPart.SharedStringTablePart?.SharedStringTable;
            if (sharedStringTable == null || !int.TryParse(value, out var sharedStringIndex))
            {
                return value;
            }

            return sharedStringTable.ElementAt(sharedStringIndex).InnerText;
        }

        if (dataType == Spreadsheet.CellValues.Boolean)
        {
            return value == "1" ? "TRUE" : "FALSE";
        }

        return value;
    }

    private static int GetColumnIndex(string cellReference)
    {
        if (string.IsNullOrEmpty(cellReference))
        {
            return -1;
        }

        var columnReference = new string(cellReference.Where(char.IsLetter).ToArray()).ToUpperInvariant();
        if (string.IsNullOrEmpty(columnReference))
        {
            return -1;
        }

        var index = 0;
        foreach (var c in columnReference)
        {
            index *= 26;
            index += c - 'A' + 1;
        }

        return index - 1;
    }

    private static bool TryParseIntValue(string value, out int number)
    {
        return int.TryParse(value, NumberStyles.Integer, CultureInfo.InvariantCulture, out number) ||
               int.TryParse(value, NumberStyles.Integer, CultureInfo.CurrentCulture, out number);
    }

    private static DateTime? ParseExcelDate(string value)
    {
        if (double.TryParse(value, NumberStyles.Any, CultureInfo.InvariantCulture, out var oa))
        {
            try
            {
                return DateTime.FromOADate(oa);
            }
            catch
            {
                return null;
            }
        }

        if (DateTime.TryParse(value, CultureInfo.CurrentCulture, DateTimeStyles.AssumeLocal, out var currentCulture))
        {
            return currentCulture;
        }

        if (DateTime.TryParse(value, CultureInfo.InvariantCulture, DateTimeStyles.AssumeLocal, out var invariantCulture))
        {
            return invariantCulture;
        }

        return null;
    }

    private static bool ParseExcelBoolean(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            return false;
        }

        if (bool.TryParse(value, out var booleanValue))
        {
            return booleanValue;
        }

        if (int.TryParse(value, NumberStyles.Integer, CultureInfo.InvariantCulture, out var intValue) ||
            int.TryParse(value, NumberStyles.Integer, CultureInfo.CurrentCulture, out intValue))
        {
            return intValue != 0;
        }

        return string.Equals(value, "да", StringComparison.InvariantCultureIgnoreCase) ||
               string.Equals(value, "yes", StringComparison.InvariantCultureIgnoreCase);
    }

    private void dateTimePickerOrderDate_ValueChanged(object? sender, EventArgs e)
    {
        dateTimePickerOrderDate.CalendarTitleBackColor = dateTimePickerOrderDate.Checked
            ? System.Drawing.Color.LightGreen
            : SystemColors.Highlight;
    }

    private string CreateInvoiceDocument(Order order)
    {
        var folderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "orderManagementReports");
        Directory.CreateDirectory(folderPath);
        var fileName = $"Invoice_{order.OrderId}_{order.OrderDate:yyyyMMdd_HHmm}.docx";
        var filePath = Path.Combine(folderPath, fileName);

        using var wordDoc = WordprocessingDocument.Create(filePath, WordprocessingDocumentType.Document);
        var mainPart = wordDoc.AddMainDocumentPart();
        mainPart.Document = new Document();
        var body = new Body();

        body.Append(CreateParagraph("СЧЕТ НА ОПЛАТУ", true, 16, JustificationValues.Center));
        body.Append(CreateParagraph($"Дата заказа: {order.OrderDate:dd.MM.yyyy}", false, 12));
        body.Append(CreateParagraph($"Номер заказа: {order.OrderId}", false, 12));
        body.Append(CreateParagraph(string.Empty));
        body.Append(CreateParagraph($"Клиент: {order.Customer.Name}", false, 12));
        body.Append(CreateParagraph($"Контактное лицо: {order.Customer.ContactPerson}", false, 12));
        body.Append(CreateParagraph($"Телефон: {order.Customer.Phone}", false, 12));
        body.Append(CreateParagraph($"Адрес: {order.Customer.Address}", false, 12));
        body.Append(CreateParagraph(string.Empty));
        body.Append(CreateParagraph($"Товар: {order.Item.Description}", false, 12));
        body.Append(CreateParagraph($"Количество: {order.Quantity}", false, 12));
        body.Append(CreateParagraph($"Цена за единицу: {order.Item.Price} руб.", false, 12));
        body.Append(CreateParagraph($"Итого: {order.TotalCost} руб.", true, 12));
        body.Append(CreateParagraph($"Сумма прописью: {NumberToWords(order.TotalCost)}", false, 12));
        body.Append(CreateParagraph(string.Empty));
        body.Append(CreateParagraph("Подпись ответственного лица: _____________________", false, 12));

        mainPart.Document.Append(body);
        mainPart.Document.Save();

        return filePath;
    }

    private string CreateOrdersReportDocument(IReadOnlyCollection<Order> orders, DateOnly from, DateOnly to)
    {
        var folderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "orderManagementReports");
        Directory.CreateDirectory(folderPath);
        var fileName = $"Orders_{from:yyyyMMdd}_{to:yyyyMMdd}.docx";
        var filePath = Path.Combine(folderPath, fileName);

        using var wordDoc = WordprocessingDocument.Create(filePath, WordprocessingDocumentType.Document);
        var mainPart = wordDoc.AddMainDocumentPart();
        mainPart.Document = new Document();
        var body = new Body();

        body.Append(CreateParagraph("ОТЧЕТ ПО ЗАКАЗАМ", true, 16, JustificationValues.Center));
        body.Append(CreateParagraph($"Период: с {from:dd.MM.yyyy} по {to:dd.MM.yyyy}", false, 12, JustificationValues.Center));
        body.Append(CreateParagraph(string.Empty));

        var table = new Table();
        table.AppendChild(new TableProperties(
            new TableBorders(
                new TopBorder { Val = new EnumValue<BorderValues>(BorderValues.Single), Size = 4 },
                new BottomBorder { Val = new EnumValue<BorderValues>(BorderValues.Single), Size = 4 },
                new LeftBorder { Val = new EnumValue<BorderValues>(BorderValues.Single), Size = 4 },
                new RightBorder { Val = new EnumValue<BorderValues>(BorderValues.Single), Size = 4 },
                new InsideHorizontalBorder { Val = new EnumValue<BorderValues>(BorderValues.Single), Size = 4 },
                new InsideVerticalBorder { Val = new EnumValue<BorderValues>(BorderValues.Single), Size = 4 }
            )));

        var headerRow = new TableRow();
        headerRow.Append(
            CreateCell("Дата"),
            CreateCell("Клиент"),
            CreateCell("Товар"),
            CreateCell("Количество"),
            CreateCell("Цена"),
            CreateCell("Сумма")
        );
        table.Append(headerRow);

        foreach (var order in orders)
        {
            var row = new TableRow();
            row.Append(
                CreateCell(order.OrderDate.ToString("dd.MM.yyyy")),
                CreateCell(order.Customer.Name),
                CreateCell(order.Item.Description),
                CreateCell(order.Quantity.ToString()),
                CreateCell(order.Item.Price.ToString()),
                CreateCell(order.TotalCost.ToString())
            );
            table.Append(row);
        }

        body.Append(table);
        body.Append(CreateParagraph(string.Empty));
        body.Append(CreateParagraph($"Всего заказов: {orders.Count}", false, 12));
        body.Append(CreateParagraph($"Общая сумма: {orders.Sum(o => o.TotalCost)} руб.", true, 12));

        mainPart.Document.Append(body);
        mainPart.Document.Save();

        return filePath;
    }

    private static Paragraph CreateParagraph(string text, bool bold, int fontSize, JustificationValues align)
    {
        var runProps = new RunProperties(new FontSize { Val = (fontSize * 2).ToString() });

        if (bold)
        {
            runProps.Append(new Bold());
        }

        return new Paragraph(
            new ParagraphProperties(new Justification { Val = align }),
            new Run(runProps, new Text(text ?? string.Empty)));
    }

    private static Paragraph CreateParagraph(string text, bool bold = false, int fontSize = 12)
    {
        return CreateParagraph(text, bold, fontSize, JustificationValues.Left);
    }

    private static TableCell CreateCell(string text)
    {
        return new TableCell(new Paragraph(new Run(new Text(text ?? string.Empty))));
    }

    private static string NumberToWords(int number)
    {
        return number switch
        {
            <= 0 => "ноль",
            1 => "один",
            2 => "два",
            3 => "три",
            4 => "четыре",
            5 => "пять",
            6 => "шесть",
            7 => "семь",
            8 => "восемь",
            9 => "девять",
            10 => "десять",
            _ => number.ToString()
        };
    }

    private static void OpenFile(string filePath)
    {
        if (!File.Exists(filePath))
        {
            return;
        }

        var info = new ProcessStartInfo(filePath)
        {
            UseShellExecute = true
        };
        Process.Start(info);
    }

    private static bool MatchesFilter(string? source, string filter)
    {
        return string.IsNullOrWhiteSpace(filter) || (!string.IsNullOrEmpty(source) && source.Contains(filter, StringComparison.InvariantCultureIgnoreCase));
    }
}