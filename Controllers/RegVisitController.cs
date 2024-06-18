using HIVBackend.Data;
using HIVBackend.Models.DBModuls;
using HIVBackend.Models.FormModels;
using HIVBackend.Models.OutputModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HIVBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegVisitController : ControllerBase
    {

        private readonly HivContext _context;
        public RegVisitController(HivContext context)
        {
            _context = context;
        }

        [HttpGet, Route("GetForm")]
        [Authorize(Roles = "User")]
        public IActionResult GetForm()
        {
            RegVisit outModel = new();
            outModel.Doctors = _context.TblDoctors.Where(e => e.DoctorLong != null).Select(e => e.DoctorLong)?.ToList();
            outModel.Cabs = _context.TblCabinets.Where(e => e.CabinetLong != null).Select(e => e.CabinetShort)?.ToList();

            return Ok(outModel);
        }

        [HttpPost, Route("GetUnregDate")]
        [Authorize(Roles = "User")]
        public IActionResult GetUnregDate(RegVisitGetUnregDate form)
        {
            DateTime startDate = DateTime.Parse(form.StartDate),
                    endDate = DateTime.Parse(form.EndDate);

            if (startDate > endDate)
                return BadRequest("Некорректный диапазон дат");

            int docId = _context.TblDoctors.Where(e => e.DoctorLong == form.DocName).FirstOrDefault().DoctorId,
                cabId = _context.TblCabinets.Where(e => e.CabinetLong == form.CabName).FirstOrDefault().CabinetId;

            RegVisitCalendar outModel = new();

            List<RegCalendar> calendars = new();
            DateTime currentDate = startDate;

            while (currentDate <= endDate)
            {
                int countRecord = _context.TblPatientRegistries.Where(e => e.RegDoctorId == docId && e.RegDate == DateOnly.FromDateTime(currentDate)).Count();
                string dayOfWeek = currentDate.DayOfWeek.ToString();
                bool isActive = dayOfWeek != "Sunday";

                calendars.Add(new RegCalendar
                {
                    Date = currentDate,
                    IsActive = isActive,
                    DayOfWeek = dayOfWeek,
                    CuontRecord = countRecord
                });
                currentDate = currentDate.AddDays(1);
            }

            outModel.Calendars = calendars;
            outModel.DocId = docId;
            outModel.CabId = cabId;
            outModel.PatientId = form.PatientId;

            return Ok(outModel);
        }

        [HttpPost, Route("GetUnregTime")]
        [Authorize(Roles = "User")]
        public IActionResult GetUnregTime(RegVisitGetUnregTime form)
        {
            DateTime date = DateTime.Parse(form.Date);

            RegVisitTime outModel = new();
            List<RegTime> regTimes = new();

            var regTime = _context.TblRegTimes.OrderBy(e => e.RegTimeId).ToList();

            foreach (var item in regTime)
            {
                int countRecord = _context.TblPatientRegistries.Where(e => e.RegDoctorId == form.DocId && e.RegDate == DateOnly.FromDateTime(date) && e.RegTimeId == item.RegTimeId).Count();
                bool isActive = countRecord < 11;

                regTimes.Add(new RegTime
                {
                    TimeName = item.RegTimeLong,
                    IsActive = isActive,
                    CuontRecord = countRecord
                });
            }

            outModel.PatientId = form.PatientId;
            outModel.DocId = form.DocId;
            outModel.CabId = form.CabId;
            outModel.Date = date;
            outModel.RegTimes = regTimes;

            return Ok(outModel);
        }

        [HttpPost, Route("SetVisit")]
        [Authorize(Roles = "User")]
        public IActionResult SetVisit(SetVisit form)
        {
            TblPatientRegistry registry = new()
            {
                RegDate = DateOnly.FromDateTime(form.Date),
                RegCabinetId = form.CabId,
                PatientId = form.PatientId,
                RegTimeId = _context.TblRegTimes.Where(e => e.RegTimeLong == form.TimeName).First().RegTimeId,
                RegDoctorId = form.DocId
            };

            _context.TblPatientRegistries.Add(registry);
            _context.SaveChanges();

            return Ok();
        }
    }
}
