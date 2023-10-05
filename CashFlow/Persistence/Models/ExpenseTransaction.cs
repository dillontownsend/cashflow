using CashFlow.Common.Enums;

namespace CashFlow.Persistence.Models;

public class ExpenseTransaction : Model
{
    public int Id { get; set; }
    public DateTime TransactionDate { get; set; }
    public string Payee { get; set; } = null!;
    public decimal Amount { get; set; }
    public string? CheckNumber { get; set; }
    public string Notes { get; set; } = null!;
    public bool IsScheduled { get; set; }
    public ScheduledTransactionInterval ScheduledTransactionInterval { get; set; }
}