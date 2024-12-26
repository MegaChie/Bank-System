namespace Bank_System.Models
{
    public class Transaction
    {
        public int ID { get; set; }
        public int? SenderAccountID { get; set; } // Null if deposit or withdraw
        public int? ReceiverAccountID { get; set; } // Null if deposit or withdraw
        public decimal Amount { get; set; }
        public string? TransactionType { get; set; } // Withdraw, deposit or transfer
        public DateTime Timestamp { get; set; }

        public Account SenderAccount { get; set; }
        public Account ReceiverAccount { get; set; }
    }
}
