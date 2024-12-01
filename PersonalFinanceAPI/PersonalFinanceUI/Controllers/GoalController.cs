using AutoMapper;
using Entities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PersonalFinance.Domain.DTO.Goal;
using PersonalFinance.Domain.DTO.User;
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
        [HttpGet("id: int", Name = "GoalsByUserId")]
        public IActionResult GetAllGoalsByUserId(Guid userId)
        {
           var user = _repository.User.GetUser(userId, trackChanges: false);
            if (user == null)
            {
                _logger.LogError("User object is null");
                return NotFound();
            }
            var goals = _repository.Goal.GetAllGoalsByUserId(userId);
            var goalsDTO = _mapper.Map<IEnumerable<GoalDTO>>(goals);
            return Ok(goalsDTO);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet("isAchieved: bool", Name = "GoalsByAchievement")]
        public IActionResult GetAllGoalsByAchievement(bool isAchieved)
        {
            _logger.LogInfo("Get all goals by user Id");
            var goals = _repository.Goal.GetAllGoalsByAchievement(isAchieved);
            var goalsDTO = _mapper.Map<IEnumerable<GoalDTO>>(goals);
            return Ok(goalsDTO);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet("deadline: date", Name = "GoalsByDeadline")]
        public IActionResult GetAllGoalsByDeadline(DateTime deadline)
        {
            _logger.LogInfo("Get all goals by deadline");
            var goals = _repository.Goal.GetAllGoalsByDeadline(deadline);
            var goalsDTO = _mapper.Map<IEnumerable<GoalDTO>>(goals);
            return Ok(goalsDTO);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult CreateGoal([FromBody] AddGoalDTO goal)
        {
            if (goal == null)
            {
                _logger.LogError("Goal object is null");
                return NotFound();
            }


            var goalEntity = _mapper.Map<Goal>(goal);
            _repository.Goal.CreateGoal(goalEntity);
            _repository.Save();

            var goalToReturn = _mapper.Map<GoalDTO>(goalEntity);
            return CreatedAtRoute("GoalsByUserId", new { id = goalToReturn.UserId }, goalToReturn);
        }
    }
}
