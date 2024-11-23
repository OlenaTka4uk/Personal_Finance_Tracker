using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PersonalFinance.Domain.DTO;
using PersonalFinance.Persistense.Interfaces;
using PersonalFinance.Persistense.Repositories;
using PersonalFinance.Service.Interfaces.Logger;
using System;
using static System.Collections.Specialized.BitVector32;

namespace PersonalFinance.UI.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        public UserController(IRepositoryManager repository, ILoggerManager logger)
        {
            _repository = repository;
            _logger = logger;
        }
        [HttpGet]
        public IActionResult GetAllUsers()
        {
            try
            {
               
                var users = _repository.User.GetAllUsers(trackChanges: false);
                var usersDTO = users.Select(c => new UserDTO
                {
                    UserId = c.UserId,
                    UserName = string.Join(' ', c.UserFirstName, c.UserLastName),                    
                    Email = c.Email,
                    PasswordHash = c.PasswordHash,
                    CreatedAt = c.CreatedAt,
                    Role = c.Role
                }).ToList();

                return Ok(usersDTO);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong in the {nameof(GetAllUsers)} action {ex}");
            return StatusCode(500, "Internal server error");
            }
        }


    }
}
