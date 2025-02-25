using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WarehouseManagement.Models;

namespace WarehouseManagement.Data
{
    public class WarehouseManagementContext : DbContext
    {
        public WarehouseManagementContext (DbContextOptions<WarehouseManagementContext> options)
            : base(options)
        {
        }

        public DbSet<WarehouseManagement.Models.Products> Products { get; set; } = default!;
        public DbSet<WarehouseManagement.Models.StockMovements> StockMovements { get; set; } = default!;
        public DbSet<WarehouseManagement.Models.Suppliers> Suppliers { get; set; } = default!;
    }
}
