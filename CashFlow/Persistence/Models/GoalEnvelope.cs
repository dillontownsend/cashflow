using CashFlow.Common.Enums;

namespace CashFlow.Persistence.Models;

public class GoalEnvelope : Envelope
{
    public decimal Goal { get; set; }
    public decimal Balance { get; set; }
    public GoalEnvelopeInterval GoalEnvelopeInterval { get; set; }
    public DateTime? DueDate { get; set; }

    public ICollection<ExpenseOrCreditTransaction> ExpenseOrCreditTransactions { get; set; } = null!;
}