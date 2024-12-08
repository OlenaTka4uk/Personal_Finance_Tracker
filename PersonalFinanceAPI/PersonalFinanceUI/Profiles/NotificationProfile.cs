using AutoMapper;
using Entities.Models;
using PersonalFinance.Domain.DTO.Notification;

namespace PersonalFinance.UI.Profiles
{
    public class NotificationProfile : Profile
    {
        public NotificationProfile()
        {
            CreateMap<Notification, NotificationDTO>()
                .ReverseMap();

            CreateMap<AddNotificationDTO, Notification>();
            CreateMap<UpdateNotificationDTO, Notification>();
        }
    }
}
