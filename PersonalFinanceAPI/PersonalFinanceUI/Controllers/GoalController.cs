using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PersonalFinance.Domain.DTO;
using PersonalFinance.Persistense.Interfaces;
using PersonalFinance.Service.Interfaces.Logger;

namespace PersonalFinance.UI.Controllers
{
    [Route("api/goal")]
    [ApiController]
    public class GoalController : ControllerBase
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        public GoalController(IRepositoryManager repository, ILoggerManager logger)
        {
            _repository = repository;
            _logger = logger;
        }

        [HttpGet("id: int")]
        public IActionResult GetAllGoalsByUserId(Guid id)
        {
            try
            {

                var goals = _repository.Goal.GetAllGoalsByUserId(id);
                var goalsDTO = goals.Select(c => new GoalDTO
                {
                    GoalId = c.GoalId, 
                    GoalName = c.GoalName,
                    UserId = c.UserId,
                    TargetAmount= c.TargetAmount,
                    CurrentAmount= c.CurrentAmount,
                    Deadline= c.Deadline,
                    IsAchieved= c.IsAchieved,
                    Description= c.Description
                }).ToList();

                return Ok(goalsDTO);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong in the {nameof(GetAllGoalsByUserId)} action {ex}");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
