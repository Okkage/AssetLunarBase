namespace AssetLunarBase.Models;

public class Asset : Entity
{
    public Guid PortfolioId { get; private set; }
    public Guid AssetTypeId { get; private set; }

    public Portfolio Portfolio { get; private set; } = null;

    public AssetType AssetType { get; private set; } = null;

    public string Ticker { get; private set; } = string.Empty;
    public string Name { get; private set; } = string.Empty;
    public int Quantity { get; private set; }
    public decimal AveragePrice { get; private set; }
    public decimal? CurrentPrice { get; private set; }
    
    public decimal TotalInvested => Quantity * AveragePrice;
    public decimal TotalCurrent => Quantity * (CurrentPrice ?? AveragePrice);
    public decimal Profit => TotalCurrent - TotalInvested;
    
    protected Asset() { } 
    
    public static Asset Create(Guid portfolioId, Guid assetTypeId, string ticker, string name, int qty, decimal avgPrice) =>
        new()
        {
            PortfolioId = portfolioId,
            AssetTypeId = assetTypeId,
            Ticker = ticker.ToUpperInvariant(),
            Name = name,
            Quantity = qty,
            AveragePrice = avgPrice
        };

    public void UpdatePrice(decimal price)
    {
        CurrentPrice = price;
        Update();
    }

    public void AddPurchase(int qty, decimal price)
    {
        var totalCost = (Quantity * AveragePrice) + (qty * price);
        Quantity += qty;
        AveragePrice = totalCost / Quantity;
        Update();
    }

}