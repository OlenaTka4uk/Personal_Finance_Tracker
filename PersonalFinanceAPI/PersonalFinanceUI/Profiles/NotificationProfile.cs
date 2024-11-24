using AutoMapper;
using Entities.Models;
using PersonalFinance.Domain.DTO;

namespace PersonalFinance.UI.Profiles
{
    public class NotificationProfile : Profile
    {
        public NotificationProfile()
        {
            CreateMap<Notification, NotificationDTO>()
                .ReverseMap();
        }
    }
}
