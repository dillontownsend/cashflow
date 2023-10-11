using CashFlow.Common.Enums;

namespace CashFlow.Persistence.Models;

public class CreditCardAccount : TransferableAccount
{
    public DebtPaymentType DebtPaymentType { get; set; }

    public ICollection<ExpenseOrCreditTransaction> ExpenseOrCreditTransactions { get; set; } = null!;
    public ICollection<IncomeTransaction> IncomeTransactions { get; set; } = null!;
}