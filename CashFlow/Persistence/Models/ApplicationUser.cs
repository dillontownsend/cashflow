using Microsoft.AspNetCore.Identity;

namespace CashFlow.Persistence.Models;

public class ApplicationUser : IdentityUser
{
    public UserBudgetProfile UserBudgetProfile { get; set; } = null!;
}