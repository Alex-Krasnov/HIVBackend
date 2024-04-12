using HIVBackend.Models.DBModels;
using System;
using System.Collections.Generic;

namespace HIVBackend.Models.DBModuls;

public partial class TblPatientCard
{
    public int PatientId { get; set; }

    public int? OtherYn { get; set; }

    public DateOnly? InputDate { get; set; }

    public string? CardNo { get; set; }

    public string? FamilyName { get; set; }

    public string? FirstName { get; set; }

    public string? ThirdName { get; set; }

    public int? SexId { get; set; }

    public DateOnly? BirthDate { get; set; }

    public int? RegionId { get; set; }

    public string? CityName { get; set; }

    public string? AddrName { get; set; }

    public string? AddrInd { get; set; }

    public string? AddrStreet { get; set; }

    public string? AddrHouse { get; set; }

    public string? AddrFlat { get; set; }

    public int? CountryId { get; set; }

    public int? DiagnosisId { get; set; }

    public int? DiagnosisCdcId { get; set; }

    public DateOnly? RegOnDate { get; set; }

    public DateOnly? RegOffDate { get; set; }

    public DateOnly? DieDate { get; set; }

    public DateOnly? DieAidsDate { get; set; }

    public int? CheckCourseId { get; set; }

    public int? InfectCourseId { get; set; }

    public int? DieCourseId { get; set; }

    public int? Aids12Id { get; set; }

    public int? CodeMkb10Id { get; set; }

    public string? User1 { get; set; }

    public DateOnly? Datetime1 { get; set; }

    public int? PregCheckId { get; set; }

    public short? PregMonthNo { get; set; }

    public int? FamilyTypeId { get; set; }

    public int? MotherPatientId { get; set; }

    public int? FatherPatientId { get; set; }

    public int? ArvtgetYn { get; set; }

    public DateOnly? CheckFirstDate { get; set; }

    public int? ChildPlaceId { get; set; }

    public float? BreastMonthNo { get; set; }

    public int? ChildPhpId { get; set; }

    public int? JailId { get; set; }

    public int? JailedOffRegionId { get; set; }

    public DateOnly? JailedOffDate { get; set; }

    public int? Added { get; set; }

    public string? StageDescr { get; set; }

    public string? PatientDescr { get; set; }

    public int? InvalidId { get; set; }

    public float? VirusLoad { get; set; }

    public DateOnly? DefineVirusDate { get; set; }

    public DateOnly? DefineBiochemDate { get; set; }

    public DateOnly? DefineImmuneDate { get; set; }

    public int? RegOnCheck1 { get; set; }

    public string? PasSer { get; set; }

    public string? PasNum { get; set; }

    public string? PasWhom { get; set; }

    public DateOnly? PasWhen { get; set; }

    public string? OmsSer { get; set; }

    public string? OmsNum { get; set; }

    public DateOnly? OmsWhen { get; set; }

    public string? Snils { get; set; }

    public DateOnly? DefineResistDate { get; set; }

    public int? RegistId { get; set; }

    public int? PregExtrYn { get; set; }

    public int? StatusId { get; set; }

    public Guid? Uidpatient { get; set; }

    public string? LocationName { get; set; }

    public string? AddrExt { get; set; }

    public int? ArvtId { get; set; }

    public DateOnly? DiagnosisDefDate { get; set; }

    public int? FlgInstVirus { get; set; }

    public int? TransfAreaFlg { get; set; }

    public DateOnly? TransfAreaDate { get; set; }

    public int? MaterhomeId { get; set; }

    public string? ChildDescr { get; set; }

    public bool? FlgZamMedPart { get; set; }

    public bool? FlgHeadPhysician { get; set; }

    public DateOnly? TransfFederDate { get; set; }

    public int? AddrNameRed { get; set; }

    public DateOnly? UfsinDate { get; set; }

    public int? RegOffReason { get; set; }

    public int? EpidemTimeInfect { get; set; }

    public string? EpidemDescr { get; set; }

    public DateOnly? DieDateInput { get; set; }

    public int? FactRegionId { get; set; }

    public string? FactCityName { get; set; }

    public string? FactLocationName { get; set; }

    public string? FactAddrInd { get; set; }

    public string? FactAddrStreet { get; set; }

    public string? FactAddrHouse { get; set; }

    public string? FactAddrExt { get; set; }

    public string? FactAddrFlat { get; set; }

    public string? SnilsFed { get; set; }

    public decimal? Growth { get; set; }

    public decimal? Weight { get; set; }

    public string? FioChange { get; set; }

    public DateOnly? DtMailReg { get; set; }

    public DateOnly? DtRegBeg { get; set; }

    public DateOnly? DtRegEnd { get; set; }

    public string? Codeword { get; set; }

    public int? Forma309 { get; set; }

    public int? DieCourseId1 { get; set; }

    public int? DieCourseId2 { get; set; }

    public int? DieCourseId3 { get; set; }

    public int? DieCourseId4 { get; set; }

    public int? DieCourseId5 { get; set; }

    public int? EduId { get; set; }

    public int? FamilyStatusId { get; set; }

    public int? EmploymentId { get; set; }

    public int? TransId { get; set; }

    public string? NumMail { get; set; }

    public int? PlaceCheckId { get; set; }

    public DateOnly? EpidemTimeInfectStart { get; set; }

