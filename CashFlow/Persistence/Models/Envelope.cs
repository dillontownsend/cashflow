namespace CashFlow.Persistence.Models;

public abstract class Envelope : Model
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;

    public int UserBudgetProfileId { get; set; }
    public UserBudgetProfile UserBudgetProfile { get; set; } = null!;

    public virtual ICollection<EnvelopeTransferTransaction> FromEnvelopeTransferTransactions { get; set; } = null!;
    public virtual ICollection<EnvelopeTransferTransaction> ToEnvelopeTransferTransactions { get; set; } = null!;
}