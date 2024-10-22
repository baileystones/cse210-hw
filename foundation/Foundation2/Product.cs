class Product
{
    private string _productName;
    private int _productID;
    private double _price;
    private int _quantity;

    public Product(string productName, int productId, double price, int quantity)
    {
        _productName = productName;
        _productID = productId;
        _price = price;
        _quantity = quantity;
    }

    public double ComputeTotalCost()
    {
        return _price * _quantity;
    }

    public string GetProductname()
    {
        return _productName;
    }

    public int GetProductID()
    {
        return _productID;
    }
}