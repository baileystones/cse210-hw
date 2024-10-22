using System.Collections.Generic;

class Order
{
    private List<Product> _products = new List<Product>();
    private Customer _customer;
    private double _usaShippingCost = 5;
    private double _internationalShippingCost = 35;

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
        double totalCost = 0;
        foreach (Product product in _products)
        {
            totalCost += product.ComputeTotalCost();
        }

        if (_customer.IsInUSA())
        {
            totalCost += _usaShippingCost;
        }
        else
        {
            totalCost += _internationalShippingCost;
        }
        return totalCost;
    }

    public string DisplayPackingLabel()
    {
        string packingLabel = "\nPacking Label:\n";
        foreach (Product product in _products)
        {
            packingLabel += $"{product.GetProductname()} (Id-{product.GetProductID()})\n";
        }
        return packingLabel;
    }

    public string DisplayShippingLabel()
    {
        return $"Shipping Label:\n{_customer.GetName()}\n{_customer.DisplayCustomerAddress()}";
    }
}