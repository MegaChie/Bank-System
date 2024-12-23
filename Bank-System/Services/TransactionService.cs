using Bank_System.Models;
using Bank_System.Repositories.Interfaces;

namespace Bank_System.Services
{
    public class TransactionService
    {
        private readonly ITransactionRepository _transactionRepository;

        public TransactionService(ITransactionRepository transactionRepository)
        {
            _transactionRepository = transactionRepository;
        }

        public async Task<IEnumerable<Transaction>> GetTransactionsByAccountIdAsync(int accountID)
        {
            return await _transactionRepository.GetTransactionsByAccountIdAsync(accountID);
        }
    }
}
