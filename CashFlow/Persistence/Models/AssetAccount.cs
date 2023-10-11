namespace CashFlow.Persistence.Models;

public class AssetAccount : TransferableAccount
{
    public ICollection<ExpenseOrCreditTransaction> ExpenseOrCreditTransactions { get; set; } = null!;
    public ICollection<IncomeTransaction> IncomeTransactions { get; set; } = null!;
    public ICollection<DebtTransaction> DebtTransactions { get; set; } = null!;
}