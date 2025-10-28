using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Globalization;
using System.Windows.Forms;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using Microsoft.EntityFrameworkCore;
using System.Runtime.InteropServices;
using Excel = Microsoft.Office.Interop.Excel;
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
    private Excel.Application? excelApp;
    private Excel.Window? excelWindow;
    private Excel.Workbook? excelWorkbook;
    private Excel.Sheets? excelSheets;
    private Excel.Worksheet? excelWorksheet;
    private Excel.Range? excelRange;

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
        var orders = dbContext.Orders
            .Include(o => o.Customer)
            .Include(o => o.Item)
            .OrderBy(o => o.Customer.Name)
            .ThenBy(o => o.OrderDate)
            .ToList();

        if (orders.Count == 0)
        {
            MessageBox.Show("Нет данных для экспорта.", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        string? savedPath = null;

        try
        {
            OpenExcelDocument();
            BuildOrdersExcelReport(orders);
            savedPath = SaveExcelWorkbook();
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Ошибка при экспорте: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        finally
        {
            ReleaseExcelResources();
        }

        if (!string.IsNullOrWhiteSpace(savedPath))
        {
            MessageBox.Show($"Файл сохранен: {savedPath}", "Экспорт завершен", MessageBoxButtons.OK, MessageBoxIcon.Information);
            OpenFile(savedPath);
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

        Excel.Application? importApp = null;
        Excel.Workbook? importWorkbook = null;
        Excel.Worksheet? importWorksheet = null;
        Excel.Range? usedRange = null;
        string? summary = null;

        try
        {
            importApp = new Excel.Application();
            importWorkbook = importApp.Workbooks.Open(dialog.FileName);
            importWorksheet = (Excel.Worksheet)importWorkbook.Worksheets[1];
            usedRange = importWorksheet.UsedRange;

            var rowCount = usedRange.Rows.Count;
            if (rowCount < 4)
            {
                MessageBox.Show("Файл не содержит данных для импорта.", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var addedCustomers = 0;
            var addedItems = 0;
            var addedOrders = 0;
            var skippedOrders = 0;
            var skippedOrdersMissingData = 0;

            for (var row = 4; row <= rowCount; row++)
            {
                GetRangeValue(usedRange, row, 1, out var customerName);
                if (string.IsNullOrWhiteSpace(customerName))
                {
                    continue;
                }

                if (string.Equals(customerName, "Итого", StringComparison.InvariantCultureIgnoreCase))
                {
                    continue;
                }

                GetRangeValue(usedRange, row, 2, out var contactPerson);
                GetRangeValue(usedRange, row, 3, out var phone);
                GetRangeValue(usedRange, row, 4, out var address);
                GetRangeValue(usedRange, row, 5, out var itemDescription);
                GetRangeValue(usedRange, row, 6, out var priceText);
                GetRangeValue(usedRange, row, 7, out var deliveryText);
                GetRangeValue(usedRange, row, 8, out var quantityText);
                var dateRaw = GetRangeValue(usedRange, row, 9, out var dateText);

                if (string.IsNullOrWhiteSpace(itemDescription) || string.IsNullOrWhiteSpace(quantityText))
                {
                    skippedOrdersMissingData++;
                    continue;
                }

                if (!TryParseIntValue(quantityText, out var quantity) || quantity <= 0)
                {
                    skippedOrders++;
                    continue;
                }

                if (string.IsNullOrWhiteSpace(dateText))
                {
                    skippedOrdersMissingData++;
                    continue;
                }

                var orderDate = ConvertExcelDate(dateRaw ?? (object?)dateText);
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
                        Name = customerName,
                        ContactPerson = contactPerson,
                        Phone = phone,
                        Address = address
                    };
                    dbContext.Customers.Add(customer);
                    addedCustomers++;
                }
                else
                {
                    if (!string.IsNullOrWhiteSpace(contactPerson) && string.IsNullOrWhiteSpace(customer.ContactPerson))
                    {
                        customer.ContactPerson = contactPerson;
                    }

                    if (!string.IsNullOrWhiteSpace(phone) && string.IsNullOrWhiteSpace(customer.Phone))
                    {
                        customer.Phone = phone;
                    }

                    if (!string.IsNullOrWhiteSpace(address) && string.IsNullOrWhiteSpace(customer.Address))
                    {
                        customer.Address = address;
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

                    var delivery = ParseExcelBoolean(deliveryText);
                    item = new Item
                    {
                        Description = itemDescription,
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
                        item.Delivery = ParseExcelBoolean(deliveryText);
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
            RefreshCustomersView();
            RefreshItemsView();
            RefreshOrdersView();

            summary = $"Импорт завершен.\nКлиенты: добавлено {addedCustomers}.\nТовары: добавлено {addedItems}.\nЗаказы: добавлено {addedOrders}.\nПропущено заказов (дубликаты/ошибки): {skippedOrders}.\nПропущено строк из-за отсутствующих данных: {skippedOrdersMissingData}.";
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Ошибка импорта: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        finally
        {
            importWorkbook?.Close(false);
            importApp?.Quit();
            ReleaseComObject(usedRange);
            ReleaseComObject(importWorksheet);
            ReleaseComObject(importWorkbook);
            ReleaseComObject(importApp);
        }

        if (!string.IsNullOrWhiteSpace(summary))
        {
            MessageBox.Show(summary, "Импорт завершен", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }

    private void OpenExcelDocument()
    {
        excelApp = new Excel.Application
        {
            DisplayAlerts = false
        };
        excelWorkbook = excelApp.Workbooks.Add();
        excelWindow = excelApp.ActiveWindow;
        excelSheets = excelWorkbook.Worksheets;
        excelWorksheet = (Excel.Worksheet)excelSheets[1];
        excelWorksheet.Name = "Заказы";
    }

    private void BuildOrdersExcelReport(IReadOnlyCollection<Order> orders)
    {
        var sheet = RequireWorksheet();

        ReleaseComObject(excelRange);
        excelRange = sheet.get_Range("A1", "F1");
        excelRange.Merge(Type.Missing);
        excelRange.Value2 = "Отчет по заказам";
        excelRange.Font.Bold = true;
        excelRange.Font.Size = 16;
        excelRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

        PutCell("F2", DateTime.Now.ToString("d", CultureInfo.CurrentCulture));
        if (excelRange != null)
        {
            excelRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignRight;
        }

        var rowIndex = 4;
        var groups = orders
            .OrderBy(o => o.Customer.Name, StringComparer.InvariantCultureIgnoreCase)
            .ThenBy(o => o.OrderDate)
            .GroupBy(o => o.Customer.Name, StringComparer.InvariantCultureIgnoreCase);

        foreach (var group in groups)
        {
            rowIndex = WriteCustomerOrdersGroup(group.Key, group.ToList(), rowIndex);
        }

        sheet.Columns.AutoFit();
    }

    private int WriteCustomerOrdersGroup(string customerName, List<Order> orders, int startRow)
    {
        var sheet = RequireWorksheet();

        ReleaseComObject(excelRange);
        excelRange = sheet.get_Range($"A{startRow}", $"F{startRow}");
        excelRange.Merge(Type.Missing);
        excelRange.Value2 = customerName;
        excelRange.Font.Bold = true;
        excelRange.Font.Italic = true;
        excelRange.Interior.ColorIndex = 45;
        excelRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
        excelRange.BorderAround(Excel.XlLineStyle.xlContinuous, Excel.XlBorderWeight.xlThin, Excel.XlColorIndex.xlColorIndexAutomatic, Type.Missing);

        startRow++;

        WriteExcelHeaderRow(startRow);
        startRow++;

        var index = 1;
        var totalQuantity = 0;
        var totalCost = 0;

        foreach (var order in orders.OrderBy(o => o.OrderDate).ThenBy(o => o.OrderId))
        {
            PutCellBorder($"A{startRow}", index.ToString(CultureInfo.InvariantCulture));
            PutCellBorder($"B{startRow}", order.OrderDate.ToLocalTime().ToString("d", CultureInfo.CurrentCulture));
            PutCellBorder($"C{startRow}", order.Item.Description);
            PutCellBorder($"D{startRow}", order.Quantity.ToString(CultureInfo.InvariantCulture));
            PutCellBorder($"E{startRow}", order.Item.Price.ToString("N0", CultureInfo.CurrentCulture));
            PutCellBorder($"F{startRow}", order.TotalCost.ToString("N0", CultureInfo.CurrentCulture));

            index++;
            totalQuantity += order.Quantity;
            totalCost += order.TotalCost;
            startRow++;
        }

        PutCell($"A{startRow}", $"Итого: заказов {orders.Count}, количество {totalQuantity}, сумма {totalCost.ToString("N0", CultureInfo.CurrentCulture)} руб.");
        ReleaseComObject(excelRange);
        excelRange = sheet.get_Range($"A{startRow}", $"F{startRow}");
        excelRange.Merge(Type.Missing);
        excelRange.Font.Italic = true;
        excelRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignRight;
        excelRange.Interior.ColorIndex = 50;
        excelRange.BorderAround(Excel.XlLineStyle.xlContinuous, Excel.XlBorderWeight.xlThin, Excel.XlColorIndex.xlColorIndexAutomatic, Type.Missing);

        return startRow + 2;
    }

    private void WriteExcelHeaderRow(int rowIndex)
    {
        var headers = new[] { "№", "Дата", "Товар", "Количество", "Цена", "Сумма" };
        for (var i = 0; i < headers.Length; i++)
        {
            var cellAddress = $"{GetColumnLetter(i + 1)}{rowIndex}";
            PutCellBorder(cellAddress, headers[i]);
            if (excelRange != null)
            {
                excelRange.Font.Bold = true;
                excelRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
            }
        }
    }

    private void PutCell(string cellAddress, string value)
    {
        var sheet = RequireWorksheet();
        ReleaseComObject(excelRange);
        excelRange = sheet.get_Range(cellAddress, Type.Missing);
        excelRange.Value2 = value ?? string.Empty;
    }

    private void PutCellBorder(string cellAddress, string value)
    {
        PutCell(cellAddress, value);
        excelRange?.BorderAround(Excel.XlLineStyle.xlContinuous, Excel.XlBorderWeight.xlThin, Excel.XlColorIndex.xlColorIndexAutomatic, Type.Missing);
    }

    private Excel.Worksheet RequireWorksheet()
    {
        return excelWorksheet ?? throw new InvalidOperationException("Рабочий лист Excel не инициализирован.");
    }

    private string SaveExcelWorkbook()
    {
        if (excelWorkbook == null)
        {
            throw new InvalidOperationException("Рабочая книга Excel не создана.");
        }

        var folderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "orderManagementReports");
        Directory.CreateDirectory(folderPath);
        var fileName = $"Orders_{DateTime.Now:yyyyMMdd_HHmmss}.xlsx";
        var filePath = Path.Combine(folderPath, fileName);
        excelWorkbook.SaveAs(filePath);
        return filePath;
    }

    private void ReleaseExcelResources()
    {
        try
        {
            excelWorkbook?.Close(false);
        }
        catch
        {
        }

        try
        {
            excelApp?.Quit();
        }
        catch
        {
        }

        ReleaseComObject(excelRange);
        ReleaseComObject(excelWorksheet);
        ReleaseComObject(excelSheets);
        ReleaseComObject(excelWorkbook);
        ReleaseComObject(excelWindow);
        ReleaseComObject(excelApp);

        excelRange = null;
        excelWorksheet = null;
        excelSheets = null;
        excelWorkbook = null;
        excelWindow = null;
        excelApp = null;
    }

    private static string GetColumnLetter(int index)
    {
        var dividend = index;
        var columnName = string.Empty;

        while (dividend > 0)
        {
            var modulo = (dividend - 1) % 26;
            columnName = Convert.ToChar('A' + modulo) + columnName;
            dividend = (dividend - modulo) / 26;
        }

        return columnName;
    }

    private static object? GetRangeValue(Excel.Range usedRange, int row, int column, out string text)
    {
        Excel.Range? cell = null;
        try
        {
            cell = usedRange.Cells[row, column] as Excel.Range;
            var raw = cell?.Value2;
            text = NormalizeExcelText(raw);
            return raw;
        }
        finally
        {
            ReleaseComObject(cell);
        }
    }

    private static string NormalizeExcelText(object? value)
    {
        if (value == null)
        {
            return string.Empty;
        }

        return value switch
        {
            string text => text.Trim(),
            bool flag => flag ? "TRUE" : "FALSE",
            double number when Math.Abs(number - Math.Round(number)) < double.Epsilon => Math.Round(number).ToString("0", CultureInfo.InvariantCulture),
            double number => number.ToString(CultureInfo.InvariantCulture),
            DateTime dateTime => dateTime.ToString("d", CultureInfo.InvariantCulture),
            _ => value.ToString()?.Trim() ?? string.Empty
        };
    }

    private static DateTime? ConvertExcelDate(object? value)
    {
        if (value == null)
        {
            return null;
        }

        if (value is double doubleValue)
        {
            try
            {
                return DateTime.FromOADate(doubleValue);
            }
            catch
            {
                return null;
            }
        }

        if (value is DateTime dateTime)
        {
            return dateTime;
        }

        var stringValue = value.ToString();
        if (DateTime.TryParse(stringValue, CultureInfo.CurrentCulture, DateTimeStyles.AssumeLocal, out var parsed))
        {
            return parsed;
        }

        if (DateTime.TryParse(stringValue, CultureInfo.InvariantCulture, DateTimeStyles.AssumeLocal, out parsed))
        {
            return parsed;
        }

        return null;
    }

    private static bool TryParseIntValue(string value, out int number)
    {
        return int.TryParse(value, NumberStyles.Integer, CultureInfo.InvariantCulture, out number) ||
               int.TryParse(value, NumberStyles.Integer, CultureInfo.CurrentCulture, out number);
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

    private static void ReleaseComObject(object? component)
    {
        if (component == null)
        {
            return;
        }

        try
        {
            while (Marshal.ReleaseComObject(component) > 0)
            {
            }
        }
        catch
        {
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