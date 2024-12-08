using AutoMapper;
using Entities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PersonalFinance.Domain.DTO.User;
using PersonalFinance.Domain.DTO.UserWithDetails;
using PersonalFinance.Persistense.Interfaces;
using PersonalFinance.Service.Interfaces.Logger;

namespace PersonalFinance.UI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserWithDetailsController : ControllerBase
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;
        public UserWithDetailsController(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet]
        public IActionResult GetAllUsersWithDetails()
        {
            _logger.LogInfo("Get all users with details");
            var users = _repository.User.GetAllUsers(trackChanges: false);
            var usersDTO = _mapper.Map<IEnumerable<UserWithDetailsDTO>>(users);
            return Ok(usersDTO);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("{id}", Name = "UserWithDetailsById")]
        public IActionResult GetUser(Guid id)
        {
            var user = _repository.User.GetUser(id, trackChanges: false);
            if (user == null)
            {
                _logger.LogError("User is null");
                return NotFound();
            }

            var userDTO = _mapper.Map<UserWithDetailsDTO>(user);
            return Ok(userDTO);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public IActionResult CreateUserWithDetails([FromBody] AddUserWithDetailsDTO user)
        {
            if (user == null)
            {
                _logger.LogError("AddUserWithDetailsDTO object is null.");
                return BadRequest();
            }

            var userEntity = _mapper.Map<User>(user);
            _repository.User.CreateUser(userEntity);
            _repository.Save();

            var userToReturn = _mapper.Map<UserWithDetailsDTO>(userEntity);
            return CreatedAtRoute("UserById", new { id = userToReturn.UserId }, userToReturn);
        }

    }
}
