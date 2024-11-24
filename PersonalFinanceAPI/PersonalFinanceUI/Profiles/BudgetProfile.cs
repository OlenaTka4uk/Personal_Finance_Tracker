using AutoMapper;
using Entities.Models;
using PersonalFinance.Domain.DTO;

namespace PersonalFinance.UI.Profiles
{
    public class BudgetProfile : Profile
    {
        public BudgetProfile()
        {
            CreateMap<Budget, BudgetDTO>()
                .ReverseMap();
        }
    }
}
