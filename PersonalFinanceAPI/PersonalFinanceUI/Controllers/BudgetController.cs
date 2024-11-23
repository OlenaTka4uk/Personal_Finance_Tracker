using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PersonalFinance.Domain.DTO;
using PersonalFinance.Persistense.Interfaces;
using PersonalFinance.Service.Interfaces.Logger;

namespace PersonalFinance.UI.Controllers
{
    [Route("api/budget")]
    [ApiController]
    public class BudgetController : ControllerBase
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        public BudgetController(IRepositoryManager repository, ILoggerManager logger)
        {
            _repository = repository;
            _logger = logger;
        }

        [HttpGet("id: int")]
        public IActionResult GetAllBudgetByUserId(Guid id)
        {
            try
            {

                var budget = _repository.Budget.GetAllBudgetsByUserId(id);
                var budgetDTO = budget.Select(c => new BudgetDTO
                {
                    BudgetId = c.BudgetId,
                    UserId = c.UserId,
                    Amount= c.Amount,
                    Spent= c.Spent,
                    Category= c.Category,
                    StartDate= c.StartDate,
                    EndDate= c.EndDate,
                }).ToList();

                return Ok(budgetDTO);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong in the {nameof(GetAllBudgetByUserId)} action {ex}");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
