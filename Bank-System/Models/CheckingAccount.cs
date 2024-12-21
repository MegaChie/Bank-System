namespace Bank_System.Models
{
    public class CheckingAccount : Account
    {
        public decimal Overdraft { get; set; } = 521;

        public override void Withdraw(decimal amount)
        {
            if (Balance - amount < -Overdraft)
            {
                throw new InvalidOperationException("Overdraft limit execeed."
                                                    + "You now owe us.");
            }
            Balance -= amount;
        }

        public override void Deposit(decimal amount)
        {
            Balance += amount;
        }
    }
}
