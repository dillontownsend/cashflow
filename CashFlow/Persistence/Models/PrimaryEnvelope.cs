namespace CashFlow.Persistence.Models;

public class PrimaryEnvelope : Envelope
{
    public decimal Amount { get; set; }
    public decimal Balance { get; set; }
    public int? DueDayOfMonth { get; set; }
}