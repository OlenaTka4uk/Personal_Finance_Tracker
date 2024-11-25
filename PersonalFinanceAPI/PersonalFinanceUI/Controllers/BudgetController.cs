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
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet("id: int")]
        public IActionResult GetAllBudgetByUserId(Guid id)
        {
           if (id == Guid.Empty)
            {
                return BadRequest();
            }
            var budget = _repository.Budget.GetAllBudgetsByUserId(id);
            var budgetDTO = _mapper.Map<IEnumerable<BudgetDTO>>(budget);
            return Ok(budgetDTO);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet("name: string")]
        public IActionResult GetAllBudgetByUserName(string userFirstName, string userLastName)
        {
            if (userFirstName == "" || userLastName == "")
            {
                return BadRequest();
            }
            var budget = _repository.Budget.GetAllBudgetsByUserName(userFirstName, userLastName);
            var budgetDTO = _mapper.Map<IEnumerable<BudgetDTO>>(budget);
            return Ok(budgetDTO);
        }
    }
}
