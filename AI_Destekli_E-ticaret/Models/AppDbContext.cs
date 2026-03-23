
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AI_Destekli_E_ticaret.Models;

public class AppDbContext : IdentityDbContext<AppUser>
{

    public AppDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Product> Products { get; set; }
    public DbSet<CartItem> CartItems { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        // Force SQLite to properly Auto-Increment
        builder.Entity<CartItem>()
            .Property(c => c.Id)
            .ValueGeneratedOnAdd();

        builder.Entity<Product>()
            .Property(p => p.Id)
            .ValueGeneratedOnAdd();
    }
}