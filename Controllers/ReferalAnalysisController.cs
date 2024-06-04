using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using DocumentFormat.OpenXml;
using HIVBackend.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using HIVBackend.Models.FormModels;
using HIVBackend.Services;

namespace HIVBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReferalAnalysisController : ControllerBase
    {
        private readonly HivContext _context;
        public ReferalAnalysisController(HivContext context)
        {
            _context = context;
        }

        [HttpGet, Route("GetDataForReferalAnalysis")]
        [Authorize(Roles = "User")]
        public IActionResult GetDataForReferalAnalysis()
        {
            List<string?> listResearch = _context.TblResearches.OrderBy(e => e.SortNum).Select(e => e.ResearchLong).ToList();
            var listDoc = _context.TblDoctors.OrderBy(e => e.DoctorLong).Select(e => e.DoctorLong).ToList();
            return Ok(new { listResearch = listResearch, listDoc = listDoc });
        }

        [HttpPost, Route("GetReferalAnalysis")]
        [Authorize(Roles = "User")]
        public IActionResult GetReferalAnalysis(ReferalAnalysis referalAnalysis)
        {
            var createFile = new ReferalAnalysisCreateWord();
            string fileName = $"referal_analysis_{referalAnalysis.PatientId}.docx";
            string path = Path.Combine(Environment.CurrentDirectory, fileName);

            if (System.IO.File.Exists(path))
                System.IO.File.Delete(path);

            createFile.GenerateWordFile(referalAnalysis.PatientId, referalAnalysis.DocName, referalAnalysis.ListResearch, _context, path, referalAnalysis.IsExtended);

            string contentType = "application/vnd.openxmlformats-officedocument.wordprocessingml.document";
            byte[] fileBytes = System.IO.File.ReadAllBytes(path);

            return File(fileBytes, contentType, "referal_analysis.docx");
        }
    }
}
