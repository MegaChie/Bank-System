using Microsoft.AspNetCore.Mvc;
using Bank_System.Services;
using Bank_System.Models;

namespace Bank_System.Controllers
{
    [ApiController]
    [Route("api/accounts")]
    public class AccountsController : ControllerBase
    {
        private readonly AccountService _accountService;
        public AccountsController(AccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpPost("deposit")]
        public async Task<IActionResult> Deposit([FromBody] DepositRequest request)
        {
            await _accountService.DepositAsync(request.AccountID, request.Amount);
            return Ok(new
            {
                Message = "Deposit successful.",
                Target = request.AccountID,
                Amount = request.Amount
            });
        }

        [HttpPost("withdraw")]
        public async Task<IActionResult> Withdraw([FromBody] WithdrawRequest request)
        {
            await _accountService.WithdrawAsync(request.AccountID, request.Amount);
            return Ok(new
            {
                Message = "Withdrawal successful.",
                Target = request.AccountID,
                Amount = -request.Amount
            });
        }

        [HttpPost("transfer")]
        public async Task<IActionResult> Transfer([FromBody] TransferRequest request)
        {
            await _accountService.TransferAsync(request.FromAccountId, request.ToAccountId, request.Amount);
            return Ok(new
            {
                Message = "Transfer successful.",
                Source = request.FromAccountId,
                Target = request.ToAccountId,
                Amount = request.Amount
            });
        }

        [HttpGet("{ID}/balace")]
        public async Task<IActionResult> GetBalance(int ID)
        {
            var balance = await _accountService.GetBalanceAsync(ID);
            return Ok(new
            {
                Balance = balance
            });
        }

        [HttpPost]
        public async Task<IActionResult> AddAcount([FromBody] AccountDto accountDto)
        {
            Account account;
            if (accountDto.AccountType == "Checking")
            {
                account = new CheckingAccount
                {
                    AccountNumber = accountDto.AccountNumber,
                    Balance = accountDto.Balance,
                    Overdraft = accountDto.OverdraftLimit ?? 521
                };

            }
            else if (accountDto.AccountType == "Savings")
            {
                account = new SavingsAccount
                {
                    AccountNumber = accountDto.AccountNumber,
                    Balance = accountDto.Balance,
                    Intrest = accountDto.InterestRate ?? 0.04M
                };
            }
            else
            {
                return BadRequest("Wrong AccountType. Use 'Checking' or 'Savings'.");
            }

            await _accountService.AddAccountAsync(account);
            return CreatedAtAction(nameof(GetBalance), new { id = account.ID },
                                   account);
        }

        [HttpDelete("{accountID}")]
        public async Task<IActionResult> DeleteAccount(int accountID)
        {
            await _accountService.DeleteAccountAsync(accountID);
            return Ok(new
            {
                Message = "Account records purged.",
                AccountID = accountID,
            });
        }
    }

    public class DepositRequest
    {
        public int AccountID { get; set; }
        public decimal Amount { get; set; }
    }

    public class WithdrawRequest
    {
        public int AccountID { get; set; }
        public decimal Amount { get; set; }
    }

    public class TransferRequest
    {
        public int FromAccountId { get; set; }
        public int ToAccountId { get; set; }
        public decimal Amount { get; set; }
    }
}
