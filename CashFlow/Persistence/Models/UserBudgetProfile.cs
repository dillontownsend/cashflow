namespace CashFlow.Persistence.Models;

public class UserBudgetProfile : Model
{
    public int Id { get; set; }
    public int BudgetStartDayOfMonth { get; set; }

    public string ApplicationUserId { get; set; } = null!;
    public ApplicationUser ApplicationUser { get; set; } = null!;
    public ICollection<Account> Accounts { get; set; } = null!;
    public ICollection<Envelope> Envelopes { get; set; } = null!;
}