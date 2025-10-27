using Microsoft.EntityFrameworkCore;
using orderManagement.Models;

namespace orderManagement.Data;

public class OrderManagementContext : DbContext
{
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<Item> Items { get; set; }

    private const string ConnectionString = "Host=localhost;Database=orderManagement;Username=postgres;Password=11111111";

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(ConnectionString);
    }
}