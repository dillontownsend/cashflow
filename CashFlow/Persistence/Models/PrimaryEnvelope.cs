namespace CashFlow.Persistence.Models;

public class PrimaryEnvelope : Model
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public decimal Amount { get; set; }
    public decimal Balance { get; set; }
    public int? DueDayOfMonth { get; set; }
    public int UserBudgetProfileId { get; set; }
    public UserBudgetProfile UserBudgetProfile { get; set; } = null!;
}