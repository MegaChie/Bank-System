using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
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
            return Ok("Deposit success!");
        }

        [HttpPost("withdraw")]
        public async Task<IActionResult> Withdraw([FromBody] WithdrawRequest request)
        {
            await _accountService.WithdrawAsync(request.AccountID, request.Amount);
            return Ok("Withdraw success!");
        }

        [HttpPost("transfer")]
        public async Task<IActionResult> Transfer([FromBody] TransferRequest request)
        {
            await _accountService.TransferAsync(request.FromAccountId, request.ToAccountId, request.Amount);
            return Ok("Transfare success!");
        }

        [HttpGet("{ID}/balace")]
        public async Task<IActionResult> GetBalance(int ID)
        {
            var balance = await _accountService.GetBalanceAsync(ID);
            return Ok(balance);
        }

        [HttpPost]
        public async Task<IActionResult> AddAcount([FromBody] Account account)
        {
            await _accountService.AddAccountAsync(account);
            return CreatedAtAction(nameof(GetBalance), new { id = account.ID }, account);
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
