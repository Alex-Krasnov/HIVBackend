using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using DocumentFormat.OpenXml;
using HIVBackend.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using HIVBackend.Models.FormModels;
using HIVBackend.Services;

namespace HIVBackend.Controllers.PatientCard
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReferalAnalysisIbController : ControllerBase
    {
        private readonly HivContext _context;
        public ReferalAnalysisIbController(HivContext context)
        {
            _context = context;
        }

        [HttpGet, Route("GetDataForReferalAnalysisIb")]
        [Authorize(Roles = "User")]
        public IActionResult GetDataForReferalAnalysisIb()
        {
            var listDoc = _context.TblDoctors.OrderBy(e => e.DoctorLong).Select(e => e.DoctorLong).ToList();
            return Ok(listDoc);
        }

        [HttpPost, Route("GetReferalAnalysisIb")]
        [Authorize(Roles = "User")]
        public IActionResult GetReferalAnalysisIb(ReferalAnalysis referalAnalysis)
        {
            var createFile = new ReferalAnalysisIbCreateWord();
            string fileName = $"referal_analysis_ib_{referalAnalysis.PatientId}.docx";
            string path = Path.Combine(Environment.CurrentDirectory, fileName);

            if (System.IO.File.Exists(path))
                System.IO.File.Delete(path);

            createFile.GenerateWordFile(referalAnalysis.PatientId, referalAnalysis.DocName, _context, path);

            string contentType = "application/vnd.openxmlformats-officedocument.wordprocessingml.document";
            byte[] fileBytes = System.IO.File.ReadAllBytes(path);

            return File(fileBytes, contentType, "referal_analysis.docx");
        }
    }
}
