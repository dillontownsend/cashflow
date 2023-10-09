using CashFlow.Persistence;
using CashFlow.Persistence.Models;

namespace CashFlow.Services;

public class UserBudgetProfileService
{
    private readonly UnitOfWork _unitOfWork;

    public UserBudgetProfileService(UnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task CreateUserBudgetProfileAsync(ApplicationUser applicationUser)
    {
        await _unitOfWork.UserBudgetProfileRepository.CreateUserBudgetProfileAsync(applicationUser);
        await _unitOfWork.SaveChangesAsync();
    }
}