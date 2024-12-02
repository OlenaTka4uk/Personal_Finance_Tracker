using AutoMapper;
using Entities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PersonalFinance.Domain.DTO.Transaction;
using PersonalFinance.Domain.DTO.User;
using PersonalFinance.Persistense.Interfaces;
using PersonalFinance.Service.Interfaces.Logger;
using System.ComponentModel.Design;

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
        [ProducesResponseType(StatusCodes.Status404NotFound)]       
        [HttpGet("id: int", Name = "TransactionByUserId")]
        public IActionResult GetAllTransactionById(Guid userId)
        {
            var user = _repository.User.GetUser(userId, trackChanges: false);
            if (user == null)
            {
                _logger.LogError("User object is null");
                return NotFound();
            }

            var transactions = _repository.Transaction.GetAllTransaction(userId);            
            var transactionsDTO = _mapper.Map<IEnumerable<TransactionDTO>>(transactions);
            return Ok(transactionsDTO);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("name: string", Name = "GetTransactionByUserName")]
        public IActionResult GetAllTransactiosByUserName(string userFirstName, string userLastName)
        {
            if (userFirstName == "" || userLastName == "")
            {
                _logger.LogInfo("User first name or last name is empty");
                return BadRequest();
            }
            var user = _repository.User.GetUserByFullName(userFirstName, userLastName, trackChanges: false);
            if (user == null)
            {
                _logger.LogError("User object is not found");
                return NotFound();
            }
            var transactions = _repository.Transaction.GetAllTransactionsByUserName(userFirstName, userLastName);
            var transactionsDTO = _mapper.Map<IEnumerable<TransactionDTO>>(transactions);
            return Ok(transactionsDTO);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("date: date", Name ="GetAllTransactionByDate")]
        public IActionResult GetAllTransactionByUserAndDate(Guid userId, DateTime transactionDate)
        {
            var user = _repository.User.GetUser(userId,trackChanges: false);
            if (user == null)
            {
                _logger.LogError("User object is not found");
                return NotFound();
            }

            var transactions = _repository.Transaction.GetAllTransactionsByUserAndDate(userId, transactionDate, trackChanges: false);
            var transactionsDTO = _mapper.Map<IEnumerable<TransactionDTO>>(transactions);
            return Ok(transactionsDTO);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult CreateTransaction(Guid userId, [FromBody]AddTransactionDTO transaction)
        {
            if (transaction == null)
            {
                _logger.LogError("AddTransactionDTO object is null");
                return BadRequest();
            }

           var user = _repository.User.GetUser(userId, trackChanges: false);
            if (user == null)
            {
                _logger.LogError("User is not found");
                return NotFound();
            }

            var transactionEntity = _mapper.Map<Transaction>(transaction);
            _repository.Transaction.CreateTransaction(userId, transactionEntity);
            _repository.Save();

            var transactionToReturn = _mapper.Map<TransactionDTO>(transactionEntity);
            return CreatedAtRoute("TransactionByUserId", new { userId, id = transactionToReturn.TransactionId }, transactionToReturn);
        }
    }
}
