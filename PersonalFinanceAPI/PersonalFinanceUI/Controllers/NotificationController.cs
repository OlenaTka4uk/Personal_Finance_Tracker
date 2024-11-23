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
        public NotificationController(IRepositoryManager repository, ILoggerManager logger)
        {
            _repository = repository;
            _logger = logger;
        }

        [HttpGet("id: int")]
        public IActionResult GetAllNotificationsByUserId(Guid id)
        {
            try
            {

                var notifications = _repository.Notification.GetAllNotificationsByUserId(id);
                var notificationsDTO = notifications.Select(c => new NotificationDTO
                {
                    NotificationId = c.NotificationId,
                    UserId = c.UserId,
                    Message= c.Message,
                    IsRead=c.IsRead,
                    SentAt=c.SentAt
                }).ToList();

                return Ok(notificationsDTO);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong in the {nameof(GetAllNotificationsByUserId)} action {ex}");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
