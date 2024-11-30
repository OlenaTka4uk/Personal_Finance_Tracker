using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PersonalFinance.Domain.DTO;
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
        [HttpGet("id: int")]
        public IActionResult GetAllBudgetByUserId(Guid userId)
        {
            var user = _repository.User.GetUser(userId, trackChanges: false);
           if (user == null)
            {
                return NotFound();
            }
            var budget = _repository.Budget.GetAllBudgetsByUserId(userId);
            var budgetDTO = _mapper.Map<IEnumerable<BudgetDTO>>(budget);
            return Ok(budgetDTO);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("name: string")]
        public IActionResult GetAllBudgetByUserName(string userFirstName, string userLastName)
        {
            if (userFirstName == "" || userLastName == "")
            {
                return BadRequest();
            }
            var user = _repository.User.GetUserByFullName(userFirstName, userLastName, trackChanges: false);
            if (user == null)
            {
                return NotFound();
            }
            var budget = _repository.Budget.GetAllBudgetsByUserName(userFirstName, userLastName);
            var budgetDTO = _mapper.Map<IEnumerable<BudgetDTO>>(budget);
            return Ok(budgetDTO);
        }
    }
}
