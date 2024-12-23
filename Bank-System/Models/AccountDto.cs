namespace Bank_System.Models
{
    public class AccountDto
    {
        public string? AccountType { get; set; } // "Checking" or "Savings"
        public string? AccountNumber { get; set; }
        public decimal Balance { get; set; }
        public decimal? OverdraftLimit { get; set; } // For CheckingAccount
        public decimal? InterestRate { get; set; }  // For SavingsAccount
    }
}
