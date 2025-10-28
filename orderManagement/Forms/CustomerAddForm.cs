using System;
using System.Windows.Forms;
using orderManagement.Data;
using orderManagement.Models;

namespace orderManagement.Forms;

public partial class CustomerAddForm : Form
{
    private readonly OrderManagementContext dbContext;

    public CustomerAddForm(OrderManagementContext context)
    {
        InitializeComponent();
        dbContext = context;
    }

    private void buttonSave_Click(object? sender, EventArgs e)
    {
        var name = textBoxName.Text.Trim();

        if (string.IsNullOrWhiteSpace(name))
        {
            MessageBox.Show("Укажите название клиента.", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        var customer = new Customer
        {
            Name = name,
            ContactPerson = textBoxContact.Text.Trim(),
            Phone = textBoxPhone.Text.Trim(),
            Address = textBoxAddress.Text.Trim()
        };

        try
        {
            dbContext.Customers.Add(customer);
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
