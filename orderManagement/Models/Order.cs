namespace orderManagement.Models;

public class Order
{
    public int OrderId { get; set; }
    public int CustomerId { get; set; }
    public int ItemId { get; set; }
    public int Quantity { get; set; }
    public DateTime OrderDate { get; set; } = DateTime.Now;

    public virtual Customer Customer { get; set; } = null!;
    public virtual Item Item { get; set; } = null!;
}