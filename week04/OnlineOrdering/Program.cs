using System;

class Program
{
    static void Main(string[] args)
    {
        Address address1 = new Address("123 Main St", "Rexburg", "ID", "USA");
        Customer customer1 = new Customer("John Smith", address1);

        Order order1 = new Order(customer1);
        order1.AddProduct(new Product("Book", "B101", 12.99, 2));
        order1.AddProduct(new Product("Pen", "P202", 1.50, 5));

        order1.DisplayPackingLabel();
        Console.WriteLine();
        order1.DisplayShippingLabel();
        Console.WriteLine($"Total Cost: ${order1.GetTotalCost():0.00}");
    }
}
