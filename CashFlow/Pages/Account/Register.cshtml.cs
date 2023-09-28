using System.ComponentModel.DataAnnotations;
using CashFlow.Extensions;
using CashFlow.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CashFlow.Pages.Account;

[BindProperties]
public class Register : PageModel
{
    private readonly AccountService _accountService;

    public Register(AccountService accountService)
    {
        _accountService = accountService;
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

        await _accountService.LoginAsync(Email, Password);

        var redirectUrl = $"{HttpContext.Request.GetBaseUrl()}/App";
        Response.Headers.Add("HX-Location", redirectUrl);
        return new EmptyResult();
    }
}