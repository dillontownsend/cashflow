namespace CashFlow.Persistence.Models;

public class IncomeTransaction : Transaction
{
    public int AccountId { get; set; }
    public Account Account { get; set; } = null!;
}