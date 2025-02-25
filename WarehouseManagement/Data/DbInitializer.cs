using Microsoft.EntityFrameworkCore;
using WarehouseManagement.Models;

namespace WarehouseManagement.Data
{
    public static class DbInitializer
    {
        public static void Initialize(WarehouseManagementContext context)
        {

            context.Database.Migrate();


            if (context.Suppliers.Any())
            {
                return;
            }


            var suppliers = new Suppliers[]
            {
                new Suppliers { Name = "Tech Distributors", ContactPerson = "Kovács Péter", Phone = "123-456-789" },
                new Suppliers { Name = "Office Solutions Ltd.", ContactPerson = "Nagy Anna", Phone = "987-654-321" }
            };
            context.Suppliers.AddRange(suppliers);
            context.SaveChanges();


            var products = new Products[]
            {
                new Products { Name = "Dell Laptop", Category = "Electronics", Stock = 50, SupplierId = suppliers[0].Id },
                new Products { Name = "HP Printer", Category = "Office Equipment", Stock = 20, SupplierId = suppliers[1].Id },
                new Products { Name = "Wireless Mouse", Category = "Accessories", Stock = 100, SupplierId = suppliers[0].Id },
                new Products { Name = "Office Chair", Category = "Furniture", Stock = 10, SupplierId = suppliers[1].Id }
            };
            context.Products.AddRange(products);
            context.SaveChanges();


            var stockMovements = new StockMovements[]
            {
                new StockMovements { ProductId = products[0].Id, Type = "in", Quantity = 20, Date = DateTime.UtcNow.AddDays(-10) },
                new StockMovements { ProductId = products[1].Id, Type = "out", Quantity = 5, Date = DateTime.UtcNow.AddDays(-5) },
                new StockMovements { ProductId = products[2].Id, Type = "in", Quantity = 50, Date = DateTime.UtcNow.AddDays(-3) },
                new StockMovements { ProductId = products[3].Id, Type = "out", Quantity = 2, Date = DateTime.UtcNow.AddDays(-1) }
            };
            context.StockMovements.AddRange(stockMovements);
            context.SaveChanges();
        }
    }
}
