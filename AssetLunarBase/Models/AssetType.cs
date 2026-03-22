namespace AssetLunarBase.Models;

public class AssetType : Entity
{
    #region Data Declarations

    public string Name { get; set; } = string.Empty;     // Stock, Bond, Crypto, ETF, REIT...
    public string Code { get; set; } = string.Empty;     // STK, BND, CRY, ETF...
    public string? DefaultCurrency { get;set; }
    public bool CanHaveDividends { get; set; } = false;

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