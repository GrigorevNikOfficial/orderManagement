using System;
using System.Linq;
using System.Windows.Forms;
using orderManagement.Data;
using orderManagement.Models;

namespace orderManagement.Forms;

public partial class OrderAddForm : Form
{
    private readonly OrderManagementContext dbContext;

    public OrderAddForm(OrderManagementContext context)
    {
        InitializeComponent();
        dbContext = context;
    }

    private void OrderAddForm_Load(object? sender, EventArgs e)
    {
        LoadLookups();
        dateTimePickerOrderDate.Value = DateTime.Today;
    }

    private void LoadLookups()
    {
        comboBoxCustomer.DataSource = dbContext.Customers.Local.ToList();
        comboBoxCustomer.DisplayMember = nameof(Customer.Name);
        comboBoxCustomer.ValueMember = nameof(Customer.CustomerId);
        comboBoxCustomer.SelectedIndex = comboBoxCustomer.Items.Count > 0 ? 0 : -1;

        comboBoxItem.DataSource = dbContext.Items.Local.ToList();
        comboBoxItem.DisplayMember = nameof(Item.Description);
        comboBoxItem.ValueMember = nameof(Item.ItemId);
        comboBoxItem.SelectedIndex = comboBoxItem.Items.Count > 0 ? 0 : -1;
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

        var order = new Order
        {
            CustomerId = customer.CustomerId,
            Customer = customer,
            ItemId = item.ItemId,
            Item = item,
            Quantity = quantity,
            OrderDate = dateTimePickerOrderDate.Value.Date
        };

        try
        {
            dbContext.Orders.Add(order);
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
