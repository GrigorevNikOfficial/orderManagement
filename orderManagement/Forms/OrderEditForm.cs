using System;
using System.Linq;
using System.Windows.Forms;
using orderManagement.Data;
using orderManagement.Models;

namespace orderManagement.Forms;

public partial class OrderEditForm : Form
{
    private readonly Order order;
    private readonly OrderManagementContext dbContext;

    public OrderEditForm(Order order, OrderManagementContext context)
    {
        InitializeComponent();
        this.order = order;
        dbContext = context;
    }

    private void OrderEditForm_Load(object? sender, EventArgs e)
    {
        var customers = dbContext.Customers.Local.ToList();
        comboBoxCustomer.DataSource = customers;
        comboBoxCustomer.DisplayMember = nameof(Customer.Name);
        comboBoxCustomer.ValueMember = nameof(Customer.CustomerId);
        comboBoxCustomer.SelectedItem = customers.FirstOrDefault(c => c.CustomerId == order.CustomerId);

        var items = dbContext.Items.Local.ToList();
        comboBoxItem.DataSource = items;
        comboBoxItem.DisplayMember = nameof(Item.Description);
        comboBoxItem.ValueMember = nameof(Item.ItemId);
        comboBoxItem.SelectedItem = items.FirstOrDefault(i => i.ItemId == order.ItemId);

        numericQuantity.Value = Math.Min(numericQuantity.Maximum, Math.Max(numericQuantity.Minimum, order.Quantity));
        dateTimePickerOrderDate.Value = order.OrderDate;
    }

    private void buttonSave_Click(object? sender, EventArgs e)
    {
        if (comboBoxCustomer.SelectedItem is not Customer customer)
        {
            MessageBox.Show("Выберите клиента.", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        if (comboBoxItem.SelectedItem is not Item item)
        {
            MessageBox.Show("Выберите товар.", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        var quantity = (int)numericQuantity.Value;
        if (quantity <= 0)
        {
            MessageBox.Show("Количество должно быть больше нуля.", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        order.CustomerId = customer.CustomerId;
        order.Customer = customer;
        order.ItemId = item.ItemId;
        order.Item = item;
        order.Quantity = quantity;
        order.OrderDate = dateTimePickerOrderDate.Value.Date;

        try
        {
            dbContext.SaveChanges();
            DialogResult = DialogResult.OK;
            Close();
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Ошибка при сохранении: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void buttonCancel_Click(object? sender, EventArgs e)
    {
        DialogResult = DialogResult.Cancel;
        Close();
    }
}
