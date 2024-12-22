using System.Collections.Generic;
using System.Threading.Tasks;
using Bank_System.Models;

namespace Bank_System.Repositories.Interfaces
{
    public interface ITransactionRepository
    {
        Task<IEnumerable<Transaction>> GetTransactionsByAccountIdAsync(int AccountID);
        Task AddTransactionAsync(Transaction transaction);
    }
}
