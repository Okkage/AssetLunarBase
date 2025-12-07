namespace AssetLunarBase.Models;

public class Portfolio : Entity
{
    public Guid UserId { get; private set; }
    public string Name { get; private set; } = "Minha Carteira";
    public bool IsDefault { get; private set; } = false;

    public List<Asset> Assets { get; private set; } = new();

    // Calculados
    public decimal TotalInvested => Assets.Sum(a => a.TotalInvested);
    public decimal TotalCurrentValue => Assets.Sum(a => a.TotalCurrent);
    public decimal TotalProfit => TotalCurrentValue - TotalInvested;
    public decimal TotalProfitPercent => 
        TotalInvested > 0 ? Math.Round(TotalProfit / TotalInvested * 100, 2) : 0;
    
    
}