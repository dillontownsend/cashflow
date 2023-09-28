using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CashFlow.Pages.App;

[Authorize]
public class Index : PageModel
{
    public void OnGet()
    {
    }
}