using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Bank_System.Data
{
    public class BankingContextFactory : IDesignTimeDbContextFactory<BankingContext>
    {
        public BankingContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<BankingContext>();
            optionsBuilder.UseSqlite("Mode=ReadWriteCreate;Cache=Default;Data Source=Bank_System.db");

            return new BankingContext(optionsBuilder.Options);
        }
    }
}
