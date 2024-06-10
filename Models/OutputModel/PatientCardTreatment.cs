using System;

namespace HIVBackend.Models.OutputModel
{
    public class PatientCardTreatment
    {
        public int PatientId { get; set; }
        public string? PatientFio { get; set; }
        public string? StageName { get; set; }
        public string? StageCom { get; set; }
        public string? PatientCom { get; set; }
        public string? InvalidName { get; set; }
        public DateOnly? HepBdate { get; set; }
        public string? HepBDescr { get; set; }

        public List<string>? ListInvalids { get; set; }
        public List<string>? ListCorrespIllness { get; set; }
        public List<string>? ListCureSchemas { get; set; }
        public List<string>? ListCureChanges { get; set; }
        public List<string>? ListRangeTherapy { get; set; }
        public List<string>? ListLpus { get; set; }
        public List<string>? ListHospCourses { get; set; }
        public List<string>? ListHospResults { get; set; }

        public List<FrmCorrespIllnesses>? CorrespIllnesses { get; set; }
        public List<FrmCureSchemas>? CureSchemas { get; set; }
        public List<FrmHospResultRs>? HospResultRs { get; set; }
        public List<FrmHepC>? hepCs { get; set; }
    }
    public class FrmCorrespIllnesses
    {
        public string? CorrespIllness { get; set; }
        public DateOnly? CorrespIllnessDate { get; set; }
    }
    public class FrmCureSchemas
    {
        public string? CureSchemaName { get; set; }
        public DateOnly? StartDate { get; set; }
        public DateOnly? EndDate { get; set; }
        public string? SchemaComm { get; set; }
        public string? CureChangeName { get; set; }
        public string? ProtNum { get; set; }
        public string? RangeTherapy { get; set; }
        public Boolean? Last { get; set; }
    }
    public class FrmHospResultRs
    {
        public DateOnly? DateHospIn { get; set; }
        public string? LpuName { get; set; }
        public string? HospCourseName { get; set; }
        public DateOnly? DateHospOut { get; set; }
        public string? HospResult { get; set; }
    }
    public class FrmHepC
    {
        public int Id { get; set; }
        public DateOnly DateStart { get; set; }
        public DateOnly? DateEnd { get; set; }
        public string? Descr { get; set; }
        public DateOnly? DateCreate { get; set; }
    }
}