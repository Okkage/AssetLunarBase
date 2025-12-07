
using AssetLunarBase.Data; 
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace AssetLunarBase; 

public class AssetDbContextFactory : IDesignTimeDbContextFactory<AssetDbContext>
{
    public AssetDbContext CreateDbContext(string[] args)
    {
       
        var builder = new DbContextOptionsBuilder<AssetDbContext>();
        var connectionString = "Server=localhost;Database=AssetLunarBase;Trusted_Connection=True;TrustServerCertificate=True;";

        builder.UseSqlServer(connectionString);

        return new AssetDbContext(builder.Options);
    }
}
