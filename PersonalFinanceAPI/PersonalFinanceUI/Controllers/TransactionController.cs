using AutoMapper;
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
        private readonly IMapper _mapper;
        public TransactionController(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet("id: int")]
        public IActionResult GetAllTransactionById(Guid id)
        {
            try
            {

                var transactions = _repository.Transaction.GetAllTransaction(id);
                var transactionsDTO = _mapper.Map<IEnumerable<TransactionDTO>>(transactions);
                return Ok(transactionsDTO);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong in the {nameof(GetAllTransactionById)} action {ex}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("name: string", Name = "GetTransactionByUserName")]
        public IActionResult GetAllTransactiosByUserName(string userFirstName, string userLastName)
        {
            try
            {

                var transactions = _repository.Transaction.GetAllTransactionsByUserName(userFirstName, userLastName);
                var transactionsDTO = _mapper.Map<IEnumerable<TransactionDTO>>(transactions);
                return Ok(transactionsDTO);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong in the {nameof(GetAllTransactiosByUserName)} action {ex}");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
