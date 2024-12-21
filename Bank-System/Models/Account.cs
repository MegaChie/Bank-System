namespace Bank_System.Models
{
    public abstract class Account
    {
        public int ID { get; set; }
        public decimal Balance { get; set; }
        public DateTime Created { get; set; }
        public string? AccountType { get; set; }
        public string? AccountNumber { get; set; }

        public abstract void Withdraw(decimal amount);
        public abstract void Deposit(decimal amount);
    }

    
}
