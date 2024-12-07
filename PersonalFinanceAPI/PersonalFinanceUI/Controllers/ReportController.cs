using AutoMapper;
using Entities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PersonalFinance.Domain.DTO.Report;
using PersonalFinance.Domain.DTO.Transaction;
using PersonalFinance.Domain.DTO.User;
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
        private readonly IMapper _mapper;
        public ReportController(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("id: int", Name = "ReportsByUserId")]
        public IActionResult GetAllReportsByUserId(Guid userId)
        {
            var user = _repository.User.GetUser(userId, trackChanges: false);
            if (user == null)
            {
                _logger.LogError("User object is null");
                return NotFound();
            }            
            var reports = _repository.Report.GetAllReportsByUserId(userId);
            var reportsDTO = _mapper.Map<IEnumerable<ReportDTO>>(reports);
            return Ok(reportsDTO);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult CreateReport(Guid userId, [FromBody]AddReportDTO report)
        {
            if (report == null)
            {
                _logger.LogError("Report object is null");
                return NotFound();
            }

            var user = _repository.User.GetUser(userId, trackChanges: false);
            if (user == null)
            {
                _logger.LogError("User is not found");
                return NotFound();
            }

            var reportEntity = _mapper.Map<Report>(report);
            _repository.Report.CreateReport(userId, reportEntity);
            _repository.Save();

            var reportToReturn = _mapper.Map<ReportDTO>(reportEntity);
            return CreatedAtRoute("ReportsByUserId", new {userId, id = reportToReturn.ReportId }, reportToReturn);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("{id}", Name = "ReportById")]
        public IActionResult GetReport(Guid id)
        {
            var report = _repository.Report.GetReport(id, trackChanges: false);

            if (report == null)
            {
                _logger.LogError("Report is null");
                return NotFound();
            }

            var reportDTO = _mapper.Map<ReportDTO>(report);
            return Ok(reportDTO);
        }

        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpDelete("id:int")]
        public IActionResult DeleteReport(Guid reportId)
        {
            var report = _repository.Report.GetReport(reportId, trackChanges: false);
            if (report == null)
            {
                _logger.LogError($"Unable to delete report: {reportId}");
                return NotFound();
            }

            _repository.Report.DeleteReport(report);
            _repository.Save();
            return NoContent();
        }
    }
}
