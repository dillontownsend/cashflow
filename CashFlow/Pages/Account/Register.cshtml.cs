using System.ComponentModel.DataAnnotations;
using CashFlow.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CashFlow.Pages.Account;

[BindProperties]
public class Register : PageModel
{
    [EmailAddress, Required] public string Email { get; set; } = "";
    [Required] public string Password { get; set; } = "";

    [Required, Compare(nameof(Password), ErrorMessage = "Passwords did not match")]
    public string ConfirmPassword { get; set; } = "";

    public void OnGet()
    {
    }

    public IActionResult OnPost()
    {
        if (!ModelState.IsValid) return Partial("_RegisterForm");

        Response.Headers.Add("HX-Location", HttpContext.Request.GetBaseUrl());
        return new EmptyResult();
    }
}