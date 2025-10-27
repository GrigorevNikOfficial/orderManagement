namespace orderManagement.Models;

public class Customer
{
    public int CustomerId { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public string ContactPerson { get; set; } = string.Empty;

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public Customer()
    {
        Orders = new List<Order>();
    }

    public override string ToString()
    {
        return Name;
    }
    
}