using System;
using System.Collections.Generic;
using HIVBackend.Models.DBModuls;
using Microsoft.EntityFrameworkCore;

namespace HIVBackend.Data;

public partial class HivContext : DbContext
{
    public HivContext()
    {
    }

    public HivContext(DbContextOptions<HivContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TblAclTestBh> TblAclTestBhs { get; set; }

    public virtual DbSet<TblAclTestGe> TblAclTestGes { get; set; }

    public virtual DbSet<TblAclTestResistence> TblAclTestResistences { get; set; }

    public virtual DbSet<TblAgegr> TblAgegrs { get; set; }

    public virtual DbSet<TblAids12> TblAids12s { get; set; }

    public virtual DbSet<TblArvt> TblArvts { get; set; }

    public virtual DbSet<TblBiochem> TblBiochems { get; set; }

    public virtual DbSet<TblBirthType> TblBirthTypes { get; set; }

    public virtual DbSet<TblCabinet> TblCabinets { get; set; }

    public virtual DbSet<TblCheckCourse> TblCheckCourses { get; set; }

    public virtual DbSet<TblCheckPlace> TblCheckPlaces { get; set; }

    public virtual DbSet<TblChemop> TblChemops { get; set; }

    public virtual DbSet<TblChildCount> TblChildCounts { get; set; }

    public virtual DbSet<TblChildPhp> TblChildPhps { get; set; }

    public virtual DbSet<TblChildPlace> TblChildPlaces { get; set; }

    public virtual DbSet<TblCodeMkb10> TblCodeMkb10s { get; set; }

    public virtual DbSet<TblCorrespIllness> TblCorrespIllnesses { get; set; }

    public virtual DbSet<TblCountry> TblCountries { get; set; }

    public virtual DbSet<TblCovid> TblCovids { get; set; }

    public virtual DbSet<TblCovidVac> TblCovidVacs { get; set; }

    public virtual DbSet<TblCureChange> TblCureChanges { get; set; }

    public virtual DbSet<TblCureSchema> TblCureSchemas { get; set; }

    public virtual DbSet<TblDiagnosis> TblDiagnoses { get; set; }

    public virtual DbSet<TblDiagnosisCdc> TblDiagnosisCdcs { get; set; }

    public virtual DbSet<TblDieCourse> TblDieCourses { get; set; }

    public virtual DbSet<TblDoctor> TblDoctors { get; set; }

    public virtual DbSet<TblDtype> TblDtypes { get; set; }

    public virtual DbSet<TblFamilyType> TblFamilyTypes { get; set; }

    public virtual DbSet<TblFinSource> TblFinSources { get; set; }

    public virtual DbSet<TblHepatitResult> TblHepatitResults { get; set; }

    public virtual DbSet<TblHepatitResult2> TblHepatitResult2s { get; set; }

    public virtual DbSet<TblHospCourse> TblHospCourses { get; set; }

    public virtual DbSet<TblHospResult> TblHospResults { get; set; }

    public virtual DbSet<TblIbResult> TblIbResults { get; set; }

    public virtual DbSet<TblImmuneStat> TblImmuneStats { get; set; }

    public virtual DbSet<TblInfectCourse> TblInfectCourses { get; set; }

    public virtual DbSet<TblInvalid> TblInvalids { get; set; }

    public virtual DbSet<TblJail> TblJails { get; set; }

    public virtual DbSet<TblListAvlType> TblListAvlTypes { get; set; }

    public virtual DbSet<TblListClinVarCovid> TblListClinVarCovids { get; set; }

    public virtual DbSet<TblListCommitment> TblListCommitments { get; set; }

    public virtual DbSet<TblListCourseCovid> TblListCourseCovids { get; set; }

    public virtual DbSet<TblListEducation> TblListEducations { get; set; }

    public virtual DbSet<TblListEmloyment> TblListEmloyments { get; set; }

    public virtual DbSet<TblListEpidDoctor> TblListEpidDoctors { get; set; }

    public virtual DbSet<TblListFamilyStatus> TblListFamilyStatuses { get; set; }

    public virtual DbSet<TblListFullMkb10> TblListFullMkb10s { get; set; }

    public virtual DbSet<TblListMkb10Covid> TblListMkb10Covids { get; set; }

    public virtual DbSet<TblListMkbPneumonium> TblListMkbPneumonia { get; set; }

    public virtual DbSet<TblListMkbTuder> TblListMkbTuders { get; set; }

    public virtual DbSet<TblListOutHosp> TblListOutHosps { get; set; }

    public virtual DbSet<TblListPlaceCheck> TblListPlaceChecks { get; set; }

    public virtual DbSet<TblListSituationDetect> TblListSituationDetects { get; set; }

    public virtual DbSet<TblListTran> TblListTrans { get; set; }

    public virtual DbSet<TblListTransmisionMech> TblListTransmisionMeches { get; set; }

    public virtual DbSet<TblListVac> TblListVacs { get; set; }

    public virtual DbSet<TblListVulnerableGroup> TblListVulnerableGroups { get; set; }

    public virtual DbSet<TblListYn> TblListYns { get; set; }

    public virtual DbSet<TblLpu> TblLpus { get; set; }

    public virtual DbSet<TblMaterHome> TblMaterHomes { get; set; }

    public virtual DbSet<TblMedicine> TblMedicines { get; set; }

    public virtual DbSet<TblMedicineForSchema> TblMedicineForSchemas { get; set; }

    public virtual DbSet<TblMessage> TblMessages { get; set; }

    public virtual DbSet<TblMonth> TblMonths { get; set; }

    public virtual DbSet<TblPatDiagnosis> TblPatDiagnoses { get; set; }

    public virtual DbSet<TblPatientAclResult> TblPatientAclResults { get; set; }

    public virtual DbSet<TblPatientBiochem> TblPatientBiochems { get; set; }

    public virtual DbSet<TblPatientBlot> TblPatientBlots { get; set; }

    public virtual DbSet<TblPatientCard> TblPatientCards { get; set; }

    public virtual DbSet<TblPatientCheck> TblPatientChecks { get; set; }

    public virtual DbSet<TblPatientCheckOut> TblPatientCheckOuts { get; set; }

    public virtual DbSet<TblPatientChemop> TblPatientChemops { get; set; }

    public virtual DbSet<TblPatientChildSendForm> TblPatientChildSendForms { get; set; }

    public virtual DbSet<TblPatientContact> TblPatientContacts { get; set; }

    public virtual DbSet<TblPatientContactChemsex> TblPatientContactChemsexes { get; set; }

    public virtual DbSet<TblPatientContactDrug> TblPatientContactDrugs { get; set; }

    public virtual DbSet<TblPatientContactPavInj> TblPatientContactPavInjs { get; set; }

    public virtual DbSet<TblPatientContactPavNotInj> TblPatientContactPavNotInjs { get; set; }

    public virtual DbSet<TblPatientCorrespIllness> TblPatientCorrespIllnesses { get; set; }

    public virtual DbSet<TblPatientCureSchema> TblPatientCureSchemas { get; set; }

    public virtual DbSet<TblPatientDiagnosis> TblPatientDiagnoses { get; set; }

    public virtual DbSet<TblPatientHepatitResult> TblPatientHepatitResults { get; set; }

    public virtual DbSet<TblPatientHepatitResult2> TblPatientHepatitResult2s { get; set; }

    public virtual DbSet<TblPatientHosp> TblPatientHosps { get; set; }

    public virtual DbSet<TblPatientHospResultR> TblPatientHospResultRs { get; set; }

    public virtual DbSet<TblPatientImmuneStat> TblPatientImmuneStats { get; set; }

    public virtual DbSet<TblPatientJail> TblPatientJails { get; set; }

    public virtual DbSet<TblPatientMedicine> TblPatientMedicines { get; set; }

    public virtual DbSet<TblPatientNonresident> TblPatientNonresidents { get; set; }

    public virtual DbSet<TblPatientPregnantM> TblPatientPregnantMs { get; set; }

    public virtual DbSet<TblPatientPrescrM> TblPatientPrescrMs { get; set; }

    public virtual DbSet<TblPatientRegistry> TblPatientRegistries { get; set; }

    public virtual DbSet<TblPatientRegistryTalon> TblPatientRegistryTalons { get; set; }

    public virtual DbSet<TblPatientResist> TblPatientResists { get; set; }

    public virtual DbSet<TblPatientShowIllness> TblPatientShowIllnesses { get; set; }

    public virtual DbSet<TblPatientStacionar> TblPatientStacionars { get; set; }

    public virtual DbSet<TblPatientVirusLoad> TblPatientVirusLoads { get; set; }

    public virtual DbSet<TblPregCheck> TblPregChecks { get; set; }

    public virtual DbSet<TblQgr> TblQgrs { get; set; }

    public virtual DbSet<TblQuest> TblQuests { get; set; }

    public virtual DbSet<TblQuestDimeR> TblQuestDimeRs { get; set; }

    public virtual DbSet<TblRangeTherapy> TblRangeTherapies { get; set; }

    public virtual DbSet<TblRegTime> TblRegTimes { get; set; }

    public virtual DbSet<TblRegion> TblRegions { get; set; }

    public virtual DbSet<TblRegionSelect> TblRegionSelects { get; set; }

    public virtual DbSet<TblRegist> TblRegists { get; set; }

    public virtual DbSet<TblRegtype> TblRegtypes { get; set; }

    public virtual DbSet<TblResearch> TblResearches { get; set; }

    public virtual DbSet<TblResist> TblResists { get; set; }

    public virtual DbSet<TblRmedic> TblRmedics { get; set; }

    public virtual DbSet<TblSchemaMedicineR> TblSchemaMedicineRs { get; set; }

    public virtual DbSet<TblSecDi> TblSecDis { get; set; }

    public virtual DbSet<TblSetup> TblSetups { get; set; }

    public virtual DbSet<TblSex> TblSexes { get; set; }

    public virtual DbSet<TblShowIllness> TblShowIllnesses { get; set; }

    public virtual DbSet<TblSpec> TblSpecs { get; set; }

    public virtual DbSet<TblStacionar> TblStacionars { get; set; }

    public virtual DbSet<TblStatus> TblStatuses { get; set; }

    public virtual DbSet<TblTalonListOfValue> TblTalonListOfValues { get; set; }

    public virtual DbSet<TblTempDieCureMkb10list> TblTempDieCureMkb10lists { get; set; }

    public virtual DbSet<TblUser> TblUsers { get; set; }

    public virtual DbSet<TblVloadResult> TblVloadResults { get; set; }

    public virtual DbSet<TblZzztempSnil> TblZzztempSnils { get; set; }

    public virtual DbSet<QrySearchMainInf> QrySearchMainInfs { get; set; }
    
    public virtual DbSet<QrySearchPregnant> QrySearchPregnants { get; set; }

    public virtual DbSet<QrySearchChild> QrySearchChilds { get; set; }

    public virtual DbSet<QrySearchTreatment> QrySearchTreatments { get; set; }

    public virtual DbSet<QrySearchAnalyse> QrySearchAnalyses { get; set; }

    public virtual DbSet<QrySearchAcl> QrySearchAcls { get; set; }

    public virtual DbSet<QrySearchVisit> QrySearchVisits { get; set; }

    public virtual DbSet<QrySearchEpid> QrySearchEpids { get; set; }

    public virtual DbSet<QrySearchHosp> QrySearchHosps { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=HIV;Username=vs_test;Password=4100");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TblAclTestBh>(entity =>
        {
            entity.HasKey(e => e.AclTestCode);

            entity.ToTable("tblAclTest_BH");

            entity.Property(e => e.AclTestCode)
                .HasMaxLength(50)
                .HasColumnName("acl_test_code");
            entity.Property(e => e.AclTestName)
                .HasMaxLength(255)
                .HasColumnName("acl_test_name");
            entity.Property(e => e.AclTestRefint)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("acl_test_refint");
            entity.Property(e => e.Datetime1).HasColumnName("datetime1");
            entity.Property(e => e.Desc01)
                .HasMaxLength(255)
                .HasColumnName("desc01");
            entity.Property(e => e.User1)
                .HasMaxLength(50)
                .HasColumnName("user1");
        });

        modelBuilder.Entity<TblAclTestGe>(entity =>
        {
            entity.HasKey(e => e.AclTestCode);

            entity.ToTable("tblAclTest_GE");

            entity.Property(e => e.AclTestCode)
                .HasMaxLength(50)
                .HasColumnName("acl_test_code");
            entity.Property(e => e.AclTestName)
                .HasMaxLength(255)
                .HasColumnName("acl_test_name");
            entity.Property(e => e.AclTestRefint)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("acl_test_refint");
            entity.Property(e => e.Datetime1).HasColumnName("datetime1");
            entity.Property(e => e.Desc01)
                .HasMaxLength(255)
                .HasColumnName("desc01");
            entity.Property(e => e.User1)
                .HasMaxLength(50)
                .HasColumnName("user1");
        });

        modelBuilder.Entity<TblAclTestResistence>(entity =>
        {
            entity.HasKey(e => e.AclTestCode).HasName("PK_dbo.tblAclTest_Resistence");

            entity.ToTable("tblAclTest_Resistence");

            entity.Property(e => e.AclTestCode)
                .HasMaxLength(50)
                .HasColumnName("acl_test_code");
            entity.Property(e => e.AclTestName)
                .HasMaxLength(255)
                .HasColumnName("acl_test_name");
            entity.Property(e => e.Datetime1).HasColumnName("datetime1");
            entity.Property(e => e.Desc01)
                .HasMaxLength(255)
                .HasColumnName("desc01");
            entity.Property(e => e.User1)
                .HasMaxLength(50)
                .HasColumnName("user1");
        });

        modelBuilder.Entity<TblAgegr>(entity =>
        {
            entity.HasKey(e => e.AgegrId);

            entity.ToTable("tblAgegr");

            entity.Property(e => e.AgegrId).HasColumnName("agegr_id");
            entity.Property(e => e.AgegrLong)
                .HasMaxLength(100)
                .HasColumnName("agegr_long");
            entity.Property(e => e.AgegrShort)
                .HasMaxLength(50)
                .HasColumnName("agegr_short");
            entity.Property(e => e.Datetime1).HasColumnName("datetime1");
            entity.Property(e => e.End1).HasColumnName("end1");
            entity.Property(e => e.Start1).HasColumnName("start1");
            entity.Property(e => e.User1)
                .HasMaxLength(50)
                .HasColumnName("user1");
        });

        modelBuilder.Entity<TblAids12>(entity =>
        {
            entity.HasKey(e => e.Aids12Id);

            entity.ToTable("tblAids12");

            entity.Property(e => e.Aids12Id).HasColumnName("aids12_id");
            entity.Property(e => e.Aids12Long)
                .HasMaxLength(100)
                .HasColumnName("aids12_long");
            entity.Property(e => e.Aids12Short)
                .HasMaxLength(50)
                .HasColumnName("aids12_short");
            entity.Property(e => e.Datetime1).HasColumnName("datetime1");
            entity.Property(e => e.User1)
                .HasMaxLength(50)
                .HasColumnName("user1");
        });

        modelBuilder.Entity<TblArvt>(entity =>
        {
            entity.HasKey(e => e.ArvtId);

            entity.ToTable("tblArvt");

            entity.Property(e => e.ArvtId).HasColumnName("arvt_id");
            entity.Property(e => e.ArvtLong)
                .HasMaxLength(100)
                .HasColumnName("arvt_long");
            entity.Property(e => e.ArvtShort)
                .HasMaxLength(50)
                .HasColumnName("arvt_short");
            entity.Property(e => e.Datetime1).HasColumnName("datetime1");
            entity.Property(e => e.User1)
                .HasMaxLength(50)
                .HasColumnName("user1");
        });

        modelBuilder.Entity<TblBiochem>(entity =>
        {
            entity.HasKey(e => e.BiochemId);

            entity.ToTable("tblBiochem");

            entity.Property(e => e.BiochemId).HasColumnName("biochem_id");
            entity.Property(e => e.BiochemLong)
                .HasMaxLength(100)
                .HasColumnName("biochem_long");
            entity.Property(e => e.BiochemShort)
                .HasMaxLength(50)
                .HasColumnName("biochem_short");
            entity.Property(e => e.Comment1)
                .HasMaxLength(255)
                .HasColumnName("comment1");
            entity.Property(e => e.Datetime1).HasColumnName("datetime1");
            entity.Property(e => e.Max1).HasColumnName("max1");
            entity.Property(e => e.Min1).HasColumnName("min1");
            entity.Property(e => e.User1)
                .HasMaxLength(50)
                .HasColumnName("user1");
        });

        modelBuilder.Entity<TblBirthType>(entity =>
        {
            entity.HasKey(e => e.BirthTypeId);

            entity.ToTable("tblBirthType");

            entity.Property(e => e.BirthTypeId).HasColumnName("birth_type_id");
            entity.Property(e => e.BirthTypeLong)
                .HasMaxLength(100)
                .HasColumnName("birth_type_long");
            entity.Property(e => e.BirthTypeShort)
                .HasMaxLength(50)
                .HasColumnName("birth_type_short");
            entity.Property(e => e.Datetime1).HasColumnName("datetime1");
            entity.Property(e => e.User1)
                .HasMaxLength(50)
                .HasColumnName("user1");
        });

        modelBuilder.Entity<TblCabinet>(entity =>
        {
            entity.HasKey(e => e.CabinetId);

            entity.ToTable("tblCabinet");

            entity.Property(e => e.CabinetId)
                .ValueGeneratedNever()
                .HasColumnName("cabinet_id");
            entity.Property(e => e.CabinetLong)
                .HasMaxLength(100)
                .HasColumnName("cabinet_long");
            entity.Property(e => e.CabinetShort)
                .HasMaxLength(50)
                .HasColumnName("cabinet_short");
            entity.Property(e => e.Datetime1).HasColumnName("datetime1");
            entity.Property(e => e.FlgTalonnworeg).HasColumnName("flg_talonnworeg");
            entity.Property(e => e.Sort).HasColumnName("sort");
            entity.Property(e => e.User1)
                .HasMaxLength(50)
                .HasColumnName("user1");
        });

        modelBuilder.Entity<TblCheckCourse>(entity =>
        {
            entity.HasKey(e => e.CheckCourseId);

            entity.ToTable("tblCheckCourse");

            entity.Property(e => e.CheckCourseId).HasColumnName("check_course_id");
            entity.Property(e => e.CheckCourseLong)
                .HasMaxLength(100)
                .HasColumnName("check_course_long");
            entity.Property(e => e.CheckCourseShort)
                .HasMaxLength(50)
                .HasColumnName("check_course_short");
            entity.Property(e => e.Datetime1).HasColumnName("datetime1");
            entity.Property(e => e.User1)
                .HasMaxLength(50)
                .HasColumnName("user1");
        });

        modelBuilder.Entity<TblCheckPlace>(entity =>
        {
            entity.HasKey(e => e.CheckPlaceId);

            entity.ToTable("tblCheckPlace");

            entity.Property(e => e.CheckPlaceId).HasColumnName("check_place_id");
            entity.Property(e => e.CheckPlaceLong)
                .HasMaxLength(100)
                .HasColumnName("check_place_long");
            entity.Property(e => e.CheckPlaceShort)
                .HasMaxLength(50)
                .HasColumnName("check_place_short");
            entity.Property(e => e.Datetime1).HasColumnName("datetime1");
            entity.Property(e => e.User1)
                .HasMaxLength(50)
                .HasColumnName("user1");
        });

        modelBuilder.Entity<TblChemop>(entity =>
        {
            entity.HasKey(e => e.ChemopId);

            entity.ToTable("tblChemop");

            entity.Property(e => e.ChemopId).HasColumnName("chemop_id");
            entity.Property(e => e.ChemopLong)
                .HasMaxLength(100)
                .HasColumnName("chemop_long");
            entity.Property(e => e.ChemopShort)
                .HasMaxLength(50)
                .HasColumnName("chemop_short");
            entity.Property(e => e.Datetime1).HasColumnName("datetime1");
            entity.Property(e => e.User1)
                .HasMaxLength(50)
                .HasColumnName("user1");
        });

        modelBuilder.Entity<TblChildCount>(entity =>
        {
            entity.HasKey(e => e.ChildCountId);

            entity.ToTable("tblChildCount");

            entity.Property(e => e.ChildCountId).HasColumnName("child_count_id");
            entity.Property(e => e.ChildCountLong)
                .HasMaxLength(100)
                .HasColumnName("child_count_long");
            entity.Property(e => e.ChildCountShort)
                .HasMaxLength(50)
                .HasColumnName("child_count_short");
        });

        modelBuilder.Entity<TblChildPhp>(entity =>
        {
            entity.HasKey(e => e.ChildPhpId);

            entity.ToTable("tblChildPHP");

            entity.Property(e => e.ChildPhpId).HasColumnName("child_php_id");
            entity.Property(e => e.ChildPhpLong)
                .HasMaxLength(100)
                .HasColumnName("child_php_long");
            entity.Property(e => e.ChildPhpShort)
                .HasMaxLength(50)
                .HasColumnName("child_php_short");
            entity.Property(e => e.Datetime1).HasColumnName("datetime1");
            entity.Property(e => e.User1)
                .HasMaxLength(50)
                .HasColumnName("user1");
        });

        modelBuilder.Entity<TblChildPlace>(entity =>
        {
            entity.HasKey(e => e.ChildPlaceId);

            entity.ToTable("tblChildPlace");

            entity.Property(e => e.ChildPlaceId).HasColumnName("child_place_id");
            entity.Property(e => e.ChildPlaceLong)
                .HasMaxLength(100)
                .HasColumnName("child_place_long");
            entity.Property(e => e.ChildPlaceShort)
                .HasMaxLength(50)
                .HasColumnName("child_place_short");
            entity.Property(e => e.Datetime1).HasColumnName("datetime1");
            entity.Property(e => e.User1)
                .HasMaxLength(50)
                .HasColumnName("user1");
        });

        modelBuilder.Entity<TblCodeMkb10>(entity =>
        {
            entity.HasKey(e => e.CodeMkb10Id);

            entity.ToTable("tblCodeMKB10");

            entity.Property(e => e.CodeMkb10Id).HasColumnName("code_mkb10_id");
            entity.Property(e => e.CodeMkb10Long)
                .HasMaxLength(100)
                .HasColumnName("code_mkb10_long");
            entity.Property(e => e.CodeMkb10Short)
                .HasMaxLength(50)
                .HasColumnName("code_mkb10_short");
            entity.Property(e => e.Datetime1).HasColumnName("datetime1");
            entity.Property(e => e.User1)
                .HasMaxLength(50)
                .HasColumnName("user1");
        });

        modelBuilder.Entity<TblCorrespIllness>(entity =>
        {
            entity.HasKey(e => e.CorrespIllnessId);

            entity.ToTable("tblCorrespIllness");

            entity.Property(e => e.CorrespIllnessId).HasColumnName("corresp_illness_id");
            entity.Property(e => e.CorrespIllnessLong)
                .HasMaxLength(100)
                .HasColumnName("corresp_illness_long");
            entity.Property(e => e.CorrespIllnessShort)
                .HasMaxLength(50)
                .HasColumnName("corresp_illness_short");
            entity.Property(e => e.Datetime1).HasColumnName("datetime1");
            entity.Property(e => e.User1)
                .HasMaxLength(50)
                .HasColumnName("user1");
        });

        modelBuilder.Entity<TblCountry>(entity =>
        {
            entity.HasKey(e => e.CountryId);

            entity.ToTable("tblCountry");

            entity.Property(e => e.CountryId).HasColumnName("country_id");
            entity.Property(e => e.CountryLong)
                .HasMaxLength(100)
                .HasColumnName("country_long");
            entity.Property(e => e.CountryShort)
                .HasMaxLength(50)
                .HasColumnName("country_short");
            entity.Property(e => e.Datetime1).HasColumnName("datetime1");
            entity.Property(e => e.User1)
                .HasMaxLength(50)
                .HasColumnName("user1");
        });

        modelBuilder.Entity<TblCovid>(entity =>
        {
            entity.HasKey(e => e.IdCovid).HasName("PK_tblCOVID_1");

            entity.ToTable("tblCOVID");

            entity.HasIndex(e => e.CovidMkb10, "IX_tblCOVID_covid_MKB10");

            entity.HasIndex(e => e.PatDiagn, "IX_tblCOVID_pat_diagn");

            entity.HasIndex(e => e.PatientId, "IX_tblCOVID_patient_id");

            entity.Property(e => e.IdCovid).HasColumnName("id_covid");
            entity.Property(e => e.Alv).HasColumnName("alv");
            entity.Property(e => e.ArterHyper).HasColumnName("arter_hyper");
            entity.Property(e => e.BronhAstma).HasColumnName("bronh_astma");
            entity.Property(e => e.Cancer).HasColumnName("cancer");
            entity.Property(e => e.ClinVarOfCovid).HasColumnName("clin_var_of_covid");
            entity.Property(e => e.Comment)
                .HasMaxLength(250)
                .IsFixedLength()
                .HasColumnName("comment");
            entity.Property(e => e.CommitmentId).HasColumnName("commitment_id");
            entity.Property(e => e.CoronarySynd).HasColumnName("coronary_synd");
            entity.Property(e => e.CovidMkb10).HasColumnName("covid_MKB10");
            entity.Property(e => e.DDischarge).HasColumnName("d_discharge");
            entity.Property(e => e.DNegativeResCovid).HasColumnName("d_negative_res_covid");
            entity.Property(e => e.DPeriodDes).HasColumnName("d_period_des");
            entity.Property(e => e.DPositivResCovid).HasColumnName("d_positiv_res_covid");
            entity.Property(e => e.DeathCovid).HasColumnName("death_covid");
            entity.Property(e => e.Diabetes).HasColumnName("diabetes");
            entity.Property(e => e.Hobl).HasColumnName("hobl");
            entity.Property(e => e.Hospitalization).HasColumnName("hospitalization");
            entity.Property(e => e.KidneyDes).HasColumnName("kidney_des");
            entity.Property(e => e.Orit).HasColumnName("ORIT");
            entity.Property(e => e.OutcomeHospitalization).HasColumnName("outcome_hospitalization");
            entity.Property(e => e.OutpatTreat).HasColumnName("outpat_treat");
            entity.Property(e => e.Oxygen).HasColumnName("oxygen");
            entity.Property(e => e.PatDiagn).HasColumnName("pat_diagn");
            entity.Property(e => e.PatientId).HasColumnName("patient_id");
            entity.Property(e => e.Pneumonia).HasColumnName("pneumonia");
            entity.Property(e => e.SecDisId).HasColumnName("sec_dis_id");
            entity.Property(e => e.SeverityCourseCovid).HasColumnName("severity_course_covid");
            entity.Property(e => e.Tuberculosis).HasColumnName("tuberculosis");
            entity.Property(e => e.TypeAlv).HasColumnName("type_alv");

            entity.HasOne(d => d.CovidMkb10Navigation).WithMany(p => p.TblCovids)
                .HasForeignKey(d => d.CovidMkb10)
                .HasConstraintName("FK_tblCOVID_tblListMkb10COVID");

            entity.HasOne(d => d.PatDiagnNavigation).WithMany(p => p.TblCovids)
                .HasForeignKey(d => d.PatDiagn)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_tblCOVID_tblPatDiagnosis");

            entity.HasOne(d => d.Patient).WithMany(p => p.TblCovids)
                .HasForeignKey(d => d.PatientId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_tblCOVID_tblPatientCard");
        });

        modelBuilder.Entity<TblCovidVac>(entity =>
        {
            entity.HasKey(e => e.VacId);

            entity.ToTable("tblCOVID_vac");

            entity.HasIndex(e => e.PatientId, "IX_tblCOVID_vac");

            entity.HasIndex(e => e.VacName, "IX_tblCOVID_vac_vac_name");

            entity.Property(e => e.VacId).HasColumnName("vac_id");
            entity.Property(e => e.DVac1).HasColumnName("d_vac1");
            entity.Property(e => e.DVac2).HasColumnName("d_vac2");
            entity.Property(e => e.PatientId).HasColumnName("patient_id");
            entity.Property(e => e.VacName).HasColumnName("vac_name");

            entity.HasOne(d => d.VacNameNavigation).WithMany(p => p.TblCovidVacs)
                .HasForeignKey(d => d.VacName)
                .HasConstraintName("FK_tblCOVID_vac_tblListVac");
        });

        modelBuilder.Entity<TblCureChange>(entity =>
        {
            entity.HasKey(e => e.CureChangeId);

            entity.ToTable("tblCureChange");

            entity.Property(e => e.CureChangeId).HasColumnName("cure_change_id");
            entity.Property(e => e.CureChangeLong)
                .HasMaxLength(100)
                .HasColumnName("cure_change_long");
            entity.Property(e => e.CureChangeShort)
                .HasMaxLength(50)
                .HasColumnName("cure_change_short");
            entity.Property(e => e.Datetime1).HasColumnName("datetime1");
            entity.Property(e => e.User1)
                .HasMaxLength(50)
                .HasColumnName("user1");
        });

        modelBuilder.Entity<TblCureSchema>(entity =>
        {
            entity.HasKey(e => e.CureSchemaId);

            entity.ToTable("tblCureSchema");

            entity.Property(e => e.CureSchemaId).HasColumnName("cure_schema_id");
            entity.Property(e => e.CureSchemaLong)
                .HasMaxLength(100)
                .HasColumnName("cure_schema_long");
            entity.Property(e => e.CureSchemaNoact).HasColumnName("cure_schema_noact");
            entity.Property(e => e.CureSchemaShort)
                .HasMaxLength(50)
                .HasColumnName("cure_schema_short");
            entity.Property(e => e.Datetime1).HasColumnName("datetime1");
            entity.Property(e => e.User1)
                .HasMaxLength(50)
                .HasColumnName("user1");
        });

        modelBuilder.Entity<TblDiagnosis>(entity =>
        {
            entity.HasKey(e => e.DiagnosisId);

            entity.ToTable("tblDiagnosis");

            entity.Property(e => e.DiagnosisId).HasColumnName("diagnosis_id");
            entity.Property(e => e.Datetime1).HasColumnName("datetime1");
            entity.Property(e => e.DiagnosisLong)
                .HasMaxLength(100)
                .HasColumnName("diagnosis_long");
            entity.Property(e => e.DiagnosisShort)
                .HasMaxLength(50)
                .HasColumnName("diagnosis_short");
            entity.Property(e => e.User1)
                .HasMaxLength(50)
                .HasColumnName("user1");
        });

        modelBuilder.Entity<TblDiagnosisCdc>(entity =>
        {
            entity.HasKey(e => e.DiagnosisCdcId);

            entity.ToTable("tblDiagnosisCDC");

            entity.Property(e => e.DiagnosisCdcId).HasColumnName("diagnosis_cdc_id");
            entity.Property(e => e.Datetime1).HasColumnName("datetime1");
            entity.Property(e => e.DiagnosisCdcLong)
                .HasMaxLength(100)
                .HasColumnName("diagnosis_cdc_long");
            entity.Property(e => e.DiagnosisCdcShort)
                .HasMaxLength(50)
                .HasColumnName("diagnosis_cdc_short");
            entity.Property(e => e.User1)
                .HasMaxLength(50)
                .HasColumnName("user1");
        });

        modelBuilder.Entity<TblDieCourse>(entity =>
        {
            entity.HasKey(e => e.DieCourseId);

            entity.ToTable("tblDieCourse");

            entity.Property(e => e.DieCourseId).HasColumnName("die_course_id");
            entity.Property(e => e.Datetime1).HasColumnName("datetime1");
            entity.Property(e => e.DieCourseLong)
                .HasMaxLength(100)
                .HasColumnName("die_course_long");
            entity.Property(e => e.DieCourseShort)
                .HasMaxLength(50)
                .HasColumnName("die_course_short");
            entity.Property(e => e.User1)
                .HasMaxLength(50)
                .HasColumnName("user1");
        });

        modelBuilder.Entity<TblDoctor>(entity =>
        {
            entity.HasKey(e => e.DoctorId);

            entity.ToTable("tblDoctor");

            entity.Property(e => e.DoctorId).HasColumnName("doctor_id");
            entity.Property(e => e.Datetime1).HasColumnName("datetime1");
            entity.Property(e => e.DoctorLong)
                .HasMaxLength(100)
                .HasColumnName("doctor_long");
            entity.Property(e => e.DoctorShort)
                .HasMaxLength(50)
                .HasColumnName("doctor_short");
            entity.Property(e => e.DoctorSnils)
                .HasMaxLength(14)
                .IsFixedLength()
                .HasColumnName("doctor_snils");
            entity.Property(e => e.Ext1Pcod)
                .HasMaxLength(50)
                .HasColumnName("ext1_pcod");
            entity.Property(e => e.SpecId).HasColumnName("spec_id");
            entity.Property(e => e.User1)
                .HasMaxLength(50)
                .HasColumnName("user1");
        });

        modelBuilder.Entity<TblDtype>(entity =>
        {
            entity.HasKey(e => e.DtypeId);

            entity.ToTable("tblDtype");

            entity.Property(e => e.DtypeId).HasColumnName("dtype_id");
            entity.Property(e => e.DtChanged).HasColumnName("dt_changed");
            entity.Property(e => e.DtypeName)
                .HasMaxLength(50)
                .HasColumnName("dtype_name");
            entity.Property(e => e.DtypeTbl)
                .HasMaxLength(50)
                .HasColumnName("dtype_tbl");
        });

        modelBuilder.Entity<TblFamilyType>(entity =>
        {
            entity.HasKey(e => e.FamilyTypeId);

            entity.ToTable("tblFamilyType");

            entity.Property(e => e.FamilyTypeId).HasColumnName("family_type_id");
            entity.Property(e => e.Datetime1).HasColumnName("datetime1");
            entity.Property(e => e.FamilyTypeLong)
                .HasMaxLength(100)
                .HasColumnName("family_type_long");
            entity.Property(e => e.FamilyTypeShort)
                .HasMaxLength(50)
                .HasColumnName("family_type_short");
            entity.Property(e => e.User1)
                .HasMaxLength(50)
                .HasColumnName("user1");
        });

        modelBuilder.Entity<TblFinSource>(entity =>
        {
            entity.HasKey(e => e.FinSourceId);

            entity.ToTable("tblFinSource");

            entity.Property(e => e.FinSourceId).HasColumnName("fin_source_id");
            entity.Property(e => e.Datetime1).HasColumnName("datetime1");
            entity.Property(e => e.FinSourceLong)
                .HasMaxLength(100)
                .HasColumnName("fin_source_long");
            entity.Property(e => e.FinSourceShort)
                .HasMaxLength(50)
                .HasColumnName("fin_source_short");
            entity.Property(e => e.User1)
                .HasMaxLength(50)
                .HasColumnName("user1");
        });

        modelBuilder.Entity<TblHepatitResult>(entity =>
        {
            entity.HasKey(e => e.HepatitResultId);

            entity.ToTable("tblHepatitResult");

            entity.Property(e => e.HepatitResultId).HasColumnName("hepatit_result_id");
            entity.Property(e => e.Datetime1).HasColumnName("datetime1");
            entity.Property(e => e.HepatitResultLong)
                .HasMaxLength(100)
                .HasColumnName("hepatit_result_long");
            entity.Property(e => e.HepatitResultShort)
                .HasMaxLength(50)
                .HasColumnName("hepatit_result_short");
            entity.Property(e => e.User1)
                .HasMaxLength(50)
                .HasColumnName("user1");
        });

        modelBuilder.Entity<TblHepatitResult2>(entity =>
        {
            entity.HasKey(e => e.HepatitResult2Id);

            entity.ToTable("tblHepatitResult2");

            entity.Property(e => e.HepatitResult2Id).HasColumnName("hepatit_result2_id");
            entity.Property(e => e.Datetime1).HasColumnName("datetime1");
            entity.Property(e => e.HepatitResult2Long)
                .HasMaxLength(100)
                .HasColumnName("hepatit_result2_long");
            entity.Property(e => e.HepatitResult2Short)
                .HasMaxLength(50)
                .HasColumnName("hepatit_result2_short");
            entity.Property(e => e.User1)
                .HasMaxLength(50)
                .HasColumnName("user1");
        });

        modelBuilder.Entity<TblHospCourse>(entity =>
        {
            entity.HasKey(e => e.HospCourseId);

            entity.ToTable("tblHospCourse");

            entity.Property(e => e.HospCourseId).HasColumnName("hosp_course_id");
            entity.Property(e => e.Datetime1).HasColumnName("datetime1");
            entity.Property(e => e.HospCourseLong)
                .HasMaxLength(100)
                .HasColumnName("hosp_course_long");
            entity.Property(e => e.HospCourseShort)
                .HasMaxLength(50)
                .HasColumnName("hosp_course_short");
            entity.Property(e => e.User1)
                .HasMaxLength(50)
                .HasColumnName("user1");
        });

        modelBuilder.Entity<TblHospResult>(entity =>
        {
            entity.HasKey(e => e.HospResultId);

            entity.ToTable("tblHospResult");

            entity.Property(e => e.HospResultId).HasColumnName("hosp_result_id");
            entity.Property(e => e.Datetime1).HasColumnName("datetime1");
            entity.Property(e => e.HospResultLong)
                .HasMaxLength(100)
                .HasColumnName("hosp_result_long");
            entity.Property(e => e.HospResultShort)
                .HasMaxLength(50)
                .HasColumnName("hosp_result_short");
            entity.Property(e => e.User1)
                .HasMaxLength(50)
                .HasColumnName("user1");
        });

        modelBuilder.Entity<TblIbResult>(entity =>
        {
            entity.HasKey(e => e.IbResultId);

            entity.ToTable("tblIbResult");

            entity.Property(e => e.IbResultId).HasColumnName("ib_result_id");
            entity.Property(e => e.Datetime1).HasColumnName("datetime1");
            entity.Property(e => e.IbResultLong)
                .HasMaxLength(50)
                .HasColumnName("ib_result_long");
            entity.Property(e => e.IbResultShort)
                .HasMaxLength(3)
                .HasColumnName("ib_result_short");
            entity.Property(e => e.User1)
                .HasMaxLength(50)
                .HasColumnName("user1");
        });

        modelBuilder.Entity<TblImmuneStat>(entity =>
        {
            entity.HasKey(e => e.ImmuneStatId);

            entity.ToTable("tblImmuneStat");

            entity.Property(e => e.ImmuneStatId)
                .ValueGeneratedNever()
                .HasColumnName("immune_stat_id");
            entity.Property(e => e.Comment1)
                .HasMaxLength(255)
                .HasColumnName("comment1");
            entity.Property(e => e.Datetime1).HasColumnName("datetime1");
            entity.Property(e => e.ImmuneStatLong)
                .HasMaxLength(100)
                .HasColumnName("immune_stat_long");
            entity.Property(e => e.ImmuneStatShort)
                .HasMaxLength(50)
                .HasColumnName("immune_stat_short");
            entity.Property(e => e.Max1).HasColumnName("max1");
            entity.Property(e => e.Min1).HasColumnName("min1");
            entity.Property(e => e.User1)
                .HasMaxLength(50)
                .HasColumnName("user1");
        });

        modelBuilder.Entity<TblInfectCourse>(entity =>
        {
            entity.HasKey(e => e.InfectCourseId);

            entity.ToTable("tblInfectCourse");

            entity.Property(e => e.InfectCourseId).HasColumnName("infect_course_id");
            entity.Property(e => e.Datetime1).HasColumnName("datetime1");
            entity.Property(e => e.InfectCourseLong)
                .HasMaxLength(100)
                .HasColumnName("infect_course_long");
            entity.Property(e => e.InfectCourseShort)
                .HasMaxLength(50)
                .HasColumnName("infect_course_short");
            entity.Property(e => e.User1)
                .HasMaxLength(50)
                .HasColumnName("user1");
        });

        modelBuilder.Entity<TblInvalid>(entity =>
        {
            entity.HasKey(e => e.InvalidId);

            entity.ToTable("tblInvalid");

            entity.Property(e => e.InvalidId).HasColumnName("invalid_id");
            entity.Property(e => e.Datetime1).HasColumnName("datetime1");
            entity.Property(e => e.InvalidLong)
                .HasMaxLength(100)
                .HasColumnName("invalid_long");
            entity.Property(e => e.InvalidShort)
                .HasMaxLength(50)
                .HasColumnName("invalid_short");
            entity.Property(e => e.User1)
                .HasMaxLength(50)
                .HasColumnName("user1");
        });

        modelBuilder.Entity<TblJail>(entity =>
        {
            entity.HasKey(e => e.JailId);

            entity.ToTable("tblJail");

            entity.Property(e => e.JailId).HasColumnName("jail_id");
            entity.Property(e => e.Datetime1).HasColumnName("datetime1");
            entity.Property(e => e.JailLong)
                .HasMaxLength(100)
                .HasColumnName("jail_long");
            entity.Property(e => e.JailShort)
                .HasMaxLength(50)
                .HasColumnName("jail_short");
            entity.Property(e => e.MosregYn).HasColumnName("mosregYN");
            entity.Property(e => e.SizoYn).HasColumnName("sizoYN");
            entity.Property(e => e.User1)
                .HasMaxLength(50)
                .HasColumnName("user1");
        });

        modelBuilder.Entity<TblListAvlType>(entity =>
        {
            entity.HasKey(e => e.IdTypeAvl);

            entity.ToTable("tblListAvlType");

            entity.Property(e => e.IdTypeAvl).HasColumnName("id_type_avl");
            entity.Property(e => e.TypeAvlName)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("type_avl_name");
        });

        modelBuilder.Entity<TblListClinVarCovid>(entity =>
        {
            entity.HasKey(e => e.IdClinVarCovid);

            entity.ToTable("tblListClinVarCOVID");

            entity.Property(e => e.IdClinVarCovid).HasColumnName("id_clin_var_COVID");
            entity.Property(e => e.ClinVarCovidName)
                .HasMaxLength(75)
                .IsFixedLength()
                .HasColumnName("clin_var_COVID_name");
        });

        modelBuilder.Entity<TblListCommitment>(entity =>
        {
            entity.HasKey(e => e.IdCommitment);

            entity.ToTable("tblListCommitment");

            entity.Property(e => e.IdCommitment).HasColumnName("id_commitment");
            entity.Property(e => e.CommitmentName)
                .HasMaxLength(50)
                .IsFixedLength()
                .HasColumnName("commitment_name");
        });

        modelBuilder.Entity<TblListCourseCovid>(entity =>
        {
            entity.HasKey(e => e.IdCourseCovid);

            entity.ToTable("tblListCourseCOVID");

            entity.Property(e => e.IdCourseCovid).HasColumnName("id_course_COVID");
            entity.Property(e => e.CourseCovidName)
                .HasMaxLength(50)
                .IsFixedLength()
                .HasColumnName("course_COVID_name");
        });

        modelBuilder.Entity<TblListEducation>(entity =>
        {
            entity.HasKey(e => e.EducationId);

            entity.ToTable("tblListEducation");

            entity.Property(e => e.EducationId)
                .ValueGeneratedNever()
                .HasColumnName("education_id");
            entity.Property(e => e.EduName)
                .HasMaxLength(50)
                .IsFixedLength()
                .HasColumnName("edu_name");
        });

        modelBuilder.Entity<TblListEmloyment>(entity =>
        {
            entity.HasKey(e => e.EmploymentId);

            entity.ToTable("tblListEmloyment");

            entity.Property(e => e.EmploymentId)
                .ValueGeneratedNever()
                .HasColumnName("employment_id");
            entity.Property(e => e.EmploymentName)
                .HasMaxLength(50)
                .IsFixedLength()
                .HasColumnName("employment_name");
        });

        modelBuilder.Entity<TblListEpidDoctor>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("tblListEpidDoctors");

            entity.Property(e => e.DoctorName)
                .HasMaxLength(50)
                .IsFixedLength()
                .HasColumnName("doctor_name");
            entity.Property(e => e.DoctorSnils)
                .HasMaxLength(14)
                .IsFixedLength()
                .HasColumnName("doctor_snils");
            entity.Property(e => e.IdDoctor).HasColumnName("id_doctor");
        });

