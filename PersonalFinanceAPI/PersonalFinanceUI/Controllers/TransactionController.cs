using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PersonalFinance.Domain.DTO;
using PersonalFinance.Persistense.Interfaces;
using PersonalFinance.Service.Interfaces.Logger;

namespace PersonalFinance.UI.Controllers
{
    [Route("api/transaction")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        public TransactionController(IRepositoryManager repository, ILoggerManager logger)
        {
            _repository = repository;
            _logger = logger;
        }

        [HttpGet("id: int")]
        public IActionResult GetAllTransactionById(Guid id)
        {
            try
            {

                var transactions = _repository.Transaction.GetAllTransaction(id);
                var transactionsDTO = transactions.Select(c => new TransactionDTO
                {
                    TransactionId= c.TransactionId,
                    UserId = c.UserId,
                    TransactionType= c.TransactionType,
                    Category= c.Category,
                    TransactionDate= c.TransactionDate,
                    Amount= c.Amount,
                    Description= c.Description
                }).ToList();

                return Ok(transactionsDTO);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong in the {nameof(GetAllTransactionById)} action {ex}");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
