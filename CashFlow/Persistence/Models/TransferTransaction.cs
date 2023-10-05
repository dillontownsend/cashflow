using CashFlow.Common.Enums;

namespace CashFlow.Persistence.Models;

public class TransferTransaction : Model
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public decimal Amount { get; set; }
    public TransferTransactionType TransferTransactionType { get; set; }
    public string Notes { get; set; } = null!;
    public bool IsScheduled { get; set; }
    public ScheduledTransactionInterval ScheduledTransactionInterval { get; set; }
}