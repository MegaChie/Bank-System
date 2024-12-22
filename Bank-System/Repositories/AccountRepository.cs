using System.Collections.Generic;
using System.Threading.Tasks;
using Bank_System.Data;
using Bank_System.Models;
using Bank_System.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Bank_System.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly BankingContext _context;

        public AccountRepository(BankingContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Account>> GetAllAccountsAsync()
        {
            return await _context.Accounts.ToListAsync();
        }

        public async Task<Account> GetAccountByIdAsync(int ID)
        {
            return await _context.Accounts.FindAsync(ID);
        }

        public async Task AddAccountAsync(Account account)
        {
            await _context.Accounts.AddAsync(account);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAccountAsync(Account account)
        {
            _context.Accounts.Update(account);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAccountAsync(int ID)
        {
            var account = await GetAccountByIdAsync(ID);
            if (account != null)
            {
                _context.Accounts.Remove(account);
                await _context.SaveChangesAsync();
            }
        }
    }
}
