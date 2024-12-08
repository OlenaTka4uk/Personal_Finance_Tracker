using AutoMapper;
using Entities.Models;
using PersonalFinance.Domain.DTO.User;

namespace PersonalFinance.UI.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserDTO>()
                .ReverseMap();         

            CreateMap<AddUserDTO, User>();
            CreateMap<UpdateUserDTO, User>();
        }
    }
}
