using System;
using System.Collections.Generic;

namespace HIVBackend.Models.DBModuls;

public partial class TblPatientPregnantM
{
    public int PatientId { get; set; }

    public short PregId { get; set; }

    public short? MedicineStMonthNo { get; set; }

    public int? ChildPatientId { get; set; }

    public string? ChildFamilyName { get; set; }

    public string? ChildFirstName { get; set; }

    public string? ChildThirdName { get; set; }

    public int? PwcheckYn { get; set; }

    public int? BirthTypeId { get; set; }

    public DateOnly? ChildBirthDate { get; set; }

    public string? User1 { get; set; }

    public DateOnly? Datetime1 { get; set; }

    public int? ChildCountId { get; set; }

    public DateOnly? PregDate { get; set; }

    public int? PhpschemaId1 { get; set; }

    public int? PhpschemaId2 { get; set; }

    public int? PhpschemaId3 { get; set; }

    public DateOnly? DateStart1 { get; set; }

    public DateOnly? DateEnd1 { get; set; }

    public int? FlgConfirm { get; set; }

    public int? MedicineId { get; set; }

    public int? MedicineId2 { get; set; }

    public int? MedicineId3 { get; set; }

    public string? PregDescr { get; set; }

    public DateOnly? Php1Sdate { get; set; }

    public DateOnly? Php1Edate { get; set; }

    public string? Php1Descr { get; set; }

    public DateOnly? Php2Sdate { get; set; }

    public DateOnly? Php2Edate { get; set; }

    public string? Php2Descr { get; set; }

    public DateOnly? Php3Sdate { get; set; }

    public DateOnly? Php3Edate { get; set; }

    public string? Php3Descr { get; set; }

    public short? Pwmonth { get; set; }

    public virtual TblChildCount? ChildCount { get; set; }

    public virtual TblMedicine? Medicine { get; set; }

    public virtual TblMedicine? MedicineId2Navigation { get; set; }

    public virtual TblMedicine? MedicineId3Navigation { get; set; }

    public virtual TblPatientCard Patient { get; set; } = null!;

    public virtual TblCureSchema? PhpschemaId1Navigation { get; set; }

    public virtual TblCureSchema? PhpschemaId2Navigation { get; set; }

    public virtual TblCureSchema? PhpschemaId3Navigation { get; set; }
}
