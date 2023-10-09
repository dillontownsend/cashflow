using CashFlow.Persistence.Models;
using Microsoft.AspNetCore.Identity;

namespace CashFlow.Services;

public class AccountService
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly SignInManager<ApplicationUser> _signInManager;

    public AccountService(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
    {
        _userManager = userManager;
        _signInManager = signInManager;
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

    public async Task<SignInResult> LoginAsync(string email, string password)
    {
        return await _signInManager.PasswordSignInAsync(email, password, isPersistent: true, lockoutOnFailure: false);
    }

    public async Task<ApplicationUser> GetApplicationUserByEmailAsync(string applicationUserEmail)
    {
        return await _userManager.FindByEmailAsync(applicationUserEmail) ??
               throw new Exception($"User with id '{applicationUserEmail}' does not exist");
    }
}