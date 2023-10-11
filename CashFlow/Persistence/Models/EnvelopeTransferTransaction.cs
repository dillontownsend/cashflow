namespace CashFlow.Persistence.Models;

public class EnvelopeTransferTransaction : Transaction
{
    public int FromEnvelopeId { get; set; }
    public virtual Envelope FromEnvelope { get; set; } = null!;
    public int ToEnvelopeId { get; set; }
    public virtual Envelope ToEnvelope { get; set; } = null!;
}