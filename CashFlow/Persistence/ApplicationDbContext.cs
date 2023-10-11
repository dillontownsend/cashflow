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
    public DbSet<ExpenseOrCreditTransaction> ExpenseOrCreditTransactions { get; set; }
    public DbSet<EnvelopeTransferTransaction> EnvelopeTransferTransactions { get; set; }
    public DbSet<AccountTransferTransaction> AccountTransferTransactions { get; set; }
    public DbSet<IncomeTransaction> IncomeTransactions { get; set; }
    public DbSet<DebtTransaction> DebtTransactions { get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<EnvelopeTransferTransaction>()
            .HasOne(e => e.FromEnvelope)
            .WithMany(e => e.FromEnvelopeTransferTransactions)
            .HasForeignKey(e => e.FromEnvelopeId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<EnvelopeTransferTransaction>()
            .HasOne(e => e.ToEnvelope)
            .WithMany(e => e.ToEnvelopeTransferTransactions)
            .HasForeignKey(e => e.ToEnvelopeId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<AccountTransferTransaction>()
            .HasOne(e => e.FromAccount)
            .WithMany(e => e.FromAccountTransferTransactions)
            .HasForeignKey(e => e.FromAccountId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<AccountTransferTransaction>()
            .HasOne(e => e.ToAccount)
            .WithMany(e => e.ToAccountTransferTransactions)
            .HasForeignKey(e => e.ToAccountId)
            .OnDelete(DeleteBehavior.Restrict);

        base.OnModelCreating(modelBuilder);
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new())
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