using CashFlow.Common.Enums;

namespace CashFlow.Persistence.Models;

public class DebtAccount : Model
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public decimal Balance { get; set; }
    public DebtPaymentType DebtPaymentType { get; set; }
    public decimal InterestRate { get; set; }
    public int UserBudgetProfileId { get; set; }
    public UserBudgetProfile UserBudgetProfile { get; set; } = null!;
    public int DebtEnvelopeId { get; set; }
    public DebtEnvelope DebtEnvelope { get; set; } = null!;
}