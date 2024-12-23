namespace Bank_System.Models
{
    public class Transaction
    {
        public int ID { get; set; }
        public int AccountID { get; set; }
        public decimal Amount { get; set; }
        public string? TransactionType { get; set; }
        public DateTime Timestamp { get; set; }
        public Account Account { get; set; }
    }
}
