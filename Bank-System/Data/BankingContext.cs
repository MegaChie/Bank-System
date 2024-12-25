using Microsoft.EntityFrameworkCore;
using Bank_System.Models;

namespace Bank_System.Data
{
    public class BankingContext : DbContext
    {
        public BankingContext(DbContextOptions<BankingContext> options) : base(options) { }

        public DbSet<Account> Accounts { get; set; }
        public DbSet<Transaction> Transactions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>()
                .HasDiscriminator<string>("AccountType")
                .HasValue<CheckingAccount>("Checking")
                .HasValue<SavingsAccount>("Savings");

            modelBuilder.Entity<Transaction>()
                .HasOne(t => t.SenderAccount)
                .WithMany()
                .HasForeignKey(t => t.SenderAccountID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Transaction>()
                .HasOne(t => t.ReceiverAccount)
                .WithMany()
                .HasForeignKey(t => t.ReceiverAccountID)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
