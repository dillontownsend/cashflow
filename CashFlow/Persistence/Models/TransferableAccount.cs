namespace CashFlow.Persistence.Models;

public class TransferableAccount : Account
{
    public virtual ICollection<AccountTransferTransaction> FromAccountTransferTransactions { get; set; } = null!;
    public virtual ICollection<AccountTransferTransaction> ToAccountTransferTransactions { get; set; } = null!;
}