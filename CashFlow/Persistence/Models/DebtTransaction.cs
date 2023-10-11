namespace CashFlow.Persistence.Models;

public class DebtTransaction : Transaction
{
    public decimal Principal { get; set; }
    public decimal Interest { get; set; }
    public decimal Fees { get; set; }

    public int DebtAccountId { get; set; }
    public DebtAccount DebtAccount { get; set; } = null!;
    public int AssetAccountId { get; set; }
    public AssetAccount AssetAccount { get; set; } = null!;
}