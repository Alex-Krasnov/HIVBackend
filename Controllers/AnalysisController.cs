using HIVBackend.Data;
using HIVBackend.Models.DTOs;
using HIVBackend.Models.DTOs.Requests;
using HIVBackend.Models.DTOs.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HIVBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "User")]
    public class AnalysisController : ControllerBase
    {
        private readonly HivContext _context;

        public AnalysisController(HivContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAnalyses([FromQuery] AnalysisFilter filter)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var query = _context.TblPatientAclResults.AsQueryable();

            if (filter.PatientId.HasValue)
                query = query.Where(a => a.PatientId == filter.PatientId);

            if (filter.StartDate.HasValue)
                query = query.Where(a => DateOnly.FromDateTime(a.AclSampleDate) >=  filter.StartDate);

            if (filter.EndDate.HasValue)
                query = query.Where(a => DateOnly.FromDateTime(a.AclSampleDate) <= filter.EndDate);

            if (!string.IsNullOrEmpty(filter.AnalysisCode))
                query = query.Where(a => a.AclTestCode == filter.AnalysisCode);

            var totalCount = await query.CountAsync();

            var items = await query
                .OrderBy(a => a.AclSampleDate)
                .ThenBy(a => a.AclTestCode)
                .Skip((filter.PageNumber - 1) * Definition.PAGE_SIZE_ANALYSIS)
                .Take(Definition.PAGE_SIZE_ANALYSIS)
                .Select(a => new AnalysisDto
                {
                    PatientId = a.PatientId,
                    AnalysisDate = a.AclSampleDate,
                    AnalysisCode = a.AclTestCode,
                    Result = a.AclResult
                })
                .ToListAsync();

            return Ok(new PagedResponse<AnalysisDto>(items, filter.PageNumber, Definition.PAGE_SIZE_ANALYSIS, totalCount));
        }

        [HttpDelete]
        [Authorize(Roles = "Lab")]
        public IActionResult DeleteAnalysis([FromQuery] DeleteAnalysisRequest request)
        {
            var entity = _context.TblPatientAclResults
                .FirstOrDefault(a =>
                    a.PatientId == request.PatientId &&
                    a.AclSampleDate == request.AnalysisDate &&
                    a.AclTestCode == request.AnalysisCode);

            if (entity == null)
                return NotFound("Анализ не найден");

            _context.TblPatientAclResults.Remove(entity);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
