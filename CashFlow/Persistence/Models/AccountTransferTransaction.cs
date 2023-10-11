namespace CashFlow.Persistence.Models;

public class AccountTransferTransaction : Transaction
{
    public int FromAccountId { get; set; }
    public virtual TransferableAccount FromAccount { get; set; } = null!;
    public int ToAccountId { get; set; }
    public virtual TransferableAccount ToAccount { get; set; } = null!;
}