        modelBuilder.Entity<TblListFamilyStatus>(entity =>
        {
            entity.HasKey(e => e.FamilyStatusId);

            entity.ToTable("tblListFamilyStatus");

            entity.Property(e => e.FamilyStatusId)
                .ValueGeneratedNever()
                .HasColumnName("family_status_id");
            entity.Property(e => e.FammilyStatusName)
                .HasMaxLength(50)
                .IsFixedLength()
                .HasColumnName("fammily_status_name");
        });

        modelBuilder.Entity<TblListFullMkb10>(entity =>
        {
            entity.HasKey(e => e.DieCourseId);

            entity.ToTable("tblListFullMKB10");

            entity.Property(e => e.DieCourseId)
                .ValueGeneratedNever()
                .HasColumnName("die_course_id");
            entity.Property(e => e.Datetime1).HasColumnName("datetime1");
            entity.Property(e => e.DieCourseLong)
                .HasMaxLength(100)
                .HasColumnName("die_course_long");
            entity.Property(e => e.DieCourseShort)
                .HasMaxLength(50)
                .HasColumnName("die_course_short");
            entity.Property(e => e.User1)
                .HasMaxLength(50)
                .IsFixedLength()
                .HasColumnName("user1");
        });

        modelBuilder.Entity<TblListMkb10Covid>(entity =>
        {
            entity.HasKey(e => e.Mkb10Id);

            entity.ToTable("tblListMkb10COVID");

            entity.Property(e => e.Mkb10Id)
                .ValueGeneratedNever()
                .HasColumnName("MKB10_id");
            entity.Property(e => e.Mkb10LongName)
                .HasMaxLength(100)
                .IsFixedLength()
                .HasColumnName("mkb10_long_name");
            entity.Property(e => e.Mkb10ShortName)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("MKB10_sort_name");
        });

        modelBuilder.Entity<TblListMkbPneumonium>(entity =>
        {
            entity.HasKey(e => e.IdPneumonia);

            entity.ToTable("tblListMkbPneumonia");

            entity.Property(e => e.IdPneumonia).HasColumnName("id_pneumonia");
            entity.Property(e => e.PneumoniaNameLong)
                .HasMaxLength(100)
                .IsFixedLength()
                .HasColumnName("pneumonia_name_long");
            entity.Property(e => e.PneumoniaNameShort)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("pneumonia_name_short");
        });

