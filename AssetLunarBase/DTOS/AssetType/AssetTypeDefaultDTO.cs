using AssetLunarBase.Models;

namespace AssetLunarBase.DTOS.Stock;

public class AssetTypeDefaultDTO
{
    public string Name { get; set; } = string.Empty;     
    public  string Code { get; set; } = string.Empty;     
    public  string? DefaultCurrency { get;set; }
    public  bool CanHaveDividends { get; set; } = false;

    
    
}

public static class AssetTypeMapper
{
    public static AssetTypeDefaultDTO AssetTypeMapToDefaultDTO(AssetType assetType)
    {
        return new AssetTypeDefaultDTO()
        {
            Name = assetType.Name,
            Code = assetType.Code,
            DefaultCurrency = assetType.DefaultCurrency,
            CanHaveDividends = assetType.CanHaveDividends
        };
    }
}