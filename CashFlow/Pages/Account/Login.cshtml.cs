using System.ComponentModel.DataAnnotations;
using CashFlow.Extensions;
using CashFlow.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CashFlow.Pages.Account;

[AllowAnonymous, BindProperties]
public class Login : PageModel
{
    private readonly AccountService _accountService;

    public Login(AccountService accountService)
    {
        _accountService = accountService;
    }

    [EmailAddress, Required] public string Email { get; set; } = "";
    [Required] public string Password { get; set; } = "";

    [BindProperty(SupportsGet = true)] public string? ReturnUrl { get; set; }

    public IActionResult OnGet()
    {
        if (User.Identity != null && User.Identity.IsAuthenticated)
        {
            return RedirectToPage("/App/Index");
        }

        if (HttpContext.Request.Query.TryGetValue("ReturnUrl", out var returnUrl))
            ReturnUrl = returnUrl.ToString();

        return Page();
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

        var redirectUrl = ReturnUrl != null
            ? $"{HttpContext.Request.GetBaseUrl()}{ReturnUrl}"
            : $"{HttpContext.Request.GetBaseUrl()}/App";

        Response.Headers.Add("HX-Location", redirectUrl);
        return new EmptyResult();
    }
}