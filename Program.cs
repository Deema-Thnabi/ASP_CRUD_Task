using CRUD.Data;
using CRUD.Models;
using Microsoft.EntityFrameworkCore;

namespace CRUD
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ApplicartionDbContext dbContext = new ApplicartionDbContext();

            // add data to product table
            dbContext.Products.AddRange(new List<Product>()
            {
                new Product()
                {
                    Name = "Laptop",
                    Price = 999.99m
                },
                new Product()
                {
                    Name = "Smartphone",
                    Price = 799.99m
                },
                new Product()
                {
                    Name = "Tablet",
                    Price = 499.99m
                },
                new Product()
                {
                    Name = "Headphones",
                    Price = 199.99m
                },
                new Product()
                {
                    Name = "Smartwatch",
                    Price = 249.99m
                }
            });
            //----------------------------------------------------

            // add data to order table 
            dbContext.Orders.AddRange(new List<Order>()
            {
                new Order()
                {
                    Address = "123 Main St",
                    CreatedAt = DateTime.Now,
                },
                new Order()
                {
                    Address = "456 Elm St",
                    CreatedAt = DateTime.Now
                },
                new Order()
                {
                    Address = "789 Oak St",
                    CreatedAt = DateTime.Now
                }
            });
            dbContext.SaveChanges();



            // get all Products 
            var products = dbContext.Products.AsNoTracking().ToList();
            products.ForEach(p => Console.WriteLine($"ProductName: {p.Name} and Price is {p.Price}"));

            // get all Orders
            Console.WriteLine("============================================================");
            var orders = dbContext.Orders.AsNoTracking().ToList();
            orders.ForEach(o => Console.WriteLine($"OrderAddress: {o.Address} and Created At {o.CreatedAt}"));


            // update product name
            Console.WriteLine("============================================================");
            var product = dbContext.Products.FirstOrDefault(p => p.Id == 4);

            if (product is not null)
            {
                product.Name = "Lamba";
            } else Console.WriteLine("No Product");

            dbContext.SaveChanges();



            // update order created at
            Console.WriteLine("============================================================");
            var createdAt = dbContext.Orders.FirstOrDefault(o => o.Id == 2);

            if (createdAt is not null)
            {
                createdAt.CreatedAt = DateTime.Now;
            }
            else Console.WriteLine("No Order");

            dbContext.SaveChanges();

            // remove product with id 2
            Console.WriteLine("===============================================");
            var removeProduct = dbContext.Products.FirstOrDefault(p =>p.Id == 2);
            if (removeProduct is not null)
            {
                dbContext.Products.Remove(removeProduct);
            }
            else Console.WriteLine("No Product");

            dbContext.SaveChanges();

            // remove order with id 3
            Console.WriteLine("===============================================");
            var removeOrder = dbContext.Orders.FirstOrDefault(o => o.Id == 3);
            if (removeOrder is not null)
            {
                dbContext.Orders.Remove(removeOrder);
            }
            else Console.WriteLine("No Order");

            dbContext.SaveChanges(); 
        }
    }
}
