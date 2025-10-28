using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using Microsoft.EntityFrameworkCore;
using orderManagement.Data;
using orderManagement.Forms;
using orderManagement.Models;

namespace orderManagement;

public partial class MainForm : Form
{
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
            (!useDate || DateOnly.FromDateTime(order.OrderDate.Date) == selectedDate) &&
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