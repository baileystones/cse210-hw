//DISCLAIMER: My code was pretty buggy for some reason, so I used ChatGPT for help, but this is my own work. 
using System;

class Program
{
    static void Main(string[] args)
    {
        Address address1 = new Address("123 Silly Goose St", "Rexburg", "ID", "USA");
        Address address2 = new Address("333 Birch Lane", "Toronto", "ON", "Canada");

        Customer customer1 = new Customer("Isaac Nielson", address1);
        Customer customer2 = new Customer("Isabel Matheson", address2);

        Product product1 = new Product("Kickball", 13, 14.99, 3);
        Product product2 = new Product("Volleyball", 6, 33.99, 4);
        Product product3 = new Product("Baseball", 8, 15.49, 9);
        Product product4 = new Product("Football", 2, 37.99, 14);

        Order order1 = new Order(customer1);
        order1.AddProduct(product1);
        order1.AddProduct(product2);        
        
        Order order2 = new Order(customer2);
        order2.AddProduct(product3);
        order2.AddProduct(product4);  

        Console.WriteLine(order1.DisplayPackingLabel());
        Console.WriteLine(order1.DisplayShippingLabel());
        Console.WriteLine($"\nTotal Cost: ${order1.CalculateTotalCost():0.00}");
        Console.WriteLine("___________________________");
 
        Console.WriteLine(order2.DisplayPackingLabel());
        Console.WriteLine(order2.DisplayShippingLabel());
        Console.WriteLine($"\nTotal Cost: ${order2.CalculateTotalCost():0.00}");
        Console.WriteLine("___________________________");
    }
}