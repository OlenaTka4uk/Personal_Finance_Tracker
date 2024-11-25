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

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]       
        [HttpGet("id: int")]
        public IActionResult GetAllTransactionById(Guid id)
        {
            if (id == Guid.Empty)
            {
                return BadRequest(ModelState);
            }

            var transactions = _repository.Transaction.GetAllTransaction(id);            
            var transactionsDTO = _mapper.Map<IEnumerable<TransactionDTO>>(transactions);
            return Ok(transactionsDTO);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet("name: string", Name = "GetTransactionByUserName")]
        public IActionResult GetAllTransactiosByUserName(string userFirstName, string userLastName)
        {
            if (userFirstName == "" || userLastName == "")
            {
                return BadRequest();
            }
            var transactions = _repository.Transaction.GetAllTransactionsByUserName(userFirstName, userLastName);
            var transactionsDTO = _mapper.Map<IEnumerable<TransactionDTO>>(transactions);
            return Ok(transactionsDTO);
        }
    }
}
