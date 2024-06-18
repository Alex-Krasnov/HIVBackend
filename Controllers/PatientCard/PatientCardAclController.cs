using HIVBackend.Data;
using HIVBackend.Models.DBModuls;
using HIVBackend.Models.OutputModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace HIVBackend.Controllers.PatientCard
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientCardAclController : ControllerBase
    {
        private readonly HivContext _context;
        public PatientCardAclController(HivContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Authorize(Roles = "User")]
        public IActionResult Get(int patientId)
        {
            List<FrmBHGE> bh = new();
            List<FrmBHGE> ge = new();

            TblPatientCard patient = _context.TblPatientCards.Where(e => e.PatientId == patientId && e.IsActive == true).ToList().FirstOrDefault();
            if (patient is null)
                return BadRequest("Пациент не найден");


            var patientBH = from i in _context.TblPatientAclResults
                            where i.PatientId == patientId &&
                            (i.AclTestCode.Contains("Б0001")
                            || i.AclTestCode.Contains("Б0005")
                            || i.AclTestCode.Contains("Б0010")
                            || i.AclTestCode.Contains("Б0015")
                            || i.AclTestCode.Contains("Б0020")
                            || i.AclTestCode.Contains("Б0025")
                            || i.AclTestCode.Contains("Б0030")
                            || i.AclTestCode.Contains("Б0035")
                            || i.AclTestCode.Contains("Б0040")
                            || i.AclTestCode.Contains("Б0045")
                            || i.AclTestCode.Contains("Б0050")
                            || i.AclTestCode.Contains("Б0055")
                            || i.AclTestCode.Contains("Б0060")
                            || i.AclTestCode.Contains("Б0065")
                            || i.AclTestCode.Contains("Б0070")
                            || i.AclTestCode.Contains("Б0075")
                            || i.AclTestCode.Contains("Б0080")
                            || i.AclTestCode.Contains("Б0085")
                            || i.AclTestCode.Contains("Б0090")
                            || i.AclTestCode.Contains("Б0095")
                            || i.AclTestCode.Contains("Б0100")
                            || i.AclTestCode.Contains("Б0105")
                            || i.AclTestCode.Contains("Б0110")
                            || i.AclTestCode.Contains("Б0115"))
                            group i by i.AclSampleDate into e
                            select new
                            {
                                e.Key
                            };

            var patientGE = from i in _context.TblPatientAclResults
                            where i.PatientId == patientId &&
                            (i.AclTestCode.Contains("Г0001")
                            || i.AclTestCode.Contains("Г0005")
                            || i.AclTestCode.Contains("Г0010")
                            || i.AclTestCode.Contains("Г0015")
                            || i.AclTestCode.Contains("Г0020")
                            || i.AclTestCode.Contains("Г0025")
                            || i.AclTestCode.Contains("Г0030")
                            || i.AclTestCode.Contains("Г0035")
                            || i.AclTestCode.Contains("Г0040")
                            || i.AclTestCode.Contains("Г0045")
                            || i.AclTestCode.Contains("Г0050")
                            || i.AclTestCode.Contains("Г0055")
                            || i.AclTestCode.Contains("Г0060")
                            || i.AclTestCode.Contains("Г0065")
                            || i.AclTestCode.Contains("Г0070")
                            || i.AclTestCode.Contains("Г0075")
                            || i.AclTestCode.Contains("Г0080")
                            || i.AclTestCode.Contains("Г0085")
                            || i.AclTestCode.Contains("Г0090")
                            || i.AclTestCode.Contains("Г0095")
                            || i.AclTestCode.Contains("Г0100")
                            || i.AclTestCode.Contains("Г0105")
                            || i.AclTestCode.Contains("Г0110")
                            || i.AclTestCode.Contains("Г0115"))
                            group i by i.AclSampleDate into e
                            select new
                            {
                                e.Key
                            };

            List<TblPatientAclResult> b001 = _context.TblPatientAclResults.Where(e => e.PatientId == patientId && e.AclTestCode.Contains("Б0001")).ToList();
            List<TblPatientAclResult> b005 = _context.TblPatientAclResults.Where(e => e.PatientId == patientId && e.AclTestCode.Contains("Б0005")).ToList();
            List<TblPatientAclResult> b010 = _context.TblPatientAclResults.Where(e => e.PatientId == patientId && e.AclTestCode.Contains("Б0010")).ToList();
            List<TblPatientAclResult> b015 = _context.TblPatientAclResults.Where(e => e.PatientId == patientId && e.AclTestCode.Contains("Б0015")).ToList();
            List<TblPatientAclResult> b020 = _context.TblPatientAclResults.Where(e => e.PatientId == patientId && e.AclTestCode.Contains("Б0020")).ToList();
            List<TblPatientAclResult> b025 = _context.TblPatientAclResults.Where(e => e.PatientId == patientId && e.AclTestCode.Contains("Б0025")).ToList();
            List<TblPatientAclResult> b030 = _context.TblPatientAclResults.Where(e => e.PatientId == patientId && e.AclTestCode.Contains("Б0030")).ToList();
            List<TblPatientAclResult> b035 = _context.TblPatientAclResults.Where(e => e.PatientId == patientId && e.AclTestCode.Contains("Б0035")).ToList();
            List<TblPatientAclResult> b040 = _context.TblPatientAclResults.Where(e => e.PatientId == patientId && e.AclTestCode.Contains("Б0040")).ToList();
            List<TblPatientAclResult> b045 = _context.TblPatientAclResults.Where(e => e.PatientId == patientId && e.AclTestCode.Contains("Б0045")).ToList();
            List<TblPatientAclResult> b050 = _context.TblPatientAclResults.Where(e => e.PatientId == patientId && e.AclTestCode.Contains("Б0050")).ToList();
            List<TblPatientAclResult> b055 = _context.TblPatientAclResults.Where(e => e.PatientId == patientId && e.AclTestCode.Contains("Б0055")).ToList();
            List<TblPatientAclResult> b060 = _context.TblPatientAclResults.Where(e => e.PatientId == patientId && e.AclTestCode.Contains("Б0060")).ToList();
            List<TblPatientAclResult> b065 = _context.TblPatientAclResults.Where(e => e.PatientId == patientId && e.AclTestCode.Contains("Б0065")).ToList();
            List<TblPatientAclResult> b070 = _context.TblPatientAclResults.Where(e => e.PatientId == patientId && e.AclTestCode.Contains("Б0070")).ToList();
            List<TblPatientAclResult> b075 = _context.TblPatientAclResults.Where(e => e.PatientId == patientId && e.AclTestCode.Contains("Б0075")).ToList();
            List<TblPatientAclResult> b080 = _context.TblPatientAclResults.Where(e => e.PatientId == patientId && e.AclTestCode.Contains("Б0080")).ToList();
            List<TblPatientAclResult> b085 = _context.TblPatientAclResults.Where(e => e.PatientId == patientId && e.AclTestCode.Contains("Б0085")).ToList();
            List<TblPatientAclResult> b090 = _context.TblPatientAclResults.Where(e => e.PatientId == patientId && e.AclTestCode.Contains("Б0090")).ToList();
            List<TblPatientAclResult> b095 = _context.TblPatientAclResults.Where(e => e.PatientId == patientId && e.AclTestCode.Contains("Б0095")).ToList();
            List<TblPatientAclResult> b100 = _context.TblPatientAclResults.Where(e => e.PatientId == patientId && e.AclTestCode.Contains("Б0100")).ToList();
            List<TblPatientAclResult> b105 = _context.TblPatientAclResults.Where(e => e.PatientId == patientId && e.AclTestCode.Contains("Б0105")).ToList();
            List<TblPatientAclResult> b110 = _context.TblPatientAclResults.Where(e => e.PatientId == patientId && e.AclTestCode.Contains("Б0110")).ToList();
            List<TblPatientAclResult> b115 = _context.TblPatientAclResults.Where(e => e.PatientId == patientId && e.AclTestCode.Contains("Б0115")).ToList();

            List<TblPatientAclResult> g001 = _context.TblPatientAclResults.Where(e => e.PatientId == patientId && e.AclTestCode.Contains("Г0001")).ToList();
            List<TblPatientAclResult> g005 = _context.TblPatientAclResults.Where(e => e.PatientId == patientId && e.AclTestCode.Contains("Г0005")).ToList();
            List<TblPatientAclResult> g010 = _context.TblPatientAclResults.Where(e => e.PatientId == patientId && e.AclTestCode.Contains("Г0010")).ToList();
            List<TblPatientAclResult> g015 = _context.TblPatientAclResults.Where(e => e.PatientId == patientId && e.AclTestCode.Contains("Г0015")).ToList();
            List<TblPatientAclResult> g020 = _context.TblPatientAclResults.Where(e => e.PatientId == patientId && e.AclTestCode.Contains("Г0020")).ToList();
            List<TblPatientAclResult> g025 = _context.TblPatientAclResults.Where(e => e.PatientId == patientId && e.AclTestCode.Contains("Г0025")).ToList();
            List<TblPatientAclResult> g030 = _context.TblPatientAclResults.Where(e => e.PatientId == patientId && e.AclTestCode.Contains("Г0030")).ToList();
            List<TblPatientAclResult> g035 = _context.TblPatientAclResults.Where(e => e.PatientId == patientId && e.AclTestCode.Contains("Г0035")).ToList();
            List<TblPatientAclResult> g040 = _context.TblPatientAclResults.Where(e => e.PatientId == patientId && e.AclTestCode.Contains("Г0040")).ToList();
            List<TblPatientAclResult> g045 = _context.TblPatientAclResults.Where(e => e.PatientId == patientId && e.AclTestCode.Contains("Г0045")).ToList();
            List<TblPatientAclResult> g050 = _context.TblPatientAclResults.Where(e => e.PatientId == patientId && e.AclTestCode.Contains("Г0050")).ToList();
            List<TblPatientAclResult> g055 = _context.TblPatientAclResults.Where(e => e.PatientId == patientId && e.AclTestCode.Contains("Г0055")).ToList();
            List<TblPatientAclResult> g060 = _context.TblPatientAclResults.Where(e => e.PatientId == patientId && e.AclTestCode.Contains("Г0060")).ToList();
            List<TblPatientAclResult> g065 = _context.TblPatientAclResults.Where(e => e.PatientId == patientId && e.AclTestCode.Contains("Г0065")).ToList();
            List<TblPatientAclResult> g070 = _context.TblPatientAclResults.Where(e => e.PatientId == patientId && e.AclTestCode.Contains("Г0070")).ToList();
            List<TblPatientAclResult> g075 = _context.TblPatientAclResults.Where(e => e.PatientId == patientId && e.AclTestCode.Contains("Г0075")).ToList();
            List<TblPatientAclResult> g080 = _context.TblPatientAclResults.Where(e => e.PatientId == patientId && e.AclTestCode.Contains("Г0080")).ToList();
            List<TblPatientAclResult> g085 = _context.TblPatientAclResults.Where(e => e.PatientId == patientId && e.AclTestCode.Contains("Г0085")).ToList();
            List<TblPatientAclResult> g090 = _context.TblPatientAclResults.Where(e => e.PatientId == patientId && e.AclTestCode.Contains("Г0090")).ToList();
            List<TblPatientAclResult> g095 = _context.TblPatientAclResults.Where(e => e.PatientId == patientId && e.AclTestCode.Contains("Г0095")).ToList();
            List<TblPatientAclResult> g100 = _context.TblPatientAclResults.Where(e => e.PatientId == patientId && e.AclTestCode.Contains("Г0100")).ToList();
            List<TblPatientAclResult> g105 = _context.TblPatientAclResults.Where(e => e.PatientId == patientId && e.AclTestCode.Contains("Г0105")).ToList();
            List<TblPatientAclResult> g110 = _context.TblPatientAclResults.Where(e => e.PatientId == patientId && e.AclTestCode.Contains("Г0110")).ToList();
            List<TblPatientAclResult> g115 = _context.TblPatientAclResults.Where(e => e.PatientId == patientId && e.AclTestCode.Contains("Г0115")).ToList();

            foreach (var item in patientBH)
            {
                bh.Add(new()
                {
                    Date = DateOnly.FromDateTime(item.Key),
                    B001 = b001.FirstOrDefault(e => e.AclSampleDate == item.Key)?.AclResult,
                    B005 = b005.FirstOrDefault(e => e.AclSampleDate == item.Key)?.AclResult,
                    B010 = b010.FirstOrDefault(e => e.AclSampleDate == item.Key)?.AclResult,
                    B015 = b015.FirstOrDefault(e => e.AclSampleDate == item.Key)?.AclResult,
                    B020 = b020.FirstOrDefault(e => e.AclSampleDate == item.Key)?.AclResult,
                    B025 = b025.FirstOrDefault(e => e.AclSampleDate == item.Key)?.AclResult,
                    B030 = b030.FirstOrDefault(e => e.AclSampleDate == item.Key)?.AclResult,
                    B035 = b035.FirstOrDefault(e => e.AclSampleDate == item.Key)?.AclResult,
                    B040 = b040.FirstOrDefault(e => e.AclSampleDate == item.Key)?.AclResult,
                    B045 = b045.FirstOrDefault(e => e.AclSampleDate == item.Key)?.AclResult,
                    B050 = b050.FirstOrDefault(e => e.AclSampleDate == item.Key)?.AclResult,
                    B055 = b055.FirstOrDefault(e => e.AclSampleDate == item.Key)?.AclResult,
                    B060 = b060.FirstOrDefault(e => e.AclSampleDate == item.Key)?.AclResult,
                    B065 = b065.FirstOrDefault(e => e.AclSampleDate == item.Key)?.AclResult,
                    B070 = b070.FirstOrDefault(e => e.AclSampleDate == item.Key)?.AclResult,
                    B075 = b075.FirstOrDefault(e => e.AclSampleDate == item.Key)?.AclResult,
                    B080 = b080.FirstOrDefault(e => e.AclSampleDate == item.Key)?.AclResult,
                    B085 = b085.FirstOrDefault(e => e.AclSampleDate == item.Key)?.AclResult,
                    B090 = b090.FirstOrDefault(e => e.AclSampleDate == item.Key)?.AclResult,
                    B095 = b095.FirstOrDefault(e => e.AclSampleDate == item.Key)?.AclResult,
                    B100 = b100.FirstOrDefault(e => e.AclSampleDate == item.Key)?.AclResult,
                    B105 = b105.FirstOrDefault(e => e.AclSampleDate == item.Key)?.AclResult,
                    B110 = b110.FirstOrDefault(e => e.AclSampleDate == item.Key)?.AclResult,
                    B115 = b115.FirstOrDefault(e => e.AclSampleDate == item.Key)?.AclResult
                });
            }

            foreach (var item in patientGE)
            {
                ge.Add(new()
                {
                    Date = DateOnly.FromDateTime(item.Key),
                    B001 = g001.FirstOrDefault(e => e.AclSampleDate == item.Key)?.AclResult,
                    B005 = g005.FirstOrDefault(e => e.AclSampleDate == item.Key)?.AclResult,
                    B010 = g010.FirstOrDefault(e => e.AclSampleDate == item.Key)?.AclResult,
                    B015 = g015.FirstOrDefault(e => e.AclSampleDate == item.Key)?.AclResult,
                    B020 = g020.FirstOrDefault(e => e.AclSampleDate == item.Key)?.AclResult,
                    B025 = g025.FirstOrDefault(e => e.AclSampleDate == item.Key)?.AclResult,
                    B030 = g030.FirstOrDefault(e => e.AclSampleDate == item.Key)?.AclResult,
                    B035 = g035.FirstOrDefault(e => e.AclSampleDate == item.Key)?.AclResult,
                    B040 = g040.FirstOrDefault(e => e.AclSampleDate == item.Key)?.AclResult,
                    B045 = g045.FirstOrDefault(e => e.AclSampleDate == item.Key)?.AclResult,
                    B050 = g050.FirstOrDefault(e => e.AclSampleDate == item.Key)?.AclResult,
                    B055 = g055.FirstOrDefault(e => e.AclSampleDate == item.Key)?.AclResult,
                    B060 = g060.FirstOrDefault(e => e.AclSampleDate == item.Key)?.AclResult,
                    B065 = g065.FirstOrDefault(e => e.AclSampleDate == item.Key)?.AclResult,
                    B070 = g070.FirstOrDefault(e => e.AclSampleDate == item.Key)?.AclResult,
                    B075 = g075.FirstOrDefault(e => e.AclSampleDate == item.Key)?.AclResult,
                    B080 = g080.FirstOrDefault(e => e.AclSampleDate == item.Key)?.AclResult,
                    B085 = g085.FirstOrDefault(e => e.AclSampleDate == item.Key)?.AclResult,
                    B090 = g090.FirstOrDefault(e => e.AclSampleDate == item.Key)?.AclResult,
                    B095 = g095.FirstOrDefault(e => e.AclSampleDate == item.Key)?.AclResult,
                    B100 = g100.FirstOrDefault(e => e.AclSampleDate == item.Key)?.AclResult,
                    B105 = g105.FirstOrDefault(e => e.AclSampleDate == item.Key)?.AclResult,
                    B110 = g110.FirstOrDefault(e => e.AclSampleDate == item.Key)?.AclResult,
                    B115 = g115.FirstOrDefault(e => e.AclSampleDate == item.Key)?.AclResult
                });
            }

            PatientCardAcl patientCardAcl = new();

            patientCardAcl.PatientId = patient.PatientId;
            patientCardAcl.PatientFio = patient.FamilyName + " " + patient.FirstName + " " + patient.ThirdName;
            patientCardAcl.Bhs = bh.OrderByDescending(e => e.Date).ToList();
            patientCardAcl.Ges = ge.OrderByDescending(e => e.Date).ToList();
            return Ok(patientCardAcl);
        }
    }
}
