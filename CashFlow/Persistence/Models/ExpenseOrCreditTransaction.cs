namespace CashFlow.Persistence.Models;

public class ExpenseOrCreditTransaction : Transaction
{
    public int EnvelopeId { get; set; }
    public ICollection<Envelope> Envelopes { get; set; } = null!;
    public int AccountId { get; set; }
    public Account Account { get; set; } = null!;
}