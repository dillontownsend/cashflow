using CashFlow.Persistence.Models;
using Microsoft.AspNetCore.Identity;

namespace CashFlow.Services;

public class AccountService
{
    private readonly UserManager<ApplicationUser> _userManager;

    public AccountService(UserManager<ApplicationUser> userManager)
    {
        _userManager = userManager;
    }

    public async Task<IdentityResult> RegisterAsync(string email, string password)
    {
        var applicationUser = new ApplicationUser
        {
            UserName = email,
            Email = email,
        };

        return await _userManager.CreateAsync(applicationUser, password);
    }
}