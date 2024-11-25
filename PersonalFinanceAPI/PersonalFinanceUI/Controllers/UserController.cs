using AutoMapper;
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
        private readonly IMapper _mapper;
        public UserController(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet]
        public IActionResult GetAllUsers()
        {            
            var users = _repository.User.GetAllUsers(trackChanges: false);
            var usersDTO = _mapper.Map<IEnumerable<UserDTO>>(users);            
            return Ok(usersDTO);
        }

    }
}