    public DateOnly? EpidemTimeInfectEnd { get; set; }

    public int? EpidDocId { get; set; }

    public int? SituationtDetectId { get; set; }

    public int? TransmitionMechId { get; set; }

    public bool? RefusalPhp { get; set; }

    public bool? RefusalResearch { get; set; }

    public bool? RefusalTherapy { get; set; }

    public DateOnly? LetterCareDate { get; set; }

    public DateOnly? CommunicationParentDate { get; set; }

    public DateOnly? CallingDistrictSpecDate { get; set; }

    public int? VulnerableGroupId { get; set; }

    public decimal? HeightOld { get; set; }

    public decimal? WeightOld { get; set; }

    public long? UnrzFr { get; set; }

    public string? UnrzFr1 { get; set; }
    public bool IsActive { get; set; }
    public bool? FlgDiagnosisAfterDeath { get; set; }

    public virtual TblAids12? Aids12 { get; set; }

    public virtual TblArvt? Arvt { get; set; }

    public virtual TblCheckCourse? CheckCourse { get; set; }

    public virtual TblChildPhp? ChildPhp { get; set; }

    public virtual TblChildPlace? ChildPlace { get; set; }

    public virtual TblCodeMkb10? CodeMkb10 { get; set; }

    public virtual TblCountry? Country { get; set; }

    public virtual TblDieCourse? DieCourse { get; set; }

    public virtual TblFamilyType? FamilyType { get; set; }

    public virtual TblPatientCard? FatherPatient { get; set; }

    public virtual TblInfectCourse? InfectCourse { get; set; }

    public virtual TblInvalid? Invalid { get; set; }

    public virtual ICollection<TblPatientCard> InverseFatherPatient { get; } = new List<TblPatientCard>();

    public virtual ICollection<TblPatientCard> InverseMotherPatient { get; } = new List<TblPatientCard>();

    public virtual TblJail? Jail { get; set; }

    public virtual TblRegion? JailedOffRegion { get; set; }

    public virtual TblMaterHome? Materhome { get; set; }

    public virtual TblPatientCard? MotherPatient { get; set; }

    public virtual TblPregCheck? PregCheck { get; set; }

    public virtual TblRegion? Region { get; set; }

    public virtual TblRegist? Regist { get; set; }

    public virtual TblSex? Sex { get; set; }

    public virtual TblStatus? Status { get; set; }

    public virtual ICollection<TblCovid> TblCovids { get; } = new List<TblCovid>();

    public virtual ICollection<TblPatientBiochem> TblPatientBiochems { get; } = new List<TblPatientBiochem>();

    public virtual ICollection<TblPatientCheck> TblPatientChecks { get; } = new List<TblPatientCheck>();

    public virtual ICollection<TblPatientChemop> TblPatientChemops { get; } = new List<TblPatientChemop>();

    public virtual ICollection<TblPatientChildSendForm> TblPatientChildSendForms { get; } = new List<TblPatientChildSendForm>();

    public virtual ICollection<TblPatientContact> TblPatientContacts { get; } = new List<TblPatientContact>();

    public virtual ICollection<TblPatientCorrespIllness> TblPatientCorrespIllnesses { get; } = new List<TblPatientCorrespIllness>();

    public virtual ICollection<TblPatientCureSchema> TblPatientCureSchemas { get; } = new List<TblPatientCureSchema>();

    public virtual ICollection<TblPatientDiagnosis> TblPatientDiagnoses { get; } = new List<TblPatientDiagnosis>();

    public virtual ICollection<TblPatientHepatitResult2> TblPatientHepatitResult2s { get; } = new List<TblPatientHepatitResult2>();

    public virtual ICollection<TblPatientHepatitResult> TblPatientHepatitResults { get; } = new List<TblPatientHepatitResult>();

    public virtual ICollection<TblPatientHospResultR> TblPatientHospResultRs { get; } = new List<TblPatientHospResultR>();

    public virtual ICollection<TblPatientHosp> TblPatientHosps { get; } = new List<TblPatientHosp>();

    public virtual ICollection<TblPatientImmuneStat> TblPatientImmuneStats { get; } = new List<TblPatientImmuneStat>();

    public virtual ICollection<TblPatientJail> TblPatientJails { get; } = new List<TblPatientJail>();

    public virtual ICollection<TblPatientMedicine> TblPatientMedicines { get; } = new List<TblPatientMedicine>();

    public virtual ICollection<TblPatientPregnantM> TblPatientPregnantMs { get; } = new List<TblPatientPregnantM>();

    public virtual ICollection<TblPatientPrescrM> TblPatientPrescrMs { get; } = new List<TblPatientPrescrM>();

    public virtual ICollection<TblPatientResist> TblPatientResists { get; } = new List<TblPatientResist>();

    public virtual ICollection<TblPatientShowIllness> TblPatientShowIllnesses { get; } = new List<TblPatientShowIllness>();

    public virtual ICollection<TblPatientStacionar> TblPatientStacionars { get; } = new List<TblPatientStacionar>();

    public virtual ICollection<TblPatientVirusLoad> TblPatientVirusLoads { get; } = new List<TblPatientVirusLoad>();

    public virtual ICollection<TblPatientCall> TblPatientCalls { get; } = new List<TblPatientCall>();

    public virtual ICollection<TblPatientEpidChild> TblPatientEpidChildren { get; } = new List<TblPatientEpidChild>();
}
