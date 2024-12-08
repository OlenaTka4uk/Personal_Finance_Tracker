using AutoMapper;
using Entities.Models;
using PersonalFinance.Domain.DTO.User;
using PersonalFinance.Domain.DTO.UserWithDetails;

namespace PersonalFinance.UI.Profiles
{
    public class UserWithDetailsProfile : Profile
    {
        public UserWithDetailsProfile()
        {
            CreateMap<User, UserWithDetailsDTO>()
                .ReverseMap();

            CreateMap<AddUserWithDetailsDTO, User>();
            CreateMap<UpdateUserWithDetailsDTO, User>();
        }
    }
}
