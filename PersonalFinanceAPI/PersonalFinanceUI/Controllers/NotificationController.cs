using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PersonalFinance.Domain.DTO;
using PersonalFinance.Persistense.Interfaces;
using PersonalFinance.Service.Interfaces.Logger;

namespace PersonalFinance.UI.Controllers
{
    [Route("api/notification")]
    [ApiController]
    public class NotificationController : ControllerBase
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;
        public NotificationController(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet("id: int")]
        public IActionResult GetAllNotificationsByUserId(Guid id)
        {
            try
            {

                var notifications = _repository.Notification.GetAllNotificationsByUserId(id);
                var notificationsDTO = _mapper.Map<IEnumerable<NotificationDTO>>(notifications);
                return Ok(notificationsDTO);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong in the {nameof(GetAllNotificationsByUserId)} action {ex}");
                return StatusCode(500, "Internal server error");
            }
        }
        [HttpGet("isRead: bool")]
        public IActionResult GetAllNotificationsByReading(bool isRead)
        {
            try
            {

                var notifications = _repository.Notification.GetAllNotificationsByReading(isRead);
                var notificationsDTO = _mapper.Map<IEnumerable<NotificationDTO>>(notifications);

                return Ok(notificationsDTO);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong in the {nameof(GetAllNotificationsByReading)} action {ex}");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
