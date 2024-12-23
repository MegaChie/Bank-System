namespace Bank_System.Models
{
    public class SavingsAccount : Account
    {
        public decimal Intrest { get; set; } = 0.04M;

        public override void Withdraw(decimal amount)
        {
            if (Balance - amount < 0)
            {
                throw new InvalidOperationException("Insufficient funds");
            }
            Balance -= amount;
        }

        public override void Deposit(decimal amount)
        {
            Balance += amount;
        }

        public void ApplyIntrest()
        {
            Balance += Balance * Intrest;
        }
    }
}
