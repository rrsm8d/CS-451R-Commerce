using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BlazorApp.Models;
using BlazorApp.Components.Pages;

namespace BlazorApp.Data
{
    public class BlazorAppContext : DbContext
    {
        public BlazorAppContext (DbContextOptions<BlazorAppContext> options)
            : base(options)
        {
        }
        // Don't touch this
        public DbSet<BlazorApp.Models.UserAccount> UserAccount { get; set; } = default!;
        public DbSet<BlazorApp.Models.BankAccount> BankAccount { get; set; } = default!;
        public DbSet<BlazorApp.Models.BudgetPlan> BudgetPlan { get; set; } = default!;
        public DbSet<BlazorApp.Models.Transaction> Transaction { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserAccount>()
                .HasIndex(u => u.Email)
                .IsUnique();
            base.OnModelCreating(modelBuilder);
        }

        public override int SaveChanges()
        {
            HandleTransactionLogic();
            return base.SaveChanges();
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            HandleTransactionLogic();
            return await base.SaveChangesAsync(cancellationToken);
        }

        private void HandleTransactionLogic()
        {
            // Get all newly added transactions
            var newTransactions = ChangeTracker.Entries<Transaction>()
                .Where(e => e.State == EntityState.Added)
                .Select(e => e.Entity);
            if(newTransactions.Count() != 0)
            {
                foreach (var transaction in newTransactions)
                {
                    // Find goals tied to same accountId
                    var relatedGoals = BudgetPlan.Where(g => g.AccountId == transaction.AccountId);
                    if (relatedGoals.Count() != 0)
                    {
                        foreach(var goal in relatedGoals)
                        {
                            if((transaction.TransactionDate >= goal.StartDate) && (transaction.TransactionDate <= goal.EndDate))
                            {
                                // Increment the goal's TotalSpent
                                goal.BudgetExpenditures += transaction.TransactionAmount;

                                // Mark the goal as modified to save changes
                                Entry(goal).State = EntityState.Modified;
                            }
                        }
                    }
                }
            }
        }

    }
}
