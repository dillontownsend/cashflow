using Microsoft.AspNetCore.Identity;

namespace CashFlow.Persistence.Models;

public class ApplicationUser : IdentityUser
{
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}