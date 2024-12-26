using Bank_System.Models;
using Bank_System.Repositories.Interfaces;

namespace Bank_System.Services
{
    public class AccountService
    {
        private readonly IAccountRepository _accountRepository;
        private readonly ITransactionRepository _transactionRepository;

        public AccountService(IAccountRepository accountRepository, ITransactionRepository transactionRepository)
        {
            _accountRepository = accountRepository;
            _transactionRepository = transactionRepository;
        }

        public async Task DepositAsync(int accountID, decimal amount)
        {
            var account = await _accountRepository.GetAccountByIdAsync(accountID);
            if (account == null)
            {
                throw new KeyNotFoundException("Dis account aint there");
            }
            account.Balance += amount;
            await _accountRepository.UpdateAccountAsync(account);

            var transaction = new Transaction
            {
                ReceiverAccountID = accountID,
                Amount = amount,
                TransactionType = "Deposit",
                Timestamp = DateTime.UtcNow
            };
            await _transactionRepository.AddTransactionAsync(transaction);
        }

        public async Task WithdrawAsync(int accountID, decimal amount)
        {
            var account = await _accountRepository.GetAccountByIdAsync(accountID);
            if (account == null)
            {
                throw new KeyNotFoundException("Dis account aint there");
            }
            if (account is CheckingAccount checkingAccount)
            {
                if (account.Balance - amount < -checkingAccount.Overdraft)
                {
                    throw new InvalidOperationException("Overdraft limit exceeded");
                }
            }
            else if (account is SavingsAccount && account.Balance - amount < 0)
            {
                throw new InvalidOperationException("You do not have this much");
            }
            account.Balance -= amount;
            await _accountRepository.UpdateAccountAsync(account);

            var transaction = new Transaction
            {
                SenderAccountID = accountID,
                Amount = -amount,
                TransactionType = "Withdrawal",
                Timestamp = DateTime.UtcNow
            };
            await _transactionRepository.AddTransactionAsync(transaction);
        }

        public async Task TransferAsync(int fromAccountID, int toAccountID, decimal amount)
        {
            var fromAccount = await _accountRepository.GetAccountByIdAsync(fromAccountID);
            var toAccount = await _accountRepository.GetAccountByIdAsync(toAccountID);
            if (fromAccount == null || toAccount == null)
            {
                throw new KeyNotFoundException("One or both account is not found!");
            }

            await WithdrawAsync(fromAccountID, amount);
            await DepositAsync(toAccountID, amount);

            var donerTransaction = new Transaction
            {
                SenderAccountID = fromAccountID,
                Amount = amount,
                ReceiverAccountID = toAccountID,
                TransactionType = "Transfer Out",
                Timestamp = DateTime.UtcNow
            };

            var reciverTransaction = new Transaction
            {
                SenderAccountID = fromAccountID,
                Amount = amount,
                ReceiverAccountID = toAccountID,
                TransactionType = "Transfer In",
                Timestamp = DateTime.UtcNow
            };

            await _transactionRepository.AddTransactionAsync(donerTransaction);
            await _transactionRepository.AddTransactionAsync(reciverTransaction);
        }

        public async Task<decimal> GetBalanceAsync(int accountID)
        {
            var account = await _accountRepository.GetAccountByIdAsync(accountID);
            if (account == null)
            {
                throw new KeyNotFoundException("Dis account aint there");
            }
            return account.Balance;
        }

        public async Task AddAccountAsync(Account account)
        {
            await _accountRepository.AddAccountAsync(account);
        }

        public async Task DeleteAccountAsync(int accountID)
        {
            await _transactionRepository.DeleteTransactionByAccountID(accountID);
            await _accountRepository.DeleteAccountAsync(accountID);
        }
    }
}
