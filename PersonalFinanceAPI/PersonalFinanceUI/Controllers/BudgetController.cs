using AutoMapper;
using Entities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PersonalFinance.Domain.DTO.Budget;
using PersonalFinance.Domain.DTO.User;
using PersonalFinance.Persistense.Interfaces;
using PersonalFinance.Service.Interfaces.Logger;
using System.Globalization;

namespace PersonalFinance.UI.Controllers
{
    [Route("api/budget")]
    [ApiController]
    public class BudgetController : ControllerBase
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;
        public BudgetController(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("id: int", Name = "BudgetByUserId")]
        public IActionResult GetAllBudgetByUserId(Guid userId)
        {
            var user = _repository.User.GetUser(userId, trackChanges: false);
           if (user == null)
            {
                _logger.LogError("Budget object is null");
                return NotFound();
            }
            var budget = _repository.Budget.GetAllBudgetsByUserId(userId);
            var budgetDTO = _mapper.Map<IEnumerable<BudgetDTO>>(budget);
            return Ok(budgetDTO);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("name: string", Name = "BudgetByUserName")]
        public IActionResult GetAllBudgetByUserName(string userFirstName, string userLastName)
        {
            if (userFirstName == "" || userLastName == "")
            {
                _logger.LogError("User first name or last name is empty");
                return BadRequest();
            }
            var user = _repository.User.GetUserByFullName(userFirstName, userLastName, trackChanges: false);
            if (user == null)
            {
                _logger.LogError("User object is not found");
                return NotFound();
            }
            var budget = _repository.Budget.GetAllBudgetsByUserName(userFirstName, userLastName);
            var budgetDTO = _mapper.Map<IEnumerable<BudgetDTO>>(budget);
            return Ok(budgetDTO);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult CreateBudget(Guid userId, [FromBody]AddBudgetDTO budget)
        {
            if (budget == null)
            {
                _logger.LogError("Budget object is null");
                return NotFound();
            }

            var user = _repository.User.GetUser(userId, trackChanges: false);
            if (user == null)
            {
                _logger.LogError("User is not found");
                return NotFound();
            }

            var budgetEntity = _mapper.Map<Budget>(budget);
            _repository.Budget.CreateBudget(userId, budgetEntity);
            _repository.Save();

            var budgetToReturn = _mapper.Map<BudgetDTO>(budgetEntity);
            return CreatedAtRoute("BudgetByUserId", new {userId, id = budgetToReturn.BudgetId }, budgetToReturn);
        }
    }
}