        modelBuilder.Entity<TblListMkbTuder>(entity =>
        {
            entity.HasKey(e => e.IdTuder);

            entity.ToTable("tblListMkbTuder");

            entity.Property(e => e.IdTuder).HasColumnName("id_tuder");
            entity.Property(e => e.TuberNameLong)
                .HasMaxLength(100)
                .IsFixedLength()
                .HasColumnName("tuber_name_long");
            entity.Property(e => e.TuberNameShort)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("tuber_name_short");
        });

        modelBuilder.Entity<TblListOutHosp>(entity =>
        {
            entity.HasKey(e => e.IdHosp);

            entity.ToTable("tblListOutHosp");

            entity.Property(e => e.IdHosp).HasColumnName("id_hosp");
            entity.Property(e => e.HospName)
                .HasMaxLength(50)
                .IsFixedLength()
                .HasColumnName("hosp_name");
        });

        modelBuilder.Entity<TblListPlaceCheck>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("tblListPlaceCheck");

            entity.Property(e => e.PlaceCheckId).HasColumnName("place_check_id");
            entity.Property(e => e.PlaceCheckName)
                .HasMaxLength(100)
                .IsFixedLength()
                .HasColumnName("place_check_name");
        });

        modelBuilder.Entity<TblListSituationDetect>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("tblListSituationDetect");

            entity.Property(e => e.SituationDetectId).HasColumnName("situation_detect_id");
            entity.Property(e => e.SituationDetectName)
                .HasMaxLength(75)
                .IsFixedLength()
                .HasColumnName("situation_detect_name");
        });

        modelBuilder.Entity<TblListTran>(entity =>
        {
            entity.HasKey(e => e.TransId);

            entity.ToTable("tblListTrans");

            entity.Property(e => e.TransId)
                .ValueGeneratedNever()
                .HasColumnName("trans_id");
            entity.Property(e => e.TransName)
                .HasMaxLength(3)
                .IsFixedLength()
                .HasColumnName("trans_name");
        });

        modelBuilder.Entity<TblListTransmisionMech>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("tblListTransmisionMech");

            entity.Property(e => e.TransmisiomMechName)
                .HasMaxLength(100)
                .IsFixedLength()
                .HasColumnName("transmisiom_mech_name");
            entity.Property(e => e.TransmissionMechId).HasColumnName("transmission_mech_id");
        });

        modelBuilder.Entity<TblListVac>(entity =>
        {
            entity.HasKey(e => e.VacId);

            entity.ToTable("tblListVac");

            entity.Property(e => e.VacId)
                .ValueGeneratedNever()
                .HasColumnName("vac_id");
            entity.Property(e => e.VacName)
                .HasMaxLength(100)
                .IsFixedLength()
                .HasColumnName("vac_name");
        });

        modelBuilder.Entity<TblListVulnerableGroup>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("tblListVulnerableGroup");

            entity.Property(e => e.VulnerableGroupId).HasColumnName("vulnerable_group_id");
            entity.Property(e => e.VulnerableGroupName)
                .HasMaxLength(100)
                .IsFixedLength()
                .HasColumnName("vulnerable_group_name");
        });

        modelBuilder.Entity<TblListYn>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("tblListYN");

            entity.Property(e => e.IdYN).HasColumnName("id_y_n");
            entity.Property(e => e.YNName)
                .HasMaxLength(3)
                .IsFixedLength()
                .HasColumnName("y_n_name");
        });

        modelBuilder.Entity<TblLpu>(entity =>
        {
            entity.HasKey(e => e.LpuId);

            entity.ToTable("tblLpu");

            entity.Property(e => e.LpuId).HasColumnName("lpu_id");
            entity.Property(e => e.Datetime1).HasColumnName("datetime1");
            entity.Property(e => e.LpuLong)
                .HasMaxLength(100)
                .HasColumnName("lpu_long");
            entity.Property(e => e.LpuShort)
                .HasMaxLength(50)
                .HasColumnName("lpu_short");
            entity.Property(e => e.User1)
                .HasMaxLength(50)
                .HasColumnName("user1");
        });

        modelBuilder.Entity<TblMaterHome>(entity =>
        {
            entity.HasKey(e => e.MaterhomeId);

            entity.ToTable("tblMaterHome");

            entity.Property(e => e.MaterhomeId).HasColumnName("materhome_id");
            entity.Property(e => e.Datetime1).HasColumnName("datetime1");
            entity.Property(e => e.MaterhomeLong)
                .HasMaxLength(100)
                .HasColumnName("materhome_long");
            entity.Property(e => e.MaterhomeShort)
                .HasMaxLength(50)
                .HasColumnName("materhome_short");
            entity.Property(e => e.User1)
                .HasMaxLength(50)
                .HasColumnName("user1");
        });

        modelBuilder.Entity<TblMedicine>(entity =>
        {
            entity.HasKey(e => e.MedicineId);

            entity.ToTable("tblMedicine");

            entity.Property(e => e.MedicineId).HasColumnName("medicine_id");
            entity.Property(e => e.Datetime1).HasColumnName("datetime1");
            entity.Property(e => e.KorvetId)
                .HasMaxLength(255)
                .HasColumnName("korvet_id");
            entity.Property(e => e.MedicineLong)
                .HasMaxLength(255)
                .HasColumnName("medicine_long");
            entity.Property(e => e.MedicineShort)
                .HasMaxLength(50)
                .HasColumnName("medicine_short");
            entity.Property(e => e.User1)
                .HasMaxLength(50)
                .HasColumnName("user1");
        });

        modelBuilder.Entity<TblMedicineForSchema>(entity =>
        {
            entity.HasKey(e => e.MedforschemaId);

            entity.ToTable("tblMedicineForSchema");

            entity.Property(e => e.MedforschemaId).HasColumnName("medforschema_id");
            entity.Property(e => e.Datetime1).HasColumnName("datetime1");
            entity.Property(e => e.MedforschemaChild).HasColumnName("medforschema_child");
            entity.Property(e => e.MedforschemaLong)
                .HasMaxLength(100)
                .HasColumnName("medforschema_long");
            entity.Property(e => e.MedforschemaShort)
                .HasMaxLength(50)
                .HasColumnName("medforschema_short");
            entity.Property(e => e.User1)
                .HasMaxLength(50)
                .HasColumnName("user1");
        });

        modelBuilder.Entity<TblMessage>(entity =>
        {
            entity.HasKey(e => e.Mesid);

            entity.ToTable("tblMessage");

            entity.Property(e => e.Mesid)
                .ValueGeneratedNever()
                .HasColumnName("MESID");
            entity.Property(e => e.Mestxt)
                .HasMaxLength(255)
                .HasColumnName("MESTXT");
        });

        modelBuilder.Entity<TblMonth>(entity =>
        {
            entity.HasKey(e => e.MonthId);

            entity.ToTable("tblMonth");

            entity.Property(e => e.MonthId).HasColumnName("month_id");
            entity.Property(e => e.Datetime1).HasColumnName("datetime1");
            entity.Property(e => e.MonthLong)
                .HasMaxLength(8)
                .HasColumnName("month_long");
            entity.Property(e => e.MonthShort)
                .HasMaxLength(3)
                .HasColumnName("month_short");
            entity.Property(e => e.User1)
                .HasMaxLength(50)
                .HasColumnName("user1");
        });

        modelBuilder.Entity<TblPatDiagnosis>(entity =>
        {
            entity.HasKey(e => e.IdPatDiagnos);

            entity.ToTable("tblPatDiagnosis");

            entity.Property(e => e.IdPatDiagnos).HasColumnName("id_pat_diagnos");
            entity.Property(e => e.IdMkbPatDiag).HasColumnName("id_MKB_pat_diag");
            entity.Property(e => e.PatDiagCom)
                .HasMaxLength(100)
                .IsFixedLength()
                .HasColumnName("pat_diag_com");
            entity.Property(e => e.PatientId).HasColumnName("patient_id");
        });

        modelBuilder.Entity<TblPatientAclResult>(entity =>
        {
            entity.HasKey(e => new { e.PatientId, e.AclTestCode, e.AclSampleDate });

            entity.ToTable("tblPatientAclResult");

            entity.HasIndex(e => e.AclSampleDate, "INDX_sample_date");

            entity.Property(e => e.PatientId).HasColumnName("patient_id");
            entity.Property(e => e.AclTestCode)
                .HasMaxLength(50)
                .HasColumnName("acl_test_code");
            entity.Property(e => e.AclSampleDate).HasColumnName("acl_sample_date");
            entity.Property(e => e.AclMcnCode)
                .HasMaxLength(50)
                .HasColumnName("acl_mcn_code");
            entity.Property(e => e.AclRefmax)
                .HasMaxLength(50)
                .HasColumnName("acl_refmax");
            entity.Property(e => e.AclRefmin)
                .HasMaxLength(50)
                .HasColumnName("acl_refmin");
            entity.Property(e => e.AclResult)
                .HasMaxLength(50)
                .HasColumnName("acl_result");
            entity.Property(e => e.AclSpecimen)
                .HasMaxLength(50)
                .HasColumnName("acl_specimen");
            entity.Property(e => e.AclUnits)
                .HasMaxLength(50)
                .HasColumnName("acl_units");
            entity.Property(e => e.Datetime1).HasColumnName("datetime1");
            entity.Property(e => e.User1)
                .HasMaxLength(50)
                .HasColumnName("user1");
        });

        modelBuilder.Entity<TblPatientBiochem>(entity =>
        {
            entity.HasKey(e => new { e.PatientId, e.BiochemId });

            entity.ToTable("tblPatientBiochem");

            entity.HasIndex(e => e.BiochemId, "IX_tblPatientBiochem_biochem_id");

            entity.Property(e => e.PatientId).HasColumnName("patient_id");
            entity.Property(e => e.BiochemId).HasColumnName("biochem_id");
            entity.Property(e => e.BiochemValue).HasColumnName("biochem_value");
            entity.Property(e => e.Datetime1).HasColumnName("datetime1");
            entity.Property(e => e.User1)
                .HasMaxLength(50)
                .HasColumnName("user1");

            entity.HasOne(d => d.Biochem).WithMany(p => p.TblPatientBiochems)
                .HasForeignKey(d => d.BiochemId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_tblPatientBiochem_tblBiochem");

            entity.HasOne(d => d.Patient).WithMany(p => p.TblPatientBiochems)
                .HasForeignKey(d => d.PatientId)
                .HasConstraintName("FK_tblPatientBiochem_tblPatientCard");
        });

        modelBuilder.Entity<TblPatientBlot>(entity =>
        {
            entity.HasKey(e => new { e.PatientId, e.BlotId });

            entity.ToTable("tblPatientBlot");

            entity.HasIndex(e => e.CheckPlaceId, "IX_tblPatientBlot_check_place_id");

            entity.HasIndex(e => e.IbResultId, "IX_tblPatientBlot_ib_result_id");

            entity.Property(e => e.PatientId).HasColumnName("patient_id");
            entity.Property(e => e.BlotId).HasColumnName("blot_id");
            entity.Property(e => e.BlotDate).HasColumnName("blot_date");
            entity.Property(e => e.BlotNo).HasColumnName("blot_no");
            entity.Property(e => e.CheckPlaceId).HasColumnName("check_place_id");
            entity.Property(e => e.Datetime1).HasColumnName("datetime1");
            entity.Property(e => e.First1).HasColumnName("first1");
            entity.Property(e => e.FlgIfa).HasColumnName("flg_ifa");
            entity.Property(e => e.IbResultId).HasColumnName("ib_result_id");
            entity.Property(e => e.Last1).HasColumnName("last1");
            entity.Property(e => e.User1)
                .HasMaxLength(50)
                .HasColumnName("user1");
            entity.Property(e => e.VnResultId).HasColumnName("vn_result_id");

            entity.HasOne(d => d.CheckPlace).WithMany(p => p.TblPatientBlots)
                .HasForeignKey(d => d.CheckPlaceId)
                .HasConstraintName("FK_tblPatientBlot_tblCheckPlace");

            entity.HasOne(d => d.IbResult).WithMany(p => p.TblPatientBlots)
                .HasForeignKey(d => d.IbResultId)
                .HasConstraintName("FK_tblPatientBlot_tblIbResult");
        });

        modelBuilder.Entity<TblPatientCard>(entity =>
        {
            entity.HasKey(e => e.PatientId);

            entity.ToTable("tblPatientCard");

            entity.HasIndex(e => e.Aids12Id, "IX_tblPatientCard_aids12_id");
            entity.HasIndex(e => e.ArvtId, "IX_tblPatientCard_arvt_id");
            entity.HasIndex(e => e.CheckCourseId, "IX_tblPatientCard_check_course_id");
            entity.HasIndex(e => e.ChildPhpId, "IX_tblPatientCard_child_php_id");
            entity.HasIndex(e => e.ChildPlaceId, "IX_tblPatientCard_child_place_id");
            entity.HasIndex(e => e.CodeMkb10Id, "IX_tblPatientCard_code_mkb10_id");
            entity.HasIndex(e => e.CountryId, "IX_tblPatientCard_country_id");
            entity.HasIndex(e => e.DieCourseId, "IX_tblPatientCard_die_course_id");
            entity.HasIndex(e => e.FamilyTypeId, "IX_tblPatientCard_family_type_id");
            entity.HasIndex(e => e.FatherPatientId, "IX_tblPatientCard_father_patient_id");
            entity.HasIndex(e => e.InfectCourseId, "IX_tblPatientCard_infect_course_id");
            entity.HasIndex(e => e.InvalidId, "IX_tblPatientCard_invalid_id");
            entity.HasIndex(e => e.JailId, "IX_tblPatientCard_jail_id");
            entity.HasIndex(e => e.JailedOffRegionId, "IX_tblPatientCard_jailed_off_region_id");
            entity.HasIndex(e => e.MaterhomeId, "IX_tblPatientCard_materhome_id");
            entity.HasIndex(e => e.MotherPatientId, "IX_tblPatientCard_mother_patient_id");
            entity.HasIndex(e => e.PregCheckId, "IX_tblPatientCard_preg_check_id");
            entity.HasIndex(e => e.RegionId, "IX_tblPatientCard_region_id");
            entity.HasIndex(e => e.RegistId, "IX_tblPatientCard_regist_id");
            entity.HasIndex(e => e.SexId, "IX_tblPatientCard_sex_id");
            entity.HasIndex(e => e.StatusId, "IX_tblPatientCard_status_id");

            entity.Property(e => e.PatientId).HasColumnName("patient_id");
            entity.Property(e => e.Added).HasColumnName("added");
            entity.Property(e => e.AddrExt)
                .HasMaxLength(50)
                .HasColumnName("addr_ext");
            entity.Property(e => e.AddrFlat)
                .HasMaxLength(50)
                .HasColumnName("addr_flat");
            entity.Property(e => e.AddrHouse)
                .HasMaxLength(50)
                .HasColumnName("addr_house");
            entity.Property(e => e.AddrInd)
                .HasMaxLength(50)
                .HasColumnName("addr_ind");
            entity.Property(e => e.AddrName)
                .HasMaxLength(100)
                .HasColumnName("addr_name");
            entity.Property(e => e.AddrNameRed).HasColumnName("addr_name_red");
            entity.Property(e => e.AddrStreet)
                .HasMaxLength(50)
                .HasColumnName("addr_street");
            entity.Property(e => e.Aids12Id).HasColumnName("aids12_id");
            entity.Property(e => e.ArvtId).HasColumnName("arvt_id");
            entity.Property(e => e.ArvtgetYn).HasColumnName("arvtgetYN");
            entity.Property(e => e.BirthDate).HasColumnName("birth_date");
            entity.Property(e => e.BreastMonthNo).HasColumnName("breast_month_no");
            entity.Property(e => e.CallingDistrictSpecDate).HasColumnName("calling_district_spec_date");
            entity.Property(e => e.CardNo)
                .HasMaxLength(50)
                .HasColumnName("card_no");
            entity.Property(e => e.CheckCourseId).HasColumnName("check_course_id");
            entity.Property(e => e.CheckFirstDate).HasColumnName("check_first_date");
            entity.Property(e => e.ChildDescr)
                .HasMaxLength(255)
                .HasColumnName("child_descr");
            entity.Property(e => e.ChildPhpId).HasColumnName("child_php_id");
            entity.Property(e => e.ChildPlaceId).HasColumnName("child_place_id");
            entity.Property(e => e.CityName)
                .HasMaxLength(100)
                .HasColumnName("city_name");
            entity.Property(e => e.CodeMkb10Id).HasColumnName("code_mkb10_id");
            entity.Property(e => e.Codeword)
                .HasMaxLength(50)
                .HasColumnName("codeword");
            entity.Property(e => e.CommunicationParentDate).HasColumnName("communication_parent_date");
            entity.Property(e => e.CountryId).HasColumnName("country_id");
            entity.Property(e => e.Datetime1).HasColumnName("datetime1");
            entity.Property(e => e.DefineBiochemDate).HasColumnName("define_biochem_date");
            entity.Property(e => e.DefineImmuneDate).HasColumnName("define_immune_date");
            entity.Property(e => e.DefineResistDate).HasColumnName("define_resist_date");
            entity.Property(e => e.DefineVirusDate).HasColumnName("define_virus_date");
            entity.Property(e => e.DiagnosisCdcId).HasColumnName("diagnosis_cdc_id");
            entity.Property(e => e.DiagnosisDefDate).HasColumnName("diagnosis_def_date");
            entity.Property(e => e.DiagnosisId).HasColumnName("diagnosis_id");
            entity.Property(e => e.DieAidsDate).HasColumnName("die_aids_date");
            entity.Property(e => e.DieCourseId).HasColumnName("die_course_id");
            entity.Property(e => e.DieCourseId1).HasColumnName("die_course_id1");
            entity.Property(e => e.DieCourseId2).HasColumnName("die_course_id2");
            entity.Property(e => e.DieCourseId3).HasColumnName("die_course_id3");
            entity.Property(e => e.DieCourseId4).HasColumnName("die_course_id4");
            entity.Property(e => e.DieCourseId5).HasColumnName("die_course_id5");
            entity.Property(e => e.DieDate).HasColumnName("die_date");
            entity.Property(e => e.DieDateInput).HasColumnName("die_date_input");
            entity.Property(e => e.DtMailReg).HasColumnName("dt_mail_reg");
            entity.Property(e => e.DtRegBeg).HasColumnName("dt_reg_beg");
            entity.Property(e => e.DtRegEnd).HasColumnName("dt_reg_end");
            entity.Property(e => e.EduId).HasColumnName("edu_id");
            entity.Property(e => e.EmploymentId).HasColumnName("employment_id");
            entity.Property(e => e.EpidDocId).HasColumnName("epid_doc_id");
            entity.Property(e => e.FlgDiagnosisAfterDeath).HasColumnName("flg_diagnosis_after_death");
            entity.Property(e => e.EpidemDescr)
                .HasMaxLength(255)
                .HasColumnName("epidem_descr");
            entity.Property(e => e.EpidemTimeInfect).HasColumnName("epidem_time_infect");
            entity.Property(e => e.EpidemTimeInfectEnd).HasColumnName("epidem_time_infect_end");
            entity.Property(e => e.EpidemTimeInfectStart).HasColumnName("epidem_time_infect_start");
            entity.Property(e => e.FactAddrExt)
                .HasMaxLength(50)
                .HasColumnName("fact_addr_ext");
            entity.Property(e => e.FactAddrFlat)
                .HasMaxLength(50)
                .HasColumnName("fact_addr_flat");
            entity.Property(e => e.FactAddrHouse)
                .HasMaxLength(50)
                .HasColumnName("fact_addr_house");
            entity.Property(e => e.FactAddrInd)
                .HasMaxLength(50)
                .HasColumnName("fact_addr_ind");
            entity.Property(e => e.FactAddrStreet)
                .HasMaxLength(50)
                .HasColumnName("fact_addr_street");
            entity.Property(e => e.FactCityName)
                .HasMaxLength(100)
                .HasColumnName("fact_city_name");
            entity.Property(e => e.FactLocationName)
                .HasMaxLength(100)
                .HasColumnName("fact_location_name");
            entity.Property(e => e.FactRegionId).HasColumnName("fact_region_id");
            entity.Property(e => e.FamilyName)
                .HasMaxLength(100)
                .HasColumnName("family_name");
            entity.Property(e => e.FamilyStatusId).HasColumnName("family_status_id");
            entity.Property(e => e.FamilyTypeId).HasColumnName("family_type_id");
            entity.Property(e => e.FatherPatientId).HasColumnName("father_patient_id");
            entity.Property(e => e.FioChange)
                .HasMaxLength(255)
                .HasColumnName("fio_change");
            entity.Property(e => e.FirstName)
                .HasMaxLength(100)
                .HasColumnName("first_name");
            entity.Property(e => e.FlgHeadPhysician).HasColumnName("flg_head_physician");
            entity.Property(e => e.FlgInstVirus).HasColumnName("flg_inst_virus");
            entity.Property(e => e.FlgZamMedPart).HasColumnName("flg_zam_med_part");
            entity.Property(e => e.Forma309).HasColumnName("forma_309");
            entity.Property(e => e.Growth)
                .HasPrecision(5, 2)
                .HasColumnName("growth");
            entity.Property(e => e.HeightOld)
                .HasPrecision(7, 2)
                .HasColumnName("height_old");
            entity.Property(e => e.InfectCourseId).HasColumnName("infect_course_id");
            entity.Property(e => e.InputDate).HasColumnName("input_date");
            entity.Property(e => e.InvalidId).HasColumnName("invalid_id");
            entity.Property(e => e.JailId).HasColumnName("jail_id");
            entity.Property(e => e.JailedOffDate).HasColumnName("jailed_off_date");
            entity.Property(e => e.JailedOffRegionId).HasColumnName("jailed_off_region_id");
            entity.Property(e => e.LetterCareDate).HasColumnName("letter_care_date");
            entity.Property(e => e.LocationName)
                .HasMaxLength(100)
                .HasColumnName("location_name");
            entity.Property(e => e.MaterhomeId).HasColumnName("materhome_id");
            entity.Property(e => e.MotherPatientId).HasColumnName("mother_patient_id");
            entity.Property(e => e.NumMail)
                .HasMaxLength(50)
                .IsFixedLength()
                .HasColumnName("num_mail");
            entity.Property(e => e.OmsNum)
                .HasMaxLength(50)
                .HasColumnName("oms_num");
            entity.Property(e => e.OmsSer)
                .HasMaxLength(50)
                .HasColumnName("oms_ser");
            entity.Property(e => e.OmsWhen).HasColumnName("oms_when");
            entity.Property(e => e.OtherYn).HasColumnName("otherYN");
            entity.Property(e => e.PasNum)
                .HasMaxLength(50)
                .HasColumnName("pas_num");
            entity.Property(e => e.PasSer)
                .HasMaxLength(50)
                .HasColumnName("pas_ser");
            entity.Property(e => e.PasWhen).HasColumnName("pas_when");
            entity.Property(e => e.PasWhom)
                .HasMaxLength(50)
                .HasColumnName("pas_whom");
            entity.Property(e => e.PatientDescr)
                .HasMaxLength(255)
                .HasColumnName("patient_descr");
            entity.Property(e => e.PlaceCheckId).HasColumnName("place_check_id");
            entity.Property(e => e.PregCheckId).HasColumnName("preg_check_id");
            entity.Property(e => e.PregExtrYn).HasColumnName("preg_extrYN");
            entity.Property(e => e.PregMonthNo).HasColumnName("preg_month_no");
            entity.Property(e => e.RefusalPhp).HasColumnName("refusal_php");
            entity.Property(e => e.RefusalResearch).HasColumnName("refusal_research");
            entity.Property(e => e.RefusalTherapy).HasColumnName("refusal_therapy");
            entity.Property(e => e.RegOffDate).HasColumnName("reg_off_date");
            entity.Property(e => e.RegOffReason).HasColumnName("reg_off_reason");
            entity.Property(e => e.RegOnCheck1).HasColumnName("reg_on_check1");
            entity.Property(e => e.RegOnDate).HasColumnName("reg_on_date");
            entity.Property(e => e.RegionId).HasColumnName("region_id");
            entity.Property(e => e.RegistId).HasColumnName("regist_id");
            entity.Property(e => e.SexId).HasColumnName("sex_id");
            entity.Property(e => e.SituationtDetectId).HasColumnName("situationt_detect_id");
            entity.Property(e => e.Snils)
                .HasMaxLength(50)
                .HasColumnName("snils");
            entity.Property(e => e.SnilsFed)
                .HasMaxLength(50)
                .HasColumnName("snils_fed");
            entity.Property(e => e.StageDescr)
                .HasMaxLength(255)
                .HasColumnName("stage_descr");
            entity.Property(e => e.StatusId).HasColumnName("status_id");
            entity.Property(e => e.ThirdName)
                .HasMaxLength(100)
                .HasColumnName("third_name");
            entity.Property(e => e.TransId).HasColumnName("trans_id");
            entity.Property(e => e.TransfAreaDate).HasColumnName("transf_area_date");
            entity.Property(e => e.TransfAreaFlg).HasColumnName("transf_area_flg");
            entity.Property(e => e.TransfFederDate).HasColumnName("transf_feder_date");
            entity.Property(e => e.TransmitionMechId).HasColumnName("transmition_mech_id");
            entity.Property(e => e.UfsinDate).HasColumnName("ufsin_date");
            entity.Property(e => e.Uidpatient).HasColumnName("UIDpatient");
            entity.Property(e => e.UnrzFr).HasColumnName("unrz_fr_");
            entity.Property(e => e.UnrzFr1)
                .HasMaxLength(50)
                .IsFixedLength()
                .HasColumnName("unrz_fr");
            entity.Property(e => e.User1)
                .HasMaxLength(50)
                .HasColumnName("user1");
            entity.Property(e => e.VirusLoad).HasColumnName("virus_load");
            entity.Property(e => e.VulnerableGroupId).HasColumnName("vulnerable_group_id");
            entity.Property(e => e.Weight)
                .HasPrecision(5, 2)
                .HasColumnName("weight");
            entity.Property(e => e.WeightOld)
                .HasPrecision(7, 2)
                .HasColumnName("weight_old");
            entity.Property(e => e.IsActive)
                .HasColumnName("is_active");

            entity.HasOne(d => d.Aids12).WithMany(p => p.TblPatientCards)
                .HasForeignKey(d => d.Aids12Id)
                .HasConstraintName("FK_tblPatientCard_tblAids12");

            entity.HasOne(d => d.Arvt).WithMany(p => p.TblPatientCards)
                .HasForeignKey(d => d.ArvtId)
                .HasConstraintName("FK_tblPatientCard_tblArvt");

            entity.HasOne(d => d.CheckCourse).WithMany(p => p.TblPatientCards)
                .HasForeignKey(d => d.CheckCourseId)
                .HasConstraintName("FK_tblPatientCard_tblCheckCourse");

            entity.HasOne(d => d.ChildPhp).WithMany(p => p.TblPatientCards)
                .HasForeignKey(d => d.ChildPhpId)
                .HasConstraintName("FK_tblPatientCard_tblChildPHP");

            entity.HasOne(d => d.ChildPlace).WithMany(p => p.TblPatientCards)
                .HasForeignKey(d => d.ChildPlaceId)
                .HasConstraintName("FK_tblPatientCard_tblChildPlace");

            entity.HasOne(d => d.CodeMkb10).WithMany(p => p.TblPatientCards)
                .HasForeignKey(d => d.CodeMkb10Id)
                .HasConstraintName("FK_tblPatientCard_tblCodeMKB10");

            entity.HasOne(d => d.Country).WithMany(p => p.TblPatientCards)
                .HasForeignKey(d => d.CountryId)
                .HasConstraintName("FK_tblPatientCard_tblCountry");

            entity.HasOne(d => d.DieCourse).WithMany(p => p.TblPatientCards)
                .HasForeignKey(d => d.DieCourseId)
                .HasConstraintName("FK_tblPatientCard_tblDieCourse");

            entity.HasOne(d => d.FamilyType).WithMany(p => p.TblPatientCards)
                .HasForeignKey(d => d.FamilyTypeId)
                .HasConstraintName("FK_tblPatientCard_tblFamilyType");

            entity.HasOne(d => d.FatherPatient).WithMany(p => p.InverseFatherPatient)
                .HasForeignKey(d => d.FatherPatientId)
                .HasConstraintName("FK_tblPatientCard_tblPatientCard1");

            entity.HasOne(d => d.InfectCourse).WithMany(p => p.TblPatientCards)
                .HasForeignKey(d => d.InfectCourseId)
                .HasConstraintName("FK_tblPatientCard_tblInfectCourse");

            entity.HasOne(d => d.Invalid).WithMany(p => p.TblPatientCards)
                .HasForeignKey(d => d.InvalidId)
                .HasConstraintName("FK_tblPatientCard_tblInvalid");

            entity.HasOne(d => d.Jail).WithMany(p => p.TblPatientCards)
                .HasForeignKey(d => d.JailId)
                .HasConstraintName("FK_tblPatientCard_tblJail");

            entity.HasOne(d => d.JailedOffRegion).WithMany(p => p.TblPatientCardJailedOffRegions)
                .HasForeignKey(d => d.JailedOffRegionId)
                .HasConstraintName("FK_tblPatientCard_tblRegion1");

            entity.HasOne(d => d.Materhome).WithMany(p => p.TblPatientCards)
                .HasForeignKey(d => d.MaterhomeId)
                .HasConstraintName("FK_tblPatientCard_tblMaterHome");

            entity.HasOne(d => d.MotherPatient).WithMany(p => p.InverseMotherPatient)
                .HasForeignKey(d => d.MotherPatientId)
                .HasConstraintName("FK_tblPatientCard_tblPatientCard");

            entity.HasOne(d => d.PregCheck).WithMany(p => p.TblPatientCards)
                .HasForeignKey(d => d.PregCheckId)
                .HasConstraintName("FK_tblPatientCard_tblPregCheck");

            entity.HasOne(d => d.Region).WithMany(p => p.TblPatientCardRegions)
                .HasForeignKey(d => d.RegionId)
                .HasConstraintName("FK_tblPatientCard_tblRegion");

            entity.HasOne(d => d.Regist).WithMany(p => p.TblPatientCards)
                .HasForeignKey(d => d.RegistId)
                .HasConstraintName("FK_tblPatientCard_tblRegist");

            entity.HasOne(d => d.Sex).WithMany(p => p.TblPatientCards)
                .HasForeignKey(d => d.SexId)
                .HasConstraintName("FK_tblPatientCard_tblSex");

            entity.HasOne(d => d.Status).WithMany(p => p.TblPatientCards)
                .HasForeignKey(d => d.StatusId)
                .HasConstraintName("FK_tblPatientCard_tblStatus");
        });

        modelBuilder.Entity<TblPatientCheck>(entity =>
        {
            entity.HasKey(e => new { e.PatientId, e.CheckDate, e.CheckSpecId });

            entity.ToTable("tblPatientCheck");

            entity.HasIndex(e => e.CheckDoctorId, "IX_tblPatientCheck_check_doctor_id");

            entity.HasIndex(e => e.CheckSpecId, "IX_tblPatientCheck_check_spec_id");

            entity.Property(e => e.PatientId).HasColumnName("patient_id");
            entity.Property(e => e.CheckDate).HasColumnName("check_date");
            entity.Property(e => e.CheckSpecId).HasColumnName("check_spec_id");
            entity.Property(e => e.CheckDateNext).HasColumnName("check_date_next");
            entity.Property(e => e.CheckDoctorId).HasColumnName("check_doctor_id");
            entity.Property(e => e.Datetime1).HasColumnName("datetime1");
            entity.Property(e => e.User1)
                .HasMaxLength(50)
                .HasColumnName("user1");

            entity.HasOne(d => d.CheckDoctor).WithMany(p => p.TblPatientChecks)
                .HasForeignKey(d => d.CheckDoctorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_tblPatientCheck_tblDoctor");

            entity.HasOne(d => d.CheckSpec).WithMany(p => p.TblPatientChecks)
                .HasForeignKey(d => d.CheckSpecId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_tblPatientCheck_tblSpec");

            entity.HasOne(d => d.Patient).WithMany(p => p.TblPatientChecks)
                .HasForeignKey(d => d.PatientId)
                .HasConstraintName("FK_tblPatientCheck_tblPatientCard");
        });

        modelBuilder.Entity<TblPatientCheckOut>(entity =>
        {
            entity.HasKey(e => new { e.PatientId, e.CheckDate, e.CheckSpecId });

            entity.ToTable("tblPatientCheckOut");

            entity.HasIndex(e => e.CheckDoctorId, "IX_tblPatientCheckOut_check_doctor_id");

            entity.HasIndex(e => e.CheckSpecId, "IX_tblPatientCheckOut_check_spec_id");

            entity.Property(e => e.PatientId).HasColumnName("patient_id");
            entity.Property(e => e.CheckDate).HasColumnName("check_date");
            entity.Property(e => e.CheckSpecId).HasColumnName("check_spec_id");
            entity.Property(e => e.CheckDateNext).HasColumnName("check_date_next");
            entity.Property(e => e.CheckDoctorId).HasColumnName("check_doctor_id");
            entity.Property(e => e.Datetime1).HasColumnName("datetime1");
            entity.Property(e => e.User1)
                .HasMaxLength(50)
                .HasColumnName("user1");

            entity.HasOne(d => d.CheckDoctor).WithMany(p => p.TblPatientCheckOuts)
                .HasForeignKey(d => d.CheckDoctorId)
                .HasConstraintName("FK_tblPatientCheckOut_tblDoctor");

            entity.HasOne(d => d.CheckSpec).WithMany(p => p.TblPatientCheckOuts)
                .HasForeignKey(d => d.CheckSpecId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_tblPatientCheckOut_tblSpec");
        });

        modelBuilder.Entity<TblPatientChemop>(entity =>
        {
            entity.HasKey(e => new { e.PatientId, e.ChemopId, e.ChemopDateFrom });

            entity.ToTable("tblPatientChemop");

            entity.HasIndex(e => e.ChemopId, "IX_tblPatientChemop_chemop_id");

            entity.Property(e => e.PatientId).HasColumnName("patient_id");
            entity.Property(e => e.ChemopId).HasColumnName("chemop_id");
            entity.Property(e => e.ChemopDateFrom).HasColumnName("chemop_date_from");
            entity.Property(e => e.ChemopDateTo).HasColumnName("chemop_date_to");
            entity.Property(e => e.Datetime1).HasColumnName("datetime1");
            entity.Property(e => e.User1)
                .HasMaxLength(50)
                .HasColumnName("user1");

            entity.HasOne(d => d.Chemop).WithMany(p => p.TblPatientChemops)
                .HasForeignKey(d => d.ChemopId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_tblPatientChemop_tblChemop");

            entity.HasOne(d => d.Patient).WithMany(p => p.TblPatientChemops)
                .HasForeignKey(d => d.PatientId)
                .HasConstraintName("FK_tblPatientChemop_tblPatientCard");
        });

        modelBuilder.Entity<TblPatientChildSendForm>(entity =>
        {
            entity.HasKey(e => new { e.PatientId, e.Datesendform });

            entity.ToTable("tblPatientChildSendForm");

            entity.Property(e => e.PatientId).HasColumnName("patient_id");
            entity.Property(e => e.Datesendform).HasColumnName("datesendform");
            entity.Property(e => e.Datetime1).HasColumnName("datetime1");
            entity.Property(e => e.SendformDescr)
                .HasMaxLength(255)
                .HasColumnName("sendform_descr");
            entity.Property(e => e.User1)
                .HasMaxLength(50)
                .HasColumnName("user1");

            entity.HasOne(d => d.Patient).WithMany(p => p.TblPatientChildSendForms)
                .HasForeignKey(d => d.PatientId)
                .HasConstraintName("FK_tblPatientChildSendForm_tblPatientCard");
        });

        modelBuilder.Entity<TblPatientContact>(entity =>
        {
            entity.HasKey(e => new { e.PatientId, e.PatientContactId });

            entity.ToTable("tblPatientContact");

            entity.Property(e => e.PatientId).HasColumnName("patient_id");
            entity.Property(e => e.PatientContactId).HasColumnName("patient_contact_id");
            entity.Property(e => e.ContactType).HasColumnName("contact_type");
            entity.Property(e => e.InfectCourseId).HasColumnName("infect_course_id");
            entity.Property(e => e.PatientContactDescr)
                .HasMaxLength(255)
                .HasColumnName("patient_contact_descr");

            entity.HasOne(d => d.Patient).WithMany(p => p.TblPatientContacts)
                .HasForeignKey(d => d.PatientId)
                .HasConstraintName("FK_tblPatientContact_tblPatientCard");
        });

        modelBuilder.Entity<TblPatientContactChemsex>(entity =>
        {
            entity.HasKey(e => e.DrugId);

            entity.ToTable("tblPatientContactChemsex");

            entity.Property(e => e.DrugId).HasColumnName("drug_id");
            entity.Property(e => e.ContactType).HasColumnName("contact_type");
            entity.Property(e => e.DrugName)
                .HasMaxLength(25)
                .IsFixedLength()
                .HasColumnName("drug_name");
            entity.Property(e => e.PatientId).HasColumnName("patient_id");
            entity.Property(e => e.YNId).HasColumnName("y_n_id");
        });

        modelBuilder.Entity<TblPatientContactDrug>(entity =>
        {
            entity.HasKey(e => e.DrugId);

            entity.ToTable("tblPatientContactDrug");

            entity.Property(e => e.DrugId).HasColumnName("drug_id");
            entity.Property(e => e.DateEnd).HasColumnName("date_end");
            entity.Property(e => e.DateStart).HasColumnName("date_start");
            entity.Property(e => e.DrugName)
                .HasMaxLength(100)
                .IsFixedLength()
                .HasColumnName("drug_name");
            entity.Property(e => e.PatientId).HasColumnName("patient_id");
            entity.Property(e => e.PavType).HasColumnName("pav_type");
            entity.Property(e => e.YNId).HasColumnName("y_n_id");
        });

        modelBuilder.Entity<TblPatientContactPavInj>(entity =>
        {
            entity.HasKey(e => e.DrugId);

            entity.ToTable("tblPatientContactPavInj");

            entity.Property(e => e.DrugId).HasColumnName("drug_id");
            entity.Property(e => e.DateEnd).HasColumnName("date_end");
            entity.Property(e => e.DateStart).HasColumnName("date_start");
            entity.Property(e => e.DrugName)
                .HasMaxLength(25)
                .IsFixedLength()
                .HasColumnName("drug_name");
            entity.Property(e => e.PatientId).HasColumnName("patient_id");
            entity.Property(e => e.YNId).HasColumnName("y_n_id");
        });

        modelBuilder.Entity<TblPatientContactPavNotInj>(entity =>
        {
            entity.HasKey(e => e.DrugId).HasName("PK_PatientContactNotInj");

            entity.ToTable("tblPatientContactPavNotInj");

            entity.Property(e => e.DrugId).HasColumnName("drug_id");
            entity.Property(e => e.DateEnd).HasColumnName("date_end");
            entity.Property(e => e.DateStart).HasColumnName("date_start");
            entity.Property(e => e.DrugName)
                .HasMaxLength(25)
                .IsFixedLength()
                .HasColumnName("drug_name");
            entity.Property(e => e.PatientId).HasColumnName("patient_id");
            entity.Property(e => e.YNId).HasColumnName("y_n_id");
        });

        modelBuilder.Entity<TblPatientCorrespIllness>(entity =>
        {
            entity.HasKey(e => new { e.PatientId, e.CorrespIllnessId });

            entity.ToTable("tblPatientCorrespIllness");

            entity.HasIndex(e => e.CorrespIllnessId, "IX_tblPatientCorrespIllness_corresp_illness_id");

            entity.Property(e => e.PatientId).HasColumnName("patient_id");
            entity.Property(e => e.CorrespIllnessId).HasColumnName("corresp_illness_id");
            entity.Property(e => e.Datetime1).HasColumnName("datetime1");
            entity.Property(e => e.User1)
                .HasMaxLength(50)
                .HasColumnName("user1");

            entity.HasOne(d => d.CorrespIllness).WithMany(p => p.TblPatientCorrespIllnesses)
                .HasForeignKey(d => d.CorrespIllnessId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_tblPatientCorrespIllness_tblCorrespIllness");

            entity.HasOne(d => d.Patient).WithMany(p => p.TblPatientCorrespIllnesses)
                .HasForeignKey(d => d.PatientId)
                .HasConstraintName("FK_tblPatientCorrespIllness_tblPatientCard");
        });

        modelBuilder.Entity<TblPatientCureSchema>(entity =>
        {
            entity.HasKey(e => new { e.PatientId, e.CureSchemaId, e.StartDate });

            entity.ToTable("tblPatientCureSchema");

            entity.HasIndex(e => e.CureChangeId, "IX_tblPatientCureSchema_cure_change_id");

            entity.HasIndex(e => e.CureSchemaId, "IX_tblPatientCureSchema_cure_schema_id");

            entity.Property(e => e.PatientId).HasColumnName("patient_id");
            entity.Property(e => e.CureSchemaId).HasColumnName("cure_schema_id");
            entity.Property(e => e.StartDate).HasColumnName("start_date");
            entity.Property(e => e.CureChangeId).HasColumnName("cure_change_id");
            entity.Property(e => e.Datetime1).HasColumnName("datetime1");
            entity.Property(e => e.EndDate).HasColumnName("end_date");
            entity.Property(e => e.LastYn).HasColumnName("lastYN");
            entity.Property(e => e.ProtNum)
                .HasMaxLength(50)
                .HasColumnName("prot_num");
            entity.Property(e => e.RangeTherapyId).HasColumnName("range_therapy_id");
            entity.Property(e => e.SchemaDescr)
                .HasMaxLength(255)
                .HasColumnName("schema_descr");
            entity.Property(e => e.User1)
                .HasMaxLength(50)
                .HasColumnName("user1");

            entity.HasOne(d => d.CureChange).WithMany(p => p.TblPatientCureSchemas)
                .HasForeignKey(d => d.CureChangeId)
                .HasConstraintName("FK_tblPatientCureSchema_tblCureChange");

            entity.HasOne(d => d.CureSchema).WithMany(p => p.TblPatientCureSchemas)
                .HasForeignKey(d => d.CureSchemaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_tblPatientCureSchema_tblCureSchema");

            entity.HasOne(d => d.Patient).WithMany(p => p.TblPatientCureSchemas)
                .HasForeignKey(d => d.PatientId)
                .HasConstraintName("FK_tblPatientCureSchema_tblPatientCard");
        });

        modelBuilder.Entity<TblPatientDiagnosis>(entity =>
        {
            entity.HasKey(e => new { e.PatientId, e.DiagnosisDefDate });

            entity.ToTable("tblPatientDiagnosis");

            entity.HasIndex(e => e.DiagnosisId, "IX_tblPatientDiagnosis_diagnosis_id");

            entity.Property(e => e.PatientId).HasColumnName("patient_id");
            entity.Property(e => e.DiagnosisDefDate).HasColumnName("diagnosis_def_date");
            entity.Property(e => e.Datetime1).HasColumnName("datetime1");
            entity.Property(e => e.DiagnosisId).HasColumnName("diagnosis_id");
            entity.Property(e => e.User1)
                .HasMaxLength(50)
                .IsFixedLength()
                .HasColumnName("user1");

            entity.HasOne(d => d.Diagnosis).WithMany(p => p.TblPatientDiagnoses)
                .HasForeignKey(d => d.DiagnosisId)
                .HasConstraintName("FK_tblPatientDiagnosis_tblDiagnosis");

            entity.HasOne(d => d.Patient).WithMany(p => p.TblPatientDiagnoses)
                .HasForeignKey(d => d.PatientId)
                .HasConstraintName("FK_tblPatientDiagnosis_tblPatientCard");
        });

        modelBuilder.Entity<TblPatientHepatitResult>(entity =>
        {
            entity.HasKey(e => new { e.PatientId, e.DefineResultDate });

            entity.ToTable("tblPatientHepatitResult");

            entity.HasIndex(e => e.HepatitResultId, "IX_tblPatientHepatitResult_hepatit_result_id");

            entity.Property(e => e.PatientId).HasColumnName("patient_id");
            entity.Property(e => e.DefineResultDate).HasColumnName("define_result_date");
            entity.Property(e => e.HepatitLoad).HasColumnName("hepatit_load");
            entity.Property(e => e.HepatitResultId).HasColumnName("hepatit_result_id");

            entity.HasOne(d => d.HepatitResult).WithMany(p => p.TblPatientHepatitResults)
                .HasForeignKey(d => d.HepatitResultId)
                .HasConstraintName("FK_tblPatientHepatitResult_tblHepatitResult");

            entity.HasOne(d => d.Patient).WithMany(p => p.TblPatientHepatitResults)
                .HasForeignKey(d => d.PatientId)
                .HasConstraintName("FK_tblPatientHepatitResult_tblPatientCard");
        });

        modelBuilder.Entity<TblPatientHepatitResult2>(entity =>
        {
            entity.HasKey(e => new { e.PatientId, e.DefineResultDate });

            entity.ToTable("tblPatientHepatitResult2");

            entity.HasIndex(e => e.HepatitResult2Id, "IX_tblPatientHepatitResult2_hepatit_result2_id");

            entity.Property(e => e.PatientId).HasColumnName("patient_id");
            entity.Property(e => e.DefineResultDate).HasColumnName("define_result_date");
            entity.Property(e => e.Hepatit2Load).HasColumnName("hepatit2_load");
            entity.Property(e => e.HepatitResult2Id).HasColumnName("hepatit_result2_id");

            entity.HasOne(d => d.HepatitResult2).WithMany(p => p.TblPatientHepatitResult2s)
                .HasForeignKey(d => d.HepatitResult2Id)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_tblPatientHepatitResult2_tblHepatitResult2");

            entity.HasOne(d => d.Patient).WithMany(p => p.TblPatientHepatitResult2s)
                .HasForeignKey(d => d.PatientId)
                .HasConstraintName("FK_tblPatientHepatitResult2_tblPatientCard");
        });

        modelBuilder.Entity<TblPatientHosp>(entity =>
        {
            entity.HasKey(e => new { e.PatientId, e.YearId, e.HospCourseId });

            entity.ToTable("tblPatientHosp");

            entity.HasIndex(e => e.HospCourseId, "IX_tblPatientHosp_hosp_course_id");

            entity.Property(e => e.PatientId).HasColumnName("patient_id");
            entity.Property(e => e.YearId).HasColumnName("year_id");
            entity.Property(e => e.HospCourseId).HasColumnName("hosp_course_id");
            entity.Property(e => e.Datetime1).HasColumnName("datetime1");
            entity.Property(e => e.HospTimes).HasColumnName("hosp_times");
            entity.Property(e => e.User1)
                .HasMaxLength(50)
                .HasColumnName("user1");

            entity.HasOne(d => d.HospCourse).WithMany(p => p.TblPatientHosps)
                .HasForeignKey(d => d.HospCourseId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_tblPatientHosp_tblHospCourse");

            entity.HasOne(d => d.Patient).WithMany(p => p.TblPatientHosps)
                .HasForeignKey(d => d.PatientId)
                .HasConstraintName("FK_tblPatientHosp_tblPatientCard");
        });

        modelBuilder.Entity<TblPatientHospResultR>(entity =>
        {
            entity.HasKey(e => new { e.PatientId, e.LpuId, e.DateHospIn });

            entity.ToTable("tblPatientHospResultR");

            entity.HasIndex(e => e.HospCourseId, "IX_tblPatientHospResultR_hosp_course_id");

            entity.HasIndex(e => e.HospResultId, "IX_tblPatientHospResultR_hosp_result_id");

            entity.HasIndex(e => e.LpuId, "IX_tblPatientHospResultR_lpu_id");

            entity.Property(e => e.PatientId).HasColumnName("patient_id");
            entity.Property(e => e.LpuId).HasColumnName("lpu_id");
            entity.Property(e => e.DateHospIn).HasColumnName("date_hosp_in");
            entity.Property(e => e.DateHospOut).HasColumnName("date_hosp_out");
            entity.Property(e => e.Datetime1).HasColumnName("datetime1");
            entity.Property(e => e.HospCourseId).HasColumnName("hosp_course_id");
            entity.Property(e => e.HospResultId).HasColumnName("hosp_result_id");
            entity.Property(e => e.User1)
                .HasMaxLength(50)
                .HasColumnName("user1");

            entity.HasOne(d => d.HospCourse).WithMany(p => p.TblPatientHospResultRs)
                .HasForeignKey(d => d.HospCourseId)
                .HasConstraintName("FK_tblPatientHospResultR_tblHospCourse");

            entity.HasOne(d => d.HospResult).WithMany(p => p.TblPatientHospResultRs)
                .HasForeignKey(d => d.HospResultId)
                .HasConstraintName("FK_tblPatientHospResultR_tblHospResult");

            entity.HasOne(d => d.Lpu).WithMany(p => p.TblPatientHospResultRs)
                .HasForeignKey(d => d.LpuId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_tblPatientHospResultR_tblLpu");

            entity.HasOne(d => d.Patient).WithMany(p => p.TblPatientHospResultRs)
                .HasForeignKey(d => d.PatientId)
                .HasConstraintName("FK_tblPatientHospResultR_tblPatientCard");
        });

        modelBuilder.Entity<TblPatientImmuneStat>(entity =>
        {
            entity.HasKey(e => new { e.PatientId, e.ImmuneDefineDate });

            entity.ToTable("tblPatientImmuneStat");

            entity.HasIndex(e => e.ImmuneDefineDate, "immune_define_date");

            entity.Property(e => e.PatientId).HasColumnName("patient_id");
            entity.Property(e => e.ImmuneDefineDate).HasColumnName("immune_define_date");
            entity.Property(e => e.Datetime1).HasColumnName("datetime1");
            entity.Property(e => e.ImmuneValue2).HasColumnName("immune_value2");
            entity.Property(e => e.ImmuneValue3).HasColumnName("immune_value3");
            entity.Property(e => e.ImmuneValue4).HasColumnName("immune_value4");
            entity.Property(e => e.ImmuneValue5).HasColumnName("immune_value5");
            entity.Property(e => e.ImmuneValue6).HasColumnName("immune_value6");
            entity.Property(e => e.ImmuneValue7).HasColumnName("immune_value7");
            entity.Property(e => e.User1)
                .HasMaxLength(50)
                .HasColumnName("user1");

            entity.HasOne(d => d.Patient).WithMany(p => p.TblPatientImmuneStats)
                .HasForeignKey(d => d.PatientId)
                .HasConstraintName("FK_tblPatientImmuneStat_tblPatientCard");
        });

        modelBuilder.Entity<TblPatientJail>(entity =>
        {
            entity.HasKey(e => new { e.PatientId, e.JailStart, e.JailEnd });

            entity.ToTable("tblPatientJail");

            entity.Property(e => e.PatientId).HasColumnName("patient_id");
            entity.Property(e => e.JailStart).HasColumnName("jail_start");
            entity.Property(e => e.JailEnd).HasColumnName("jail_end");
            entity.Property(e => e.Datetime1).HasColumnName("datetime1");
            entity.Property(e => e.JailId).HasColumnName("jail_id");
            entity.Property(e => e.JailLeavId).HasColumnName("jail_leav_id");
            entity.Property(e => e.User1)
                .HasMaxLength(50)
                .IsFixedLength()
                .HasColumnName("user1");

            entity.HasOne(d => d.Patient).WithMany(p => p.TblPatientJails)
                .HasForeignKey(d => d.PatientId)
                .HasConstraintName("FK_tblPatientJail_tblPatientCard");
        });

        modelBuilder.Entity<TblPatientMedicine>(entity =>
        {
            entity.HasKey(e => new { e.PatientId, e.MedicineId, e.DoctorId, e.GiveDate });

            entity.ToTable("tblPatientMedicine");

            entity.HasIndex(e => e.DoctorId, "IX_tblPatientMedicine_doctor_id");

            entity.HasIndex(e => e.MedicineId, "IX_tblPatientMedicine_medicine_id");

            entity.Property(e => e.PatientId).HasColumnName("patient_id");
            entity.Property(e => e.MedicineId).HasColumnName("medicine_id");
            entity.Property(e => e.DoctorId).HasColumnName("doctor_id");
            entity.Property(e => e.GiveDate).HasColumnName("give_date");
            entity.Property(e => e.Datetime1).HasColumnName("datetime1");
            entity.Property(e => e.PackNumber).HasColumnName("pack_number");
            entity.Property(e => e.User1)
                .HasMaxLength(50)
                .HasColumnName("user1");

            entity.HasOne(d => d.Doctor).WithMany(p => p.TblPatientMedicines)
                .HasForeignKey(d => d.DoctorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_tblPatientMedicine_tblDoctor");

            entity.HasOne(d => d.Medicine).WithMany(p => p.TblPatientMedicines)
                .HasForeignKey(d => d.MedicineId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_tblPatientMedicine_tblMedicine");

            entity.HasOne(d => d.Patient).WithMany(p => p.TblPatientMedicines)
                .HasForeignKey(d => d.PatientId)
                .HasConstraintName("FK_tblPatientMedicine_tblPatientCard");
        });

        modelBuilder.Entity<TblPatientNonresident>(entity =>
        {
            entity.HasKey(e => e.PatientId);

            entity.ToTable("tblPatientNonresident");

            entity.Property(e => e.PatientId)
                .ValueGeneratedNever()
                .HasColumnName("patient_id");
            entity.Property(e => e.DateDeparture).HasColumnName("date_departure");
            entity.Property(e => e.DateDiagnosis).HasColumnName("date_diagnosis");
            entity.Property(e => e.DateRegistrationFrom).HasColumnName("date_registration_from");
            entity.Property(e => e.DateRegistrationTo).HasColumnName("date_registration_to");
            entity.Property(e => e.PlaceDiagnosis).HasColumnName("place_diagnosis");
        });

        modelBuilder.Entity<TblPatientPregnantM>(entity =>
        {
            entity.HasKey(e => new { e.PatientId, e.PregId });

            entity.ToTable("tblPatientPregnantM");

            entity.HasIndex(e => e.ChildCountId, "IX_tblPatientPregnantM_child_count_id");

            entity.HasIndex(e => e.MedicineId, "IX_tblPatientPregnantM_medicine_id");

            entity.HasIndex(e => e.MedicineId2, "IX_tblPatientPregnantM_medicine_id2");

            entity.HasIndex(e => e.MedicineId3, "IX_tblPatientPregnantM_medicine_id3");

            entity.HasIndex(e => e.PhpschemaId1, "IX_tblPatientPregnantM_phpschema_id1");

            entity.HasIndex(e => e.PhpschemaId2, "IX_tblPatientPregnantM_phpschema_id2");

            entity.HasIndex(e => e.PhpschemaId3, "IX_tblPatientPregnantM_phpschema_id3");

            entity.Property(e => e.PatientId).HasColumnName("patient_id");
            entity.Property(e => e.PregId).HasColumnName("preg_id");
            entity.Property(e => e.BirthTypeId).HasColumnName("birth_type_id");
            entity.Property(e => e.ChildBirthDate).HasColumnName("child_birth_date");
            entity.Property(e => e.ChildCountId).HasColumnName("child_count_id");
            entity.Property(e => e.ChildFamilyName)
                .HasMaxLength(50)
                .HasColumnName("child_family_name");
            entity.Property(e => e.ChildFirstName)
                .HasMaxLength(50)
                .HasColumnName("child_first_name");
            entity.Property(e => e.ChildPatientId).HasColumnName("child_patient_id");
            entity.Property(e => e.ChildThirdName)
                .HasMaxLength(50)
                .HasColumnName("child_third_name");
            entity.Property(e => e.DateEnd1).HasColumnName("date_end1");
            entity.Property(e => e.DateStart1).HasColumnName("date_start1");
            entity.Property(e => e.Datetime1).HasColumnName("datetime1");
            entity.Property(e => e.FlgConfirm).HasColumnName("flg_confirm");
            entity.Property(e => e.MedicineId).HasColumnName("medicine_id");
            entity.Property(e => e.MedicineId2).HasColumnName("medicine_id2");
            entity.Property(e => e.MedicineId3).HasColumnName("medicine_id3");
            entity.Property(e => e.MedicineStMonthNo).HasColumnName("medicine_st_month_no");
            entity.Property(e => e.Php1Descr)
                .HasMaxLength(255)
                .HasColumnName("php1_descr");
            entity.Property(e => e.Php1Edate).HasColumnName("php1_edate");
            entity.Property(e => e.Php1Sdate).HasColumnName("php1_sdate");
            entity.Property(e => e.Php2Descr)
                .HasMaxLength(255)
                .HasColumnName("php2_descr");
            entity.Property(e => e.Php2Edate).HasColumnName("php2_edate");
            entity.Property(e => e.Php2Sdate).HasColumnName("php2_sdate");
            entity.Property(e => e.Php3Descr)
                .HasMaxLength(255)
                .HasColumnName("php3_descr");
            entity.Property(e => e.Php3Edate).HasColumnName("php3_edate");
            entity.Property(e => e.Php3Sdate).HasColumnName("php3_sdate");
            entity.Property(e => e.PhpschemaId1).HasColumnName("phpschema_id1");
            entity.Property(e => e.PhpschemaId2).HasColumnName("phpschema_id2");
            entity.Property(e => e.PhpschemaId3).HasColumnName("phpschema_id3");
            entity.Property(e => e.PregDate).HasColumnName("preg_date");
            entity.Property(e => e.PregDescr)
                .HasMaxLength(255)
                .HasColumnName("preg_descr");
            entity.Property(e => e.PwcheckYn).HasColumnName("pwcheckYN");
            entity.Property(e => e.Pwmonth).HasColumnName("pwmonth");
            entity.Property(e => e.User1)
                .HasMaxLength(50)
                .HasColumnName("user1");

            entity.HasOne(d => d.ChildCount).WithMany(p => p.TblPatientPregnantMs)
                .HasForeignKey(d => d.ChildCountId)
                .HasConstraintName("FK_tblPatientPregnantM_tblChildCount");

            entity.HasOne(d => d.Medicine).WithMany(p => p.TblPatientPregnantMMedicines)
                .HasForeignKey(d => d.MedicineId)
                .HasConstraintName("FK_tblPatientPregnantM_tblMedicine");

            entity.HasOne(d => d.MedicineId2Navigation).WithMany(p => p.TblPatientPregnantMMedicineId2Navigations)
                .HasForeignKey(d => d.MedicineId2)
                .HasConstraintName("FK_tblPatientPregnantM_tblMedicine1");

            entity.HasOne(d => d.MedicineId3Navigation).WithMany(p => p.TblPatientPregnantMMedicineId3Navigations)
                .HasForeignKey(d => d.MedicineId3)
                .HasConstraintName("FK_tblPatientPregnantM_tblMedicine2");

            entity.HasOne(d => d.Patient).WithMany(p => p.TblPatientPregnantMs)
                .HasForeignKey(d => d.PatientId)
                .HasConstraintName("FK_tblPatientPregnantM_tblPatientCard");

            entity.HasOne(d => d.PhpschemaId1Navigation).WithMany(p => p.TblPatientPregnantMPhpschemaId1Navigations)
                .HasForeignKey(d => d.PhpschemaId1)
                .HasConstraintName("FK_tblPatientPregnantM_tblCureSchema");

            entity.HasOne(d => d.PhpschemaId2Navigation).WithMany(p => p.TblPatientPregnantMPhpschemaId2Navigations)
                .HasForeignKey(d => d.PhpschemaId2)
                .HasConstraintName("FK_tblPatientPregnantM_tblCureSchema1");

            entity.HasOne(d => d.PhpschemaId3Navigation).WithMany(p => p.TblPatientPregnantMPhpschemaId3Navigations)
                .HasForeignKey(d => d.PhpschemaId3)
                .HasConstraintName("FK_tblPatientPregnantM_tblCureSchema2");
        });

        modelBuilder.Entity<TblPatientPrescrM>(entity =>
        {
            entity.HasKey(e => new { e.PatientId, e.PrescrSer, e.PrescrNum });

            entity.ToTable("tblPatientPrescrM");

            entity.HasIndex(e => e.FinSourceId, "IX_tblPatientPrescrM_fin_source_id");

            entity.HasIndex(e => e.GiveMedId, "IX_tblPatientPrescrM_give_med_id");

            entity.HasIndex(e => e.MedicineId, "IX_tblPatientPrescrM_medicine_id");

            entity.Property(e => e.PatientId).HasColumnName("patient_id");
            entity.Property(e => e.PrescrSer)
                .HasMaxLength(50)
                .HasColumnName("prescr_ser");
            entity.Property(e => e.PrescrNum)
                .HasMaxLength(50)
                .HasColumnName("prescr_num");
            entity.Property(e => e.Datetime1).HasColumnName("datetime1");
            entity.Property(e => e.DoctorId).HasColumnName("doctor_id");
            entity.Property(e => e.FinSourceId).HasColumnName("fin_source_id");
            entity.Property(e => e.GiveDate).HasColumnName("give_date");
            entity.Property(e => e.GiveDateCheck1).HasColumnName("give_date_check1");
            entity.Property(e => e.GiveMedId).HasColumnName("give_med_id");
            entity.Property(e => e.GivePackNum).HasColumnName("give_pack_num");
            entity.Property(e => e.KorvetDateImp).HasColumnName("korvet_date_imp");
            entity.Property(e => e.MedicineId).HasColumnName("medicine_id");
            entity.Property(e => e.PackNumber).HasColumnName("pack_number");
            entity.Property(e => e.PrescrDate).HasColumnName("prescr_date");
            entity.Property(e => e.Uidprescr).HasColumnName("UIDprescr");
            entity.Property(e => e.User1)
                .HasMaxLength(50)
                .HasColumnName("user1");

            entity.HasOne(d => d.FinSource).WithMany(p => p.TblPatientPrescrMs)
                .HasForeignKey(d => d.FinSourceId)
                .HasConstraintName("FK_tblPatientPrescr_tblFinSource");

            entity.HasOne(d => d.GiveMed).WithMany(p => p.TblPatientPrescrMGiveMeds)
                .HasForeignKey(d => d.GiveMedId)
                .HasConstraintName("FK_tblPatientPrescrM_tblMedicine1");

            entity.HasOne(d => d.Medicine).WithMany(p => p.TblPatientPrescrMMedicines)
                .HasForeignKey(d => d.MedicineId)
                .HasConstraintName("FK_tblPatientPrescrM_tblMedicine");

            entity.HasOne(d => d.Patient).WithMany(p => p.TblPatientPrescrMs)
                .HasForeignKey(d => d.PatientId)
                .HasConstraintName("FK_tblPatientPrescr_tblPatientCard");
        });

        modelBuilder.Entity<TblPatientRegistry>(entity =>
        {
            entity.HasKey(e => new { e.RegDate, e.RegCabinetId, e.PatientId });

            entity.ToTable("tblPatientRegistry");

            entity.Property(e => e.RegDate).HasColumnName("reg_date");
            entity.Property(e => e.RegCabinetId).HasColumnName("reg_cabinet_id");
            entity.Property(e => e.PatientId).HasColumnName("patient_id");
            entity.Property(e => e.Numpp).HasColumnName("numpp");
            entity.Property(e => e.RegCheck).HasColumnName("reg_check");
            entity.Property(e => e.RegDescr)
                .HasMaxLength(255)
                .HasColumnName("reg_descr");
            entity.Property(e => e.RegDoctorId).HasColumnName("reg_doctor_id");
            entity.Property(e => e.RegTimeId).HasColumnName("reg_time_id");
        });

        modelBuilder.Entity<TblPatientRegistryTalon>(entity =>
        {
            entity.HasKey(e => new { e.RegDate, e.RegCabinetId, e.PatientId });

            entity.ToTable("tblPatientRegistryTalon");

            entity.Property(e => e.RegDate).HasColumnName("reg_date");
            entity.Property(e => e.RegCabinetId).HasColumnName("reg_cabinet_id");
            entity.Property(e => e.PatientId).HasColumnName("patient_id");
            entity.Property(e => e.TalonField01).HasColumnName("talon_field_01");
            entity.Property(e => e.TalonField12Phone)
                .HasMaxLength(50)
                .HasColumnName("talon_field_12_phone");
            entity.Property(e => e.TalonField13).HasColumnName("talon_field_13");
            entity.Property(e => e.TalonField14).HasColumnName("talon_field_14");
            entity.Property(e => e.TalonField21).HasColumnName("talon_field_21");
            entity.Property(e => e.TalonField22).HasColumnName("talon_field_22");
            entity.Property(e => e.TalonField24).HasColumnName("talon_field_24");
            entity.Property(e => e.TalonField25).HasColumnName("talon_field_25");
            entity.Property(e => e.TalonField28).HasColumnName("talon_field_28");
            entity.Property(e => e.TalonField30).HasColumnName("talon_field_30");
            entity.Property(e => e.TalonField30Spec).HasColumnName("talon_field_30_spec");
            entity.Property(e => e.TalonField32).HasColumnName("talon_field_32");
            entity.Property(e => e.TalonField35).HasColumnName("talon_field_35");
            entity.Property(e => e.TalonField36).HasColumnName("talon_field_36");
            entity.Property(e => e.TalonNum)
                .ValueGeneratedOnAdd()
                .HasColumnName("talon_num");
        });

        modelBuilder.Entity<TblPatientResist>(entity =>
        {
            entity.HasKey(e => new { e.PatientId, e.RmedicId });

            entity.ToTable("tblPatientResist");

            entity.HasIndex(e => e.ResistId, "IX_tblPatientResist_resist_id");

            entity.HasIndex(e => e.RmedicId, "IX_tblPatientResist_rmedic_id");

            entity.Property(e => e.PatientId).HasColumnName("patient_id");
            entity.Property(e => e.RmedicId).HasColumnName("rmedic_id");
            entity.Property(e => e.Datetime1).HasColumnName("datetime1");
            entity.Property(e => e.ResistId).HasColumnName("resist_id");
            entity.Property(e => e.User1)
                .HasMaxLength(50)
                .HasColumnName("user1");

            entity.HasOne(d => d.Patient).WithMany(p => p.TblPatientResists)
                .HasForeignKey(d => d.PatientId)
                .HasConstraintName("FK_tblPatientResist_tblPatientCard");

            entity.HasOne(d => d.Resist).WithMany(p => p.TblPatientResists)
                .HasForeignKey(d => d.ResistId)
                .HasConstraintName("FK_tblPatientResist_tblResist");

            entity.HasOne(d => d.Rmedic).WithMany(p => p.TblPatientResists)
                .HasForeignKey(d => d.RmedicId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_tblPatientResist_tblRmedic");
        });

        modelBuilder.Entity<TblPatientShowIllness>(entity =>
        {
            entity.HasKey(e => new { e.PatientId, e.ShowIllnessId, e.StartDate });

            entity.ToTable("tblPatientShowIllness");

            entity.HasIndex(e => e.ShowIllnessId, "IX_tblPatientShowIllness_show_illness_id");

            entity.Property(e => e.PatientId).HasColumnName("patient_id");
            entity.Property(e => e.ShowIllnessId).HasColumnName("show_illness_id");
            entity.Property(e => e.StartDate).HasColumnName("start_date");
            entity.Property(e => e.Comment)
                .HasMaxLength(250)
                .HasColumnName("comment");
            entity.Property(e => e.Datetime1).HasColumnName("datetime1");
            entity.Property(e => e.EndDate).HasColumnName("end_date");
            entity.Property(e => e.User1)
                .HasMaxLength(50)
                .HasColumnName("user1");

            entity.HasOne(d => d.Patient).WithMany(p => p.TblPatientShowIllnesses)
                .HasForeignKey(d => d.PatientId)
                .HasConstraintName("FK_tblPatientShowIllness_tblPatientCard");

            entity.HasOne(d => d.ShowIllness).WithMany(p => p.TblPatientShowIllnesses)
                .HasForeignKey(d => d.ShowIllnessId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_tblPatientShowIllness_tblShowIllness");
        });

        modelBuilder.Entity<TblPatientStacionar>(entity =>
        {
            entity.HasKey(e => new { e.PatientId, e.DocDate, e.DocNum, e.StacionarId, e.MedicineId });

            entity.ToTable("tblPatientStacionar");

            entity.HasIndex(e => e.DoctorId, "IX_tblPatientStacionar_doctor_id");

            entity.HasIndex(e => e.GiveMedId, "IX_tblPatientStacionar_give_med_id");

            entity.HasIndex(e => e.MedicineId, "IX_tblPatientStacionar_medicine_id");

            entity.HasIndex(e => e.StacionarId, "IX_tblPatientStacionar_stacionar_id");

            entity.Property(e => e.PatientId).HasColumnName("patient_id");
            entity.Property(e => e.DocDate).HasColumnName("doc_date");
            entity.Property(e => e.DocNum)
                .HasMaxLength(50)
                .HasColumnName("doc_num");
            entity.Property(e => e.StacionarId).HasColumnName("stacionar_id");
            entity.Property(e => e.MedicineId).HasColumnName("medicine_id");
            entity.Property(e => e.Datetime1).HasColumnName("datetime1");
            entity.Property(e => e.DoctorId).HasColumnName("doctor_id");
            entity.Property(e => e.GiveDate).HasColumnName("give_date");
            entity.Property(e => e.GiveMedId).HasColumnName("give_med_id");
            entity.Property(e => e.GivePackNum).HasColumnName("give_pack_num");
            entity.Property(e => e.LetterNum)
                .HasMaxLength(50)
                .HasColumnName("letter_num");
            entity.Property(e => e.PackNumber).HasColumnName("pack_number");
            entity.Property(e => e.User1)
                .HasMaxLength(50)
                .HasColumnName("user1");
            entity.Property(e => e.ZayavkaDate).HasColumnName("zayavka_date");

            entity.HasOne(d => d.Doctor).WithMany(p => p.TblPatientStacionars)
                .HasForeignKey(d => d.DoctorId)
                .HasConstraintName("FK_tblPatientStacionar_tbDoctor");

            entity.HasOne(d => d.GiveMed).WithMany(p => p.TblPatientStacionarGiveMeds)
                .HasForeignKey(d => d.GiveMedId)
                .HasConstraintName("FK_tblPatientStacionar_tblMedicine2");

            entity.HasOne(d => d.Medicine).WithMany(p => p.TblPatientStacionarMedicines)
                .HasForeignKey(d => d.MedicineId)
                .HasConstraintName("FK_tblPatientStacionar_tblMedicine");

            entity.HasOne(d => d.Patient).WithMany(p => p.TblPatientStacionars)
                .HasForeignKey(d => d.PatientId)
                .HasConstraintName("FK_tblPatientStacionar_tblPatientCard");

            entity.HasOne(d => d.Stacionar).WithMany(p => p.TblPatientStacionars)
                .HasForeignKey(d => d.StacionarId)
                .HasConstraintName("FK_tblPatientStacionar_tblStacionar");
        });

        modelBuilder.Entity<TblPatientVirusLoad>(entity =>
        {
            entity.HasKey(e => new { e.PatientId, e.DefineVirusDate });

            entity.ToTable("tblPatientVirusLoad");

            entity.HasIndex(e => e.VloadResultId, "IX_tblPatientVirusLoad_vload_result_id");

            entity.Property(e => e.PatientId).HasColumnName("patient_id");
            entity.Property(e => e.DefineVirusDate).HasColumnName("define_virus_date");
            entity.Property(e => e.VirusLoad).HasColumnName("virus_load");
            entity.Property(e => e.VloadResultId).HasColumnName("vload_result_id");

            entity.HasOne(d => d.Patient).WithMany(p => p.TblPatientVirusLoads)
                .HasForeignKey(d => d.PatientId)
                .HasConstraintName("FK_tblPatientVirusLoad_tblPatientCard");

            entity.HasOne(d => d.VloadResult).WithMany(p => p.TblPatientVirusLoads)
                .HasForeignKey(d => d.VloadResultId)
                .HasConstraintName("FK_tblPatientVirusLoad_tblVloadResult");
        });

        modelBuilder.Entity<TblPregCheck>(entity =>
        {
            entity.HasKey(e => e.PregCheckId);

            entity.ToTable("tblPregCheck");

            entity.Property(e => e.PregCheckId).HasColumnName("preg_check_id");
            entity.Property(e => e.Datetime1).HasColumnName("datetime1");
            entity.Property(e => e.PregCheckLong)
                .HasMaxLength(100)
                .HasColumnName("preg_check_long");
            entity.Property(e => e.PregCheckShort)
                .HasMaxLength(50)
                .HasColumnName("preg_check_short");
            entity.Property(e => e.User1)
                .HasMaxLength(50)
                .HasColumnName("user1");
        });

        modelBuilder.Entity<TblQgr>(entity =>
        {
            entity.HasKey(e => e.QgrId);

            entity.ToTable("tblQgr");

            entity.Property(e => e.QgrId).HasColumnName("qgr_id");
            entity.Property(e => e.Datetime1).HasColumnName("datetime1");
            entity.Property(e => e.QgrName)
                .HasMaxLength(255)
                .HasColumnName("qgr_name");
            entity.Property(e => e.User1)
                .HasMaxLength(50)
                .HasColumnName("user1");
        });

        modelBuilder.Entity<TblQuest>(entity =>
        {
            entity.HasKey(e => e.QuestId);

            entity.ToTable("tblQuest");

            entity.HasIndex(e => e.QgrId, "IX_tblQuest_qgr_id");

            entity.Property(e => e.QuestId).HasColumnName("quest_id");
            entity.Property(e => e.B1)
                .HasMaxLength(50)
                .HasColumnName("b1");
            entity.Property(e => e.B10)
                .HasMaxLength(50)
                .HasColumnName("b10");
            entity.Property(e => e.B11)
                .HasMaxLength(50)
                .HasColumnName("b11");
            entity.Property(e => e.B12)
                .HasMaxLength(50)
                .HasColumnName("b12");
            entity.Property(e => e.B12c1)
                .HasMaxLength(50)
                .HasColumnName("b12c1");
            entity.Property(e => e.B12c2)
                .HasMaxLength(50)
                .HasColumnName("b12c2");
            entity.Property(e => e.B12c3)
                .HasMaxLength(50)
                .HasColumnName("b12c3");
            entity.Property(e => e.B12c4)
                .HasMaxLength(50)
                .HasColumnName("b12c4");
            entity.Property(e => e.B13)
                .HasMaxLength(50)
                .HasColumnName("b13");
            entity.Property(e => e.B14)
                .HasMaxLength(50)
                .HasColumnName("b14");
            entity.Property(e => e.B15)
                .HasMaxLength(50)
                .HasColumnName("b15");
            entity.Property(e => e.B16)
                .HasMaxLength(50)
                .HasColumnName("b16");
            entity.Property(e => e.B17)
                .HasMaxLength(50)
                .HasColumnName("b17");
            entity.Property(e => e.B17c1)
                .HasMaxLength(50)
                .HasColumnName("b17c1");
            entity.Property(e => e.B17c2)
                .HasMaxLength(50)
                .HasColumnName("b17c2");
            entity.Property(e => e.B17c3)
                .HasMaxLength(50)
                .HasColumnName("b17c3");
            entity.Property(e => e.B18)
                .HasMaxLength(50)
                .HasColumnName("b18");
            entity.Property(e => e.B18c1)
                .HasMaxLength(50)
                .HasColumnName("b18c1");
            entity.Property(e => e.B18c2)
                .HasMaxLength(50)
                .HasColumnName("b18c2");
            entity.Property(e => e.B19)
                .HasMaxLength(50)
                .HasColumnName("b19");
            entity.Property(e => e.B1c1)
                .HasMaxLength(50)
                .HasColumnName("b1c1");
            entity.Property(e => e.B1c2)
                .HasMaxLength(50)
                .HasColumnName("b1c2");
            entity.Property(e => e.B2)
                .HasMaxLength(50)
                .HasColumnName("b2");
            entity.Property(e => e.B20)
                .HasMaxLength(50)
                .HasColumnName("b20");
            entity.Property(e => e.B21)
                .HasMaxLength(50)
                .HasColumnName("b21");
            entity.Property(e => e.B22)
                .HasMaxLength(50)
                .HasColumnName("b22");
            entity.Property(e => e.B23)
                .HasMaxLength(50)
                .HasColumnName("b23");
            entity.Property(e => e.B2c1)
                .HasMaxLength(50)
                .HasColumnName("b2c1");
            entity.Property(e => e.B2c2)
                .HasMaxLength(50)
                .HasColumnName("b2c2");
            entity.Property(e => e.B2c3)
                .HasMaxLength(50)
                .HasColumnName("b2c3");
            entity.Property(e => e.B2c4)
                .HasMaxLength(50)
                .HasColumnName("b2c4");
            entity.Property(e => e.B2c5)
                .HasMaxLength(50)
                .HasColumnName("b2c5");
            entity.Property(e => e.B2c6)
                .HasMaxLength(50)
                .HasColumnName("b2c6");
            entity.Property(e => e.B2c7)
                .HasMaxLength(50)
                .HasColumnName("b2c7");
            entity.Property(e => e.B3)
                .HasMaxLength(50)
                .HasColumnName("b3");
            entity.Property(e => e.B3c1)
                .HasMaxLength(50)
                .HasColumnName("b3c1");
            entity.Property(e => e.B3c2)
                .HasMaxLength(50)
                .HasColumnName("b3c2");
            entity.Property(e => e.B3c3)
                .HasMaxLength(50)
                .HasColumnName("b3c3");
            entity.Property(e => e.B4)
                .HasMaxLength(50)
                .HasColumnName("b4");
            entity.Property(e => e.B4c1)
                .HasMaxLength(50)
                .HasColumnName("b4c1");
            entity.Property(e => e.B5)
                .HasMaxLength(50)
                .HasColumnName("b5");
            entity.Property(e => e.B5c1)
                .HasMaxLength(50)
                .HasColumnName("b5c1");
            entity.Property(e => e.B5c2)
                .HasMaxLength(50)
                .HasColumnName("b5c2");
            entity.Property(e => e.B6)
                .HasMaxLength(50)
                .HasColumnName("b6");
            entity.Property(e => e.B7)
                .HasMaxLength(50)
                .HasColumnName("b7");
            entity.Property(e => e.B8)
                .HasMaxLength(50)
                .HasColumnName("b8");
            entity.Property(e => e.B8c1)
                .HasMaxLength(50)
                .HasColumnName("b8c1");
            entity.Property(e => e.B8c2)
                .HasMaxLength(50)
                .HasColumnName("b8c2");
            entity.Property(e => e.B9)
                .HasMaxLength(50)
                .HasColumnName("b9");
            entity.Property(e => e.B9c1)
                .HasMaxLength(50)
                .HasColumnName("b9c1");
            entity.Property(e => e.B9c2)
                .HasMaxLength(50)
                .HasColumnName("b9c2");
            entity.Property(e => e.B9c3)
                .HasMaxLength(50)
                .HasColumnName("b9c3");
            entity.Property(e => e.B9c4)
                .HasMaxLength(50)
                .HasColumnName("b9c4");
            entity.Property(e => e.B9c5)
                .HasMaxLength(50)
                .HasColumnName("b9c5");
            entity.Property(e => e.Blot1).HasColumnName("blot1");
            entity.Property(e => e.Date1).HasColumnName("date1");
            entity.Property(e => e.Datetime1).HasColumnName("datetime1");
            entity.Property(e => e.Pivot1).HasColumnName("pivot1");
            entity.Property(e => e.QgrId).HasColumnName("qgr_id");
            entity.Property(e => e.QuestName)
                .HasMaxLength(255)
                .HasColumnName("quest_name");
            entity.Property(e => e.RepName)
                .HasMaxLength(50)
                .HasColumnName("rep_name");
            entity.Property(e => e.Trans1).HasColumnName("trans1");
            entity.Property(e => e.User1)
                .HasMaxLength(50)
                .HasColumnName("user1");

            entity.HasOne(d => d.Qgr).WithMany(p => p.TblQuests)
                .HasForeignKey(d => d.QgrId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_tblQuest_tblQgr");
        });

        modelBuilder.Entity<TblQuestDimeR>(entity =>
        {
            entity.HasKey(e => new { e.QuestId, e.DimeId, e.DtypeId });

            entity.ToTable("tblQuestDimeR");

            entity.HasIndex(e => e.DtypeId, "IX_tblQuestDimeR_dtype_id");

            entity.Property(e => e.QuestId).HasColumnName("quest_id");
            entity.Property(e => e.DimeId).HasColumnName("dime_id");
            entity.Property(e => e.DtypeId).HasColumnName("dtype_id");
            entity.Property(e => e.Datetime1).HasColumnName("datetime1");
            entity.Property(e => e.User1)
                .HasMaxLength(50)
                .HasColumnName("user1");

            entity.HasOne(d => d.Dtype).WithMany(p => p.TblQuestDimeRs)
                .HasForeignKey(d => d.DtypeId)
                .HasConstraintName("FK_tblQuestDimeR_tblDtype");

            entity.HasOne(d => d.Quest).WithMany(p => p.TblQuestDimeRs)
                .HasForeignKey(d => d.QuestId)
                .HasConstraintName("FK_tblQuestDimeR_tblQuest");
        });

        modelBuilder.Entity<TblRangeTherapy>(entity =>
        {
            entity.HasKey(e => e.RangeTherapyId);

            entity.ToTable("tblRangeTherapy");

            entity.Property(e => e.RangeTherapyId).HasColumnName("range_therapy_id");
            entity.Property(e => e.Datetime1).HasColumnName("datetime1");
            entity.Property(e => e.RangeTherapyLong)
                .HasMaxLength(100)
                .HasColumnName("range_therapy_long");
            entity.Property(e => e.RangeTherapyShort)
                .HasMaxLength(50)
                .HasColumnName("range_therapy_short");
            entity.Property(e => e.User1)
                .HasMaxLength(50)
                .HasColumnName("user1");
        });

        modelBuilder.Entity<TblRegTime>(entity =>
        {
            entity.HasKey(e => e.RegTimeId);

            entity.ToTable("tblRegTime");

            entity.Property(e => e.RegTimeId)
                .ValueGeneratedNever()
                .HasColumnName("reg_time_id");
            entity.Property(e => e.PatientCount).HasColumnName("patient_count");
            entity.Property(e => e.RegTimeLong)
                .HasMaxLength(11)
                .HasColumnName("reg_time_long");
            entity.Property(e => e.RegTimeShort)
                .HasMaxLength(11)
                .HasColumnName("reg_time_short");
        });

        modelBuilder.Entity<TblRegion>(entity =>
        {
            entity.HasKey(e => e.RegionId);

            entity.ToTable("tblRegion");

            entity.HasIndex(e => e.RegtypeId, "IX_tblRegion_regtype_id");

            entity.Property(e => e.RegionId).HasColumnName("region_id");
            entity.Property(e => e.Datetime1).HasColumnName("datetime1");
            entity.Property(e => e.Index1)
                .HasMaxLength(50)
                .HasColumnName("index1");
            entity.Property(e => e.MosregYn).HasColumnName("mosregYN");
            entity.Property(e => e.RegionLong)
                .HasMaxLength(100)
                .HasColumnName("region_long");
            entity.Property(e => e.RegionShort)
                .HasMaxLength(50)
                .HasColumnName("region_short");
            entity.Property(e => e.RegtypeId).HasColumnName("regtype_id");
            entity.Property(e => e.SubjectRf).HasColumnName("subject_rf");
            entity.Property(e => e.User1)
                .HasMaxLength(50)
                .HasColumnName("user1");

            entity.HasOne(d => d.Regtype).WithMany(p => p.TblRegions)
                .HasForeignKey(d => d.RegtypeId)
                .HasConstraintName("FK_tblRegion_tblRegtype");
        });

        modelBuilder.Entity<TblRegionSelect>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("tblRegionSelect");

            entity.Property(e => e.Datetime1).HasColumnName("datetime1");
            entity.Property(e => e.RegionSelectId)
                .ValueGeneratedOnAdd()
                .HasColumnName("RegionSelect_id");
            entity.Property(e => e.RegionSelectItem)
                .HasMaxLength(8000)
                .HasColumnName("RegionSelect_item");
            entity.Property(e => e.RegionSelectName)
                .HasMaxLength(255)
                .HasColumnName("RegionSelect_name");
            entity.Property(e => e.User1)
                .HasMaxLength(50)
                .HasColumnName("user1");
        });

        modelBuilder.Entity<TblRegist>(entity =>
        {
            entity.HasKey(e => e.RegistId);

            entity.ToTable("tblRegist");

            entity.Property(e => e.RegistId)
                .ValueGeneratedNever()
                .HasColumnName("regist_id");
            entity.Property(e => e.Datetime1).HasColumnName("datetime1");
            entity.Property(e => e.RegistLong)
                .HasMaxLength(100)
                .HasColumnName("regist_long");
            entity.Property(e => e.RegistShort)
                .HasMaxLength(50)
                .HasColumnName("regist_short");
            entity.Property(e => e.User1)
                .HasMaxLength(50)
                .HasColumnName("user1");
        });

        modelBuilder.Entity<TblRegtype>(entity =>
        {
            entity.HasKey(e => e.RegtypeId);

            entity.ToTable("tblRegtype");

            entity.Property(e => e.RegtypeId).HasColumnName("regtype_id");
            entity.Property(e => e.Datetime1).HasColumnName("datetime1");
            entity.Property(e => e.RegtypeLong)
                .HasMaxLength(100)
                .HasColumnName("regtype_long");
            entity.Property(e => e.RegtypeShort)
                .HasMaxLength(50)
                .HasColumnName("regtype_short");
            entity.Property(e => e.User1)
                .HasMaxLength(50)
                .HasColumnName("user1");
        });

        modelBuilder.Entity<TblResearch>(entity =>
        {
            entity.HasKey(e => e.ResearchId);

            entity.ToTable("tblResearch");

            entity.Property(e => e.ResearchId).HasColumnName("research_id");
            entity.Property(e => e.Datetime1).HasColumnName("datetime1");
            entity.Property(e => e.ResearchLong)
                .HasMaxLength(100)
                .HasColumnName("research_long");
            entity.Property(e => e.User1)
                .HasMaxLength(50)
                .HasColumnName("user1");
        });

        modelBuilder.Entity<TblResist>(entity =>
        {
            entity.HasKey(e => e.ResistId);

            entity.ToTable("tblResist");

            entity.Property(e => e.ResistId)
                .ValueGeneratedNever()
                .HasColumnName("resist_id");
            entity.Property(e => e.Datetime1).HasColumnName("datetime1");
            entity.Property(e => e.ResistLong)
                .HasMaxLength(100)
                .HasColumnName("resist_long");
            entity.Property(e => e.ResistShort)
                .HasMaxLength(50)
                .HasColumnName("resist_short");
            entity.Property(e => e.User1)
                .HasMaxLength(50)
                .HasColumnName("user1");
        });

        modelBuilder.Entity<TblRmedic>(entity =>
        {
            entity.HasKey(e => e.RmedicId);

            entity.ToTable("tblRmedic");

            entity.Property(e => e.RmedicId)
                .ValueGeneratedNever()
                .HasColumnName("rmedic_id");
            entity.Property(e => e.Datetime1).HasColumnName("datetime1");
            entity.Property(e => e.RmedicLong)
                .HasMaxLength(100)
                .HasColumnName("rmedic_long");
            entity.Property(e => e.RmedicShort)
                .HasMaxLength(50)
                .HasColumnName("rmedic_short");
            entity.Property(e => e.User1)
                .HasMaxLength(50)
                .HasColumnName("user1");
        });

        modelBuilder.Entity<TblSchemaMedicineR>(entity =>
        {
            entity.HasKey(e => new { e.CureSchemaId, e.MedicineId });

            entity.ToTable("tblSchemaMedicineR");

            entity.HasIndex(e => e.MedicineId, "IX_tblSchemaMedicineR_medicine_id");

            entity.Property(e => e.CureSchemaId).HasColumnName("cure_schema_id");
            entity.Property(e => e.MedicineId).HasColumnName("medicine_id");
            entity.Property(e => e.Datetime1).HasColumnName("datetime1");
            entity.Property(e => e.User1)
                .HasMaxLength(50)
                .HasColumnName("user1");

            entity.HasOne(d => d.CureSchema).WithMany(p => p.TblSchemaMedicineRs)
                .HasForeignKey(d => d.CureSchemaId)
                .HasConstraintName("FK_tblSchemaMedicineR_tblCureSchema");

            entity.HasOne(d => d.Medicine).WithMany(p => p.TblSchemaMedicineRs)
                .HasForeignKey(d => d.MedicineId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_tblSchemaMedicineR_tblMedicine");
        });

        modelBuilder.Entity<TblSecDi>(entity =>
        {
            entity.HasKey(e => e.IdSecDis);

            entity.ToTable("tblSecDis");

            entity.Property(e => e.IdSecDis).HasColumnName("id_sec_dis");
            entity.Property(e => e.Comment)
                .HasMaxLength(100)
                .IsFixedLength()
                .HasColumnName("comment");
            entity.Property(e => e.DEnd).HasColumnName("d_end");
            entity.Property(e => e.DStart).HasColumnName("d_start");
            entity.Property(e => e.IdMkbSecDis).HasColumnName("id_MKB_sec_dis");
            entity.Property(e => e.PatientId).HasColumnName("patient_id");
        });

        modelBuilder.Entity<TblSetup>(entity =>
        {
            entity.ToTable("tblSetup");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
        });

        modelBuilder.Entity<TblSex>(entity =>
        {
            entity.HasKey(e => e.SexId);

            entity.ToTable("tblSex");

            entity.Property(e => e.SexId).HasColumnName("sex_id");
            entity.Property(e => e.Datetime1).HasColumnName("datetime1");
            entity.Property(e => e.SexLong)
                .HasMaxLength(50)
                .HasColumnName("sex_long");
            entity.Property(e => e.SexShort)
                .HasMaxLength(3)
                .HasColumnName("sex_short");
            entity.Property(e => e.User1)
                .HasMaxLength(50)
                .HasColumnName("user1");
        });

        modelBuilder.Entity<TblShowIllness>(entity =>
        {
            entity.HasKey(e => e.ShowIllnessId);

            entity.ToTable("tblShowIllness");

            entity.Property(e => e.ShowIllnessId).HasColumnName("show_illness_id");
            entity.Property(e => e.Datetime1).HasColumnName("datetime1");
            entity.Property(e => e.ShowIllnessLong)
                .HasMaxLength(100)
                .HasColumnName("show_illness_long");
            entity.Property(e => e.ShowIllnessShort)
                .HasMaxLength(50)
                .HasColumnName("show_illness_short");
            entity.Property(e => e.User1)
                .HasMaxLength(50)
                .HasColumnName("user1");
        });

        modelBuilder.Entity<TblSpec>(entity =>
        {
            entity.HasKey(e => e.SpecId);

            entity.ToTable("tblSpec");

            entity.Property(e => e.SpecId).HasColumnName("spec_id");
            entity.Property(e => e.Datetime1).HasColumnName("datetime1");
            entity.Property(e => e.SpecLong)
                .HasMaxLength(50)
                .HasColumnName("spec_long");
            entity.Property(e => e.SpecShort)
                .HasMaxLength(50)
                .HasColumnName("spec_short");
            entity.Property(e => e.User1)
                .HasMaxLength(50)
                .HasColumnName("user1");
        });

        modelBuilder.Entity<TblStacionar>(entity =>
        {
            entity.HasKey(e => e.StacionarId);

            entity.ToTable("tblStacionar");

            entity.Property(e => e.StacionarId).HasColumnName("stacionar_id");
            entity.Property(e => e.Datetime1).HasColumnName("datetime1");
            entity.Property(e => e.StacionarLong)
                .HasMaxLength(100)
                .HasColumnName("stacionar_long");
            entity.Property(e => e.StacionarShort)
                .HasMaxLength(50)
                .HasColumnName("stacionar_short");
            entity.Property(e => e.User1)
                .HasMaxLength(50)
                .HasColumnName("user1");
        });

        modelBuilder.Entity<TblStatus>(entity =>
        {
            entity.HasKey(e => e.StatusId);

            entity.ToTable("tblStatus");

            entity.Property(e => e.StatusId)
                .ValueGeneratedNever()
                .HasColumnName("status_id");
            entity.Property(e => e.StatusLong)
                .HasMaxLength(100)
                .HasColumnName("status_long");
            entity.Property(e => e.StatusShort)
                .HasMaxLength(50)
                .HasColumnName("status_short");
        });

        modelBuilder.Entity<TblTalonListOfValue>(entity =>
        {
            entity.HasKey(e => new { e.TalonField, e.ValueId });

            entity.ToTable("tblTalonListOfValue");

            entity.Property(e => e.TalonField).HasColumnName("talon_field");
            entity.Property(e => e.ValueId).HasColumnName("value_id");
            entity.Property(e => e.ValueDescr)
                .HasMaxLength(255)
                .HasColumnName("value_descr");
            entity.Property(e => e.ValueSort).HasColumnName("value_sort");
        });

        modelBuilder.Entity<TblTempDieCureMkb10list>(entity =>
        {
            entity.HasKey(e => e.DieCourseId);

            entity.ToTable("tblTempDieCureMKB10List");

            entity.Property(e => e.DieCourseId).HasColumnName("die_course_id");
            entity.Property(e => e.DethtypeId).HasColumnName("Dethtype_id");
            entity.Property(e => e.DieCourseLong)
                .HasMaxLength(250)
                .IsFixedLength()
                .HasColumnName("die_course_long");
            entity.Property(e => e.DieCourseShort)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("die_course_short");
        });

        modelBuilder.Entity<TblUser>(entity =>
        {
            entity.HasKey(e => new { e.Uid, e.Pwd });

            entity.ToTable("tblUser");

            entity.HasIndex(e => e.RegionId, "IX_tblUser_region_id");

            entity.Property(e => e.Uid)
                .HasMaxLength(50)
                .HasColumnName("uid");
            entity.Property(e => e.Pwd)
                .HasMaxLength(50)
                .HasColumnName("pwd");
            entity.Property(e => e.Admin1).HasColumnName("admin1");
            entity.Property(e => e.Datetime1).HasColumnName("datetime1");
            entity.Property(e => e.Delete1).HasColumnName("delete1");
            entity.Property(e => e.Excel1).HasColumnName("excel1");
            entity.Property(e => e.Klassif1).HasColumnName("klassif1");
            entity.Property(e => e.RegionId).HasColumnName("region_id");
            entity.Property(e => e.User1)
                .HasMaxLength(50)
                .HasColumnName("user1");
            entity.Property(e => e.UserName)
                .HasMaxLength(100)
                .HasColumnName("user_name");
            entity.Property(e => e.Write1).HasColumnName("write1");
            entity.Property(e => e.RefreshToken).HasColumnName("refresh_token");
            entity.Property(e => e.RefreshTokenExpiryTime).HasColumnName("refresh_token_expiry_time");

            entity.HasOne(d => d.Region).WithMany(p => p.TblUsers)
                .HasForeignKey(d => d.RegionId)
                .HasConstraintName("FK_tblUser_tblRegion");
        });

        modelBuilder.Entity<TblVloadResult>(entity =>
        {
            entity.HasKey(e => e.VloadResultId);

            entity.ToTable("tblVloadResult");

            entity.Property(e => e.VloadResultId).HasColumnName("vload_result_id");
            entity.Property(e => e.Datetime1).HasColumnName("datetime1");
            entity.Property(e => e.User1)
                .HasMaxLength(50)
                .HasColumnName("user1");
            entity.Property(e => e.VloadResultLong)
                .HasMaxLength(100)
                .HasColumnName("vload_result_long");
            entity.Property(e => e.VloadResultShort)
                .HasMaxLength(50)
                .HasColumnName("vload_result_short");
        });

        modelBuilder.Entity<TblZzztempSnil>(entity =>
        {
            entity.HasKey(e => e.PatientId);

            entity.ToTable("tblZZZTempSNILS");

            entity.Property(e => e.PatientId)
                .ValueGeneratedNever()
                .HasColumnName("patient_id");
            entity.Property(e => e.Datetime1).HasColumnName("datetime1");
            entity.Property(e => e.Snils)
                .HasMaxLength(50)
                .HasColumnName("snils");
            entity.Property(e => e.SnilsFed)
                .HasMaxLength(50)
                .HasColumnName("snils_fed");
        });

        modelBuilder.Entity<QrySearchMainInf>(entity =>
        {
            entity.HasNoKey();

            entity.ToTable("qrySearchMainInf");

            entity.Property(e => e.PatientId)
                .HasColumnName("patient_id");

            entity.Property(e => e.InputDate)
                .HasColumnName("input_date");

            entity.Property(e => e.Snils)
                .HasColumnName("snils");

            entity.Property(e => e.FamilyName)
                .HasColumnName("family_name");

            entity.Property(e => e.FirstName)
                .HasColumnName("first_name");

            entity.Property(e => e.ThirdName)
                .HasColumnName("third_name");

            entity.Property(e => e.SexShort)
                .HasColumnName("sex_short");

            entity.Property(e => e.BirthDate)
                .HasColumnName("birth_date");

            entity.Property(e => e.RegionLong)
                .HasColumnName("region_long");

            entity.Property(e => e.RegionLongFact)
                .HasColumnName("region_long_fact");

            entity.Property(e => e.CountryLong)
                .HasColumnName("country_long");

            entity.Property(e => e.CityName)
                .HasColumnName("city_name");

            entity.Property(e => e.LocationName)
                .HasColumnName("location_name");

            entity.Property(e => e.AddrInd)
                .HasColumnName("addr_ind");

            entity.Property(e => e.AddrStreet)
                .HasColumnName("addr_street");

            entity.Property(e => e.AddrHouse)
                .HasColumnName("addr_house");

            entity.Property(e => e.AddrExt)
                .HasColumnName("addr_ext");

            entity.Property(e => e.AddrFlat)
                .HasColumnName("addr_flat");

            entity.Property(e => e.RegOnDate)
                .HasColumnName("reg_on_date");

            entity.Property(e => e.RegOffDate)
                .HasColumnName("reg_off_date");

            entity.Property(e => e.RegOff)
                .HasColumnName("reg_off");

            entity.Property(e => e.CheckPlaceLong)
                .HasColumnName("check_place_long");

            entity.Property(e => e.DiagnosisLong)
                .HasColumnName("diagnosis_long");

            entity.Property(e => e.DiagnosisDefDate)
                .HasColumnName("diagnosis_def_date");

            entity.Property(e => e.DieDate)
                .HasColumnName("die_date");

            entity.Property(e => e.DieAidsDate)
                .HasColumnName("die_aids_date");

            entity.Property(e => e.DieDateInput)
                .HasColumnName("die_date_input");

            entity.Property(e => e.CheckCourseLong)
                .HasColumnName("check_course_long");

            entity.Property(e => e.DieCourseShort)
                .HasColumnName("die_course_short");

            entity.Property(e => e.DieCourseLong)
                .HasColumnName("die_course_long");

            entity.Property(e => e.DethtypeId)
                .HasColumnName("Dethtype_id");

            entity.Property(e => e.InfectCourseLong)
                .HasColumnName("infect_course_long");

            entity.Property(e => e.ShowIllnessLong)
                .HasColumnName("show_illness_long");

            entity.Property(e => e.StartDate)
                .HasColumnName("start_date");

            entity.Property(e => e.EndDate)
                .HasColumnName("end_date");

            entity.Property(e => e.IbResultShort)
                .HasColumnName("ib_result_short");

            entity.Property(e => e.BlotDate)
                .HasColumnName("blot_date");

            entity.Property(e => e.BlotNo)
                .HasColumnName("blot_no");

            entity.Property(e => e.First1)
                .HasColumnName("first1");

            entity.Property(e => e.Last1)
                .HasColumnName("last1");

            entity.Property(e => e.Datetime1)
                .HasColumnName("datetime1");

            entity.Property(e => e.HospCourseLong)
                .HasColumnName("hosp_course_long");

            entity.Property(e => e.CardNo)
                .HasColumnName("card_no");

            entity.Property(e => e.ArvtLong)
                .HasColumnName("arvt_long");

            entity.Property(e => e.CodeMkb10Long)
                .HasColumnName("code_mkb10_long");

            entity.Property(e => e.Archive)
                .HasColumnName("archive");

            entity.Property(e => e.TransfAreaDate)
                .HasColumnName("transf_area_date");

            entity.Property(e => e.FlgZamMedPart)
                .HasColumnName("flg_zam_med_part");

            entity.Property(e => e.FlgHeadPhysician)
                .HasColumnName("flg_head_physician");

            entity.Property(e => e.TransfFederDate)
                .HasColumnName("transf_feder_date");

            entity.Property(e => e.UfsinDate)
                .HasColumnName("ufsin_date");

            entity.Property(e => e.Aids12Long)
                .HasColumnName("aids12_long");

            entity.Property(e => e.UnrzFr)
                .HasColumnName("unrz_fr");

            entity.Property(e => e.ChemopLong)
                .HasColumnName("chemop_long");

            entity.Property(e => e.ChemopDateFrom)
                .HasColumnName("chemop_date_from");

            entity.Property(e => e.ChemopDateTo)
                .HasColumnName("chemop_date_to");

            entity.Property(e => e.DtRegBeg)
                .HasColumnName("dt_reg_beg");

            entity.Property(e => e.DtRegEnd)
                .HasColumnName("dt_reg_end");

            entity.Property(e => e.PasSer)
                .HasColumnName("pas_ser");

            entity.Property(e => e.PasNum)
                .HasColumnName("pas_num");

            entity.Property(e => e.PasWhen)
                .HasColumnName("pas_when");

            entity.Property(e => e.PasWhom)
                .HasColumnName("pas_whom");

            entity.Property(e => e.FioChange)
                .HasColumnName("fio_change");

            entity.Property(e => e.Age)
                .HasColumnName("age");

            entity.Property(e => e.RegtypeId)
                .HasColumnName("regtype_id");

            entity.Property(e => e.FactRegtypeId)
                .HasColumnName("fact_regtype_id");
        });

        modelBuilder.Entity<QrySearchPregnant>(entity =>
        {
            entity.HasNoKey();

            entity.ToTable("qrySearchPregnant");

            entity.Property(e => e.PatientId)
                .HasColumnName("patient_id");

            entity.Property(e => e.InputDate)
                .HasColumnName("input_date");

            entity.Property(e => e.FamilyName)
                .HasColumnName("family_name");

            entity.Property(e => e.FirstName)
                .HasColumnName("first_name");

            entity.Property(e => e.ThirdName)
                .HasColumnName("third_name");

            entity.Property(e => e.BirthDate)
                .HasColumnName("birth_date");

            entity.Property(e => e.RegionLong)
                .HasColumnName("region_long");

            entity.Property(e => e.RegionLongFact)
                .HasColumnName("region_long_fact");

            entity.Property(e => e.CountryLong)
                .HasColumnName("country_long");

            entity.Property(e => e.RegOnDate)
                .HasColumnName("reg_on_date");

            entity.Property(e => e.RegOffDate)
                .HasColumnName("reg_off_date");

            entity.Property(e => e.DiagnosisLong)
                .HasColumnName("diagnosis_long");

            entity.Property(e => e.DiagnosisDefDate)
                .HasColumnName("diagnosis_def_date");

            entity.Property(e => e.CheckCourseLong)
                .HasColumnName("check_course_long");

            entity.Property(e => e.InfectCourseLong)
                .HasColumnName("infect_course_long");

            entity.Property(e => e.ShowIllnessLong)
                .HasColumnName("show_illness_long");

            entity.Property(e => e.StartDate)
                .HasColumnName("start_date");

            entity.Property(e => e.EndDate)
                .HasColumnName("end_date");

            entity.Property(e => e.TransfAreaDate)
                .HasColumnName("transf_area_date");

            entity.Property(e => e.ArvtLong)
                .HasColumnName("arvt_long");

            entity.Property(e => e.UfsinDate)
                .HasColumnName("ufsin_date");

            entity.Property(e => e.FlgZamMedPart)
                .HasColumnName("flg_zam_med_part");

            entity.Property(e => e.FlgHeadPhysician)
                .HasColumnName("flg_head_physician");

            entity.Property(e => e.CityName)
                .HasColumnName("city_name");

            entity.Property(e => e.LocationName)
                .HasColumnName("location_name");

            entity.Property(e => e.AddrInd)
                .HasColumnName("addr_ind");

            entity.Property(e => e.AddrStreet)
                .HasColumnName("addr_street");

            entity.Property(e => e.AddrHouse)
                .HasColumnName("addr_house");

            entity.Property(e => e.AddrExt)
                .HasColumnName("addr_ext");

            entity.Property(e => e.AddrFlat)
                .HasColumnName("addr_flat");

            entity.Property(e => e.PregCheckLong)
                .HasColumnName("preg_check_long");

            entity.Property(e => e.PregMonthNo)
                .HasColumnName("preg_month_no");

            entity.Property(e => e.Php1Name)
                .HasColumnName("php1_name");

            entity.Property(e => e.BirthTypeLong)
                .HasColumnName("birth_type_long");

            entity.Property(e => e.MedecineStartMonthNo)
                .HasColumnName("medicine_st_month_no");

            entity.Property(e => e.ChildBirthDate)
                .HasColumnName("child_birth_date");

            entity.Property(e => e.PregDate)
                .HasColumnName("preg_date");

            entity.Property(e => e.ChildFamilyName)
                .HasColumnName("child_family_name");

            entity.Property(e => e.ChildFirstName)
                .HasColumnName("child_first_name");

            entity.Property(e => e.ChildThirdName)
                .HasColumnName("child_third_name");

            entity.Property(e => e.CardNo)
                .HasColumnName("card_no");

            entity.Property(e => e.Php2Name)
                .HasColumnName("php2_name");

            entity.Property(e => e.Php3Name)
                .HasColumnName("php3_name");

            entity.Property(e => e.DateStart1)
                .HasColumnName("date_start1");

            entity.Property(e => e.DateEnd1)
                .HasColumnName("date_end1");

            entity.Property(e => e.MedecineForSchemaLong1)
                .HasColumnName("medforschema_long1");

            entity.Property(e => e.MedecineForSchemaLong2)
                .HasColumnName("medforschema_long2");

            entity.Property(e => e.MedecineForSchemaLong3)
                .HasColumnName("medforschema_long3");

            entity.Property(e => e.ChildId)
                .HasColumnName("child_id");

            entity.Property(e => e.MaterhomeLong)
                .HasColumnName("materhome_long");

            entity.Property(e => e.AclSampleDate)
                .HasColumnName("acl_sample_date");

            entity.Property(e => e.AclMcnCode)
                .HasColumnName("acl_mcn_code");

            entity.Property(e => e.RegtypeId)
                .HasColumnName("regtype_id");

            entity.Property(e => e.FactRegtypeId)
                .HasColumnName("fact_regtype_id");
        });

        modelBuilder.Entity<QrySearchChild>(entity =>
        {
            entity.HasNoKey();

            entity.ToTable("qrySearchChild");

            entity.Property(e => e.PatientId)
                .HasColumnName("patient_id");

            entity.Property(e => e.InputDate)
                .HasColumnName("input_date");

            entity.Property(e => e.FamilyName)
                .HasColumnName("family_name");

            entity.Property(e => e.FirstName)
                .HasColumnName("first_name");

            entity.Property(e => e.ThirdName)
                .HasColumnName("third_name");

            entity.Property(e => e.BirthDate)
                .HasColumnName("birth_date");

            entity.Property(e => e.AgeDay)
                .HasColumnName("age_day");

            entity.Property(e => e.RegionLong)
                .HasColumnName("region_long");

            entity.Property(e => e.RegtypeId)
                .HasColumnName("regtype_id");

            entity.Property(e => e.RegionLongFact)
                .HasColumnName("region_long_fact");

            entity.Property(e => e.FactRegtypeId)
                .HasColumnName("fact_regtype_id");

            entity.Property(e => e.CountryLong)
                .HasColumnName("country_long");

            entity.Property(e => e.RegOnDate)
                .HasColumnName("reg_on_date");

            entity.Property(e => e.RegOffDate)
                .HasColumnName("reg_off_date");

            entity.Property(e => e.RegOff)
                .HasColumnName("reg_off");

            entity.Property(e => e.DiagnosisLong)
                .HasColumnName("diagnosis_long");

            entity.Property(e => e.DiagnosisDefDate)
                .HasColumnName("diagnosis_def_date");

            entity.Property(e => e.CheckCourseLong)
                .HasColumnName("check_course_long");

            entity.Property(e => e.InfectCourseLong)
                .HasColumnName("infect_course_long");

            entity.Property(e => e.ShowIllnessLong)
                .HasColumnName("show_illness_long");

            entity.Property(e => e.StartDate)
                .HasColumnName("start_date");

            entity.Property(e => e.EndDate)
                .HasColumnName("end_date");

            entity.Property(e => e.TransfAreaDate)
                .HasColumnName("transf_area_date");

            entity.Property(e => e.FlgZamMedPart)
                .HasColumnName("flg_zam_med_part");

            entity.Property(e => e.FlgHeadPhysician)
                .HasColumnName("flg_head_physician");

            entity.Property(e => e.CodeMkb10Long)
                .HasColumnName("code_mkb10_long");

            entity.Property(e => e.FamilyTypeLong)
                .HasColumnName("family_type_long");

            entity.Property(e => e.CheckFirstDate)
                .HasColumnName("check_first_date");

            entity.Property(e => e.ChildPlaceLong)
                .HasColumnName("child_place_long");

            entity.Property(e => e.BreastMonthNo)
                .HasColumnName("breast_month_no");

            entity.Property(e => e.ChildPhpLong)
                .HasColumnName("child_php_long");

            entity.Property(e => e.SexShort)
                .HasColumnName("sex_short");

            entity.Property(e => e.CardNo)
                .HasColumnName("card_no");

            entity.Property(e => e.MotherPatientId)
                .HasColumnName("mother_patient_id");

            entity.Property(e => e.FatherPatientId)
                .HasColumnName("father_patient_id");

            entity.Property(e => e.CityName)
                .HasColumnName("city_name");

            entity.Property(e => e.LocationName)
                .HasColumnName("location_name");

            entity.Property(e => e.AddrInd)
                .HasColumnName("addr_ind");

            entity.Property(e => e.AddrStreet)
                .HasColumnName("addr_street");

            entity.Property(e => e.AddrHouse)
                .HasColumnName("addr_house");

            entity.Property(e => e.AddrExt)
                .HasColumnName("addr_ext");

            entity.Property(e => e.AddrFlat)
                .HasColumnName("addr_flat");

            entity.Property(e => e.ArvtLong)
                .HasColumnName("arvt_long");

            entity.Property(e => e.DieDate)
                .HasColumnName("die_date");

            entity.Property(e => e.DieAidsDate)
                .HasColumnName("die_aids_date");

            entity.Property(e => e.MaterHomeLong)
                .HasColumnName("materhome_long");

            entity.Property(e => e.Form309)
                .HasColumnName("forma_309");

        });

        modelBuilder.Entity<QrySearchTreatment>(entity =>
        {
            entity.HasNoKey();

            entity.ToTable("qrySearchTreatment");

            entity.Property(e => e.PatientId)
                .HasColumnName("patient_id");

            entity.Property(e => e.InputDate)
                .HasColumnName("input_date");

            entity.Property(e => e.FamilyName)
                .HasColumnName("family_name");

            entity.Property(e => e.FirstName)
                .HasColumnName("first_name");

            entity.Property(e => e.ThirdName)
                .HasColumnName("third_name");

            entity.Property(e => e.SexShort)
                .HasColumnName("sex_short");

            entity.Property(e => e.BirthDate)
                .HasColumnName("birth_date");

            entity.Property(e => e.RegionLong)
                .HasColumnName("region_long");

            entity.Property(e => e.RegtypeId)
                .HasColumnName("regtype_id");

            entity.Property(e => e.RegionLongFact)
                .HasColumnName("region_long_fact");

            entity.Property(e => e.FactRegtypeId)
                .HasColumnName("fact_regtype_id");

            entity.Property(e => e.CountryLong)
                .HasColumnName("country_long");

            entity.Property(e => e.CityName)
                .HasColumnName("city_name");

            entity.Property(e => e.LocationName)
                .HasColumnName("location_name");

            entity.Property(e => e.AddrInd)
                .HasColumnName("addr_ind");

            entity.Property(e => e.AddrStreet)
                .HasColumnName("addr_street");

            entity.Property(e => e.AddrHouse)
                .HasColumnName("addr_house");

            entity.Property(e => e.AddrExt)
                .HasColumnName("addr_ext");

            entity.Property(e => e.AddrFlat)
                .HasColumnName("addr_flat");

            entity.Property(e => e.RegOnDate)
                .HasColumnName("reg_on_date");

            entity.Property(e => e.RegOffDate)
                .HasColumnName("reg_off_date");

            entity.Property(e => e.RegOff)
                .HasColumnName("reg_off");

            entity.Property(e => e.DiagnosisLong)
                .HasColumnName("diagnosis_long");

            entity.Property(e => e.DieDate)
                .HasColumnName("die_date");

            entity.Property(e => e.DieAidsDate)
                .HasColumnName("die_aids_date");

            entity.Property(e => e.DieCourseShort)
                .HasColumnName("die_course_short");

            entity.Property(e => e.DieCourseLong)
                .HasColumnName("die_course_long");

            entity.Property(e => e.DethtypeId)
                .HasColumnName("Dethtype_id");

            entity.Property(e => e.CheckCourseLong)
                .HasColumnName("check_course_long");

            entity.Property(e => e.InfectCourseLong)
                .HasColumnName("infect_course_long");

            entity.Property(e => e.ShowIllnessLong)
                .HasColumnName("show_illness_long");

            entity.Property(e => e.StartDate)
                .HasColumnName("start_date");

            entity.Property(e => e.EndDate)
                .HasColumnName("end_date");

            entity.Property(e => e.TransfAreaDate)
                .HasColumnName("transf_area_date");

            entity.Property(e => e.FlgZamMedPart)
                .HasColumnName("flg_zam_med_part");

            entity.Property(e => e.FlgHeadPhysician)
                .HasColumnName("flg_head_physician");

            entity.Property(e => e.IbResultShort)
                .HasColumnName("ib_result_short");

            entity.Property(e => e.BlotDate)
                .HasColumnName("blot_date");

            entity.Property(e => e.BlotNo)
                .HasColumnName("blot_no");

            entity.Property(e => e.First1)
                .HasColumnName("first1");

            entity.Property(e => e.Last1)
                .HasColumnName("last1");

            entity.Property(e => e.Datetime1)
                .HasColumnName("datetime1");

            entity.Property(e => e.UfsinDate)
                .HasColumnName("ufsin_date");

            entity.Property(e => e.InvalidLong)
                .HasColumnName("invalid_long");

            entity.Property(e => e.CorrespIllnessLong)
                .HasColumnName("corresp_illness_long");

            entity.Property(e => e.CorrespIllnessDate)
                .HasColumnName("correspillness_date");

            entity.Property(e => e.CureSchemaLong)
                .HasColumnName("cure_schema_long");

            entity.Property(e => e.SchemaStartDate)
                .HasColumnName("chema_start_date");

            entity.Property(e => e.SchemaLast)
                .HasColumnName("schema_last");

            entity.Property(e => e.MedforschemaLong)
                .HasColumnName("medforschema_long");

            entity.Property(e => e.CureChangeLong)
                .HasColumnName("cure_change_long");

            entity.Property(e => e.MedicineLong)
                .HasColumnName("medicine_long");

            entity.Property(e => e.GiveMedicineLong)
                .HasColumnName("give_medicine_long");

            entity.Property(e => e.DoctorLong)
                .HasColumnName("doctor_long");

            entity.Property(e => e.GiveDate)
                .HasColumnName("give_date");

            entity.Property(e => e.CardNo)
                .HasColumnName("card_no");

            entity.Property(e => e.FinSourceLong)
                .HasColumnName("fin_source_long");

            entity.Property(e => e.ArvtLong)
                .HasColumnName("arvt_long");

            entity.Property(e => e.RangeTherapyLong)
                .HasColumnName("range_therapy_long");

            entity.Property(e => e.VlDate)
                .HasColumnName("vl_date");

            entity.Property(e => e.VlResult)
                .HasColumnName("vl_result");

            entity.Property(e => e.ImDate)
                .HasColumnName("im_date");

            entity.Property(e => e.ImResult)
                .HasColumnName("i0025");
        });

        modelBuilder.Entity<QrySearchAnalyse>(entity =>
        {
            entity.HasNoKey();

            entity.ToTable("qrySearchAnalyse");

            entity.Property(e => e.PatientId)
                .HasColumnName("patient_id");

            entity.Property(e => e.InputDate)
                .HasColumnName("input_date");

            entity.Property(e => e.FamilyName)
                .HasColumnName("family_name");

            entity.Property(e => e.FirstName)
                .HasColumnName("first_name");

            entity.Property(e => e.ThirdName)
                .HasColumnName("third_name");

            entity.Property(e => e.SexShort)
                .HasColumnName("sex_short");

            entity.Property(e => e.BirthDate)
                .HasColumnName("birth_date");

            entity.Property(e => e.RegionLong)
                .HasColumnName("region_long");

            entity.Property(e => e.RegtypeId)
                .HasColumnName("regtype_id");

            entity.Property(e => e.RegionLongFact)
                .HasColumnName("region_long_fact");

            entity.Property(e => e.FactRegtypeId)
                .HasColumnName("fact_regtype_id");

            entity.Property(e => e.CountryLong)
                .HasColumnName("country_long");

            entity.Property(e => e.CityName)
                .HasColumnName("city_name");

            entity.Property(e => e.LocationName)
                .HasColumnName("location_name");

            entity.Property(e => e.AddrInd)
                .HasColumnName("addr_ind");

            entity.Property(e => e.AddrStreet)
                .HasColumnName("addr_street");

            entity.Property(e => e.AddrHouse)
                .HasColumnName("addr_house");

            entity.Property(e => e.AddrExt)
                .HasColumnName("addr_ext");

            entity.Property(e => e.AddrFlat)
                .HasColumnName("addr_flat");

            entity.Property(e => e.RegOnDate)
                .HasColumnName("reg_on_date");

            entity.Property(e => e.RegOffDate)
                .HasColumnName("reg_off_date");

            entity.Property(e => e.RegOff)
                .HasColumnName("reg_off");

            entity.Property(e => e.DiagnosisLong)
                .HasColumnName("diagnosis_long");

            entity.Property(e => e.DieDate)
                .HasColumnName("die_date");

            entity.Property(e => e.DieAidsDate)
                .HasColumnName("die_aids_date");

            entity.Property(e => e.DieCourseShort)
                .HasColumnName("die_course_short");

            entity.Property(e => e.DieCourseLong)
                .HasColumnName("die_course_long");

            entity.Property(e => e.DethtypeId)
                .HasColumnName("Dethtype_id");

            entity.Property(e => e.CheckCourseLong)
                .HasColumnName("check_course_long");

            entity.Property(e => e.InfectCourseLong)
                .HasColumnName("infect_course_long");

            entity.Property(e => e.ShowIllnessLong)
                .HasColumnName("show_illness_long");

            entity.Property(e => e.StartDate)
                .HasColumnName("start_date");

            entity.Property(e => e.EndDate)
                .HasColumnName("end_date");

            entity.Property(e => e.TransfAreaDate)
                .HasColumnName("transf_area_date");

            entity.Property(e => e.FlgZamMedPart)
                .HasColumnName("flg_zam_med_part");

            entity.Property(e => e.FlgHeadPhysician)
                .HasColumnName("flg_head_physician");

            entity.Property(e => e.IbResultShort)
                .HasColumnName("ib_result_short");

            entity.Property(e => e.BlotDate)
                .HasColumnName("blot_date");

            entity.Property(e => e.BlotNo)
                .HasColumnName("blot_no");

            entity.Property(e => e.First1)
                .HasColumnName("first1");

            entity.Property(e => e.Last1)
                .HasColumnName("last1");

            entity.Property(e => e.Datetime1)
                .HasColumnName("datetime1");

            entity.Property(e => e.UfsinDate)
                .HasColumnName("ufsin_date");

            entity.Property(e => e.VlDate)
                .HasColumnName("vl_date");

            entity.Property(e => e.VlResult)
                .HasColumnName("vl_result");

            entity.Property(e => e.ImDate)
                .HasColumnName("im_date");

            entity.Property(e => e.I0015)
                .HasColumnName("i0015");

            entity.Property(e => e.I0025)
                .HasColumnName("i0025");

            entity.Property(e => e.I0035)
                .HasColumnName("i0035");

            entity.Property(e => e.HepBRes)
                .HasColumnName("hep_b_res");

            entity.Property(e => e.HepBDate)
                .HasColumnName("hep_b_date");

            entity.Property(e => e.HepCRes)
                .HasColumnName("hep_c_res");

            entity.Property(e => e.HepCDate)
                .HasColumnName("hep_c_date");

            entity.Property(e => e.HepBIfaRes)
                .HasColumnName("hep_b_ifa_res");

            entity.Property(e => e.HepBIfaDate)
                .HasColumnName("hep_b_ifa_date");

            entity.Property(e => e.HepCIfaRes)
                .HasColumnName("hep_c_ifa_res");

            entity.Property(e => e.HepCIfaDate)
                .HasColumnName("hep_c_ifa_date");

            entity.Property(e => e.HepSyphIfaRes)
                .HasColumnName("hep_syph_ifa_res");

            entity.Property(e => e.HepSyphIfaDate)
                .HasColumnName("hep_syph_ifa_date");

            entity.Property(e => e.CardNo)
                .HasColumnName("card_no");

            entity.Property(e => e.ArvtLong)
                .HasColumnName("arvt_long");
        });

        modelBuilder.Entity<QrySearchAcl>(entity =>
        {
            entity.HasNoKey();

            entity.ToTable("qrySearchAcl");

            entity.Property(e => e.PatientId)
                .HasColumnName("patient_id");

            entity.Property(e => e.InputDate)
                .HasColumnName("input_date");

            entity.Property(e => e.FamilyName)
                .HasColumnName("family_name");

            entity.Property(e => e.FirstName)
                .HasColumnName("first_name");

            entity.Property(e => e.ThirdName)
                .HasColumnName("third_name");

            entity.Property(e => e.SexShort)
                .HasColumnName("sex_short");

            entity.Property(e => e.BirthDate)
                .HasColumnName("birth_date");

            entity.Property(e => e.RegionLong)
                .HasColumnName("region_long");

            entity.Property(e => e.RegtypeId)
                .HasColumnName("regtype_id");

            entity.Property(e => e.RegionLongFact)
                .HasColumnName("region_long_fact");

            entity.Property(e => e.FactRegtypeId)
                .HasColumnName("fact_regtype_id");

            entity.Property(e => e.RegOnDate)
                .HasColumnName("reg_on_date");

            entity.Property(e => e.RegOffDate)
                .HasColumnName("reg_off_date");

            entity.Property(e => e.RegOff)
                .HasColumnName("reg_off");

            entity.Property(e => e.DiagnosisLong)
                .HasColumnName("diagnosis_long");

            entity.Property(e => e.CheckCourseLong)
                .HasColumnName("check_course_long");

            entity.Property(e => e.IbResultShort)
                .HasColumnName("ib_result_short");

            entity.Property(e => e.BlotDate)
                .HasColumnName("blot_date");

            entity.Property(e => e.BlotNo)
                .HasColumnName("blot_no");

            entity.Property(e => e.First1)
                .HasColumnName("first1");

            entity.Property(e => e.Last1)
                .HasColumnName("last1");

            entity.Property(e => e.Datetime1)
                .HasColumnName("datetime1");

            entity.Property(e => e.AclTestCode)
                .HasColumnName("acl_test_code");

            entity.Property(e => e.AclSampleDate)
                .HasColumnName("acl_sample_date");

            entity.Property(e => e.AclMcnCode)
                .HasColumnName("acl_mcn_code");

            entity.Property(e => e.AclResult)
                .HasColumnName("acl_result");
        });

        modelBuilder.Entity<QrySearchVisit>(entity =>
        {
            entity.HasNoKey();

            entity.ToTable("qrySearchVisit");

            entity.Property(e => e.PatientId)
                .HasColumnName("patient_id");

            entity.Property(e => e.InputDate)
                .HasColumnName("input_date");

            entity.Property(e => e.FamilyName)
                .HasColumnName("family_name");

            entity.Property(e => e.FirstName)
                .HasColumnName("first_name");

            entity.Property(e => e.ThirdName)
                .HasColumnName("third_name");

            entity.Property(e => e.SexShort)
                .HasColumnName("sex_short");

            entity.Property(e => e.BirthDate)
                .HasColumnName("birth_date");

            entity.Property(e => e.RegionLong)
                .HasColumnName("region_long");

            entity.Property(e => e.RegtypeId)
                .HasColumnName("regtype_id");

            entity.Property(e => e.RegionLongFact)
                .HasColumnName("region_long_fact");

            entity.Property(e => e.FactRegtypeId)
                .HasColumnName("fact_regtype_id");

            entity.Property(e => e.CountryLong)
                .HasColumnName("country_long");

            entity.Property(e => e.CityName)
                .HasColumnName("city_name");

            entity.Property(e => e.LocationName)
                .HasColumnName("location_name");

            entity.Property(e => e.AddrInd)
                .HasColumnName("addr_ind");

            entity.Property(e => e.AddrStreet)
                .HasColumnName("addr_street");

            entity.Property(e => e.AddrHouse)
                .HasColumnName("addr_house");

            entity.Property(e => e.AddrExt)
                .HasColumnName("addr_ext");

            entity.Property(e => e.AddrFlat)
                .HasColumnName("addr_flat");

            entity.Property(e => e.RegOnDate)
                .HasColumnName("reg_on_date");

            entity.Property(e => e.RegOffDate)
                .HasColumnName("reg_off_date");

            entity.Property(e => e.RegOff)
                .HasColumnName("reg_off"); 

            entity.Property(e => e.DiagnosisLong)
                .HasColumnName("diagnosis_long");

            entity.Property(e => e.CheckCourseLong)
                .HasColumnName("check_course_long");

            entity.Property(e => e.InfectCourseLong)
                .HasColumnName("infect_course_long");

            entity.Property(e => e.ShowIllnessLong)
                .HasColumnName("show_illness_long");

            entity.Property(e => e.StartDate)
                .HasColumnName("start_date");

            entity.Property(e => e.EndDate)
                .HasColumnName("end_date");

            entity.Property(e => e.TransfAreaDate)
                .HasColumnName("transf_area_date");

            entity.Property(e => e.FlgZamMedPart)
                .HasColumnName("flg_zam_med_part");

            entity.Property(e => e.FlgHeadPhysician)
                .HasColumnName("flg_head_physician");

            entity.Property(e => e.UfsinDate)
                .HasColumnName("ufsin_date");

            entity.Property(e => e.CardNo)
                .HasColumnName("card_no");

            entity.Property(e => e.DtRegBeg)
                .HasColumnName("dt_reg_beg");

            entity.Property(e => e.DtRegEnd)
                .HasColumnName("dt_reg_end");

            entity.Property(e => e.DoctorLong)
                .HasColumnName("doctor_long");

            entity.Property(e => e.RegDate)
                .HasColumnName("reg_date");

            entity.Property(e => e.CheckDate)
                .HasColumnName("check_date");

            entity.Property(e => e.RegCheck)
                .HasColumnName("reg_check");

            entity.Property(e => e.ArvtLong)
                .HasColumnName("arvt_long");
        });

        modelBuilder.Entity<QrySearchEpid>(entity =>
        {
            entity.HasNoKey();

            entity.ToTable("qrySearchEpid");

            entity.Property(e => e.PatientId)
                .HasColumnName("patient_id");

            entity.Property(e => e.InputDate)
                .HasColumnName("input_date");

            entity.Property(e => e.FamilyName)
                .HasColumnName("family_name");

            entity.Property(e => e.FirstName)
                .HasColumnName("first_name");

            entity.Property(e => e.ThirdName)
                .HasColumnName("third_name");

            entity.Property(e => e.SexShort)
                .HasColumnName("sex_short");

            entity.Property(e => e.BirthDate)
                .HasColumnName("birth_date");

            entity.Property(e => e.RegionLong)
                .HasColumnName("region_long");

            entity.Property(e => e.RegtypeId)
                .HasColumnName("regtype_id");

            entity.Property(e => e.RegionLongFact)
                .HasColumnName("region_long_fact");

            entity.Property(e => e.FactRegtypeId)
                .HasColumnName("fact_regtype_id");

            entity.Property(e => e.CountryLong)
                .HasColumnName("country_long");

            entity.Property(e => e.CityName)
                .HasColumnName("city_name");

            entity.Property(e => e.LocationName)
                .HasColumnName("location_name");

            entity.Property(e => e.AddrInd)
                .HasColumnName("addr_ind");

            entity.Property(e => e.AddrStreet)
                .HasColumnName("addr_street");

            entity.Property(e => e.AddrHouse)
                .HasColumnName("addr_house");

            entity.Property(e => e.AddrExt)
                .HasColumnName("addr_ext");

            entity.Property(e => e.AddrFlat)
                .HasColumnName("addr_flat");

            entity.Property(e => e.RegOnDate)
                .HasColumnName("reg_on_date");

            entity.Property(e => e.RegOffDate)
                .HasColumnName("reg_off_date");

            entity.Property(e => e.RegOff)
                .HasColumnName("reg_off");

            entity.Property(e => e.CheckPlaceLong)
                .HasColumnName("check_place_long");

            entity.Property(e => e.DiagnosisLong)
                .HasColumnName("diagnosis_long");

            entity.Property(e => e.DieDate)
                .HasColumnName("die_date");

            entity.Property(e => e.DieAidsDate)
                .HasColumnName("die_aids_date");

            entity.Property(e => e.DieCourseShort)
                .HasColumnName("die_course_short");

            entity.Property(e => e.DieCourseLong)
                .HasColumnName("die_course_long");

            entity.Property(e => e.DethtypeId)
                .HasColumnName("Dethtype_id");

            entity.Property(e => e.CheckCourseLong)
                .HasColumnName("check_course_long");

            entity.Property(e => e.InfectCourseLong)
                .HasColumnName("infect_course_long");

            entity.Property(e => e.ShowIllnessLong)
                .HasColumnName("show_illness_long");

            entity.Property(e => e.StartDate)
                .HasColumnName("start_date");

            entity.Property(e => e.EndDate)
                .HasColumnName("end_date");

            entity.Property(e => e.IbResultShort)
                .HasColumnName("ib_result_short");

            entity.Property(e => e.BlotDate)
                .HasColumnName("blot_date");

            entity.Property(e => e.BlotNo)
                .HasColumnName("blot_no");

            entity.Property(e => e.First1)
                .HasColumnName("first1");

            entity.Property(e => e.Last1)
                .HasColumnName("last1");

            entity.Property(e => e.Datetime1)
                .HasColumnName("datetime1");

            entity.Property(e => e.HospCourseLong)
                .HasColumnName("hosp_course_long");

            entity.Property(e => e.Age)
                .HasColumnName("age");

            entity.Property(e => e.CardNo)
                .HasColumnName("card_no");

            entity.Property(e => e.ArvtLong)
                .HasColumnName("arvt_long");

            entity.Property(e => e.CodeMkb10Long)
                .HasColumnName("code_mkb10_long");

            entity.Property(e => e.TransfAreaDate)
                .HasColumnName("transf_area_date");

            entity.Property(e => e.FlgZamMedPart)
                .HasColumnName("flg_zam_med_part");

            entity.Property(e => e.FlgHeadPhysician)
                .HasColumnName("flg_head_physician");

            entity.Property(e => e.TransfFederDate)
                .HasColumnName("transf_feder_date");

            entity.Property(e => e.UfsinDate)
                .HasColumnName("ufsin_date");

            entity.Property(e => e.Aids12Long)
                .HasColumnName("aids12_long");

            entity.Property(e => e.DtMailReg)
                .HasColumnName("dt_mail_reg");

            entity.Property(e => e.EduName)
                .HasColumnName("edu_name");

            entity.Property(e => e.FamilyStatusName)
                .HasColumnName("fammily_status_name");

            entity.Property(e => e.EmploymentName)
                .HasColumnName("employment_name");

            entity.Property(e => e.TransName)
                .HasColumnName("trans_name");

            entity.Property(e => e.PlaceCheckName)
                .HasColumnName("place_check_name");

            entity.Property(e => e.SituationDetectName)
                .HasColumnName("situation_detect_name");

            entity.Property(e => e.TrasmisoinMechName)
                .HasColumnName("transmisiom_mech_name");

            entity.Property(e => e.VulnerableGroupName)
                .HasColumnName("vulnerable_group_name");

            entity.Property(e => e.DVac1)
                .HasColumnName("d_vac1");

            entity.Property(e => e.DVac2)
                .HasColumnName("d_vac2");

            entity.Property(e => e.VacName)
                .HasColumnName("vac_name");

            entity.Property(e => e.DPositivResCovid)
                .HasColumnName("d_positiv_res_covid");

            entity.Property(e => e.DNegativeResCovid)
                .HasColumnName("d_negative_res_covid");

            entity.Property(e => e.Mkb10LongName)
                .HasColumnName("mkb10_long_name");

            entity.Property(e => e.Mkb10LongName)
                .HasColumnName("mkb10_long_name");

            entity.Property(e => e.YnNameChemsex)
                .HasColumnName("y_n_name_chemsex");

            entity.Property(e => e.ChemsexContactType)
                .HasColumnName("chemsex_contact_type");

            entity.Property(e => e.DateStartPavInj)
                .HasColumnName("date_start_pav_inj");

            entity.Property(e => e.DateEndPavInj)
                .HasColumnName("date_end_pav_inj");

            entity.Property(e => e.YnNamePavInj)
                .HasColumnName("y_n_name_pav_inj");

            entity.Property(e => e.DateStartPavNotInj)
                .HasColumnName("date_start_pav_not_inj");

            entity.Property(e => e.DateEndPavNotInj)
                .HasColumnName("date_end_pav_not_inj");

            entity.Property(e => e.YnNamePavNotInj)
                .HasColumnName("y_n_name_pav_not_inj");

            entity.Property(e => e.EpidemInfectStart)
                .HasColumnName("epidem_time_infect_start");

            entity.Property(e => e.EpidemInfectEnd)
                .HasColumnName("epidem_time_infect_end");
        });

        modelBuilder.Entity<QrySearchHosp>(entity =>
        {
            entity.HasNoKey();

            entity.ToTable("qrySearchHosp");

            entity.Property(e => e.PatientId)
                .HasColumnName("patient_id");

            entity.Property(e => e.InputDate)
                .HasColumnName("input_date");

            entity.Property(e => e.FamilyName)
                .HasColumnName("family_name");

            entity.Property(e => e.FirstName)
                .HasColumnName("first_name");

            entity.Property(e => e.ThirdName)
                .HasColumnName("third_name");

            entity.Property(e => e.SexShort)
                .HasColumnName("sex_short");

            entity.Property(e => e.BirthDate)
                .HasColumnName("birth_date");

            entity.Property(e => e.RegionLong)
                .HasColumnName("region_long");

            entity.Property(e => e.RegtypeId)
                .HasColumnName("regtype_id");

            entity.Property(e => e.RegionLongFact)
                .HasColumnName("region_long_fact");

            entity.Property(e => e.FactRegtypeId)
                .HasColumnName("fact_regtype_id");

            entity.Property(e => e.CountryLong)
                .HasColumnName("country_long");

            entity.Property(e => e.CityName)
                .HasColumnName("city_name");

            entity.Property(e => e.LocationName)
                .HasColumnName("location_name");

            entity.Property(e => e.AddrInd)
                .HasColumnName("addr_ind");

            entity.Property(e => e.AddrStreet)
                .HasColumnName("addr_street");

            entity.Property(e => e.AddrHouse)
                .HasColumnName("addr_house");

            entity.Property(e => e.AddrExt)
                .HasColumnName("addr_ext");

            entity.Property(e => e.AddrFlat)
                .HasColumnName("addr_flat");

            entity.Property(e => e.RegOnDate)
                .HasColumnName("reg_on_date");

            entity.Property(e => e.RegOffDate)
                .HasColumnName("reg_off_date");

            entity.Property(e => e.RegOff)
                .HasColumnName("reg_off");

            entity.Property(e => e.DiagnosisLong)
                .HasColumnName("diagnosis_long");

            entity.Property(e => e.DiagnosisDefDate)
                .HasColumnName("diagnosis_def_date");

            entity.Property(e => e.CheckCourseLong)
                .HasColumnName("check_course_long");

            entity.Property(e => e.InfectCourseLong)
                .HasColumnName("infect_course_long");

            entity.Property(e => e.ShowIllnessLong)
                .HasColumnName("show_illness_long");

            entity.Property(e => e.StartDate)
                .HasColumnName("start_date");

            entity.Property(e => e.EndDate)
                .HasColumnName("end_date");

            entity.Property(e => e.TransfAreaDate)
                .HasColumnName("transf_area_date");

            entity.Property(e => e.FlgZamMedPart)
                .HasColumnName("flg_zam_med_part");

            entity.Property(e => e.FlgHeadPhysician)
                .HasColumnName("flg_head_physician");

            entity.Property(e => e.TransfFederDate)
                .HasColumnName("transf_feder_date");

            entity.Property(e => e.UfsinDate)
                .HasColumnName("ufsin_date");

            entity.Property(e => e.DateHospIn)
                .HasColumnName("date_hosp_in");

            entity.Property(e => e.DateHospOut)
                .HasColumnName("date_hosp_out");

            entity.Property(e => e.LpuLong)
                .HasColumnName("lpu_long");

            entity.Property(e => e.HospCourseLong)
                .HasColumnName("hosp_course_long");

            entity.Property(e => e.HospResultLong)
                .HasColumnName("hosp_result_long");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
