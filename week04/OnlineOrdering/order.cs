using System;
using System.Collections.Generic;

public class Order
{
    private List<Product> _products = new List<Product>();
    private Customer _customer;

    public Order(Customer customer)
    {
        _customer = customer;
    }

    public void AddProduct(Product product)
    {
        _products.Add(product);
    }

    public double GetShippingCost()
    {
        return _customer.IsInUSA() ? 5.0 : 35.0;
    }

    public double GetTotalCost()
    {
        double total = 0;
        foreach (var product in _products)
        {
            total += product.GetSubtotal();
        }
        return total + GetShippingCost();
    }

    public void DisplayPackingLabel()
    {
        Console.WriteLine("Packing Label:");
        foreach (var product in _products)
        {
            Console.WriteLine($"- {product.Name} (ID: {product.ProductId}) x{product.Quantity}");
        }
    }

    public void DisplayShippingLabel()
    {
        Console.WriteLine("Shipping Label:");
        Console.WriteLine(_customer.Name);
        Console.WriteLine(_customer.GetShippingAddress());
    }
}
