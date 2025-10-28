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

    private void MainForm_Load(object? sender, EventArgs e)
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
            dataGridView3.DataSource = dbContext.Orders.Local.ToBindingList();
            
            if (dataGridView3.Columns.Contains("CustomerId")) 
            { 
                dataGridView3.Columns["CustomerId"].Visible = false; 
            }
            if (dataGridView3.Columns.Contains("ItemId")) 
            { 
                dataGridView3.Columns["ItemId"].Visible = false; 
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Ошибка при загрузке данных: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void MainForm_FormClosing(object? sender, FormClosingEventArgs e)
    {
        this.dbContext?.Dispose();
        this.dbContext = null!;
    }
}