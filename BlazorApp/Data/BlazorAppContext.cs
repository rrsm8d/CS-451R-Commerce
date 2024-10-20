using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BlazorApp.Models;

namespace BlazorApp.Data
{
    public class BlazorAppContext : DbContext
    {
        public BlazorAppContext (DbContextOptions<BlazorAppContext> options)
            : base(options)
        {
        }

        public DbSet<BlazorApp.Models.UserAccount> UserAccount { get; set; } = default!;
        public DbSet<BlazorApp.Models.BankAccount> BankAccount { get; set; } = default!;
        public DbSet<BlazorApp.Models.BudgetPlan> BudgetPlan { get; set; } = default!;
        public DbSet<BlazorApp.Models.Transaction> Transaction { get; set; } = default!;
    }
}
