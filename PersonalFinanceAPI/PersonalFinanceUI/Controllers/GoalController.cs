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

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("id: int")]
        public IActionResult GetAllGoalsByUserId(Guid userId)
        {
           var user = _repository.User.GetUser(userId, trackChanges: false);
            if (user == null)
            {
                return NotFound();
            }
            var goals = _repository.Goal.GetAllGoalsByUserId(userId);
            var goalsDTO = _mapper.Map<IEnumerable<GoalDTO>>(goals);
            return Ok(goalsDTO);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet("isAchieved: bool")]
        public IActionResult GetAllGoalsByAchievement(bool isAchieved)
        {
            var goals = _repository.Goal.GetAllGoalsByAchievement(isAchieved);
            var goalsDTO = _mapper.Map<IEnumerable<GoalDTO>>(goals);
            return Ok(goalsDTO);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet("deadline: date")]
        public IActionResult GetAllGoalsByDeadline(DateTime deadline)
        {
            var goals = _repository.Goal.GetAllGoalsByDeadline(deadline);
            var goalsDTO = _mapper.Map<IEnumerable<GoalDTO>>(goals);
            return Ok(goalsDTO);
        }
    }
}
