namespace CashFlow.Persistence.Models;

public class UserBudgetProfile : Model
{
    public int Id { get; set; }
    public int BudgetStartDayOfMonth { get; set; }

    public Guid ApplicationUserId { get; set; }
    public ApplicationUser ApplicationUser { get; set; } = null!;
    public ICollection<Account> Accounts { get; set; } = new List<Account>();
    public ICollection<Envelope> Envelopes { get; set; } = new List<Envelope>();
}