using System;
using System.Linq;
using System.Windows.Forms;
using orderManagement.Data;
using orderManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace orderManagement;

public partial class MainForm : Form
{
    private OrderManagementContext dbContext;
    
    public MainForm()
    {
        InitializeComponent();

        // Создаем контекст и подписываемся на событие загрузки формы
        dbContext = new OrderManagementContext();
        this.Load += MainForm_Load;
        // Закроем контекст при закрытии формы
        this.FormClosing += MainForm_FormClosing;
    }

    private void MainForm_Load(object sender, EventArgs e)
    {
        // Простая привязка: читаем данные из контекста и передаем списки в качестве источников данных.
        // Можно заменить на .Local.ToBindingList() при необходимости двусторонней привязки.
        try
        {
            // EnsureCreated() временно использовался для быстрой проверки локально.
            // Для корректного управления схемой рекомендуется использовать миграции EF Core.
            // Если вы используете миграции, закомментируйте или удалите вызов EnsureCreated().
            // dbContext.Database.EnsureCreated();

            // Загружаем данные в кэш контекста
            dbContext.Customers.Load();
            dbContext.Items.Load();
            dbContext.Orders.Load();

            // Привязываем локальные коллекции к DataGridView для двусторонней привязки
            dataGridView1.DataSource = dbContext.Customers.Local.ToBindingList();
            dataGridView2.DataSource = dbContext.Items.Local.ToBindingList();

            // Для заказов: показываем в гриде не id связанных сущностей, а читаемые поля
            // Отключаем автогенерацию колонок и создаём нужные колонки вручную.
            dataGridView3.AutoGenerateColumns = false;
            dataGridView3.Columns.Clear();

            dataGridView3.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "OrderId",
                HeaderText = "OrderId",
                ReadOnly = true
            });

            // Поддерживается привязка к вложенным свойствам (Navigation.Name)
            dataGridView3.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Customer.Name",
                HeaderText = "Customer",
                ReadOnly = true
            });

            dataGridView3.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Item.Description",
                HeaderText = "Item",
                ReadOnly = true
            });

            dataGridView3.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Quantity",
                HeaderText = "Quantity"
            });

            dataGridView3.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "OrderDate",
                HeaderText = "Order Date"
            });

            dataGridView3.DataSource = dbContext.Orders.Local.ToBindingList();
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Ошибка при загрузке данных: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
    {
        this.dbContext?.Dispose();
        this.dbContext = null!;
    }
}