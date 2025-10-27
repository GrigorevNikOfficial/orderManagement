using Microsoft.EntityFrameworkCore;
using orderManagement.Models;

namespace orderManagement.Data;

public class orderManagementContext : DbContext
{
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<Item> Items { get; set; }

    private const string connectionString = "Host=localhost;Database=orderManagement;Username=postgres;Password=11111111";

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(connectionString);
    }
}