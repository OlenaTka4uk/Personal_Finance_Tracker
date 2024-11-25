using AutoMapper;
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
        private readonly IMapper _mapper;
        public ReportController(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet("id: int")]
        public IActionResult GetAllReportsByUserId(Guid id)
        {
            if (id == Guid.Empty)
            {
               return BadRequest(ModelState);
            }            
            var reports = _repository.Report.GetAllReportsByUserId(id);
            var reportsDTO = _mapper.Map<IEnumerable<ReportDTO>>(reports);
            return Ok(reportsDTO);
        }
    }
}
