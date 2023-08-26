using ExpenseTracker.Shared.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTracker.infrastracture
{
    public class ExpenseDbContext:DbContext
    {
        public ExpenseDbContext()
        {
            this.Database.Migrate();
        }

        public ExpenseDbContext(DbContextOptions options) : base(options)
        {
           
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Expense> Expenses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Expense>()

                //.HasOne(e => e.Categories)

                //.WithMany()
                //.HasForeignKey(e => e.CategoryId)
                .HasKey(e => e.Id);
                //.OnDelete(DeleteBehavior.Restrict);
        }
    }
}
