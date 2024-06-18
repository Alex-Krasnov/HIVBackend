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
    public class PatientCardChildController : ControllerBase
    {
        private readonly HivContext _context;
        public PatientCardChildController(HivContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Authorize(Roles = "User")]
        public IActionResult Get(int patientId)
        {

            TblPatientCard? patient = _context.TblPatientCards.FirstOrDefault(e => e.PatientId == patientId && e.IsActive == true);
            if (patient is null)
                return BadRequest("Пациент не найден");

            string? mFio = null, fFio = null;

            if (patient.MotherPatientId != null)
            {
                TblPatientCard m = _context.TblPatientCards.First(e => e.PatientId == patient.MotherPatientId && e.IsActive == true);
                mFio = m.FamilyName + " " + m.FirstName + " " + m.ThirdName;
            }

            if (patient.FatherPatientId != null)
            {
                TblPatientCard f = _context.TblPatientCards.First(e => e.PatientId == patient.FatherPatientId && e.IsActive == true);
                fFio = f.FamilyName + " " + f.FirstName + " " + f.ThirdName;
            }

            PatientCardChild patientCardChild = new();

            patientCardChild.PatientId = patient.PatientId;
            patientCardChild.PatientFio = patient.FamilyName + " " + patient.FirstName + " " + patient.ThirdName;
            patientCardChild.FamilyType = _context.TblFamilyTypes.FirstOrDefault(e => e.FamilyTypeId == patient.FamilyTypeId)?.FamilyTypeLong;
            patientCardChild.MId = patient.MotherPatientId;
            patientCardChild.MFio = mFio;
            patientCardChild.FId = patient.FatherPatientId;
            patientCardChild.FFio = fFio;
            patientCardChild.FirstCheckDate = patient.CheckFirstDate;
            patientCardChild.ChildPlace = _context.TblChildPlaces.FirstOrDefault(e => e.ChildPlaceId == patient.ChildPlaceId)?.ChildPlaceLong;
            patientCardChild.BreastMonth = patient.BreastMonthNo;
            patientCardChild.ChildPhp = _context.TblChildPhps.FirstOrDefault(e => e.ChildPhpId == patient.ChildPhpId)?.ChildPhpLong;
            patientCardChild.MaterHome = _context.TblMaterHomes.FirstOrDefault(e => e.MaterhomeId == patient.MaterhomeId)?.MaterhomeLong;
            patientCardChild.ChildDescr = patient.ChildDescr;
            patientCardChild.Growth = patient.Growth;
            patientCardChild.Weight = patient.Weight;
            patientCardChild.Forma309 = _context.TblListYns.FirstOrDefault(e => e.IdYN == patient.Forma309)?.YNName;
            patientCardChild.LastCareDate = patient.LetterCareDate;
            patientCardChild.CommunicationParentDate = patient.CommunicationParentDate;
            patientCardChild.CallingDistrictSpecDate = patient.CallingDistrictSpecDate;
            patientCardChild.RefusalPhp = patient.RefusalPhp;
            patientCardChild.RefusalResearch = patient.RefusalResearch;
            patientCardChild.RefusalTherapy = patient.RefusalTherapy;

            patientCardChild.ListFamilyType = _context.TblFamilyTypes.Select(e => e.FamilyTypeLong).ToList();
            patientCardChild.ListChildPhp = _context.TblChildPhps.Select(e => e.ChildPhpLong).ToList();
            patientCardChild.ListChildPlace = _context.TblChildPlaces.Select(e => e.ChildPlaceLong).ToList();
            patientCardChild.ListMaterHome = _context.TblMaterHomes.Select(e => e.MaterhomeLong).ToList();
            patientCardChild.ListForm309 = _context.TblListYns.Select(e => e.YNName).ToList();
            return Ok(patientCardChild);
        }

        [HttpPost, Route("UpdatePatient")]
        [Authorize(Roles = "User")]
        public IActionResult UpdatePatient(PatientCardChildForm patient)
        {
            TblPatientCard item = _context.TblPatientCards.First(e => e.PatientId == patient.PatientId);
            _context.TblPatientCards.Attach(item);

            item.FamilyTypeId = _context.TblFamilyTypes.FirstOrDefault(e => e.FamilyTypeLong == patient.FamilyType)?.FamilyTypeId;
            item.MotherPatientId = patient.MId;
            item.FatherPatientId = patient.FId;
            item.CheckFirstDate = patient.FirstCheckDate != null && patient.FirstCheckDate?.Length != 0 ? DateOnly.Parse(patient.FirstCheckDate) : null;
            item.ChildPlaceId = _context.TblChildPlaces.FirstOrDefault(e => e.ChildPlaceLong == patient.ChildPlace)?.ChildPlaceId;
            item.BreastMonthNo = patient.BreastMonth;
            item.ChildPhpId = _context.TblChildPhps.FirstOrDefault(e => e.ChildPhpLong == patient.ChildPhp)?.ChildPhpId;
            item.MaterhomeId = _context.TblMaterHomes.FirstOrDefault(e => e.MaterhomeLong == patient.MaterHome)?.MaterhomeId;
            item.ChildDescr = patient.ChildDescr;
            item.Growth = patient.Growth;
            item.Weight = patient.Weight;
            item.Forma309 = _context.TblListYns.FirstOrDefault(e => e.YNName == patient.Forma309)?.IdYN;
            item.LetterCareDate = patient.LastCareDate != null && patient.LastCareDate?.Length != 0 ? DateOnly.Parse(patient.LastCareDate) : null;
            item.CommunicationParentDate = patient.CommunicationParentDate != null && patient.CommunicationParentDate?.Length != 0 ? DateOnly.Parse(patient.CommunicationParentDate) : null;
            item.CallingDistrictSpecDate = patient.CallingDistrictSpecDate != null && patient.CallingDistrictSpecDate?.Length != 0 ? DateOnly.Parse(patient.CallingDistrictSpecDate) : null;
            item.RefusalPhp = patient.RefusalPhp;
            item.RefusalResearch = patient.RefusalResearch;
            item.RefusalTherapy = patient.RefusalTherapy;


            _context.Entry(item).Property(e => e.FamilyTypeId).IsModified = true;
            _context.Entry(item).Property(e => e.MotherPatientId).IsModified = true;
            _context.Entry(item).Property(e => e.FatherPatientId).IsModified = true;
            _context.Entry(item).Property(e => e.CheckFirstDate).IsModified = true;
            _context.Entry(item).Property(e => e.BreastMonthNo).IsModified = true;
            _context.Entry(item).Property(e => e.ChildPhpId).IsModified = true;
            _context.Entry(item).Property(e => e.MaterhomeId).IsModified = true;
            _context.Entry(item).Property(e => e.ChildDescr).IsModified = true;
            _context.Entry(item).Property(e => e.Growth).IsModified = true;
            _context.Entry(item).Property(e => e.Weight).IsModified = true;
            _context.Entry(item).Property(e => e.Forma309).IsModified = true;
            _context.Entry(item).Property(e => e.LetterCareDate).IsModified = true;
            _context.Entry(item).Property(e => e.CommunicationParentDate).IsModified = true;
            _context.Entry(item).Property(e => e.CallingDistrictSpecDate).IsModified = true;
            _context.Entry(item).Property(e => e.RefusalPhp).IsModified = true;
            _context.Entry(item).Property(e => e.RefusalResearch).IsModified = true;
            _context.Entry(item).Property(e => e.RefusalTherapy).IsModified = true;

            _context.SaveChanges();
            return Ok();
        }
    }
}
