using Microsoft.EntityFrameworkCore;
using StockManagement.Data.Entities;

namespace StockManagement.Data
{
    public class StockManagementDbContext : DbContext
    {
        public StockManagementDbContext(DbContextOptions<StockManagementDbContext> options)
            : base(options) 
        {
            Database.EnsureCreated();
        }

        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(new Product
            {
                ProductId = 1,
                Name = "Hot wheels",
                Description = "Scale car",
                AgeRestriction = 9,
                Company = "Mattel",
                Price = 9.99f
            }, new Product
            {
                ProductId = 2,
                Name = "Uno",
                Description = "Cards game",
                AgeRestriction = 12,
                Company = "Hasbro",
                Price = 19.99f
            }
            , new Product
            {
                ProductId = 3,
                Name = "Jenga",
                Description = "Board game",
                AgeRestriction = 12,
                Company = "Mattel",
                Price = 19.99f
            }, new Product
            {
                ProductId = 4,
                Name = "Pictionary",
                Description = "Board game",
                AgeRestriction = 12,
                Company = "Hasbro",
                Price = 19.99f
            });
        }
    }
}
