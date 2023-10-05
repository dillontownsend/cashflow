namespace CashFlow.Persistence.Models;

public class DebtEnvelope : Envelope
{
    public decimal MonthlyPayment { get; set; }
    public int? DueDayOfMonth { get; set; }
    
    public DebtAccount? DebtAccount { get; set; }
}