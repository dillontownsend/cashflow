namespace CashFlow.Persistence.Models;

public class DebtEnvelope : Model
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public decimal MonthlyPayment { get; set; }
    public int? DueDayOfMonth { get; set; }
    public int UserBudgetProfileId { get; set; }
    public UserBudgetProfile UserBudgetProfile { get; set; } = null!;
    public DebtAccount? DebtAccount { get; set; }
}