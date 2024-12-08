using AutoMapper;
using Entities.Models;
using PersonalFinance.Domain.DTO.Goal;

namespace PersonalFinance.UI.Profiles
{
    public class GoalProfile : Profile
    {
        public GoalProfile()
        {
            CreateMap<Goal, GoalDTO>()
                .ReverseMap();

            CreateMap<AddGoalDTO, Goal>();
            CreateMap<UpdateGoalDTO, Goal>();
        }
    }
}
