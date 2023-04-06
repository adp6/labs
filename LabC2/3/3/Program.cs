using System;
using System.Collections.Generic;
using System.Linq;


namespace _3
{
    class Product
    {
        public string Name { get; set; }
        public string Category { get; set; }
        public decimal Price { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<Product> products = new List<Product>
        {
            new Product { Name = "Product 1", Category = "Category A", Price = 10 },
            new Product { Name = "Product 2", Category = "Category B", Price = 20 },
            new Product { Name = "Product 3", Category = "Category A", Price = 15 },
            new Product { Name = "Product 4", Category = "Category C", Price = 25 },
            new Product { Name = "Product 5", Category = "Category B", Price = 30 },
        };

            var groupedProducts = products.GroupBy(p => p.Category);

            foreach (var group in groupedProducts)
            {
                Console.WriteLine("Category: " + group.Key);
                foreach (var product in group)
                {
                    Console.WriteLine("\t" + product.Name + " - " + product.Price);
                    Console.ReadLine();
                }
            }
        }
    }
}
