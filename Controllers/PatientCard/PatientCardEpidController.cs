using HIVBackend.Data;
using HIVBackend.Models.DBModels;
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
            List<FrmEpidChild> epidChildren = new();
            List<FrmCallStatus> callStatuses = new();

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
            List<TblPatientCall>? patientCall = _context.TblPatientCalls.Where(e => e.PatientId == patientId)?.ToList();
            List<TblPatientEpidChild>? patientEpidChildren = _context.TblPatientEpidChildren.Where(e => e.PatientId == patientId)?.ToList();

            foreach (var item in patientConstantContact)
            {
                var pcItem = _context.TblPatientCards.FirstOrDefault(e => e.PatientId == item.PatientContactId);
                string fio = pcItem?.FamilyName + " " + pcItem?.FirstName + " " + pcItem?.ThirdName;
                constantContact.Add(new()
                {
                    ContactId = item.PatientContactId,
                    InfectCourseName = _context.TblInfectCourses.FirstOrDefault(e => e.InfectCourseId == item.InfectCourseId)?.InfectCourseLong,
                    Fio = fio,
                    Type = item.ContactType

                });
            }

            foreach (var item in patientRandomContact)
            {
                var pcItem = _context.TblPatientCards.FirstOrDefault(e => e.PatientId == item.PatientContactId);
                string fio = pcItem?.FamilyName + " " + pcItem?.FirstName + " " + pcItem?.ThirdName;
                randomContact.Add(new()
                {
                    ContactId = item.PatientContactId,
                    InfectCourseName = _context.TblInfectCourses.FirstOrDefault(e => e.InfectCourseId == item.InfectCourseId)?.InfectCourseLong,
                    Fio = fio,
                    Type = item.ContactType
                });
            }

            foreach (var item in patientOtherContact)
            {
                var pcItem = _context.TblPatientCards.FirstOrDefault(e => e.PatientId == item.PatientContactId);
                string fio = pcItem?.FamilyName + " " + pcItem?.FirstName + " " + pcItem?.ThirdName;
                otherContact.Add(new()
                {
                    ContactId = item.PatientContactId,
                    InfectCourseName = _context.TblInfectCourses.FirstOrDefault(e => e.InfectCourseId == item.InfectCourseId)?.InfectCourseLong,
                    Fio = fio,
                    Type = item.ContactType
                });
            }

            foreach (var item in patientChemsex)
            {
                chemsex.Add(new()
                {
                    DrugId = item.DrugId,
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
                    VacId = item.VacId,
                    DVac1 = item.DVac1,
                    DVac2 = item.DVac2,
                    VacName = _context.TblListVacs.FirstOrDefault(e => e.VacId == item.VacName)?.VacName
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

            foreach (var item in patientEpidChildren)
            {
                epidChildren.Add(new()
                {
                    Id = item.PatientEpidChildId,
                    BirthDate = item.BirthDate,
                    FamilyName = item.ChildFamilyName,
                    FirstName = item.ChildFirstName,
                    ThirdName = item.ChildThirdName,
                    Exam = item.Exam,
                    SexName = _context.TblSexes.FirstOrDefault(e => e.SexId == item.SexId)?.SexShort
                });
            }

            foreach (var item in patientCall)
            {
                callStatuses.Add(new()
                {
                    Id = item.PatientCallId,
                    CallDate = item.CallDate,
                    CallStatus = _context.TblListCallStatuses.FirstOrDefault(e => e.CallStatusId == item.CallStatusId)?.LongName
                });
            }

            PatientCardEpid patientCardEpid = new();

            patientCardEpid.PatientId = patient.PatientId;
            patientCardEpid.PatientFio = patient.FamilyName + " " + patient.FirstName + " " + patient.ThirdName;
            patientCardEpid.DtMailReg = patient.DtMailReg;
            patientCardEpid.NumMail = patient.NumMail;
            patientCardEpid.EduName = _context.TblListEducations.FirstOrDefault(e => e.EducationId == patient.EduId)?.EduName;
            patientCardEpid.FamilyStatusName = _context.TblListFamilyStatuses.FirstOrDefault(e => e.FamilyStatusId == patient.FamilyStatusId)?.FammilyStatusName;
            patientCardEpid.EmploymentName = _context.TblListEmployments.FirstOrDefault(e => e.EmploymentId == patient.EmploymentId)?.EmploymentName;
            patientCardEpid.TransName = _context.TblListTrans.FirstOrDefault(e => e.TransId == patient.TransId)?.TransName;
            patientCardEpid.EpidemCom = patient.EpidemDescr;
            patientCardEpid.TransmitionMechName = _context.TblListTransmisionMeches.FirstOrDefault(e => e.TransmissionMechId == patient.TransmitionMechId)?.TransmisiomMechName;
            patientCardEpid.SituationDetectName = _context.TblListSituationDetects.FirstOrDefault(e => e.SituationDetectId == patient.SituationtDetectId)?.SituationDetectName;
            patientCardEpid.EpidTimeInfectStart = patient.EpidemTimeInfectStart;
            patientCardEpid.EpidTimeInfectEnd = patient.EpidemTimeInfectEnd;
            patientCardEpid.EpidDocName = _context.TblListEpidDoctors.FirstOrDefault(e => e.IdDoctor == patient.EpidDocId)?.DoctorName;
            patientCardEpid.MaxIdEpidChil = _context.TblPatientEpidChildren.Max(e => e.PatientEpidChildId);
            patientCardEpid.MaxIdCall = _context.TblPatientCalls.Max(e => e.PatientCallId);

            patientCardEpid.ListTypeContacts = _context.TblInfectCourses.Where(e => e.InfectCourseId == 100 || e.InfectCourseId == 104).Select(e => e.InfectCourseLong)?.OrderBy(e => e).ToList();
            patientCardEpid.ListYn = _context.TblListYns.Select(e => e.YNName)?.OrderBy(e => e).ToList();
            patientCardEpid.ListEdu = _context.TblListEducations.Select(e => e.EduName)?.OrderBy(e => e).ToList();
            patientCardEpid.ListFamilyStatus = _context.TblListFamilyStatuses.Select(e => e.FammilyStatusName)?.OrderBy(e => e).ToList();
            patientCardEpid.ListEmployment = _context.TblListEmployments.Select(e => e.EmploymentName)?.OrderBy(e => e).ToList();
            patientCardEpid.ListTrans = _context.TblListTrans.Select(e => e.TransName)?.OrderBy(e => e).ToList();
            patientCardEpid.ListVac = _context.TblListVacs.Select(e => e.VacName)?.OrderBy(e => e).ToList();
            patientCardEpid.ListCovidMKB = _context.TblListMkb10Covids.Select(e => e.Mkb10LongName)?.OrderBy(e => e).ToList();
            patientCardEpid.ListTransmitionMech = _context.TblListTransmisionMeches.Select(e => e.TransmisiomMechName)?.OrderBy(e => e).ToList();
            patientCardEpid.ListSituationDetect = _context.TblListSituationDetects.Select(e => e.SituationDetectName)?.OrderBy(e => e).ToList();
            patientCardEpid.ListEpidDoc = _context.TblListEpidDoctors.Select(e => e.DoctorName)?.OrderBy(e => e).ToList();
            patientCardEpid.ListSex = _context.TblSexes.Select(e => e.SexShort)?.OrderBy(e => e).ToList();
            patientCardEpid.ListCallStatus = _context.TblListCallStatuses.Select(e => e.LongName)?.OrderBy(e => e).ToList();

            patientCardEpid.ConstantContact = constantContact;
            patientCardEpid.RandomContact = randomContact;
            patientCardEpid.OtherContact = otherContact;
            patientCardEpid.Chemsex = chemsex;
            patientCardEpid.PavInj = pavInj;
            patientCardEpid.PavNotInj = pavNotInj;
            patientCardEpid.CovidVac = covidVac;
            patientCardEpid.Covid = covid;
            patientCardEpid.EpidChild = epidChildren.OrderBy(e => e.Id).ToList();
            patientCardEpid.CallStatuses = callStatuses.OrderBy(e => e.Id).ToList();

            return Ok(patientCardEpid);
        }

        [HttpGet, Route("GetFio")]
        [Authorize(Roles = "User")]
        public IActionResult GetFio(int patientId)
        {
            var patient = _context.TblPatientCards.First(e => e.PatientId == patientId);
            string fio = patient.FamilyName + " " + patient.FirstName + " " + patient.ThirdName;

            return Ok(new { fio });
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
                ContactType = contact.Type,
                InfectCourseId = _context.TblInfectCourses.FirstOrDefault(e => e.InfectCourseLong == contact.InfectCourseName)?.InfectCourseId
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
                ContactType = contact.Type
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

            _context.TblPatientContactChemsexes.Attach(item);
            _context.TblPatientContactChemsexes.Remove(item);
            _context.SaveChanges();
            return Ok();
        }

        [HttpPost, Route("CreateChemsex")]
        [Authorize(Roles = "User")]
        public IActionResult CreateChemsex(Chemsex chemsex)
        {
            int maxId = _context.TblPatientContactChemsexes.Max(e => e.DrugId) + 1;
            TblPatientContactChemsex item = new()
            {
                DrugId = maxId,
                PatientId = chemsex.PatientId,
                YNId = _context.TblListYns.FirstOrDefault(e => e.YNName == chemsex.YnName)?.IdYN,
                DrugName = chemsex.DrugName,
                ContactType = _context.TblInfectCourses.FirstOrDefault(e => e.InfectCourseLong == chemsex.ContactTypeName)?.InfectCourseId
            };

            _context.TblPatientContactChemsexes.Attach(item);
            _context.TblPatientContactChemsexes.Add(item);
            _context.SaveChanges();
            //int chemsexId = item.DrugId;
            //int chemsexId = _context.TblPatientContactChemsexes.First(e => e.PatientId == item.PatientId
            //&& e.YNId == item.YNId && e.DrugName == item.DrugName && e.ContactType == item.ContactType).DrugId;
            return Ok(maxId);
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

        [HttpDelete, Route("DelPavInj")]
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
            int maxId = _context.TblPatientContactPavInjs.Max(e => e.DrugId) + 1;
            TblPatientContactPavInj item = new()
            {
                DrugId = maxId,
                PatientId = pav.PatientId,
                YNId = _context.TblListYns.FirstOrDefault(e => e.YNName == pav.YnName)?.IdYN,
                DrugName = pav.DrugName,
                DateStart = pav.DateStart != null && pav.DateStart?.Length != 0 ? DateOnly.Parse(pav.DateStart) : null,
                DateEnd = pav.DateEnd != null && pav.DateEnd?.Length != 0 ? DateOnly.Parse(pav.DateEnd) : null
            };

            _context.TblPatientContactPavInjs.Attach(item);
            _context.TblPatientContactPavInjs.Add(item);
            _context.SaveChanges();
            return Ok(maxId);
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
            item.DrugName = pav.DrugName;
            _context.Entry(item).Property(e => e.DrugName).IsModified = true;
            item.DateStart = pav.DateStart != null && pav.DateStart?.Length != 0 ? DateOnly.Parse(pav.DateStart) : null;
            _context.Entry(item).Property(e => e.DateStart).IsModified = true;
            item.DateEnd = pav.DateEnd != null && pav.DateEnd?.Length != 0 ? DateOnly.Parse(pav.DateEnd) : null;
            _context.Entry(item).Property(e => e.DateEnd).IsModified = true;

            _context.SaveChanges();
            return Ok();
        }

        [HttpDelete, Route("DelPavNotInj")]
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
            int maxId = _context.TblPatientContactPavNotInjs.Max(e => e.DrugId) + 1;
            TblPatientContactPavNotInj item = new()
            {
                DrugId = maxId,
                PatientId = pav.PatientId,
                YNId = _context.TblListYns.FirstOrDefault(e => e.YNName == pav.YnName)?.IdYN,
                DrugName = pav.DrugName,
                DateStart = pav.DateStart != null && pav.DateStart?.Length != 0 ? DateOnly.Parse(pav.DateStart) : null,
                DateEnd = pav.DateEnd != null && pav.DateEnd?.Length != 0 ? DateOnly.Parse(pav.DateEnd) : null
            };

            _context.TblPatientContactPavNotInjs.Attach(item);
            _context.TblPatientContactPavNotInjs.Add(item);
            _context.SaveChanges();
            return Ok(maxId);
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
                VacId = id
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
            int maxId = _context.TblCovidVacs.Max(e => e.VacId) + 1;
            TblCovidVac item = new()
            {
                VacId = maxId,
                DVac1 = covidVac.DVac1 != null && covidVac.DVac1?.Length != 0 ? DateOnly.Parse(covidVac.DVac1) : null,
                DVac2 = covidVac.DVac2 != null && covidVac.DVac2?.Length != 0 ? DateOnly.Parse(covidVac.DVac2) : null,
                VacName = _context.TblListVacs.FirstOrDefault(e => e.VacName == covidVac.VacName)?.VacId,
                PatientId = covidVac.PatientId
            };

            _context.TblCovidVacs.Attach(item);
            _context.TblCovidVacs.Add(item);
            _context.SaveChanges();
            return Ok(maxId);
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

        [HttpDelete, Route("DelEpidChild")]
        [Authorize(Roles = "User")]
        public IActionResult DelEpidChild(int id)
        {
            TblPatientEpidChild item = new()
            {
                PatientEpidChildId = id
            };

            _context.TblPatientEpidChildren.Attach(item);
            _context.TblPatientEpidChildren.Remove(item);
            _context.SaveChanges();
            return Ok();
        }

        [HttpPost, Route("CreateEpidChild")]
        [Authorize(Roles = "User")]
        public IActionResult CreateEpidChild(EpidChild epidChild)
        {
            int maxId = _context.TblPatientEpidChildren.Max(e => e.PatientEpidChildId) + 1;
            TblPatientEpidChild item = new()
            {
                PatientEpidChildId = maxId,
                BirthDate = epidChild.BirthDate != null && epidChild.BirthDate?.Length != 0 ? DateOnly.Parse(epidChild.BirthDate) : null,
                PatientId = epidChild.PatientId,
                SexId = _context.TblSexes.FirstOrDefault(e => e.SexShort == epidChild.SexName)?.SexId,
                ChildFamilyName = epidChild.ChildFamilyName,
                ChildFirstName = epidChild.ChildFirstName,
                ChildThirdName = epidChild.ChildThirdName,
                Exam = epidChild.Exam
            };

            _context.TblPatientEpidChildren.Attach(item);
            _context.TblPatientEpidChildren.Add(item);
            _context.SaveChanges();
            return Ok(maxId);
        }

        [HttpPost, Route("UpdateEpidChild")]
        [Authorize(Roles = "User")]
        public IActionResult UpdateEpidChild(EpidChild epidChild)
        {
            TblPatientEpidChild item = new()
            {
                PatientEpidChildId = (int)epidChild.Id
            };
            _context.TblPatientEpidChildren.Attach(item);

            item.SexId = _context.TblSexes.FirstOrDefault(e => e.SexShort == epidChild.SexName)?.SexId;
            _context.Entry(item).Property(e => e.SexId).IsModified = true;

            item.ChildFamilyName = epidChild.ChildFamilyName;
            _context.Entry(item).Property(e => e.ChildFamilyName).IsModified = true;

            item.ChildFirstName = epidChild.ChildFirstName;
            _context.Entry(item).Property(e => e.ChildFirstName).IsModified = true;

            item.ChildThirdName = epidChild.ChildThirdName;
            _context.Entry(item).Property(e => e.ChildThirdName).IsModified = true;

            item.BirthDate = epidChild.BirthDate != null && epidChild.BirthDate?.Length != 0 ? DateOnly.Parse(epidChild.BirthDate) : null;
            _context.Entry(item).Property(e => e.BirthDate).IsModified = true;

            item.Exam = epidChild.Exam;
            _context.Entry(item).Property(e => e.Exam).IsModified = true;


            _context.SaveChanges();
            return Ok();
        }

        [HttpDelete, Route("DelCall")]
        [Authorize(Roles = "User")]
        public IActionResult DelCall(int id)
        {
            TblPatientCall item = new()
            {
                CallStatusId = id
            };

            _context.TblPatientCalls.Attach(item);
            _context.TblPatientCalls.Remove(item);
            _context.SaveChanges();
            return Ok();
        }

        [HttpPost, Route("CreateCall")]
        [Authorize(Roles = "User")]
        public IActionResult CreateCall(PatientCall call)
        {
            int maxId = _context.TblPatientCalls.Max(e => e.PatientCallId) + 1;
            TblPatientCall item = new()
            {
                PatientCallId = maxId,
                CallDate = call.CallDate != null && call.CallDate?.Length != 0 ? DateOnly.Parse(call.CallDate) : null,
                PatientId = call.PatientId,
                CallStatusId = _context.TblListCallStatuses.FirstOrDefault(e => e.LongName == call.CallStatusName)?.CallStatusId
            };

            _context.TblPatientCalls.Attach(item);
            _context.TblPatientCalls.Add(item);
            _context.SaveChanges();
            return Ok(maxId);
        }

        [HttpPost, Route("UpdateCall")]
        [Authorize(Roles = "User")]
        public IActionResult UpdateCall(PatientCall call)
        {
            TblPatientCall item = new()
            {
                PatientCallId = (int)call.Id
            };
            _context.TblPatientCalls.Attach(item);

            item.CallStatusId = _context.TblListCallStatuses.FirstOrDefault(e => e.LongName == call.CallStatusName)?.CallStatusId;
            _context.Entry(item).Property(e => e.CallStatusId).IsModified = true;

            item.CallDate = call.CallDate != null && call.CallDate?.Length != 0 ? DateOnly.Parse(call.CallDate) : null;
            _context.Entry(item).Property(e => e.CallDate).IsModified = true;


            _context.SaveChanges();
            return Ok();
        }

        [HttpPost, Route("CreateCovid")]
        [Authorize(Roles = "User")]
        public IActionResult CreateCovid(CovidEpid covid)
        {
            int maxId = _context.TblCovids.Max(e => e.IdCovid) + 1;
            TblCovid item = new()
            {
                IdCovid = maxId,
                PatientId = covid.PatientId,
                DPositivResCovid = covid.DPositivRes != null && covid.DPositivRes?.Length != 0 ? DateOnly.Parse(covid.DPositivRes) : null,
                DNegativeResCovid = covid.DNegativeRes != null && covid.DNegativeRes?.Length != 0 ? DateOnly.Parse(covid.DNegativeRes) : null,
                CovidMkb10 = _context.TblListMkb10Covids.FirstOrDefault(e => e.Mkb10LongName == covid.CovidMKB)?.Mkb10Id
            };

            _context.TblCovids.Attach(item);
            _context.TblCovids.Add(item);
            _context.SaveChanges();
            return Ok(maxId);
        }

        [HttpPost, Route("UpdateCovid")]
        [Authorize(Roles = "User")]
        public IActionResult UpdateCovid(CovidEpid covid)
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

        [HttpPost, Route("UpdatePatient")]
        [Authorize(Roles = "User")]
        public IActionResult UpdatePatient(PatientCardEpidForm patient)
        {
            TblPatientCard item = new()
            {
                PatientId = patient.PatientId
            };
            _context.TblPatientCards.Attach(item);

            item.DtMailReg = patient.DtMailReg != null && patient.DtMailReg?.Length != 0 ? DateOnly.Parse(patient.DtMailReg) : null;
            _context.Entry(item).Property(e => e.DtMailReg).IsModified = true;
            item.EpidemTimeInfectStart = patient.EpidTimeInfectStart != null && patient.EpidTimeInfectStart?.Length != 0 ? DateOnly.Parse(patient.EpidTimeInfectStart) : null;
            _context.Entry(item).Property(e => e.EpidemTimeInfectStart).IsModified = true;
            item.EpidemTimeInfectEnd = patient.EpidTimeInfectEnd != null && patient.EpidTimeInfectEnd?.Length != 0 ? DateOnly.Parse(patient.EpidTimeInfectEnd) : null;
            _context.Entry(item).Property(e => e.EpidemTimeInfectEnd).IsModified = true;


            item.NumMail = patient.NumMail;
            _context.Entry(item).Property(e => e.NumMail).IsModified = true;
            item.EpidemDescr = patient.EpidemCom;
            _context.Entry(item).Property(e => e.EpidemDescr).IsModified = true;

            if (patient.EduName != null)
                if (patient.EduName.Length != 0)
                {
                    var id = _context.TblListEducations.First(e => e.EduName == patient.EduName)?.EducationId;
                    if (id != item.EduId)
                        item.EduId = id;
                }
                else
                {
                    item.EduId = null;
                    _context.Entry(item).Property(e => e.EduId).IsModified = true;
                }

            if (patient.FamilyStatusName != null)
                if (patient.FamilyStatusName.Length != 0)
                {
                    var id = _context.TblListFamilyStatuses.First(e => e.FammilyStatusName == patient.FamilyStatusName)?.FamilyStatusId;
                    if (id != item.FamilyStatusId)
                        item.FamilyStatusId = id;
                }
                else
                {
                    item.FamilyStatusId = null;
                    _context.Entry(item).Property(e => e.FamilyStatusId).IsModified = true;
                }

            if (patient.EmploymentName != null)
                if (patient.EmploymentName.Length != 0)
                {
                    var id = _context.TblListEmployments.First(e => e.EmploymentName == patient.EmploymentName)?.EmploymentId;
                    if (id != item.EmploymentId)
                        item.EmploymentId = id;
                }
                else
                {
                    item.EmploymentId = null;
                    _context.Entry(item).Property(e => e.EmploymentId).IsModified = true;
                }

            if (patient.TransName != null)
                if (patient.TransName.Length != 0)
                {
                    var id = _context.TblListTrans.First(e => e.TransName == patient.TransName)?.TransId;
                    if (id != item.TransId)
                        item.TransId = id;
                }
                else
                {
                    item.TransId = null;
                    _context.Entry(item).Property(e => e.TransId).IsModified = true;
                }

            if (patient.TransmitionMechName != null)
                if (patient.TransmitionMechName.Length != 0)
                {
                    var id = _context.TblListTransmisionMeches.First(e => e.TransmisiomMechName == patient.TransmitionMechName)?.TransmissionMechId;
                    if (id != item.TransmitionMechId)
                        item.TransmitionMechId = id;
                }
                else
                {
                    item.TransmitionMechId = null;
                    _context.Entry(item).Property(e => e.TransmitionMechId).IsModified = true;
                }

            if (patient.SituationDetectName != null)
                if (patient.SituationDetectName.Length != 0)
                {
                    var id = _context.TblListSituationDetects.First(e => e.SituationDetectName == patient.SituationDetectName)?.SituationDetectId;
                    if (id != item.SituationtDetectId)
                        item.SituationtDetectId = id;
                }
                else
                {
                    item.SituationtDetectId = null;
                    _context.Entry(item).Property(e => e.SituationtDetectId).IsModified = true;
                }

            if (patient.EpidDocName != null)
                if (patient.EpidDocName.Length != 0)
                {
                    var id = _context.TblListEpidDoctors.First(e => e.DoctorName == patient.EpidDocName)?.IdDoctor;
                    if (id != item.EpidDocId)
                        item.EpidDocId = id;
                }
                else
                {
                    item.EpidDocId = null;
                    _context.Entry(item).Property(e => e.EpidDocId).IsModified = true;
                }

            _context.SaveChanges();
            return Ok();
        }
    }
}
