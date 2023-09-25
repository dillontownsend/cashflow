namespace CashFlow.Persistence.Models;

public abstract class Model
{
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}