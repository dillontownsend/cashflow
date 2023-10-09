using CashFlow.Persistence.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CashFlow.Persistence;

public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
{
    public DbSet<UserBudgetProfile> UserBudgetProfiles { get; set; }
    public DbSet<AssetAccount> AssetAccounts { get; set; }
    public DbSet<CreditCardAccount> CreditCardAccounts { get; set; }
    public DbSet<DebtAccount> DebtAccounts { get; set; }
    public DbSet<PrimaryEnvelope> PrimaryEnvelopes { get; set; }
    public DbSet<DebtEnvelope> DebtEnvelopes { get; set; }
    public DbSet<GoalEnvelope> GoalEnvelopes { get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
    {
        var entries = ChangeTracker
            .Entries()
            .Where(entityEntry => entityEntry.Entity is Model && (
                entityEntry.State == EntityState.Added
                || entityEntry.State == EntityState.Modified));

        foreach (var entityEntry in entries)
        {
            ((Model)entityEntry.Entity).UpdatedAt = DateTime.UtcNow;

            if (entityEntry.State == EntityState.Added)
            {
                ((Model)entityEntry.Entity).CreatedAt = DateTime.UtcNow;
            }
        }

        return base.SaveChangesAsync(cancellationToken);
    }

    public override int SaveChanges()
    {
        var entries = ChangeTracker
            .Entries()
            .Where(entityEntry => entityEntry.Entity is Model && (
                entityEntry.State == EntityState.Added
                || entityEntry.State == EntityState.Modified));

        foreach (var entityEntry in entries)
        {
            ((Model)entityEntry.Entity).UpdatedAt = DateTime.UtcNow;

            if (entityEntry.State == EntityState.Added)
            {
                ((Model)entityEntry.Entity).CreatedAt = DateTime.UtcNow;
            }
        }

        return base.SaveChanges();
    }
}