using HIVBackend.Data;
using HIVBackend.Models.DBModuls;
using HIVBackend.Models.OutputModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace HIVBackend.Controllers.PatientCard
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientCardResistanceController : ControllerBase
    {

        private readonly HivContext _context;
        public PatientCardResistanceController(HivContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Authorize(Roles = "User")]
        public IActionResult Get(int patientId)
        {
            List<FrmResistence> resistences = new();

            TblPatientCard patient = _context.TblPatientCards.Where(e => e.PatientId == patientId && e.IsActive == true).ToList().FirstOrDefault();
            if (patient is null)
                return BadRequest("Пациент не найден");


            var patientResistences = from i in _context.TblPatientAclResults
                                     where i.PatientId == patientId &&
                                     (i.AclTestCode == "ЛР001"
                                     || i.AclTestCode == "ЛР005"
                                     || i.AclTestCode == "ЛР010"
                                     || i.AclTestCode == "ЛР015"
                                     || i.AclTestCode == "ЛР020"
                                     || i.AclTestCode == "ЛР025"
                                     || i.AclTestCode == "ЛР030"
                                     || i.AclTestCode == "ЛР035"
                                     || i.AclTestCode == "ЛР040"
                                     || i.AclTestCode == "ЛР045"
                                     || i.AclTestCode == "ЛР050"
                                     || i.AclTestCode == "ЛР055"
                                     || i.AclTestCode == "ЛР060"
                                     || i.AclTestCode == "ЛР065"
                                     || i.AclTestCode == "ЛР070"
                                     || i.AclTestCode == "ЛР075"
                                     || i.AclTestCode == "ЛР080"
                                     || i.AclTestCode == "ЛР085"
                                     || i.AclTestCode == "ЛР090"
                                     || i.AclTestCode == "ЛР095"
                                     || i.AclTestCode == "ЛР100"
                                     || i.AclTestCode == "ЛР105"
                                     || i.AclTestCode == "ЛР110")
                                     group i by i.AclSampleDate into e
                                     select new
                                     {
                                         e.Key
                                     };
            List<TblPatientAclResult> lr001 = _context.TblPatientAclResults.Where(e => e.PatientId == patientId && e.AclTestCode == "ЛР001").ToList();
            List<TblPatientAclResult> lr005 = _context.TblPatientAclResults.Where(e => e.PatientId == patientId && e.AclTestCode == "ЛР005").ToList();
            List<TblPatientAclResult> lr010 = _context.TblPatientAclResults.Where(e => e.PatientId == patientId && e.AclTestCode == "ЛР010").ToList();
            List<TblPatientAclResult> lr015 = _context.TblPatientAclResults.Where(e => e.PatientId == patientId && e.AclTestCode == "ЛР015").ToList();
            List<TblPatientAclResult> lr020 = _context.TblPatientAclResults.Where(e => e.PatientId == patientId && e.AclTestCode == "ЛР020").ToList();
            List<TblPatientAclResult> lr025 = _context.TblPatientAclResults.Where(e => e.PatientId == patientId && e.AclTestCode == "ЛР025").ToList();
            List<TblPatientAclResult> lr030 = _context.TblPatientAclResults.Where(e => e.PatientId == patientId && e.AclTestCode == "ЛР030").ToList();
            List<TblPatientAclResult> lr035 = _context.TblPatientAclResults.Where(e => e.PatientId == patientId && e.AclTestCode == "ЛР035").ToList();
            List<TblPatientAclResult> lr040 = _context.TblPatientAclResults.Where(e => e.PatientId == patientId && e.AclTestCode == "ЛР040").ToList();
            List<TblPatientAclResult> lr045 = _context.TblPatientAclResults.Where(e => e.PatientId == patientId && e.AclTestCode == "ЛР045").ToList();
            List<TblPatientAclResult> lr050 = _context.TblPatientAclResults.Where(e => e.PatientId == patientId && e.AclTestCode == "ЛР050").ToList();
            List<TblPatientAclResult> lr055 = _context.TblPatientAclResults.Where(e => e.PatientId == patientId && e.AclTestCode == "ЛР055").ToList();
            List<TblPatientAclResult> lr060 = _context.TblPatientAclResults.Where(e => e.PatientId == patientId && e.AclTestCode == "ЛР060").ToList();
            List<TblPatientAclResult> lr065 = _context.TblPatientAclResults.Where(e => e.PatientId == patientId && e.AclTestCode == "ЛР065").ToList();
            List<TblPatientAclResult> lr070 = _context.TblPatientAclResults.Where(e => e.PatientId == patientId && e.AclTestCode == "ЛР070").ToList();
            List<TblPatientAclResult> lr075 = _context.TblPatientAclResults.Where(e => e.PatientId == patientId && e.AclTestCode == "ЛР075").ToList();
            List<TblPatientAclResult> lr080 = _context.TblPatientAclResults.Where(e => e.PatientId == patientId && e.AclTestCode == "ЛР080").ToList();
            List<TblPatientAclResult> lr085 = _context.TblPatientAclResults.Where(e => e.PatientId == patientId && e.AclTestCode == "ЛР085").ToList();
            List<TblPatientAclResult> lr090 = _context.TblPatientAclResults.Where(e => e.PatientId == patientId && e.AclTestCode == "ЛР090").ToList();
            List<TblPatientAclResult> lr095 = _context.TblPatientAclResults.Where(e => e.PatientId == patientId && e.AclTestCode == "ЛР095").ToList();
            List<TblPatientAclResult> lr100 = _context.TblPatientAclResults.Where(e => e.PatientId == patientId && e.AclTestCode == "ЛР100").ToList();
            List<TblPatientAclResult> lr105 = _context.TblPatientAclResults.Where(e => e.PatientId == patientId && e.AclTestCode == "ЛР105").ToList();
            List<TblPatientAclResult> lr110 = _context.TblPatientAclResults.Where(e => e.PatientId == patientId && e.AclTestCode == "ЛР110").ToList();


            foreach (var item in patientResistences)
            {
                resistences.Add(new()
                {
                    Date = DateOnly.FromDateTime(item.Key),
                    Lr001 = lr001.FirstOrDefault(e => e.AclSampleDate == item.Key)?.AclResult,
                    Lr005 = lr005.FirstOrDefault(e => e.AclSampleDate == item.Key)?.AclResult,
                    Lr010 = lr010.FirstOrDefault(e => e.AclSampleDate == item.Key)?.AclResult,
                    Lr015 = lr015.FirstOrDefault(e => e.AclSampleDate == item.Key)?.AclResult,
                    Lr020 = lr020.FirstOrDefault(e => e.AclSampleDate == item.Key)?.AclResult,
                    Lr025 = lr025.FirstOrDefault(e => e.AclSampleDate == item.Key)?.AclResult,
                    Lr030 = lr030.FirstOrDefault(e => e.AclSampleDate == item.Key)?.AclResult,
                    Lr035 = lr035.FirstOrDefault(e => e.AclSampleDate == item.Key)?.AclResult,
                    Lr040 = lr040.FirstOrDefault(e => e.AclSampleDate == item.Key)?.AclResult,
                    Lr045 = lr045.FirstOrDefault(e => e.AclSampleDate == item.Key)?.AclResult,
                    Lr050 = lr050.FirstOrDefault(e => e.AclSampleDate == item.Key)?.AclResult,
                    Lr055 = lr055.FirstOrDefault(e => e.AclSampleDate == item.Key)?.AclResult,
                    Lr060 = lr060.FirstOrDefault(e => e.AclSampleDate == item.Key)?.AclResult,
                    Lr065 = lr065.FirstOrDefault(e => e.AclSampleDate == item.Key)?.AclResult,
                    Lr070 = lr070.FirstOrDefault(e => e.AclSampleDate == item.Key)?.AclResult,
                    Lr075 = lr075.FirstOrDefault(e => e.AclSampleDate == item.Key)?.AclResult,
                    Lr080 = lr080.FirstOrDefault(e => e.AclSampleDate == item.Key)?.AclResult,
                    Lr085 = lr085.FirstOrDefault(e => e.AclSampleDate == item.Key)?.AclResult,
                    Lr090 = lr090.FirstOrDefault(e => e.AclSampleDate == item.Key)?.AclResult,
                    Lr095 = lr095.FirstOrDefault(e => e.AclSampleDate == item.Key)?.AclResult,
                    Lr100 = lr100.FirstOrDefault(e => e.AclSampleDate == item.Key)?.AclResult,
                    Lr105 = lr105.FirstOrDefault(e => e.AclSampleDate == item.Key)?.AclResult,
                    Lr110 = lr110.FirstOrDefault(e => e.AclSampleDate == item.Key)?.AclResult
                });
            }

            PatientCardResistence patientCardResistence = new();

            patientCardResistence.PatientId = patient.PatientId;
            patientCardResistence.PatientFio = patient.FamilyName + " " + patient.FirstName + " " + patient.ThirdName;
            patientCardResistence.Resistences = resistences;

            return Ok(patientCardResistence);
        }
    }
}
