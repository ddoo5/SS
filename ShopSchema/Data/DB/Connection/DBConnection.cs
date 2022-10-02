using Microsoft.EntityFrameworkCore;
using WebApplication1.DB.Models;

namespace WebApplication1.DB.Connections;

public class DBConnection : DbContext
{
    #region Models

    // public DbSet<Buyer> Buyers { get; set; }
    public DbSet<Product> Products { get; set; }
    // public DbSet<Order> Orders { get; set; }

    #endregion


    #region Constructor

    public DBConnection()
    {
        // Database.EnsureDeleted();
        // Database.EnsureCreated();
    }

    #endregion


    #region Creating connection
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder
            .UseNpgsql("Host=localhost;Port=5432;Database=ProductDB;Username=pgadm;Password=pgpass");
    }
    
    #endregion


    #region Creating tables
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // modelBuilder.Entity<Buyer>();
        modelBuilder.Entity<Product>();
        // modelBuilder.Entity<Order>();
    }
    
    #endregion
}