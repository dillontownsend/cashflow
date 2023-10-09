using System.ComponentModel.DataAnnotations;
using CashFlow.Extensions;
using CashFlow.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CashFlow.Pages.Account;

[AllowAnonymous, BindProperties]
public class Register : PageModel
{
    private readonly AccountService _accountService;
    private readonly UserBudgetProfileService _userBudgetProfileService;

    public Register(AccountService accountService, UserBudgetProfileService userBudgetProfileService)
    {
        _accountService = accountService;
        _userBudgetProfileService = userBudgetProfileService;
    }

    [EmailAddress, Required] public string Email { get; set; } = "";
    [Required] public string Password { get; set; } = "";

    [Required, Compare(nameof(Password), ErrorMessage = "Passwords did not match.")]
    public string ConfirmPassword { get; set; } = "";

    public IActionResult OnGet()
    {
        if (User.Identity != null && User.Identity.IsAuthenticated)
        {
            return RedirectToPage("/App/Index");
        }

        return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid) return Partial("_RegisterForm");

        var identityResult = await _accountService.RegisterAsync(Email, Password);

        if (!identityResult.Succeeded)
        {
            foreach (var identityError in identityResult.Errors)
            {
                ModelState.AddModelError("Identity", identityError.Description);
            }

            return Partial("_RegisterForm");
        }

        var applicationUser = await _accountService.GetApplicationUserByEmailAsync(Email);

        await Task.WhenAll(
            _accountService.LoginAsync(Email, Password),
            _userBudgetProfileService.CreateUserBudgetProfileAsync(applicationUser));

        var redirectUrl = $"{HttpContext.Request.GetBaseUrl()}/App";
        Response.Headers.Add("HX-Location", redirectUrl);
        return new EmptyResult();
    }
}