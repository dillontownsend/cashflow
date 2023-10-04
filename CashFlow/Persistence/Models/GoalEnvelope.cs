using CashFlow.Common.Enums;

namespace CashFlow.Persistence.Models;

public class GoalEnvelope : Model
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public decimal Goal { get; set; }
    public decimal Balance { get; set; }
    public GoalEnvelopeInterval GoalEnvelopeInterval { get; set; }
    public int? DueDayOfMonth { get; set; }
    public int UserBudgetProfileId { get; set; }
    public UserBudgetProfile UserBudgetProfile { get; set; } = null!;
}