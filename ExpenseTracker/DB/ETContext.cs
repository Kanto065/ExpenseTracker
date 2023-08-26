using ExpenseTracker.DB.Model;
using Microsoft.EntityFrameworkCore;

namespace ExpenseTracker.DB
{
    public class ETContext:DbContext
    {
        public ETContext(DbContextOptions  options) : base(options) 
        {
            
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Expense> Expenses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Expense>()
                .HasOne(e => e.Categories)
                .WithMany()
                .HasForeignKey(e => e.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);               
        }


    }
}
