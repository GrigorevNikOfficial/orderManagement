using System;
using System.Windows.Forms;
using orderManagement.Data;
using orderManagement.Models;

namespace orderManagement.Forms;

public partial class ItemEditForm : Form
{
    private readonly Item item;
    private readonly OrderManagementContext dbContext;

    public ItemEditForm(Item item, OrderManagementContext context)
    {
        InitializeComponent();
        this.item = item;
        dbContext = context;
        Load += ItemEditForm_Load;
    }

    private void ItemEditForm_Load(object? sender, EventArgs e)
    {
        textBoxDescription.Text = item.Description;
        numericPrice.Value = Math.Min(numericPrice.Maximum, Math.Max(numericPrice.Minimum, item.Price));
        checkBoxDelivery.Checked = item.Delivery;
    }

    private void buttonSave_Click(object? sender, EventArgs e)
    {
        var description = textBoxDescription.Text.Trim();
        if (string.IsNullOrWhiteSpace(description))
        {
            MessageBox.Show("Укажите описание товара.", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        item.Description = description;
        item.Price = (int)numericPrice.Value;
        item.Delivery = checkBoxDelivery.Checked;

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
