using HIVBackend.Data;
using HIVBackend.Models.DBModuls;
using HIVBackend.Models.OutputModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace HIVBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientCardDiagnosticConcomitantController : ControllerBase
    {
        private readonly HivContext _context;
        public PatientCardDiagnosticConcomitantController(HivContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Authorize(Roles = "User")]
        public IActionResult Get(int patientId)
        {
            List<FrmHepCPcr> HepCPcrs = new();
            List<FrmDiag3Col> HepBPcrs = new();
            List<FrmDiag2Col> HepCIfas = new();
            List<FrmDiag2Col> HepBIfas = new();
            List<FrmDiag2Col> SiphilisIfas = new();
            List<FrmDiag2Col> ToxIggs = new();
            List<FrmDiag2Col> ToxIgms = new();
            List<FrmDiag3Col> Vpchs = new();

            TblPatientCard patient = _context.TblPatientCards.Where(e => e.PatientId == patientId && e.IsActive == true).ToList().FirstOrDefault();
            if (patient is null)
                return BadRequest("Пациент не найден");


            var patientHepCPcrs = from i in _context.TblPatientAclResults
                                  where i.PatientId == patientId &&
                                  (i.AclTestCode == "П0025"
                                  || i.AclTestCode == "П0020")
                                  group i by i.AclSampleDate into e
                                  select new
                                  {
                                      e.Key
                                  };
            List<TblPatientAclResult> patientHepCPcrs3 = _context.TblPatientAclResults.Where(e => e.PatientId == patientId && e.AclTestCode == "П0025").ToList();
            List<TblPatientAclResult> patientHepCPcrs2 = _context.TblPatientAclResults.Where(e => e.PatientId == patientId && (e.AclTestCode == "П0020" || e.AclTestCode == "П0070")).ToList();
            List<TblPatientHepatitResult> patientHepCPcrsOld = _context.TblPatientHepatitResults.Where(e => e.PatientId == patientId).ToList();
            List<TblPatientAclResult> patientHepBPcrs = _context.TblPatientAclResults.Where(e => e.PatientId == patientId && e.AclTestCode == "П0015").ToList();
            List<TblPatientHepatitResult2> patientHepBPcrsOld = _context.TblPatientHepatitResult2s.Where(e => e.PatientId == patientId).ToList();
            List<TblPatientAclResult> patientHepCIfas = _context.TblPatientAclResults.Where(e => e.PatientId == patientId && (e.AclTestCode == "ИФА010" || e.AclTestCode == "ИХЛ08")).ToList();
            List<TblPatientAclResult> patientHepBIfas = _context.TblPatientAclResults.Where(e => e.PatientId == patientId && (e.AclTestCode == "ИФА005" || e.AclTestCode == "ИХЛ02")).ToList();
            List<TblPatientAclResult> patientSiphilisIfas = _context.TblPatientAclResults.Where(e => e.PatientId == patientId && (e.AclTestCode == "ИФА001" || e.AclTestCode == "ИХЛ12")).ToList();
            List<TblPatientAclResult> patientToxIggs = _context.TblPatientAclResults.Where(e => e.PatientId == patientId && e.AclTestCode == "ИФА0030").ToList();
            List<TblPatientAclResult> patientToxIgms = _context.TblPatientAclResults.Where(e => e.PatientId == patientId && e.AclTestCode == "ИФА0025").ToList();
            List<TblPatientAclResult> patientVpchs = _context.TblPatientAclResults.Where(e => e.PatientId == patientId && e.AclTestCode == "Р0002").ToList();


            foreach (var item in patientHepCPcrs)
            {
                HepCPcrs.Add(new()
                {
                    Date = DateOnly.FromDateTime(item.Key),
                    Result = patientHepCPcrs2.FirstOrDefault(e => e.AclSampleDate == item.Key)?.AclMcnCode,
                    ResultDescr = patientHepCPcrs2.FirstOrDefault(e => e.AclSampleDate == item.Key)?.AclResult,
                    P0025 = patientHepCPcrs3.FirstOrDefault(e => e.AclSampleDate == item.Key)?.AclMcnCode,
                    P0025R = patientHepCPcrs3.FirstOrDefault(e => e.AclSampleDate == item.Key)?.AclResult
                });
            }

            foreach (var item in patientHepCPcrsOld)
            {
                HepCPcrs.Add(new()
                {
                    Date = item.DefineResultDate,
                    Result = item.HepatitLoad.ToString(),
                    ResultDescr = _context.TblHepatitResults.FirstOrDefault(e => e.HepatitResultId == item.HepatitResultId)?.HepatitResultLong,
                    P0025 = null,
                    P0025R = null
                });
            }

            foreach (var item in patientHepBPcrs)
            {
                HepBPcrs.Add(new()
                {
                    Date = DateOnly.FromDateTime(item.AclSampleDate),
                    Result = item.AclResult,
                    ResultDescr = item.AclMcnCode
                });
            }

            foreach (var item in patientHepBPcrsOld)
            {
                HepBPcrs.Add(new()
                {
                    Date = item.DefineResultDate,
                    Result = item.Hepatit2Load.ToString(),
                    ResultDescr = _context.TblHepatitResult2s.FirstOrDefault(e => e.HepatitResult2Id == item.HepatitResult2Id)?.HepatitResult2Long
                });
            }

            foreach (var item in patientHepCIfas)
            {
                HepCIfas.Add(new()
                {
                    Date = DateOnly.FromDateTime(item.AclSampleDate),
                    Result = item.AclResult
                });
            }

            foreach (var item in patientHepBIfas)
            {
                HepBIfas.Add(new()
                {
                    Date = DateOnly.FromDateTime(item.AclSampleDate),
                    Result = item.AclResult
                });
            }

            foreach (var item in patientSiphilisIfas)
            {
                SiphilisIfas.Add(new()
                {
                    Date = DateOnly.FromDateTime(item.AclSampleDate),
                    Result = item.AclResult
                });
            }

            foreach (var item in patientToxIggs)
            {
                ToxIggs.Add(new()
                {
                    Date = DateOnly.FromDateTime(item.AclSampleDate),
                    Result = item.AclResult
                });
            }

            foreach (var item in patientToxIgms)
            {
                ToxIgms.Add(new()
                {
                    Date = DateOnly.FromDateTime(item.AclSampleDate),
                    Result = item.AclResult
                });
            }

            foreach (var item in patientVpchs)
            {
                Vpchs.Add(new()
                {
                    Date = DateOnly.FromDateTime(item.AclSampleDate),
                    Result = item.AclMcnCode,
                    ResultDescr = item.AclResult
                });
            }

            PatientCardDiagnosticConcomitant patientCardDiagnosticConcomitant = new();

            patientCardDiagnosticConcomitant.PatientId = patient.PatientId;
            patientCardDiagnosticConcomitant.PatientFio = patient.FamilyName + " " + patient.FirstName + " " + patient.ThirdName;
            patientCardDiagnosticConcomitant.HepCPcrs = HepCPcrs.OrderBy(e => e.Date).ToList();
            patientCardDiagnosticConcomitant.HepBPcrs = HepBPcrs.OrderBy(e => e.Date).ToList();
            patientCardDiagnosticConcomitant.HepCIfas = HepCIfas.OrderBy(e => e.Date).ToList();
            patientCardDiagnosticConcomitant.HepBIfas = HepBIfas.OrderBy(e => e.Date).ToList();
            patientCardDiagnosticConcomitant.SiphilisIfas = SiphilisIfas.OrderBy(e => e.Date).ToList();
            patientCardDiagnosticConcomitant.ToxIggs = ToxIggs.OrderBy(e => e.Date).ToList();
            patientCardDiagnosticConcomitant.ToxIgms = ToxIgms.OrderBy(e => e.Date).ToList();
            patientCardDiagnosticConcomitant.Vpchs = Vpchs.OrderBy(e => e.Date).ToList();

            return Ok(patientCardDiagnosticConcomitant);
        }
    }
}
