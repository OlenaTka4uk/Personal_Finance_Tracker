using AutoMapper;
using Entities.Models;
using PersonalFinance.Domain.DTO;

namespace PersonalFinance.UI.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserDTO>()
                .ForMember(x => x.UserName,
                opt => opt.MapFrom(x => string.Join(' ', x.UserLastName, x.UserFirstName)));

            CreateMap<User, UserWithDetailsDTO>()
                .ReverseMap();
        }
    }
}
