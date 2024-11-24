using AutoMapper;
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
        private readonly IMapper _mapper;
        public GoalController(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet("id: int")]
        public IActionResult GetAllGoalsByUserId(Guid id)
        {
            try
            {

                var goals = _repository.Goal.GetAllGoalsByUserId(id);
                var goalsDTO = _mapper.Map<IEnumerable<GoalDTO>>(goals);
                return Ok(goalsDTO);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong in the {nameof(GetAllGoalsByUserId)} action {ex}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("isAchieved: bool")]
        public IActionResult GetAllGoalsByAchievement(bool isAchieved)
        {
            try
            {

                var goals = _repository.Goal.GetAllGoalsByAchievement(isAchieved);
                var goalsDTO = _mapper.Map<IEnumerable<GoalDTO>>(goals);
                return Ok(goalsDTO);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong in the {nameof(GetAllGoalsByAchievement)} action {ex}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("deadline: date")]
        public IActionResult GetAllGoalsByDeadline(DateTime deadline)
        {
            try
            {

                var goals = _repository.Goal.GetAllGoalsByDeadline(deadline);
                var goalsDTO = _mapper.Map<IEnumerable<GoalDTO>>(goals);
                return Ok(goalsDTO);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong in the {nameof(GetAllGoalsByDeadline)} action {ex}");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
