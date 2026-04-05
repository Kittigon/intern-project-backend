using Microsoft.EntityFrameworkCore;
using MyApi.Models;

public class AppDbContext : DbContext
{
    public DbSet<UserModel> Users { get; set;}
    public DbSet<ProductModel> Products {get; set;}
    public DbSet<OrderModel> Orders {get; set;}

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }
}