﻿namespace HIVBackend.Models.FormModels
{
    public class PatientCardTreatmentForm
    {
        public int PatientId { get; set; }
        public string? StageCom { get; set; }
        public string? Com { get; set; }
        public string? Invalid { get; set; }
        public DateOnly? HepBDate { get; set; }
        public string? HepBDescr { get; set; }
    }
}
