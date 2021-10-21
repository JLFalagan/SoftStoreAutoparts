using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SoftStoreAutoparts.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SoftStoreAutoparts.API.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<TestClassModel> TestClassModel { get; set; }

        //Products
        public DbSet<Category> Category { get; set; }
        public DbSet<Hall> Hall { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<ProductBrand> ProductBrand { get; set; }
        public DbSet<ProductColor> ProductColor { get; set; }
        public DbSet<ProductImage> ProductImage { get; set; }
        public DbSet<ProductSource> ProductSource { get; set; }
        public DbSet<ProductType> ProductType { get; set; }
        public DbSet<ProductVehicle> ProductVehicle { get; set; }
        public DbSet<Shelf> Shelf { get; set; }
        public DbSet<TechnicalData> TechnicalData { get; set; }

        //Vehicles
        public DbSet<Segment> Segment { get; set; }
        public DbSet<Vehicle> Vehicle { get; set; }
        public DbSet<VehicleBrand> VehicleBrand { get; set; }
        public DbSet<VehicleDoor> VehicleDoor { get; set; }
        public DbSet<VehicleType> VehicleType { get; set; }
    }
}
