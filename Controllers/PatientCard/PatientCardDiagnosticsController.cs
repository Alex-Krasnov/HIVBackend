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
    public class PatientCardDiagnosticsController : ControllerBase
    {

        private readonly HivContext _context;
        public PatientCardDiagnosticsController(HivContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Authorize(Roles = "User")]
        public IActionResult Get(int patientId)
        {
            List<FrmDiag3Col> virusLoads = new();
            List<FrmDiag2Col> virusLoadsQuals = new();
            List<FrmDiag3Col> cMVs = new();
            List<FrmImStat> imStats = new();
            List<FrmImStatCD348> imStatCD348s = new();
            List<FrmDiag2Col> iHLs = new();
            List<FrmDrugRemains> drugRemains = new();

            TblPatientCard patient = _context.TblPatientCards.Where(e => e.PatientId == patientId && e.IsActive == true).ToList().FirstOrDefault();
            if (patient is null)
                return BadRequest("Пациент не найден");

            List<TblPatientAclResult>? patientVirusLoads = _context.TblPatientAclResults
                .Where(e => e.PatientId == patientId && (e.AclTestCode == "П0030" || e.AclTestCode == "П0060"))?.ToList();
            List<TblPatientAclResult>? patientVirusLoadQuals = _context.TblPatientAclResults.Where(e => e.PatientId == patientId && e.AclTestCode == "П0050")?.ToList();
            List<TblPatientVirusLoad>? patientVirusLoadsOld = _context.TblPatientVirusLoads.Where(e => e.PatientId == patientId).OrderBy(e => e.DefineVirusDate).ToList();
            List<TblPatientAclResult>? patientCMVs = _context.TblPatientAclResults.Where(e => e.PatientId == patientId && e.AclTestCode == "Р0001")?.ToList();
            List<TblPatientAclResult>? patientIHLs = _context.TblPatientAclResults.Where(e => e.PatientId == patientId && e.AclTestCode == "ИХЛ01")?.ToList();

            var imStat1 = from i in _context.TblPatientAclResults
                          where i.PatientId == patientId &&
                          (i.AclTestCode == "И0025" || i.AclTestCode == "И0030" || i.AclTestCode == "И0070")
                          group i by i.AclSampleDate into e
                          select new
                          {
                              e.Key
                          };

            List<TblPatientAclResult>? imStat2 = _context.TblPatientAclResults.Where(e => e.PatientId == patientId && (e.AclTestCode == "И0025" || e.AclTestCode == "И0070"))?.ToList();
            List<TblPatientAclResult>? imStat3 = _context.TblPatientAclResults.Where(e => e.PatientId == patientId && e.AclTestCode == "И0030")?.ToList();

            foreach (var item in imStat1)
            {
                imStats.Add(new()
                {
                    Date = DateOnly.FromDateTime(item.Key),
                    Result = imStat2?.FirstOrDefault(e => e.AclSampleDate == item.Key)?.AclResult,
                    ResultPercent = imStat3?.FirstOrDefault(e => e.AclSampleDate == item.Key)?.AclResult
                });
            }

            var imStatCD348s1 = from i in _context.TblPatientAclResults
                                where i.PatientId == patientId &&
                                (i.AclTestCode == "И0015"
                                || i.AclTestCode == "И0025"
                                || i.AclTestCode == "И0030"
                                || i.AclTestCode == "И0035"
                                || i.AclTestCode == "И0040")
                                group i by i.AclSampleDate into e
                                select new
                                {
                                    e.Key
                                };

            List<TblPatientAclResult>? imStatCD348s15 = _context.TblPatientAclResults.Where(e => e.PatientId == patientId && e.AclTestCode == "И0015")?.ToList();
            List<TblPatientAclResult>? imStatCD348s25 = _context.TblPatientAclResults.Where(e => e.PatientId == patientId && e.AclTestCode == "И0025")?.ToList();
            List<TblPatientAclResult>? imStatCD348s30 = _context.TblPatientAclResults.Where(e => e.PatientId == patientId && e.AclTestCode == "И0030")?.ToList();
            List<TblPatientAclResult>? imStatCD348s35 = _context.TblPatientAclResults.Where(e => e.PatientId == patientId && e.AclTestCode == "И0035")?.ToList();
            List<TblPatientAclResult>? imStatCD348s40 = _context.TblPatientAclResults.Where(e => e.PatientId == patientId && e.AclTestCode == "И0040")?.ToList();
            List<TblPatientImmuneStat>? imStatCD348sOld = _context.TblPatientImmuneStats.Where(e => e.PatientId == patientId)?.ToList();

            foreach (var item in imStatCD348sOld)
            {
                string? resultCD4Percent = null, resultCD8Percent = null, resultCD4CD8 = null;

                try
                {
                    resultCD4Percent = (item.ImmuneValue3 / item.ImmuneValue2 * 100).ToString();
                }
                catch { }

                try
                {
                    resultCD8Percent = (item.ImmuneValue5 / item.ImmuneValue2 * 100).ToString();
                }
                catch { }

                try
                {
                    resultCD4CD8 = (item.ImmuneValue3 / item.ImmuneValue5).ToString();
                }
                catch { }

                imStatCD348s.Add(new()
                {
                    Date = item.ImmuneDefineDate,
                    ResultCD3 = item.ImmuneValue2.ToString(),
                    ResultCD4 = item.ImmuneValue3.ToString(),
                    ResultCD4Percent = resultCD4Percent,
                    ResultCD8 = item.ImmuneValue5.ToString(),
                    ResultCD8Percent = resultCD8Percent,
                    ResultCD4CD8 = resultCD4CD8
                });
            }

            foreach (var item in imStatCD348s1)
            {
                string? cd4cd8 = null;
                var i25 = imStatCD348s25?.FirstOrDefault(e => e.AclSampleDate == item.Key)?.AclResult;
                var i35 = imStatCD348s35?.FirstOrDefault(e => e.AclSampleDate == item.Key)?.AclResult;
                try
                {
                    double div = double.Parse(i25) / double.Parse(i35);
                    cd4cd8 = div.ToString();
                }
                catch { }


                imStatCD348s.Add(new()
                {
                    Date = DateOnly.FromDateTime(item.Key),
                    ResultCD3 = imStatCD348s15?.FirstOrDefault(e => e.AclSampleDate == item.Key)?.AclResult,
                    ResultCD4 = imStatCD348s25?.FirstOrDefault(e => e.AclSampleDate == item.Key)?.AclResult,
                    ResultCD4Percent = imStatCD348s30?.FirstOrDefault(e => e.AclSampleDate == item.Key)?.AclResult,
                    ResultCD8 = imStatCD348s35?.FirstOrDefault(e => e.AclSampleDate == item.Key)?.AclResult,
                    ResultCD8Percent = imStatCD348s40?.FirstOrDefault(e => e.AclSampleDate == item.Key)?.AclResult,
                    ResultCD4CD8 = cd4cd8
                });
            }

            foreach (var item in patientVirusLoads)
            {
                virusLoads.Add(new()
                {
                    Date = DateOnly.FromDateTime(item.AclSampleDate),
                    Result = item.AclMcnCode,
                    ResultDescr = item.AclResult
                });
            }

            foreach (var item in patientVirusLoadsOld)
            {
                virusLoads.Add(new()
                {
                    Date = item.DefineVirusDate,
                    Result = item.VirusLoad.ToString(),
                    ResultDescr = _context.TblVloadResults.FirstOrDefault(e => e.VloadResultId == item.VloadResultId)?.VloadResultLong
                });
            }

            foreach (var item in patientVirusLoadQuals)
            {
                virusLoadsQuals.Add(new()
                {
                    Date = DateOnly.FromDateTime(item.AclSampleDate),
                    Result = item.AclResult
                });
            }

            foreach (var item in patientCMVs)
            {
                cMVs.Add(new()
                {
                    Date = DateOnly.FromDateTime(item.AclSampleDate),
                    Result = item.AclMcnCode,
                    ResultDescr = item.AclResult
                });
            }

            foreach (var item in patientIHLs)
            {
                iHLs.Add(new()
                {
                    Date = DateOnly.FromDateTime(item.AclSampleDate),
                    Result = item.AclResult
                });
            }

            var drugTakeDate = _context.TblPatientPrescrMs.Where(e => e.PatientId == patientId).Max(e => e.GiveDate);
            if (drugTakeDate.HasValue)
            {
                var dateDif = drugTakeDate.Value.DayNumber - DateOnly.FromDateTime(DateTime.Now).DayNumber;

                foreach (var item in _context.TblPatientPrescrMs.Where(e => e.PatientId == patientId && e.GiveDate == drugTakeDate.Value).ToList())
                {
                    var remainsPills = item.GivePackNum * 30 - dateDif;
                    var remainsPack = remainsPills / 30;

                    drugRemains.Add(new()
                    {
                        TakeDrugDate = drugTakeDate.Value,
                        DrugName = _context.TblMedicines.FirstOrDefault(e => e.MedicineId == item.GiveMedId)?.MedicineLong,
                        DrugCount = $"упак.: {remainsPack} - таб.: {remainsPills}"
                    });
                }
            }

            PatientCardDiagnostics patientCardDiagnostics = new();

            patientCardDiagnostics.PatientId = patient.PatientId;
            patientCardDiagnostics.PatientFio = patient.FamilyName + " " + patient.FirstName + " " + patient.ThirdName;
            patientCardDiagnostics.ImStats = imStats.OrderBy(e => e.Date).ToList();
            patientCardDiagnostics.ImStatCD348s = imStatCD348s.OrderBy(e => e.Date).ToList();
            patientCardDiagnostics.VirusLoads = virusLoads.OrderBy(e => e.Date).ToList();
            patientCardDiagnostics.VirusLoadsQuals = virusLoadsQuals.OrderBy(e => e.Date).ToList();
            patientCardDiagnostics.CMVs = cMVs.OrderBy(e => e.Date).ToList();
            patientCardDiagnostics.IHLs = iHLs.OrderBy(e => e.Date).ToList();
            patientCardDiagnostics.DrugRemains = drugRemains;

            patientCardDiagnostics.IsNonResident = _context.TblRegions.FirstOrDefault(e => e.RegionId == patient.RegionId)?.RegtypeId == 2;

            return Ok(patientCardDiagnostics);
        }
    }
}
