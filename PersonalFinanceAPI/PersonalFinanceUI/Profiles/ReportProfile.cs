using AutoMapper;
using Entities.Models;
using PersonalFinance.Domain.DTO.Report;

namespace PersonalFinance.UI.Profiles
{
    public class ReportProfile : Profile
    {
        public ReportProfile()
        {
            CreateMap<Report, ReportDTO>()
                .ReverseMap();

            CreateMap<AddReportDTO, Report>();
        }
    }
}
