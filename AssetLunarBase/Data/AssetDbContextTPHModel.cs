// using AssetLunarBase.Models;
// using Microsoft.EntityFrameworkCore;
//
// namespace AssetLunarBase.Data;
//
// public class AssetDbContextTPHModel : DbContext
// {
//     public DbSet<Portfolio> Portfolios => Set<Portfolio>();
//     public DbSet<Asset> Assets => Set<Asset>();
//     public DbSet<AssetType> AssetTypes => Set<AssetType>();
//
//    // public AssetDbContextTPHModel(DbContextOptions<AssetDbContextTPHModel> options) : base(options) { }
//
//     protected override void OnModelCreating(ModelBuilder b)
//     {
//         // TPH Approach, for reference if i need it for the future
//         b.Entity<Asset>()
//             .HasDiscriminator<string>("AssetKind") // Has to be called Different from the AssetType class, triggers an error
//             .HasValue<Asset>("Generic")
//             .HasValue<Stock>("Stock");
//
//         // Seed dos tipos de ativo
//         b.Entity<AssetType>().HasData(
//             AssetType.Stock
//         );
//         // Força o EF a saber que Id é gerado na aplicação (nunca IDENTITY)
//         b.Entity<Entity>()
//             .Property(e => e.Id)
//             .ValueGeneratedNever();
//         
//         b.Entity<Asset>()
//             .HasOne<AssetType>() // mesmo sem navigation property, ele acha pelo Id
//             .WithMany()
//             .HasForeignKey(a => a.AssetTypeId)
//             .HasConstraintName("FK_Assets_AssetType")  // nome único
//             .OnDelete(DeleteBehavior.Restrict);      
//         
//         b.Entity<Asset>()
//             .HasOne<Portfolio>() // mesmo sem navigation property, ele acha pelo Id
//             .WithMany()
//             .HasForeignKey(a => a.PortfolioId)
//             .HasConstraintName("FK_Assets_Portofolio")  // nome único
//             .OnDelete(DeleteBehavior.Restrict);
//
//         // Índices para performance
//         b.Entity<Asset>()
//             .HasIndex(a => a.Ticker);
//         b.Entity<Asset>()
//             .HasIndex(a => new { a.PortfolioId, a.Ticker });
//     }
//     
//     
//     
// }