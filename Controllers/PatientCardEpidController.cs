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
    public class PatientCardEpidController : ControllerBase
    {
        private readonly HivContext _context;
        public PatientCardEpidController(HivContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Authorize(Roles = "User")]
        public IActionResult Get(int patientId)
        {
            List<FrmPatientContact> constantContact = new();
            List<FrmPatientContact> randomContact = new();
            List<FrmPatientContact> otherContact = new();
            List<FrmChemsex> chemsex = new();
            List<FrmPav> pavInj = new();
            List<FrmPav> pavNotInj = new();
            List<FrmCovidVac> covidVac = new();
            List<FrmCovid> covid = new();

            TblPatientCard patient = _context.TblPatientCards.Where(e => e.PatientId == patientId && e.IsActive == true).ToList().FirstOrDefault();
            if (patient is null)
                return BadRequest("Пациент не найден");

            List<TblPatientContact>? patientConstantContact = _context.TblPatientContacts.Where(e => e.PatientId == patientId && e.ContactType == 1)?.ToList();
            List<TblPatientContact>? patientRandomContact = _context.TblPatientContacts.Where(e => e.PatientId == patientId && e.ContactType == 2)?.ToList();
            List<TblPatientContact>? patientOtherContact = _context.TblPatientContacts.Where(e => e.PatientId == patientId && e.ContactType == 6)?.ToList();
            List<TblPatientContactChemsex>? patientChemsex = _context.TblPatientContactChemsexes.Where(e => e.PatientId == patientId)?.ToList();
            List<TblPatientContactPavInj>? patientPavInj = _context.TblPatientContactPavInjs.Where(e => e.PatientId == patientId)?.ToList();
            List<TblPatientContactPavNotInj>? patientPavNotInj = _context.TblPatientContactPavNotInjs.Where(e => e.PatientId == patientId)?.ToList();
            List<TblCovidVac>? patientCovidVac = _context.TblCovidVacs.Where(e => e.PatientId == patientId)?.ToList();
            List<TblCovid>? patientCovid = _context.TblCovids.Where(e => e.PatientId == patientId)?.ToList();

            foreach (var item in patientConstantContact)
            {
                constantContact.Add(new()
                {
                    ContactId = item.PatientContactId,
                    InfectCourseName = _context.TblInfectCourses.FirstOrDefault(e => e.InfectCourseId == item.InfectCourseId)?.InfectCourseLong,
                    FamilyName = _context.TblPatientCards.FirstOrDefault(e => e.PatientId == item.PatientContactId)?.FamilyName,
                    FirstName = _context.TblPatientCards.FirstOrDefault(e => e.PatientId == item.PatientContactId)?.FirstName,
                    ThirdName = _context.TblPatientCards.FirstOrDefault(e => e.PatientId == item.PatientContactId)?.ThirdName
                });
            }

            foreach (var item in patientRandomContact)
            {
                randomContact.Add(new()
                {
                    ContactId = item.PatientContactId,
                    InfectCourseName = _context.TblInfectCourses.FirstOrDefault(e => e.InfectCourseId == item.InfectCourseId)?.InfectCourseLong,
                    FamilyName = _context.TblPatientCards.FirstOrDefault(e => e.PatientId == item.PatientContactId)?.FamilyName,
                    FirstName = _context.TblPatientCards.FirstOrDefault(e => e.PatientId == item.PatientContactId)?.FirstName,
                    ThirdName = _context.TblPatientCards.FirstOrDefault(e => e.PatientId == item.PatientContactId)?.ThirdName
                });
            }

            foreach (var item in patientOtherContact)
            {
                otherContact.Add(new()
                {
                    ContactId = item.PatientContactId,
                    InfectCourseName = _context.TblInfectCourses.FirstOrDefault(e => e.InfectCourseId == item.InfectCourseId)?.InfectCourseLong,
                    FamilyName = _context.TblPatientCards.FirstOrDefault(e => e.PatientId == item.PatientContactId)?.FamilyName,
                    FirstName = _context.TblPatientCards.FirstOrDefault(e => e.PatientId == item.PatientContactId)?.FirstName,
                    ThirdName = _context.TblPatientCards.FirstOrDefault(e => e.PatientId == item.PatientContactId)?.ThirdName
                });
            }

            foreach (var item in patientChemsex)
            {
                chemsex.Add(new()
                {
                    DrugId= item.DrugId,
                    YnName = _context.TblListYns.FirstOrDefault(e => e.IdYN == item.YNId)?.YNName,
                    DrugName = item.DrugName,
                    ContactTypeName = _context.TblInfectCourses.FirstOrDefault(e => e.InfectCourseId == item.ContactType)?.InfectCourseLong 
                });
            }

            foreach (var item in patientPavInj)
            {
                pavInj.Add(new()
                {
                    DrugId = item.DrugId,
                    YnName = _context.TblListYns.FirstOrDefault(e => e.IdYN == item.YNId)?.YNName,
                    DrugName = item.DrugName,
                    DateStart = item.DateStart,
                    DateEnd = item.DateEnd
                });
            }

            foreach (var item in patientPavNotInj)
            {
                pavNotInj.Add(new()
                {
                    DrugId = item.DrugId,
                    YnName = _context.TblListYns.FirstOrDefault(e => e.IdYN == item.YNId)?.YNName,
                    DrugName = item.DrugName,
                    DateStart = item.DateStart,
                    DateEnd = item.DateEnd
                });
            }

            foreach (var item in patientCovidVac)
            {
                covidVac.Add(new()
                {
                    VacId= item.VacId,
                    DVac1 = item.DVac1,
                    DVac2 = item.DVac2,
                    VacName = _context.TblListVacs.FirstOrDefault(e => e.VacId == item.VacId)?.VacName
                });
            }

            foreach (var item in patientCovid)
            {
                covid.Add(new()
                {
                    CovidId = item.IdCovid,
                    DPositivRes = item.DPositivResCovid,
                    DNegativeRes = item.DNegativeResCovid,
                    CovidMKB = _context.TblListMkb10Covids.FirstOrDefault(e => e.Mkb10Id == item.CovidMkb10)?.Mkb10LongName
                });
            }

            PatientCardEpid patientCardEpid = new();

            patientCardEpid.PatientId = patient.PatientId;
            patientCardEpid.PatientFio = patient.FamilyName + " " + patient.FirstName + " " + patient.ThirdName;
            patientCardEpid.DtMailReg = patient.DtMailReg;
            patientCardEpid.NumMail = patient.NumMail;
            patientCardEpid.EduName = _context.TblListEducations.FirstOrDefault(e => e.EducationId == patient.EduId)?.EduName;
            patientCardEpid.FamilyStatusName = _context.TblListFamilyStatuses.FirstOrDefault(e => e.FamilyStatusId == patient.FamilyStatusId)?.FammilyStatusName;
            patientCardEpid.EmploymentName = _context.TblListEmloyments.FirstOrDefault(e => e.EmploymentId == patient.EmploymentId)?.EmploymentName;
            patientCardEpid.TransName = _context.TblListTrans.FirstOrDefault(e => e.TransId == patient.TransId)?.TransName;
            patientCardEpid.EpidemCom = patient.EpidemDescr;
            patientCardEpid.TransmitionMechName = _context.TblListTransmisionMeches.FirstOrDefault(e => e.TransmissionMechId == patient.TransmitionMechId)?.TransmisiomMechName;
            patientCardEpid.SituationDetectName = _context.TblListSituationDetects.FirstOrDefault(e => e.SituationDetectId == patient.SituationtDetectId)?.SituationDetectName;
            patientCardEpid.EpidTimeInfectStart = patient.EpidemTimeInfectStart;
            patientCardEpid.EpidTimeInfectEnd = patient.EpidemTimeInfectEnd;
            patientCardEpid.EpidDocName = _context.TblListEpidDoctors.FirstOrDefault(e => e.IdDoctor == patient.EpidDocId)?.DoctorName;

            patientCardEpid.ListTypeContacts = _context.TblInfectCourses.Where(e => e.InfectCourseId == 100 || e.InfectCourseId == 104).Select(e => e.InfectCourseLong)?.ToList();
            patientCardEpid.ListYn = _context.TblListYns.Select(e => e.YNName)?.ToList();
            patientCardEpid.ListEdu = _context.TblListEducations.Select(e => e.EduName)?.ToList();
            patientCardEpid.ListFamilyStatus = _context.TblListFamilyStatuses.Select(e => e.FammilyStatusName)?.ToList();
            patientCardEpid.ListEmloyment = _context.TblListEmloyments.Select(e => e.EmploymentName)?.ToList();
            patientCardEpid.ListTrans = _context.TblListTrans.Select(e => e.TransName)?.ToList();
            patientCardEpid.ListVac = _context.TblListVacs.Select(e => e.VacName)?.ToList();
            patientCardEpid.ListCovidMKB = _context.TblListMkb10Covids.Select(e => e.Mkb10LongName)?.ToList();
            patientCardEpid.ListTransmitionMech = _context.TblListTransmisionMeches.Select(e => e.TransmisiomMechName)?.ToList();
            patientCardEpid.ListSituationDetect = _context.TblListSituationDetects.Select(e => e.SituationDetectName)?.ToList();
            patientCardEpid.ListEpidDoc = _context.TblListEpidDoctors.Select(e => e.DoctorName)?.ToList();

            patientCardEpid.ConstantContact = constantContact;
            patientCardEpid.RandomContact = randomContact;
            patientCardEpid.ConstantContact = otherContact;
            patientCardEpid.Chemsex = chemsex;
            patientCardEpid.PavInj = pavInj;
            patientCardEpid.PavNotInj = pavNotInj;
            patientCardEpid.CovidVac = covidVac;
            patientCardEpid.Covid = covid;

            return Ok(patientCardEpid);
        }

        [HttpDelete, Route("DelContact")]
        [Authorize(Roles = "User")]
        public IActionResult DelContact(int patientId, int contactId)
        {
            TblPatientContact item = new()
            {
                PatientId = patientId,
                PatientContactId = contactId
            };

            _context.TblPatientContacts.Attach(item);
            _context.TblPatientContacts.Remove(item);
            _context.SaveChanges();
            return Ok();
        }

        [HttpPost, Route("CreateContact")]
        [Authorize(Roles = "User")]
        public IActionResult CreateContact(Contact contact)
        {
            TblPatientContact item = new()
            {
                PatientId = contact.PatientId,
                PatientContactId = contact.ContactId,
                ContactType = contact.Type
            };

            _context.TblPatientContacts.Attach(item);
            _context.TblPatientContacts.Add(item);
            _context.SaveChanges();
            return Ok();
        }

        [HttpPost, Route("UpdateContact")]
        [Authorize(Roles = "User")]
        public IActionResult UpdateContact(Contact contact)
        {
            int contactId = contact.ContactId,
                contactIdOld = (int)contact.ContactIdOld;

            TblPatientContact item = new()
            {
                PatientId = contact.PatientId,
                PatientContactId = (int)contact.ContactIdOld
            };
            _context.TblPatientContacts.Attach(item);

            if (contactId == contactIdOld)
            {
                item.InfectCourseId = _context.TblInfectCourses.FirstOrDefault(e => e.InfectCourseLong == contact.InfectCourseName)?.InfectCourseId;
                _context.Entry(item).Property(e => e.InfectCourseId).IsModified = true;
                _context.SaveChanges();
                return Ok();
            }

            _context.TblPatientContacts.Remove(item);
            _context.SaveChanges();
            item = new()
            {
                PatientId = contact.PatientId,
                PatientContactId = contact.ContactId,
                InfectCourseId = _context.TblInfectCourses.FirstOrDefault(e => e.InfectCourseLong == contact.InfectCourseName)?.InfectCourseId,
                ContactType = (int?)contact.Type
            };
            _context.TblPatientContacts.Add(item);
            _context.SaveChanges();
            return Ok();
        }

        [HttpDelete, Route("DelChemsex")]
        [Authorize(Roles = "User")]
        public IActionResult DelChemsex(int id)
        {
            TblPatientContactChemsex item = _context.TblPatientContactChemsexes.First(e => e.DrugId == id);
                
            //_context.TblPatientContactChemsexes.Attach(item);
            _context.TblPatientContactChemsexes.Remove(item);
            _context.SaveChanges();
            return Ok();
        }

        [HttpPost, Route("CreateChemsex")]
        [Authorize(Roles = "User")]
        public IActionResult CreateChemsex(Chemsex chemsex)
        {
            TblPatientContactChemsex item = new()
            {
                PatientId = chemsex.PatientId,
                YNId = _context.TblListYns.FirstOrDefault(e => e.YNName == chemsex.YnName)?.IdYN,
                DrugName = chemsex.DrugName,
                ContactType = _context.TblInfectCourses.FirstOrDefault(e => e.InfectCourseLong == chemsex.ContactTypeName)?.InfectCourseId
            };

            _context.TblPatientContactChemsexes.Attach(item);
            _context.TblPatientContactChemsexes.Add(item);
            _context.SaveChanges();
            return Ok();
        }

        [HttpPost, Route("UpdateChemsex")]
        [Authorize(Roles = "User")]
        public IActionResult UpdateChemsex(Chemsex chemsex)
        {
            TblPatientContactChemsex item = new()
            {
                DrugId = (int)chemsex.DrugId
            };
            _context.TblPatientContactChemsexes.Attach(item);

            item.DrugName = chemsex.DrugName;
            _context.Entry(item).Property(e => e.DrugName).IsModified = true;
            item.YNId = _context.TblListYns.FirstOrDefault(e => e.YNName == chemsex.YnName)?.IdYN;
            _context.Entry(item).Property(e => e.YNId).IsModified = true;
            item.ContactType = _context.TblInfectCourses.FirstOrDefault(e => e.InfectCourseLong == chemsex.ContactTypeName)?.InfectCourseId;
            _context.Entry(item).Property(e => e.ContactType).IsModified = true;

            _context.SaveChanges();
            return Ok();
        }

        [HttpPost, Route("DelPavInj")]
        [Authorize(Roles = "User")]
        public IActionResult DelPavInj(int id)
        {
            TblPatientContactPavInj item = new()
            {
                DrugId = id
            };

            _context.TblPatientContactPavInjs.Attach(item);
            _context.TblPatientContactPavInjs.Remove(item);
            _context.SaveChanges();
            return Ok();
        }

        [HttpPost, Route("CreatePavInj")]
        [Authorize(Roles = "User")]
        public IActionResult CreatePavInj(Pav pav)
        {
            TblPatientContactPavInj item = new()
            {
                PatientId = pav.PatientId,
                YNId = _context.TblListYns.FirstOrDefault(e => e.YNName == pav.YnName)?.IdYN,
                DrugName = pav.DrugName,
                DateStart = pav.DateStart != null && pav.DateStart?.Length != 0 ? DateOnly.Parse(pav.DateStart) : null,
                DateEnd = pav.DateEnd != null && pav.DateEnd?.Length != 0 ? DateOnly.Parse(pav.DateEnd) : null
            };

            _context.TblPatientContactPavInjs.Attach(item);
            _context.TblPatientContactPavInjs.Add(item);
            _context.SaveChanges();
            return Ok();
        }

        [HttpPost, Route("UpdatePavInj")]
        [Authorize(Roles = "User")]
        public IActionResult UpdatePavInj(Pav pav)
        {
            TblPatientContactPavInj item = new()
            {
                DrugId = (int)pav.DrugId
            };
            _context.TblPatientContactPavInjs.Attach(item);

            item.YNId = _context.TblListYns.FirstOrDefault(e => e.YNName == pav.YnName)?.IdYN;
            _context.Entry(item).Property(e => e.YNId).IsModified = true;
            item.DrugName= pav.DrugName;
            _context.Entry(item).Property(e => e.DrugName).IsModified = true;
            item.DateStart = pav.DateStart != null && pav.DateStart?.Length != 0 ? DateOnly.Parse(pav.DateStart) : null;
            _context.Entry(item).Property(e => e.DateStart).IsModified = true;
            item.DateEnd = pav.DateEnd != null && pav.DateEnd?.Length != 0 ? DateOnly.Parse(pav.DateEnd) : null;
            _context.Entry(item).Property(e => e.DateEnd).IsModified = true;

            _context.SaveChanges();
            return Ok();
        }

        [HttpPost, Route("DelPavNotInj")]
        [Authorize(Roles = "User")]
        public IActionResult DelPavNotInj(int id)
        {
            TblPatientContactPavNotInj item = new()
            {
                DrugId = id
            };

            _context.TblPatientContactPavNotInjs.Attach(item);
            _context.TblPatientContactPavNotInjs.Remove(item);
            _context.SaveChanges();
            return Ok();
        }

        [HttpPost, Route("CreatePavNotInj")]
        [Authorize(Roles = "User")]
        public IActionResult CreatePavNotInj(Pav pav)
        {
            TblPatientContactPavNotInj item = new()
            {
                PatientId = pav.PatientId,
                YNId = _context.TblListYns.FirstOrDefault(e => e.YNName == pav.YnName)?.IdYN,
                DrugName = pav.DrugName,
                DateStart = pav.DateStart != null && pav.DateStart?.Length != 0 ? DateOnly.Parse(pav.DateStart) : null,
                DateEnd = pav.DateEnd != null && pav.DateEnd?.Length != 0 ? DateOnly.Parse(pav.DateEnd) : null
            };

            _context.TblPatientContactPavNotInjs.Attach(item);
            _context.TblPatientContactPavNotInjs.Add(item);
            _context.SaveChanges();
            return Ok();
        }

        [HttpPost, Route("UpdatePavNotInj")]
        [Authorize(Roles = "User")]
        public IActionResult UpdatePavNotInj(Pav pav)
        {
            TblPatientContactPavNotInj item = new()
            {
                DrugId = (int)pav.DrugId
            };
            _context.TblPatientContactPavNotInjs.Attach(item);

            item.YNId = _context.TblListYns.FirstOrDefault(e => e.YNName == pav.YnName)?.IdYN;
            _context.Entry(item).Property(e => e.YNId).IsModified = true;
            item.DrugName = pav.DrugName;
            _context.Entry(item).Property(e => e.DrugName).IsModified = true;
            item.DateStart = pav.DateStart != null && pav.DateStart?.Length != 0 ? DateOnly.Parse(pav.DateStart) : null;
            _context.Entry(item).Property(e => e.DateStart).IsModified = true;
            item.DateEnd = pav.DateEnd != null && pav.DateEnd?.Length != 0 ? DateOnly.Parse(pav.DateEnd) : null;
            _context.Entry(item).Property(e => e.DateEnd).IsModified = true;

            _context.SaveChanges();
            return Ok();
        }

        [HttpDelete, Route("DelCovidVac")]
        [Authorize(Roles = "User")]
        public IActionResult DelCovidVac(int id)
        {
            TblCovidVac item = new()
            {
                VacId= id
            };

            _context.TblCovidVacs.Attach(item);
            _context.TblCovidVacs.Remove(item);
            _context.SaveChanges();
            return Ok();
        }

        [HttpPost, Route("CreateCovidVac")]
        [Authorize(Roles = "User")]
        public IActionResult CreateCovidVac(CovidVac covidVac)
        {
            TblCovidVac item = new()
            {
                DVac1 = covidVac.DVac1 != null && covidVac.DVac1?.Length != 0 ? DateOnly.Parse(covidVac.DVac1) : null,
                DVac2 = covidVac.DVac2 != null && covidVac.DVac2?.Length != 0 ? DateOnly.Parse(covidVac.DVac2) : null,
                VacName = _context.TblListVacs.FirstOrDefault(e => e.VacName == covidVac.VacName)?.VacId,
                PatientId = covidVac.PatientId
            };

            _context.TblCovidVacs.Attach(item);
            _context.TblCovidVacs.Add(item);
            _context.SaveChanges();
            return Ok();
        }

        [HttpPost, Route("UpdateCovidVac")]
        [Authorize(Roles = "User")]
        public IActionResult UpdateCovidVac(CovidVac covidVac)
        {
            TblCovidVac item = new()
            {
                VacId = (int)covidVac.VacId
            };
            _context.TblCovidVacs.Attach(item);

            item.DVac1 = covidVac.DVac1 != null && covidVac.DVac1?.Length != 0 ? DateOnly.Parse(covidVac.DVac1) : null;
            _context.Entry(item).Property(e => e.DVac1).IsModified = true;
            item.DVac2 = covidVac.DVac2 != null && covidVac.DVac2?.Length != 0 ? DateOnly.Parse(covidVac.DVac2) : null;
            _context.Entry(item).Property(e => e.DVac2).IsModified = true;
            item.VacName = _context.TblListVacs.FirstOrDefault(e => e.VacName == covidVac.VacName)?.VacId;
            _context.Entry(item).Property(e => e.VacName).IsModified = true;
            _context.SaveChanges();
            return Ok();
        }

        [HttpPost, Route("CreateCovid")]
        [Authorize(Roles = "User")]
        public IActionResult CreateCovid(Covid covid)
        {
            TblCovid item = new()
            {
                PatientId = covid.PatientId,
                DPositivResCovid = covid.DPositivRes != null && covid.DPositivRes?.Length != 0 ? DateOnly.Parse(covid.DPositivRes) : null,
                DNegativeResCovid = covid.DNegativeRes != null && covid.DNegativeRes?.Length != 0 ? DateOnly.Parse(covid.DNegativeRes) : null,
                CovidMkb10 = _context.TblListMkb10Covids.FirstOrDefault(e => e.Mkb10LongName == covid.CovidMKB)?.Mkb10Id
            };

            _context.TblCovids.Attach(item);
            _context.TblCovids.Add(item);
            _context.SaveChanges();
            return Ok();
        }

        [HttpPost, Route("UpdateCovid")]
        [Authorize(Roles = "User")]
        public IActionResult UpdateCovid(Covid covid)
        {
            TblCovid item = new()
            {
                IdCovid = (int)covid.CovidId
            };
            _context.TblCovids.Attach(item);

            item.DPositivResCovid = covid.DPositivRes != null && covid.DPositivRes?.Length != 0 ? DateOnly.Parse(covid.DPositivRes) : null;
            _context.Entry(item).Property(e => e.DPositivResCovid).IsModified = true;
            item.DNegativeResCovid = covid.DNegativeRes != null && covid.DNegativeRes?.Length != 0 ? DateOnly.Parse(covid.DNegativeRes) : null;
            _context.Entry(item).Property(e => e.DNegativeResCovid).IsModified = true;
            item.CovidMkb10 = _context.TblListMkb10Covids.FirstOrDefault(e => e.Mkb10LongName == covid.CovidMKB)?.Mkb10Id;
            _context.Entry(item).Property(e => e.CovidMkb10).IsModified = true;
            _context.SaveChanges();
            return Ok();
        }
    }
}
