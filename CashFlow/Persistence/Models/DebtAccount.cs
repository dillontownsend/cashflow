using CashFlow.Common.Enums;

namespace CashFlow.Persistence.Models;

public class DebtAccount : Model
{
    // todo - add foreign key to debt envelope
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public decimal Balance { get; set; }
    public DebtPaymentType DebtPaymentType { get; set; }
    public decimal MonthlyPayment { get; set; }
    public decimal InterestRate { get; set; }
    public int UserBudgetProfileId { get; set; }
    public UserBudgetProfile UserBudgetProfile { get; set; } = null!;
}