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
            dataGridView3.DataSource = dbContext.Orders.Local.ToBindingList();

            // Скрываем автоматические колонки навигационных свойств и ID, которые не нужны в отображении.
            // Используем обработчик DataBindingComplete чтобы быть уверенным, что колонки созданы.
            dataGridView1.DataBindingComplete += (s, ev) =>
            {
                // В Customers есть коллекция Orders — не показываем её в гриде (пустая/нечитабельная колонка)
                if (dataGridView1.Columns["Orders"] != null)
                    dataGridView1.Columns["Orders"].Visible = false;
                if (dataGridView1.Columns["CustomerId"] != null)
                    dataGridView1.Columns["CustomerId"].Visible = false;
            };

            dataGridView2.DataBindingComplete += (s, ev) =>
            {
                // В Items тоже есть коллекция Orders — скрываем
                if (dataGridView2.Columns["Orders"] != null)
                    dataGridView2.Columns["Orders"].Visible = false;
                if (dataGridView2.Columns["ItemId"] != null)
                    dataGridView2.Columns["ItemId"].Visible = false;
            };

            dataGridView3.DataBindingComplete += (s, ev) =>
            {
                // В Orders скрываем служебные ID — оставляем навигационные свойства (Customer, Item),
                // т.к. они корректно отображают информацию (ToString() у Customer возвращает имя).
                var hide = new[] { "OrderId", "CustomerId", "ItemId" };
                foreach (var name in hide)
                {
                    if (dataGridView3.Columns[name] != null)
                        dataGridView3.Columns[name].Visible = false;
                }
            };
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