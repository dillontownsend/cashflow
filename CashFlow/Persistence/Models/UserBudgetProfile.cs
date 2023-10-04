namespace CashFlow.Persistence.Models;

public class UserBudgetProfile : Model
{
    public int Id { get; set; }
    public int BudgetStartDayOfMonth { get; set; }
    public Guid ApplicationUserId { get; set; }
    public ApplicationUser ApplicationUser { get; set; } = null!;
    public ICollection<AssetAccount> AssetAccounts { get; set; } = new List<AssetAccount>();
    public ICollection<CreditCardAccount> CreditCardAccounts { get; set; } = new List<CreditCardAccount>();
    public ICollection<DebtAccount> DebtAccounts { get; set; } = new List<DebtAccount>();
    public ICollection<PrimaryEnvelope> PrimaryEnvelopes { get; set; } = new List<PrimaryEnvelope>();
}