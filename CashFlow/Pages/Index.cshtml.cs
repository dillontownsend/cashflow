using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CashFlow.Pages;

public class IndexModel : PageModel
{
    public void OnGet()
    {
    }

    public IActionResult OnGetMobileMenu()
    {
        return Partial("_MobileMenu");
    }
}