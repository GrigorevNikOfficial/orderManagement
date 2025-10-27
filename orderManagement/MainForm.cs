using System;
using System.Linq;
using System.Windows.Forms;
using orderManagement.Data;
using orderManagement.Models;

namespace orderManagement;

public partial class MainForm : Form
{
    public MainForm()
    {
        InitializeComponent();

        // Подписываемся на событие загрузки формы — данные будут загружены при показе формы
        this.Load += MainForm_Load;
    }

    private void MainForm_Load(object? sender, EventArgs e)
    {
        // Простая привязка: читаем данные из контекста и передаем списки в качестве источников данных.
        // Можно заменить на .Local.ToBindingList() при необходимости двусторонней привязки.
        try
        {
            using var ctx = new OrderManagementContext();

            var customers = ctx.Customers.ToList();
            var items = ctx.Items.ToList();
            var orders = ctx.Orders.ToList();

            dataGridView1.DataSource = customers;
            dataGridView2.DataSource = items;
            dataGridView3.DataSource = orders;
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Ошибка при загрузке данных: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}