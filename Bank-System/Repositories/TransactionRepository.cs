using Bank_System.Data;
using Bank_System.Models;
using Bank_System.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Bank_System.Repositories
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly BankingContext _context;
        
        public TransactionRepository(BankingContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Transaction>> GetTransactionsByAccountIdAsync(int accountID)
        {
            return await _context.Transactions.Where(t =>
            t.SenderAccountID == accountID || t.ReceiverAccountID == accountID)
            .ToListAsync();
        }

        public async Task AddTransactionAsync(Transaction transaction)
        {
            await _context.Transactions.AddAsync(transaction);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteTransactionByAccountID(int accountID)
        {
            var transaction = await _context.Transactions
                .Where(t => t.SenderAccountID == accountID || t.ReceiverAccountID == accountID)
                .ToListAsync();
            _context.Transactions.RemoveRange(transaction);
            await _context.SaveChangesAsync();
        }
    }
}
