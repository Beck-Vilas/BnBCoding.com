using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using bnbapp.Models;


namespace bnbapp.DBContext;

public class bnbappContext : IdentityDbContext<IdentityUser>
{
    public bnbappContext(DbContextOptions<bnbappContext> options) : base(options)
    {

    }


    public DbSet<Company> Company { get; set; }
    public DbSet<User> User { get; set; }
    public DbSet<Order> Order { get; set; }

    public DbSet<Invoice> Invoice { get; set; }

    public DbSet<Email> Email { get; set; }

    public DbSet<SentEmail> SentEmail { get; set; }

    public DbSet<Alibaba> Alibaba { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.Entity<Company>()
        .ToTable("Company");
        builder.Entity<User>()
        .ToTable("User");
        builder.Entity<Order>()
        .ToTable("Order");
        builder.Entity<Invoice>()
        .ToTable("Invoice");
        builder.Entity<Email>()
        .ToTable("Email");
        builder.Entity<SentEmail>()
        .ToTable("SentEmail");
        builder.Entity<Alibaba>()
        .ToTable("Alibaba");

        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
    }
}