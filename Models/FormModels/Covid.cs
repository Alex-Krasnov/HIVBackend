﻿namespace HIVBackend.Models.FormModels
{
    public class Covid
    {
        public int PatientId { get; set; }
        public int? CovidId { get; set; }
        public string? DPositivRes { get; set; }
        public string? DNegativeRes { get; set; }
        public string? CovidMKB { get; set; }
    }
}
