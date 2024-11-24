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

        [HttpGet("id: int")]
        public IActionResult GetAllBudgetByUserId(Guid id)
        {
            try
            {

                var budget = _repository.Budget.GetAllBudgetsByUserId(id);
                var budgetDTO = _mapper.Map<IEnumerable<BudgetDTO>>(budget);
                return Ok(budgetDTO);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong in the {nameof(GetAllBudgetByUserId)} action {ex}");
                return StatusCode(500, "Internal server error");
            }
        }
        [HttpGet("name: string")]
        public IActionResult GetAllBudgetByUserName(string userFirstName, string userLastName)
        {
            try
            {
                var budget = _repository.Budget.GetAllBudgetsByUserName(userFirstName, userLastName);
                var budgetDTO = _mapper.Map<IEnumerable<BudgetDTO>>(budget);
                return Ok(budgetDTO);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong in the {nameof(GetAllBudgetByUserName)} action {ex}");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
