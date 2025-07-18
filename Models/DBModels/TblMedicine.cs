﻿namespace HIVBackend.Models.DBModuls;

public partial class TblMedicine
{
    public int MedicineId { get; set; }

    public string? MedicineShort { get; set; }

    public string? MedicineLong { get; set; }

    public string? User1 { get; set; }

    public DateOnly? Datetime1 { get; set; }

    public string? KorvetId { get; set; }

    public bool IsHivMed { get; set; }

    public virtual ICollection<TblPatientPregnantM> TblPatientPregnantMMedicineId2Navigations { get; } = new List<TblPatientPregnantM>();

    public virtual ICollection<TblPatientPregnantM> TblPatientPregnantMMedicineId3Navigations { get; } = new List<TblPatientPregnantM>();

    public virtual ICollection<TblPatientPregnantM> TblPatientPregnantMMedicines { get; } = new List<TblPatientPregnantM>();

    public virtual ICollection<TblPatientPrescrM> TblPatientPrescrMGiveMeds { get; } = new List<TblPatientPrescrM>();

    public virtual ICollection<TblPatientPrescrM> TblPatientPrescrMMedicines { get; } = new List<TblPatientPrescrM>();
}
