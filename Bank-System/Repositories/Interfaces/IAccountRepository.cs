using System.Collections.Generic;
using System.Threading.Tasks;
using Bank_System.Models;

namespace Bank_System.Repositories.Interfaces
{
    public interface IAccountRepository
    {
        Task<IEnumerable<Account>> GetAllAccountsAsync();
        Task<Account> GetAccountByIdAsync(int ID);
        Task AddAccountAsync(Account account);
        Task UpdateAccountAsync(Account account);
        Task DeleteAccountAsync(int ID);
    }
}
