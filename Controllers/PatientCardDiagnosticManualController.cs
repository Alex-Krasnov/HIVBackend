using HIVBackend.Data;
using HIVBackend.Models.DBModuls;
using HIVBackend.Models.FormModels;
using HIVBackend.Models.OutputModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace HIVBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientCardDiagnosticManualController : ControllerBase
    {
        private readonly HivContext _context;
        public PatientCardDiagnosticManualController(HivContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Authorize(Roles = "User")]
        public IActionResult Get(int patientId)
        {
            List<FrmDiag3Col> virusLoads = new();
            List<FrmDiag3Col> hepCs = new();
            List<FrmDiag3Col> hepBs = new();

            TblPatientCard patient = _context.TblPatientCards.Where(e => e.PatientId == patientId && e.IsActive == true).ToList().FirstOrDefault();
            if (patient is null)
                return BadRequest("Пациент не найден");
            List<TblPatientVirusLoad> patientVirusLoads = _context.TblPatientVirusLoads.Where(e => e.PatientId == patientId).ToList();
            List<TblPatientHepatitResult> patientHepCs = _context.TblPatientHepatitResults.Where(e => e.PatientId == patientId).ToList();
            List<TblPatientHepatitResult2> patientHepBs = _context.TblPatientHepatitResult2s.Where(e => e.PatientId == patientId).ToList();

            foreach (var item in patientVirusLoads)
            {
                virusLoads.Add(new()
                {
                    Date = item.DefineVirusDate,
                    Result = item.VirusLoad?.ToString(),
                    ResultDescr = _context.TblVloadResults.FirstOrDefault(e => e.VloadResultId == item.VloadResultId)?.VloadResultLong
                });
            }

            foreach(var item in patientHepCs) 
            {
                hepCs.Add(new()
                {
                    Date = item.DefineResultDate,
                    Result = item.HepatitLoad?.ToString(),
                    ResultDescr = _context.TblHepatitResults.FirstOrDefault(e => e.HepatitResultId == item.HepatitResultId)?.HepatitResultLong
                });
            }

            foreach(var item in patientHepBs)
            {
                hepBs.Add(new()
                {
                    Date = item.DefineResultDate,
                    Result = item.Hepatit2Load?.ToString(),
                    ResultDescr = _context.TblHepatitResult2s.FirstOrDefault(e => e.HepatitResult2Id == item.HepatitResult2Id)?.HepatitResult2Long
                });
            }

            PatientCardDiagnosticManual patientCardDiagnosticManual = new();

            patientCardDiagnosticManual.PatientId = patient.PatientId;
            patientCardDiagnosticManual.PatientFio = patient.FamilyName + " " + patient.FirstName + " " + patient.ThirdName;
            patientCardDiagnosticManual.ListVLResult = _context.TblVloadResults.Select(e => e.VloadResultLong).ToList();
            patientCardDiagnosticManual.ListHCResult = _context.TblHepatitResults.Select(e => e.HepatitResultLong).ToList();
            patientCardDiagnosticManual.ListHBResult = _context.TblHepatitResult2s?.Select(e => e.HepatitResult2Long).ToList();
            patientCardDiagnosticManual.VirusLoads = virusLoads;
            patientCardDiagnosticManual.HepCs = hepCs;
            patientCardDiagnosticManual.HepBs = hepBs;

            return Ok(patientCardDiagnosticManual);
        }

        [HttpDelete, Route("DelMaual")]
        [Authorize(Roles = "User")]
        public IActionResult DelMaual(int id, string date, string type)
        {
            switch (type)
            {
                case "vl":
                    TblPatientVirusLoad vl = _context.TblPatientVirusLoads.First(e => e.PatientId == id && e.DefineVirusDate == DateOnly.Parse(date));
                    _context.TblPatientVirusLoads.Attach(vl);
                    _context.TblPatientVirusLoads.Remove(vl);
                    break;
                case "hc":
                    TblPatientHepatitResult hc = _context.TblPatientHepatitResults.First(e => e.PatientId == id && e.DefineResultDate == DateOnly.Parse(date));
                    _context.TblPatientHepatitResults.Attach(hc);
                    _context.TblPatientHepatitResults.Remove(hc);
                    break;
                case "hb":
                    TblPatientHepatitResult2 hb = _context.TblPatientHepatitResult2s.First(e => e.PatientId == id && e.DefineResultDate == DateOnly.Parse(date));
                    _context.TblPatientHepatitResult2s.Attach(hb);
                    _context.TblPatientHepatitResult2s.Remove(hb);
                    break;
            }
            _context.SaveChanges();
            return Ok();
        }

        [HttpPost, Route("CreateMaual")]
        [Authorize(Roles = "User")]
        public IActionResult CreateMaual(Diag3Col diag)
        {
            switch (diag.Type)
            {
                case "vl":
                    TblPatientVirusLoad vl = new()
                    {
                        PatientId = diag.PatientId,
                        DefineVirusDate = DateOnly.Parse(diag.Date),
                        VirusLoad = diag.Result,
                        VloadResultId = _context.TblVloadResults.FirstOrDefault(e => e.VloadResultLong == diag.ResultDescr)?.VloadResultId
                    };
                    _context.TblPatientVirusLoads.Attach(vl);
                    _context.TblPatientVirusLoads.Add(vl);
                    break;
                case "hc":
                    TblPatientHepatitResult hc = new()
                    {
                        PatientId = diag.PatientId,
                        DefineResultDate = DateOnly.Parse(diag.Date),
                        HepatitLoad = diag.Result,
                        HepatitResultId = _context.TblHepatitResults.FirstOrDefault(e => e.HepatitResultLong == diag.ResultDescr)?.HepatitResultId
                    };
                    _context.TblPatientHepatitResults.Attach(hc);
                    _context.TblPatientHepatitResults.Add(hc);
                    break;
                case "hb":
                    TblPatientHepatitResult2 hb = new()
                    {
                        PatientId = diag.PatientId,
                        DefineResultDate = DateOnly.Parse(diag.Date),
                        Hepatit2Load = diag.Result,
                        HepatitResult2Id = _context.TblHepatitResult2s.FirstOrDefault(e => e.HepatitResult2Long == diag.ResultDescr)?.HepatitResult2Id
                    };
                    _context.TblPatientHepatitResult2s.Attach(hb);
                    _context.TblPatientHepatitResult2s.Add(hb);
                    break;
            }
            _context.SaveChanges();
            return Ok();
        }

        [HttpPost, Route("UpdateMaual")]
        [Authorize(Roles = "User")]
        public IActionResult UpdateMaual(Diag3Col diag)
        {
            switch (diag.Type)
            {
                case "vl":
                    TblPatientVirusLoad vl = new()
                    {
                        PatientId = diag.PatientId,
                        DefineVirusDate = DateOnly.Parse(diag.DateOld)
                    };
                    _context.TblPatientVirusLoads.Attach(vl);

                    if(diag.Date == diag.DateOld)
                    {
                        vl.VirusLoad = diag.Result;
                        _context.Entry(vl).Property(e => e.VirusLoad).IsModified = true;
                        vl.VloadResultId = _context.TblVloadResults.FirstOrDefault(e => e.VloadResultLong == diag.ResultDescr)?.VloadResultId;
                        _context.Entry(vl).Property(e => e.VloadResultId).IsModified = true;
                        break;
                    }

                    _context.TblPatientVirusLoads.Remove(vl);
                    vl = new() 
                    {
                        PatientId = diag.PatientId,
                        DefineVirusDate = DateOnly.Parse(diag.Date),
                        VirusLoad = diag.Result,
                        VloadResultId = _context.TblVloadResults.FirstOrDefault(e => e.VloadResultLong == diag.ResultDescr)?.VloadResultId
                    };
                    _context.TblPatientVirusLoads.Add(vl);
                    break;
                case "hc":
                    TblPatientHepatitResult hc = new()
                    {
                        PatientId = diag.PatientId,
                        DefineResultDate = DateOnly.Parse(diag.Date)
                    };
                    _context.TblPatientHepatitResults.Attach(hc);

                    if (diag.Date == diag.DateOld)
                    {
                        hc.HepatitLoad = diag.Result;
                        _context.Entry(hc).Property(e => e.HepatitLoad).IsModified = true;
                        hc.HepatitResultId = _context.TblHepatitResults.FirstOrDefault(e => e.HepatitResultLong == diag.ResultDescr)?.HepatitResultId;
                        _context.Entry(hc).Property(e => e.HepatitResultId).IsModified = true;
                        break;
                    }

                    _context.TblPatientHepatitResults.Remove(hc);
                    hc = new()
                    {
                        PatientId = diag.PatientId,
                        DefineResultDate = DateOnly.Parse(diag.Date),
                        HepatitLoad = diag.Result,
                        HepatitResultId = _context.TblHepatitResults.FirstOrDefault(e => e.HepatitResultLong == diag.ResultDescr)?.HepatitResultId
                    };
                    _context.TblPatientHepatitResults.Add(hc);
                    break;
                case "hb":
                    TblPatientHepatitResult2 hb = new()
                    {
                        PatientId = diag.PatientId,
                        DefineResultDate = DateOnly.Parse(diag.Date)
                    };
                    _context.TblPatientHepatitResult2s.Attach(hb);

                    if (diag.Date == diag.DateOld)
                    {
                        hb.Hepatit2Load = diag.Result;
                        _context.Entry(hb).Property(e => e.Hepatit2Load).IsModified = true;
                        hb.HepatitResult2Id = _context.TblHepatitResults.FirstOrDefault(e => e.HepatitResultLong == diag.ResultDescr)?.HepatitResultId;
                        _context.Entry(hb).Property(e => e.HepatitResult2Id).IsModified = true;
                        break;
                    }

                    _context.TblPatientHepatitResult2s.Remove(hb);
                    hb = new()
                    {
                        PatientId = diag.PatientId,
                        DefineResultDate = DateOnly.Parse(diag.Date),
                        Hepatit2Load = diag.Result,
                        HepatitResult2Id = _context.TblHepatitResult2s.FirstOrDefault(e => e.HepatitResult2Long == diag.ResultDescr)?.HepatitResult2Id
                    };
                    _context.TblPatientHepatitResult2s.Add(hb);
                    break;
            }
            _context.SaveChanges();
            return Ok();
        }
    }
}
