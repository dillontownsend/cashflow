using CashFlow.Persistence.Repositories;

namespace CashFlow.Persistence;

public class UnitOfWork
{
    private readonly ApplicationDbContext _applicationDbContext;
    public UserBudgetProfileRepository UserBudgetProfileRepository { get; }

    public UnitOfWork(UserBudgetProfileRepository userBudgetProfileRepository,
        ApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
        UserBudgetProfileRepository = userBudgetProfileRepository;
    }

    public async Task SaveChangesAsync()
    {
        await _applicationDbContext.SaveChangesAsync();
    }
}