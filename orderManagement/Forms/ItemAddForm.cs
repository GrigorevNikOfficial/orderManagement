using System;
using System.Windows.Forms;
using orderManagement.Data;
using orderManagement.Models;

namespace orderManagement.Forms;

public partial class ItemAddForm : Form
{
    private readonly OrderManagementContext dbContext;

    public ItemAddForm(OrderManagementContext context)
    {
        InitializeComponent();
        dbContext = context;
    }

    private void buttonSave_Click(object? sender, EventArgs e)
    {
        var description = textBoxDescription.Text.Trim();

        if (string.IsNullOrWhiteSpace(description))
        {
            MessageBox.Show("Укажите описание товара.", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        var item = new Item
        {
            Description = description,
            Price = (int)numericPrice.Value,
            Delivery = checkBoxDelivery.Checked
        };

        try
        {
            dbContext.Items.Add(item);
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
