
using System.Collections.Generic;

namespace ECommerceApp
{
    class Product
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }

        public Product(int id, string name, double price, int quantity)
        {
            ID = id;
            Name = name;
            Price = price;
            Quantity = quantity;
        }
    }

    class Customer
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }

        public Customer(int id, string name, string address, string email)
        {
            ID = id;
            Name = name;
            Address = address;
            Email = email;
        }
    }

    class Order
    {
        public int ID { get; set; }
        public Customer Customer { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }
        public double Total { get; set; }
        public string PaymentMethod { get; set; }

        public Order(int id, Customer customer, Product product, int quantity, double total, string paymentMethod)
        {
            ID = id;
            Customer = customer;
            Product = product;
            Quantity = quantity;
            Total = total;
            PaymentMethod = paymentMethod;
        }
    }

    class Inventory
    {
        private static List<Product> products = new List<Product>();

        public static void AddProduct(Product product)
        {
            products.Add(product);
        }

        public static void RemoveProduct(Product product)
        {
            products.Remove(product);
        }

        public static Product GetProduct(int id)
        {
            foreach (Product product in products)
            {
                if (product.ID == id)
                {
                    return product;
                }
            }

            return null;
        }

        public static void UpdateQuantity(Product product, int quantity)
        {
            product.Quantity += quantity;
        }
    }

    class PaymentProcessor
    {
        public static void ProcessPayment(Order order)
        {
            Console.WriteLine("Payment of ${0} processed successfully for order {1} using {2}.", order.Total, order.ID, order.PaymentMethod);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Product product1 = new Product(1, "Product 1", 9.99, 10);
            Inventory.AddProduct(product1);

            Customer customer1 = new Customer(1, "John Doe", "123 Main St", "john@example.com");
            Order order1 = new Order(1, customer1, product1, 2, 19.98, "Credit Card");

            Inventory.UpdateQuantity(product1, -2);
            PaymentProcessor.ProcessPayment(order1);

            Console.WriteLine("Order processed.\n");
            Console.WriteLine("Order Details:");
            Console.WriteLine("ID: " + order1.ID);
            Console.WriteLine("Customer: " + order1.Customer.Name);
            Console.WriteLine("Product: " + order1.Product.Name);
            Console.WriteLine("Quantity: " + order1.Quantity);
            Console.WriteLine("Total: $" + order1.Total);
            Console.WriteLine("Payment Method: " + order1.PaymentMethod);
        }
    }
}

