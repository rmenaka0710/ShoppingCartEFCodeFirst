
using Microsoft.EntityFrameworkCore;
using ShoppingCartEFCodeFirst.Models;

namespace ShoppingCartEFCodeFirst.Models
{
    public class ShoppingContext : DbContext 
    {
        public ShoppingContext()
        {

        }
        public ShoppingContext(DbContextOptions<ShoppingContext> options)
            : base(options)
        {

        }

            public DbSet<Customer> Customers { get; set; }

            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                optionsBuilder.UseSqlServer("TrustServerCertificate=True;Server=DESKTOP-B3AVO8T\\SQLEXPRESS;Database=Shopping;Trusted_Connection=True");
            

            }
    }
    }

