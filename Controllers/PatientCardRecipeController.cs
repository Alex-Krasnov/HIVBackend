using HIVBackend.Data;
using HIVBackend.Models.DBModuls;
using HIVBackend.Models.FormModels;
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
    public class PatientCardRecipeController : ControllerBase
    {
        private readonly HivContext _context;
        public PatientCardRecipeController(HivContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Authorize(Roles = "User")]
        public IActionResult Get(int patientId)
        {
            List<FrmRecipe> recipe = new();

            TblPatientCard patient = _context.TblPatientCards.Where(e => e.PatientId == patientId && e.IsActive == true).ToList().FirstOrDefault();
            if (patient is null)
                return BadRequest("Пациент не найден");

            List<TblPatientPrescrM> patientRecipe = _context.TblPatientPrescrMs.Where(e => e.PatientId == patientId).ToList();

            foreach(var item in patientRecipe)
            {
                recipe.Add(new()
                {
                    Ser = item.PrescrSer,
                    Num = item.PrescrNum,
                    PrescrDate = item.PrescrDate,
                    Doctor = _context.TblDoctors.FirstOrDefault(e => e.DoctorId == item.DoctorId)?.DoctorLong,
                    Medicine = _context.TblMedicines.FirstOrDefault(e => e.MedicineId == item.MedicineId)?.MedicineLong,
                    PackNum = item.PackNumber?.ToString(),
                    FinSource = _context.TblFinSources.FirstOrDefault(e => e.FinSourceId == item.FinSourceId)?.FinSourceLong,
                    GiveDate = item.GiveDate,
                    GiveDateCheck = item.GiveDateCheck1,
                    MedicineGive = _context.TblMedicines.FirstOrDefault(e => e.MedicineId == item.GiveMedId)?.MedicineLong,
                    PackNumGive = item.GivePackNum?.ToString()
                });
            }

            PatientCardRecipe patientCardRecipe = new();

            patientCardRecipe.PatientId = patient.PatientId;
            patientCardRecipe.PatientFio = patient.FamilyName + " " + patient.FirstName + " " + patient.ThirdName;
            patientCardRecipe.ListDoctor = _context.TblDoctors.Select(e => e.DoctorLong).ToList();
            patientCardRecipe.ListMedicine = _context.TblMedicines.Select(e => e.MedicineLong).ToList();
            patientCardRecipe.ListFinSource = _context.TblFinSources.Select(e => e.FinSourceLong).ToList();
            patientCardRecipe.Recipes = recipe.OrderBy(e => e.PrescrDate).ToList();

            return Ok(patientCardRecipe);
        }

        [HttpDelete, Route("DelRecipe")]
        [Authorize(Roles = "User")]
        public IActionResult DelRecipe(int patientId, string ser, string num)
        {
            TblPatientPrescrM item = new()
            {
                PatientId = patientId,
                PrescrSer = ser,
                PrescrNum = num
            };

            _context.TblPatientPrescrMs.Attach(item);
            _context.TblPatientPrescrMs.Remove(item);
            _context.SaveChanges();
            return Ok();
        }

        [HttpPost, Route("CreateRecipe")]
        [Authorize(Roles = "User")]
        public IActionResult CreateRecipe(Recipe recipe)
        {
            TblPatientPrescrM item = new()
            {
                PatientId = recipe.PatientId,
                PrescrSer = recipe.Ser,
                PrescrNum = recipe.Num,
                PrescrDate = recipe.PrescrDate != null && recipe.PrescrDate?.Length != 0 ? DateOnly.Parse(recipe.PrescrDate) : null,
                DoctorId = _context.TblDoctors.FirstOrDefault(e => e.DoctorLong == recipe.Doctor)?.DoctorId,
                MedicineId = _context.TblMedicines.FirstOrDefault(e => e.MedicineLong == recipe.Medicine)?.MedicineId,
                PackNumber = recipe.PackNum,
                FinSourceId = _context.TblFinSources.FirstOrDefault(e => e.FinSourceLong == recipe.FinSource)?.FinSourceId,
                GiveDate = recipe.GiveDate != null && recipe.GiveDate?.Length != 0 ? DateOnly.Parse(recipe.GiveDate) : null,
                GiveDateCheck1 = recipe.GiveDateCheck,
                GiveMedId = _context.TblMedicines.FirstOrDefault(e => e.MedicineLong == recipe.MedicineGive)?.MedicineId,
                GivePackNum = recipe.PackNumGive
            };

            _context.TblPatientPrescrMs.Attach(item);
            _context.TblPatientPrescrMs.Add(item);
            _context.SaveChanges();
            return Ok();
        }

        [HttpPost, Route("UpdateRecipe")]
        [Authorize(Roles = "User")]
        public IActionResult UpdateRecipe(Recipe recipe)
        {
            TblPatientPrescrM item = new()
            {
                PatientId = recipe.PatientId,
                PrescrSer = recipe.SerOld,
                PrescrNum = recipe.NumOld
            };
            _context.TblPatientPrescrMs.Attach(item);

            if (recipe.Ser == recipe.SerOld && recipe.Num == recipe.NumOld)
            {
                item.PrescrDate = recipe.PrescrDate != null && recipe.PrescrDate?.Length != 0 ? DateOnly.Parse(recipe.PrescrDate) : null;
                _context.Entry(item).Property(e => e.PrescrDate).IsModified = true;
                item.DoctorId = _context.TblDoctors.FirstOrDefault(e => e.DoctorLong == recipe.Doctor)?.DoctorId;
                _context.Entry(item).Property(e => e.DoctorId).IsModified = true;
                item.MedicineId = _context.TblMedicines.FirstOrDefault(e => e.MedicineLong == recipe.Medicine)?.MedicineId;
                _context.Entry(item).Property(e => e.MedicineId).IsModified = true;
                item.PackNumber = recipe.PackNum;
                _context.Entry(item).Property(e => e.PackNumber).IsModified = true;
                item.FinSourceId = _context.TblFinSources.FirstOrDefault(e => e.FinSourceLong == recipe.FinSource)?.FinSourceId;
                _context.Entry(item).Property(e => e.FinSourceId).IsModified = true;
                item.GiveDate = recipe.GiveDate != null && recipe.GiveDate?.Length != 0 ? DateOnly.Parse(recipe.GiveDate) : null;
                _context.Entry(item).Property(e => e.GiveDate).IsModified = true;
                item.GiveDateCheck1 = recipe.GiveDateCheck;
                _context.Entry(item).Property(e => e.GiveDateCheck1).IsModified = true;
                item.GiveMedId = _context.TblMedicines.FirstOrDefault(e => e.MedicineLong == recipe.MedicineGive)?.MedicineId;
                _context.Entry(item).Property(e => e.GiveMedId).IsModified = true;
                item.GivePackNum = recipe.PackNumGive;
                _context.Entry(item).Property(e => e.GivePackNum).IsModified = true;

                _context.SaveChanges();
                return Ok();
            }

            _context.TblPatientPrescrMs.Remove(item);
            _context.SaveChanges();
            item = new()
            {
                PatientId = recipe.PatientId,
                PrescrSer = recipe.Ser,
                PrescrNum = recipe.Num,
                PrescrDate = recipe.PrescrDate != null && recipe.PrescrDate?.Length != 0 ? DateOnly.Parse(recipe.PrescrDate) : null,
                DoctorId = _context.TblDoctors.FirstOrDefault(e => e.DoctorLong == recipe.Doctor)?.DoctorId,
                MedicineId = _context.TblMedicines.FirstOrDefault(e => e.MedicineLong == recipe.Medicine)?.MedicineId,
                PackNumber = recipe.PackNum,
                FinSourceId = _context.TblFinSources.FirstOrDefault(e => e.FinSourceLong == recipe.FinSource)?.FinSourceId,
                GiveDate = recipe.GiveDate != null && recipe.GiveDate?.Length != 0 ? DateOnly.Parse(recipe.GiveDate) : null,
                GiveDateCheck1 = recipe.GiveDateCheck,
                GiveMedId = _context.TblMedicines.FirstOrDefault(e => e.MedicineLong == recipe.MedicineGive)?.MedicineId,
                GivePackNum = recipe.PackNumGive
            };
            _context.TblPatientPrescrMs.Add(item);
            _context.SaveChanges();
            return Ok();
        }
    }
}
