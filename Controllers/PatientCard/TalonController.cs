using HIVBackend.Data;
using HIVBackend.Models.DBModuls;
using HIVBackend.Models.FormModels;
using HIVBackend.Models.OutputModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace HIVBackend.Controllers.PatientCard
{
    [Route("api/[controller]")]
    [ApiController]
    public class TalonController : ControllerBase
    {
        private readonly HivContext _context;
        public TalonController(HivContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Authorize(Roles = "User")]
        public IActionResult Get(int patientId, string regDate, string regCab)
        {
            Talon talon = new();
            int regCabId = _context.TblCabinets.First(e => e.CabinetLong == regCab).CabinetId;

            TblPatientRegistryTalon? patientTalon = _context.TblPatientRegistryTalons.FirstOrDefault(e => e.PatientId == patientId
                                                                                                    && e.RegCabinetId == regCabId
                                                                                                    && e.RegDate == DateOnly.Parse(regDate));

            if (patientTalon != null)
            {
                talon.TalonNum = patientTalon.TalonNum;
                talon.Field12 = patientTalon.TalonField12Phone;
                talon.Field13 = _context.TblTalonListOfValues.FirstOrDefault(e => e.ValueId == patientTalon.TalonField13)?.ValueDescr;
                talon.Field14 = _context.TblTalonListOfValues.FirstOrDefault(e => e.ValueId == patientTalon.TalonField14)?.ValueDescr;
                talon.Field21 = _context.TblTalonListOfValues.FirstOrDefault(e => e.ValueId == patientTalon.TalonField21)?.ValueDescr;
                talon.Field22 = _context.TblTalonListOfValues.FirstOrDefault(e => e.ValueId == patientTalon.TalonField22)?.ValueDescr;
                talon.Field24 = _context.TblTalonListOfValues.FirstOrDefault(e => e.ValueId == patientTalon.TalonField24)?.ValueDescr;
                talon.Field25 = _context.TblTalonListOfValues.FirstOrDefault(e => e.ValueId == patientTalon.TalonField25)?.ValueDescr;
                talon.Field35 = _context.TblTalonListOfValues.FirstOrDefault(e => e.ValueId == patientTalon.TalonField35)?.ValueDescr;
                talon.Field36 = _context.TblTalonListOfValues.FirstOrDefault(e => e.ValueId == patientTalon.TalonField36)?.ValueDescr;
            }
            else
            {
                talon.TalonNum = _context.TblPatientRegistryTalons.Max(e => e.TalonNum) + 1;
            }

            talon.List13 = _context.TblTalonListOfValues.Where(e => e.TalonField == 13).Select(e => e.ValueDescr).ToList();
            talon.List14 = _context.TblTalonListOfValues.Where(e => e.TalonField == 14).Select(e => e.ValueDescr).ToList();
            talon.List21 = _context.TblTalonListOfValues.Where(e => e.TalonField == 21).Select(e => e.ValueDescr).ToList();
            talon.List22 = _context.TblTalonListOfValues.Where(e => e.TalonField == 22).Select(e => e.ValueDescr).ToList();
            talon.List24 = _context.TblTalonListOfValues.Where(e => e.TalonField == 24).Select(e => e.ValueDescr).ToList();
            talon.List25 = _context.TblTalonListOfValues.Where(e => e.TalonField == 25).Select(e => e.ValueDescr).ToList();
            talon.List35 = _context.TblTalonListOfValues.Where(e => e.TalonField == 35).Select(e => e.ValueDescr).ToList();
            talon.List36 = _context.TblTalonListOfValues.Where(e => e.TalonField == 36).Select(e => e.ValueDescr).ToList();

            return Ok(talon);
        }

        [HttpPost, Route("CreateTalon")]
        [Authorize(Roles = "User")]
        public IActionResult CreateTalon(TalonIn talon)
        {
            int regCabId = _context.TblCabinets.First(e => e.CabinetLong == talon.RegCab).CabinetId;
            TblPatientRegistryTalon? patientTalon = _context.TblPatientRegistryTalons.FirstOrDefault(e => e.PatientId == talon.PatientId
                                                                                                    && e.RegCabinetId == regCabId
                                                                                                    && e.RegDate == DateOnly.Parse(talon.RegDate));
            if (patientTalon != null)
            {
                patientTalon.TalonField01 = talon.Field01 != null && talon.Field01?.Length != 0 ? DateOnly.Parse(talon.Field01) : null;
                _context.Entry(patientTalon).Property(e => e.TalonField01).IsModified = true;
                patientTalon.TalonField12Phone = talon.Field12;
                _context.Entry(patientTalon).Property(e => e.TalonField12Phone).IsModified = true;
                patientTalon.TalonField13 = _context.TblTalonListOfValues.FirstOrDefault(e => e.ValueDescr == talon.Field13)?.ValueId;
                _context.Entry(patientTalon).Property(e => e.TalonField13).IsModified = true;
                patientTalon.TalonField14 = _context.TblTalonListOfValues.FirstOrDefault(e => e.ValueDescr == talon.Field14)?.ValueId;
                _context.Entry(patientTalon).Property(e => e.TalonField14).IsModified = true;
                patientTalon.TalonField21 = _context.TblTalonListOfValues.FirstOrDefault(e => e.ValueDescr == talon.Field21)?.ValueId;
                _context.Entry(patientTalon).Property(e => e.TalonField21).IsModified = true;
                patientTalon.TalonField22 = _context.TblTalonListOfValues.FirstOrDefault(e => e.ValueDescr == talon.Field22)?.ValueId;
                _context.Entry(patientTalon).Property(e => e.TalonField22).IsModified = true;
                patientTalon.TalonField24 = _context.TblTalonListOfValues.FirstOrDefault(e => e.ValueDescr == talon.Field24)?.ValueId;
                _context.Entry(patientTalon).Property(e => e.TalonField24).IsModified = true;
                patientTalon.TalonField25 = _context.TblTalonListOfValues.FirstOrDefault(e => e.ValueDescr == talon.Field25)?.ValueId;
                _context.Entry(patientTalon).Property(e => e.TalonField25).IsModified = true;
                patientTalon.TalonField35 = _context.TblTalonListOfValues.FirstOrDefault(e => e.ValueDescr == talon.Field35)?.ValueId;
                _context.Entry(patientTalon).Property(e => e.TalonField35).IsModified = true;
                patientTalon.TalonField36 = _context.TblTalonListOfValues.FirstOrDefault(e => e.ValueDescr == talon.Field36)?.ValueId;
                _context.Entry(patientTalon).Property(e => e.TalonField36).IsModified = true;
                _context.SaveChanges();
                return Ok();
            }

            TblPatientRegistryTalon item = new()
            {
                PatientId = talon.PatientId,
                RegDate = DateOnly.Parse(talon.RegDate),
                RegCabinetId = _context.TblCabinets.First(e => e.CabinetLong == talon.RegCab).CabinetId,
                TalonNum = talon.TalonNum,
                TalonField01 = talon.Field01 != null && talon.Field01?.Length != 0 ? DateOnly.Parse(talon.Field01) : null,
                TalonField12Phone = talon.Field12,
                TalonField13 = _context.TblTalonListOfValues.FirstOrDefault(e => e.ValueDescr == talon.Field13)?.TalonField,
                TalonField14 = _context.TblTalonListOfValues.FirstOrDefault(e => e.ValueDescr == talon.Field14)?.TalonField,
                TalonField21 = _context.TblTalonListOfValues.FirstOrDefault(e => e.ValueDescr == talon.Field21)?.TalonField,
                TalonField22 = _context.TblTalonListOfValues.FirstOrDefault(e => e.ValueDescr == talon.Field22)?.TalonField,
                TalonField24 = _context.TblTalonListOfValues.FirstOrDefault(e => e.ValueDescr == talon.Field24)?.TalonField,
                TalonField25 = _context.TblTalonListOfValues.FirstOrDefault(e => e.ValueDescr == talon.Field25)?.TalonField,
                TalonField35 = _context.TblTalonListOfValues.FirstOrDefault(e => e.ValueDescr == talon.Field35)?.TalonField,
                TalonField36 = _context.TblTalonListOfValues.FirstOrDefault(e => e.ValueDescr == talon.Field36)?.TalonField
            };

            _context.TblPatientRegistryTalons.Attach(item);
            _context.TblPatientRegistryTalons.Add(item);
            _context.SaveChanges();
            return Ok();
        }
    }
}