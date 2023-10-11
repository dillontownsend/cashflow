using CashFlow.Common.Enums;

namespace CashFlow.Persistence.Models;

public class DebtAccount : Account
{
    public DebtPaymentType DebtPaymentType { get; set; }
    public decimal InterestRate { get; set; }

    public int DebtEnvelopeId { get; set; }
    public DebtEnvelope DebtEnvelope { get; set; } = null!;
    public ICollection<DebtTransaction> DebtTransactions { get; set; } = null!;
}