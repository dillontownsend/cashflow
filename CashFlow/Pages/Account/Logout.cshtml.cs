using CashFlow.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CashFlow.Pages.Account;

public class Logout : PageModel
{
    private readonly AccountService _accountService;

    public Logout(AccountService accountService)
    {
        _accountService = accountService;
    }

    public async Task<IActionResult> OnGetAsync()
    {
        await _accountService.SignOutAsync();
        return RedirectToPage("/Index");
    }
}