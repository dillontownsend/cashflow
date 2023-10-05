using CashFlow.Common.Enums;

namespace CashFlow.Persistence.Models;

public class CreditCardAccount : Account
{
    public DebtPaymentType DebtPaymentType { get; set; }
}