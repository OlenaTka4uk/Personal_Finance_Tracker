using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PersonalFinance.Domain.DTO;
using PersonalFinance.Persistense.Interfaces;
using PersonalFinance.Service.Interfaces.Logger;

namespace PersonalFinance.UI.Controllers
{
    [Route("api/report")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        public ReportController(IRepositoryManager repository, ILoggerManager logger)
        {
            _repository = repository;
            _logger = logger;
        }

        [HttpGet("id: int")]
        public IActionResult GetAllReportsByUserId(Guid id)
        {
            try
            {

                var reports = _repository.Report.GetAllReportsByUserId(id);
                var reportsDTO = reports.Select(c => new ReportDTO
                {
                    ReportId= c.ReportId,
                    UserId = c.UserId,
                    ReportTitle=c.ReportTitle,
                    ReportType=c.ReportType,
                    FilePath=c.FilePath,
                    CreatedAt=c.CreatedAt
                }).ToList();

                return Ok(reportsDTO);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong in the {nameof(GetAllReportsByUserId)} action {ex}");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
