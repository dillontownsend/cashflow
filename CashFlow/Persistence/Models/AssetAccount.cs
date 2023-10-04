namespace CashFlow.Persistence.Models;

public class AssetAccount : Model
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public decimal Balance { get; set; }
    public int UserBudgetProfileId { get; set; }
    public UserBudgetProfile UserBudgetProfile { get; set; } = null!;
}