namespace orderManagement.Models;

public class Item
{
    public int ItemId { get; set; }
    public int Price { get; set; }
    public bool Delivery { get; set; }
    public string Description { get; set; } = string.Empty;

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
    
    public override string ToString()
    { 
        return Description;
    }
}