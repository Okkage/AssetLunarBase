using AssetLunarBase.Models;
using Microsoft.EntityFrameworkCore;

namespace AssetLunarBase.Data;

public class AssetDbContext : DbContext
{
    public DbSet<Portfolio> Portfolios { get; set; }
    public DbSet<Asset> Assets { get; set; }
    public DbSet<AssetType> AssetTypes { get; set; }
    public DbSet<Stock> Stocks { get; set; }

    public AssetDbContext(DbContextOptions<AssetDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder b)
    {
        b.Entity<Stock>().ToTable("Stocks");
        
        b.Entity<Asset>()
            .HasOne(a => a.AssetType)
            .WithMany()
            .HasForeignKey(fk => fk.AssetTypeId)
            .OnDelete(DeleteBehavior.Restrict);
        
        b.Entity<Asset>()
            .HasOne(a => a.Portfolio)
            .WithMany(pt => pt.Assets)
            .HasForeignKey(fk => fk.PortfolioId)
            .OnDelete(DeleteBehavior.Restrict);
        
        // Índices para performance
        b.Entity<Asset>()
            .HasIndex(a => a.Ticker);
        b.Entity<Asset>()
            .HasIndex(a => new { a.PortfolioId, a.Ticker });
    }
    
    
    
}