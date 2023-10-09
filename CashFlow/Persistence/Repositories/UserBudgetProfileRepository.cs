using CashFlow.Persistence.Models;

namespace CashFlow.Persistence.Repositories;

public class UserBudgetProfileRepository
{
    private readonly ApplicationDbContext _applicationDbContext;

    public UserBudgetProfileRepository(ApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }

    public async Task CreateUserBudgetProfileAsync(ApplicationUser applicationUser)
    {
        var userBudgetProfile = new UserBudgetProfile
        {
            ApplicationUser = applicationUser,
            BudgetStartDayOfMonth = 1
        };

        await _applicationDbContext.UserBudgetProfiles.AddAsync(userBudgetProfile);
    }
}