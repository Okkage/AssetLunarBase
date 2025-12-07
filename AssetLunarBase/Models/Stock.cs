using System.ComponentModel.DataAnnotations.Schema;

namespace AssetLunarBase.Models;

public class Stock : Asset
{
    public string CompanyName { get; set; } = String.Empty;
    
    public string Symbol { get; set; } = String.Empty;
    
    public string Isin { get; set; } = String.Empty;
    
    [Column(TypeName = "decimal(18,2)")]
    public decimal? Value {get; set;}
    
    public string Sector { get; set; } = String.Empty;
    
    public long? MarketCap { get; set; }

    public Stock() { }

    public Stock(string companyName, string symbol, string isin, decimal value, string sector, long marketCap)
    {
        CompanyName = companyName;
        Symbol = symbol;
        Isin = isin;
        Value = value;
        Sector = sector;
        MarketCap = marketCap;
    }
    
}