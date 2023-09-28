using System.ComponentModel.DataAnnotations;
using CashFlow.Extensions;
using CashFlow.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CashFlow.Pages.Account;

[BindProperties]
public class Login : PageModel
{
    private readonly AccountService _accountService;

    public Login(AccountService accountService)
    {
        _accountService = accountService;
    }

    [EmailAddress, Required] public string Email { get; set; } = "";
    [Required] public string Password { get; set; } = "";

    public void OnGet()
    {
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid) return Partial("_LoginForm");

        var signInResult = await _accountService.LoginAsync(Email, Password);

        if (!signInResult.Succeeded)
        {
            ModelState.AddModelError("Identity", "Invalid login attempt.");
            return Partial("_LoginForm");
        }

        Response.Headers.Add("HX-Location", HttpContext.Request.GetBaseUrl());
        return new EmptyResult();
    }
}