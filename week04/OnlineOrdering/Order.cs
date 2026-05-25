using System.Collections.Generic;

public class Order
{
    private Customer _customer;
    private List<Product> _products = new List<Product>();


    public Order(Customer customer)
    {
        _customer = customer;
    }


    public void AddProduct(Product product)
    {
        _products.Add(product);
    }


    public double CalculateTotalCost()
    {
        double total = 0;
        foreach (Product product in _products)
        {
            total += product.GetTotalCost();
        }
        if (_customer.LivesInUSA())
        {
            total += 5; // Shipping cost for USA
        }
        else
        {
            total += 35; // Shipping cost for international
        }
        return total;
    }

    public string GetPackingLabel()
    {
        string ladel = "";

        foreach (Product product in _products)
        {
            ladel += product.GetPackingLabel() + "\n";
        }

        return ladel;
    }

    public string GetShippingLabel()
    {
        return $"{_customer.GetCustomerName()}\n{_customer.GetCustomerAddress()}";
    }
}