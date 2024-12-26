using Microsoft.AspNetCore.Mvc;
using Bank_System.Services;

namespace Bank_System.Controllers
{
    [ApiController]
    [Route("api/transactions")]
    public class TransactionsController : ControllerBase
    {
        private readonly TransactionService _transactionService;
        public TransactionsController(TransactionService transactionService)
        {
            _transactionService = transactionService;
        }

        [HttpGet("{accountID}")]
        public async Task<IActionResult> GetTransactions(int accountID)
        {
            var transactions = await _transactionService.GetTransactionsByAccountIdAsync(accountID);
            return Ok(transactions.Select(t => new
            {
                t.ID,
                t.SenderAccountID,
                t.Amount,
                t.ReceiverAccountID,
                t.TransactionType,
                t.Timestamp
            }));
        }
    }
}
