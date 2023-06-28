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
    public class PassportController : ControllerBase
    {

        private readonly HivContext _context;
        public PassportController(HivContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Authorize(Roles = "User")]
        public IActionResult Get(int patientId)
        {
            TblPatientCard patient = _context.TblPatientCards.Where(e => e.PatientId == patientId && e.IsActive == true).ToList().FirstOrDefault();
            if (patient is null)
                return BadRequest("Пациент не найден");

            Passport pas = new();

            pas.PatientId = patient.PatientId;
            pas.Region = _context.TblRegions.FirstOrDefault(e => e.RegionId == patient.RegionId).RegionLong;
            pas.CityName = patient.CityName;
            pas.LocationName = patient.LocationName;
            pas.Index = patient.AddrInd;
            pas.AddrStreat = patient.AddrStreet;
            pas.AddrHouse = patient.AddrHouse;
            pas.AddrExt = patient.AddrExt;
            pas.AddrFlat = patient.AddrFlat;
            pas.RegionFact = _context.TblRegions.FirstOrDefault(e => e.RegionId == patient.FactRegionId).RegionLong;
            pas.CityNameFact = patient.FactCityName;
            pas.LocationNameFact = patient.FactLocationName;
            pas.IndexFact = patient.FactAddrInd;
            pas.AddrStreatFact = patient.FactAddrStreet;
            pas.AddrExtFact = patient.FactAddrExt;
            pas.AddrHouseFact = patient.FactAddrHouse;
            pas.AddrFlatFact = patient.FactAddrFlat;
            pas.DtRegBeg = patient.DtRegBeg;
            pas.DtRegEnd = patient.DtRegEnd;
            pas.PasSer = patient.PasSer;
            pas.PasNum = patient.PasNum;
            pas.PasWhen = patient.PasWhen;
            pas.PasWhom = patient.PasWhom;
            pas.OmsNum = patient.OmsNum;
            pas.OmsSer = patient.OmsSer;
            pas.OmsWhen = patient.OmsWhen;

            pas.ListRegion = _context.TblRegions.Select(e => e.RegionLong).ToList();

            return Ok(pas);
        }

        [HttpPost, Route("Update")]
        [Authorize(Roles = "User")]
        public IActionResult Update(PassportForm pas)
        {
            TblPatientCard item = new()
            {
                PatientId = pas.PatientId,
            };
            _context.TblPatientCards.Attach(item);

            item.RegionId = _context.TblRegions.FirstOrDefault(e => e.RegionLong == pas.Region)?.RegionId;
            _context.Entry(item).Property(e => e.RegionId).IsModified = true;
            item.CityName = pas.CityName;
            _context.Entry(item).Property(e => e.CityName).IsModified = true;
            item.LocationName = pas.LocationName;
            _context.Entry(item).Property(e => e.LocationName).IsModified = true;
            item.AddrInd = pas.Index;
            _context.Entry(item).Property(e => e.AddrInd).IsModified = true;
            item.AddrStreet = pas.AddrStreat;
            _context.Entry(item).Property(e => e.AddrStreet).IsModified = true;
            item.AddrHouse = pas.AddrHouse;
            _context.Entry(item).Property(e => e.AddrHouse).IsModified = true;
            item.AddrHouse = pas.AddrHouse;
            _context.Entry(item).Property(e => e.AddrHouse).IsModified = true;
            item.AddrExt = pas.AddrExt;
            _context.Entry(item).Property(e => e.AddrExt).IsModified = true;
            item.AddrFlat = pas.AddrFlat;
            _context.Entry(item).Property(e => e.AddrFlat).IsModified = true;
            item.FactRegionId = _context.TblRegions.FirstOrDefault(e => e.RegionLong == pas.RegionFact)?.RegionId;
            _context.Entry(item).Property(e => e.FactRegionId).IsModified = true;
            item.FactCityName = pas.CityNameFact;
            _context.Entry(item).Property(e => e.FactCityName).IsModified = true;
            item.FactLocationName = pas.LocationNameFact;
            _context.Entry(item).Property(e => e.FactLocationName).IsModified = true;
            item.FactAddrInd = pas.IndexFact;
            _context.Entry(item).Property(e => e.FactAddrInd).IsModified = true;
            item.FactAddrStreet = pas.AddrStreatFact;
            _context.Entry(item).Property(e => e.FactAddrStreet).IsModified = true;
            item.FactAddrExt = pas.AddrExtFact;
            _context.Entry(item).Property(e => e.FactAddrExt).IsModified = true;
            item.FactAddrHouse = pas.AddrHouseFact;
            _context.Entry(item).Property(e => e.FactAddrHouse).IsModified = true;
            item.FactAddrFlat = pas.AddrFlatFact;
            _context.Entry(item).Property(e => e.FactAddrFlat).IsModified = true;
            item.DtRegBeg = pas.DtRegBeg != null && pas.DtRegBeg?.Length != 0 ? DateOnly.Parse(pas.DtRegBeg) : null;
            _context.Entry(item).Property(e => e.DtRegBeg).IsModified = true;
            item.DtRegEnd = pas.DtRegEnd != null && pas.DtRegEnd?.Length != 0 ? DateOnly.Parse(pas.DtRegEnd) : null;
            _context.Entry(item).Property(e => e.DtRegEnd).IsModified = true;
            item.PasSer = pas.PasSer;
            _context.Entry(item).Property(e => e.PasSer).IsModified = true;
            item.PasNum = pas.PasNum;
            _context.Entry(item).Property(e => e.PasNum).IsModified = true;
            item.PasWhen = pas.PasWhen != null && pas.PasWhen?.Length != 0 ? DateOnly.Parse(pas.PasWhen) : null;
            _context.Entry(item).Property(e => e.PasNum).IsModified = true;
            item.PasWhom = pas.PasWhom;
            _context.Entry(item).Property(e => e.PasWhom).IsModified = true;
            item.OmsSer = pas.OmsSer;
            _context.Entry(item).Property(e => e.OmsSer).IsModified = true;
            item.OmsNum = pas.OmsNum;
            _context.Entry(item).Property(e => e.OmsNum).IsModified = true;
            item.OmsWhen = pas.OmsWhen != null && pas.OmsWhen?.Length != 0 ? DateOnly.Parse(pas.OmsWhen) : null;
            _context.Entry(item).Property(e => e.OmsWhen).IsModified = true;

            _context.SaveChanges();
            return Ok();
        }
    }
}
