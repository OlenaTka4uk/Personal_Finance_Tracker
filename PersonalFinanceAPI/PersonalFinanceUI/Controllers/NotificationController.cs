﻿using AutoMapper;
using Entities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PersonalFinance.Domain.DTO.Notification;
using PersonalFinance.Domain.DTO.Report;
using PersonalFinance.Domain.DTO.User;
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

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet(Name = "GetNotificationsByUserId")]
        public IActionResult GetAllNotificationsByUserId(Guid userId)
        {
            var user = _repository.User.GetUser(userId, trackChanges: false);
            if (user == null)
            {
                _logger.LogError("User object is null");
                return NotFound();
            }

            var notifications = _repository.Notification.GetAllNotificationsByUserId(userId);
            var notificationsDTO = _mapper.Map<IEnumerable<NotificationDTO>>(notifications);
            return Ok(notificationsDTO);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet("isRead: bool", Name = "NotificationsByReading")]
        public IActionResult GetAllNotificationsByReading(bool isRead)
        {
            _logger.LogInfo("Get all notifications");
            var notifications = _repository.Notification.GetAllNotificationsByReading(isRead);
            var notificationsDTO = _mapper.Map<IEnumerable<NotificationDTO>>(notifications);
            return Ok(notificationsDTO);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult CreateNotification(Guid userId, [FromBody]AddNotificationDTO notification)
        {
            if (notification == null)
            {
                _logger.LogError("Notification object is null");
                return NotFound();
            }

            var user = _repository.User.GetUser(userId, trackChanges: false);
            if (user == null)
            {
                _logger.LogError("User is not found");
                return NotFound();
            }

            var notificationEntity = _mapper.Map<Notification>(notification);
            _repository.Notification.CreateNotification(userId, notificationEntity);
            _repository.Save();

            var notificationToReturn = _mapper.Map<NotificationDTO>(notificationEntity);
            return CreatedAtRoute("GetNotificationsByUserId", new {userId, id = notificationToReturn.NotificationId }, notificationToReturn);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("{id}", Name = "NotificationById")]
        public IActionResult GetNotification(Guid id)
        {
            var notification = _repository.Notification.GetNotification(id, trackChanges: false);

            if (notification == null)
            {
                _logger.LogError("Notification is null");
                return NotFound();
            }

            var notificationDTO = _mapper.Map<NotificationDTO>(notification);
            return Ok(notificationDTO);
        }

        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpDelete("{id}")]
        public IActionResult DeleteNotification(Guid id)
        {
            var notification = _repository.Notification.GetNotification(id, trackChanges: false);
            if (notification == null)
            {
                _logger.LogError($"Unable to delete notification: {id}");
                return NotFound();
            }

            _repository.Notification.DeleteNotification(notification);
            _repository.Save();
            return NoContent();
        }

        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpPut("{id}")]
        public IActionResult UpdateNotification(Guid userId, Guid id, [FromBody] UpdateNotificationDTO notification)
        {
            if (notification == null)
            {
                _logger.LogError($"Notification for the user {userId} is null");
                return BadRequest();
            }

            var user = _repository.User.GetUser(userId, trackChanges: false);
            if (user == null)
            {
                _logger.LogError("User is not found");
                return NotFound();
            }

            var notificationEntity = _repository.Notification.GetNotification(id, trackChanges: true);
            if (notificationEntity == null)
            {
                _logger.LogError("Notification is not exist");
                return NotFound();
            }

            _mapper.Map(notification, notificationEntity);
            _repository.Save();
            return NoContent();
        }
    }
}
