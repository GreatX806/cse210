public class Product
{
    public string Name { get; set; }
    public string ProductId { get; set; }
    public double Price { get; set; }
    public int Quantity { get; set; }

    public Product(string name, string id, double price, int quantity)
    {
        Name = name;
        ProductId = id;
        Price = price;
        Quantity = quantity;
    }

    public double GetSubtotal()
    {
        return Price * Quantity;
    }
}
