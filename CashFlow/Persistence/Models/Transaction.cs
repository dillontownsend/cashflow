using CashFlow.Common.Enums;

namespace CashFlow.Persistence.Models;

public abstract class Transaction : Model
{
    public int Id { get; set; }
    public DateOnly Date { get; set; }
    public string Description { get; set; } = null!;
    public decimal Amount { get; set; }
    public string Notes { get; set; } = null!;
    public ScheduledTransactionInterval? ScheduledTransactionInterval { get; set; }
}