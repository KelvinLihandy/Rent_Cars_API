using System;
using Microsoft.EntityFrameworkCore;
using Rent_Cars_API.Models;

namespace Rent_Cars_API.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<MsCar> MsCar { get; set; }
    public DbSet<MsCarImages> MsCarImages { get; set; }
    public DbSet<MsCustomer> MsCustomer { get; set; }
    public DbSet<MsEmployee> MsEmployee { get; set; }
    public DbSet<TrMaintenance> TrMaintenance { get; set; }
    public DbSet<TrPayment> TrPayment { get; set; }
    public DbSet<TrRental> TrRental { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<MsCar>().ToTable("MsCar", "dbo");
        modelBuilder.Entity<MsCarImages>().ToTable("MsCarImages", "dbo");
        modelBuilder.Entity<MsCustomer>().ToTable("MsCustomer", "dbo");
        modelBuilder.Entity<MsEmployee>().ToTable("MsEmployee", "dbo");
        modelBuilder.Entity<TrMaintenance>().ToTable("TrMaintenance", "dbo");
        modelBuilder.Entity<TrPayment>().ToTable("TrPayment", "dbo");
        modelBuilder.Entity<TrRental>().ToTable("TrRental", "dbo");
    }
}
