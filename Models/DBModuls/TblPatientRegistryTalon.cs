using System;
using System.Collections.Generic;

namespace HIVBackend.Models.DBModuls;

public partial class TblPatientRegistryTalon
{
    public DateOnly RegDate { get; set; }

    public int RegCabinetId { get; set; }

    public int PatientId { get; set; }

    public int TalonNum { get; set; }

    public DateOnly? TalonField01 { get; set; }

    public string? TalonField12Phone { get; set; }

    public int? TalonField13 { get; set; }

    public int? TalonField14 { get; set; }

    public int? TalonField21 { get; set; }

    public int? TalonField22 { get; set; }

    public int? TalonField24 { get; set; }

    public int? TalonField25 { get; set; }

    public int? TalonField28 { get; set; }

    public int? TalonField32 { get; set; }

    public int? TalonField35 { get; set; }

    public int? TalonField36 { get; set; }

    public int? TalonField30Spec { get; set; }

    public int? TalonField30 { get; set; }
}
