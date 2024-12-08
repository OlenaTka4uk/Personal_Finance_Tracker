using AutoMapper;
using Entities.Models;
using PersonalFinance.Domain.DTO.Budget;

namespace PersonalFinance.UI.Profiles
{
    public class BudgetProfile : Profile
    {
        public BudgetProfile()
        {
            CreateMap<Budget, BudgetDTO>()
                .ReverseMap();

            CreateMap<AddBudgetDTO, Budget>();
            CreateMap<UpdateBudgetDTO, Budget>();
        }
    }
}
