using System;
using System.Windows.Forms;
using orderManagement.Data;
using orderManagement.Models;

namespace orderManagement.Forms;

public partial class CustomerEditForm : Form
{
    private readonly Customer customer;
    private readonly OrderManagementContext dbContext;

    public CustomerEditForm(Customer customer, OrderManagementContext context)
    {
        InitializeComponent();
        this.customer = customer;
        dbContext = context;
        Load += CustomerEditForm_Load;
    }

    private void CustomerEditForm_Load(object? sender, EventArgs e)
    {
        textBoxName.Text = customer.Name;
        textBoxContact.Text = customer.ContactPerson;
        textBoxPhone.Text = customer.Phone;
        textBoxAddress.Text = customer.Address;
    }

    private void buttonSave_Click(object? sender, EventArgs e)
    {
        var name = textBoxName.Text.Trim();
        if (string.IsNullOrWhiteSpace(name))
        {
            MessageBox.Show("Укажите название клиента.", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        customer.Name = name;
        customer.ContactPerson = textBoxContact.Text.Trim();
        customer.Phone = textBoxPhone.Text.Trim();
        customer.Address = textBoxAddress.Text.Trim();

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
