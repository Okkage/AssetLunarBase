namespace AssetLunarBase.Models;

public class AssetType : Entity
{
    #region Data Declarations

    public string Name { get; init; } = string.Empty;     // Stock, Bond, Crypto, ETF, REIT...
    public string Code { get; init; } = string.Empty;     // STK, BND, CRY, ETF...
    public string? DefaultCurrency { get;init; }
    public bool CanHaveDividends { get; init; } = false;
    
    public List<Asset> Assets { get; init; } = new List<Asset>();

    #endregion

    #region Constructors

    private AssetType() { }

    public AssetType(string name, string code, string? currency = null, bool canHaveDividends = false)
    {
        Name = name;
        Code = code;
        DefaultCurrency = currency;
        CanHaveDividends = canHaveDividends;
    }

    #endregion
    
}