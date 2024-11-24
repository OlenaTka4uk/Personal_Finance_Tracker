using AutoMapper;
using Entities.Models;
using PersonalFinance.Domain.DTO;

namespace PersonalFinance.UI.Profiles
{
    public class ReportProfile : Profile
    {
        public ReportProfile()
        {
            CreateMap<Report, ReportDTO>()
                .ReverseMap();
        }
    }
}
