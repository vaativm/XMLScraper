using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace XMLScraper.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ClientDemographics",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientDrawsCode = table.Column<string>(nullable: true),
                    ClientIdentifier = table.Column<int>(nullable: false),
                    First = table.Column<string>(nullable: true),
                    Middle = table.Column<string>(nullable: true),
                    Last = table.Column<string>(nullable: true),
                    FacilityName = table.Column<string>(nullable: true),
                    CountryCode = table.Column<string>(nullable: true),
                    FacilityId = table.Column<string>(nullable: true),
                    FacilityTypeCode = table.Column<string>(nullable: true),
                    IdNumber = table.Column<string>(nullable: true),
                    IdTypeCode = table.Column<string>(nullable: true),
                    ClientDateOfBirth = table.Column<DateTimeOffset>(nullable: false),
                    ClientSexCode = table.Column<string>(nullable: false),
                    ClientOccupationCode = table.Column<string>(nullable: true),
                    ClientMaritalStatusCode = table.Column<string>(nullable: false),
                    PhoneNumber = table.Column<string>(nullable: true),
                    EnrollmentWHOStage = table.Column<string>(nullable: true),
                    CD4Count = table.Column<string>(nullable: true),
                    MUAC = table.Column<string>(nullable: true),
                    PatientType = table.Column<int>(nullable: false),
                    Height = table.Column<decimal>(nullable: false),
                    ARTInitiationDate = table.Column<DateTimeOffset>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientDemographics", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ClinicalVisits",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MasterPatientVisitId = table.Column<int>(nullable: false),
                    ClientDrawsCode = table.Column<string>(nullable: true),
                    ClientIdentifier = table.Column<int>(nullable: false),
                    BPSystolic = table.Column<int>(nullable: false),
                    BPDiastolic = table.Column<int>(nullable: false),
                    Muac = table.Column<decimal>(nullable: false),
                    Weight = table.Column<decimal>(nullable: false),
                    Height = table.Column<decimal>(nullable: false),
                    WHOStage = table.Column<string>(nullable: true),
                    FamilyPlanningStatusId = table.Column<int>(nullable: false),
                    FPMethodId7 = table.Column<int>(nullable: false),
                    EDD = table.Column<DateTimeOffset>(nullable: false),
                    LMP = table.Column<DateTimeOffset>(nullable: false),
                    Outcome = table.Column<string>(nullable: true),
                    ScreeningValueId = table.Column<int>(nullable: false),
                    ScreeningValueId2 = table.Column<int>(nullable: false),
                    AdverseEventId = table.Column<int>(nullable: false),
                    EventName = table.Column<string>(nullable: true),
                    EventCause = table.Column<string>(nullable: true),
                    Severity = table.Column<string>(nullable: true),
                    Action = table.Column<string>(nullable: true),
                    LabName = table.Column<string>(nullable: true),
                    SampleDate = table.Column<DateTimeOffset>(nullable: false),
                    Reasons = table.Column<string>(nullable: true),
                    ResultValues = table.Column<string>(nullable: true),
                    ResultUnits = table.Column<string>(nullable: true),
                    ResultDate = table.Column<DateTimeOffset>(nullable: false),
                    PatientChronicIllnessViewId = table.Column<int>(nullable: false),
                    ChronicIllness = table.Column<string>(nullable: true),
                    Treatment = table.Column<string>(nullable: true),
                    Dose = table.Column<string>(nullable: true),
                    Duration = table.Column<string>(nullable: true),
                    VisitDate = table.Column<DateTimeOffset>(nullable: false),
                    NextAppointmentDate = table.Column<DateTimeOffset>(nullable: false),
                    VisitScheduled = table.Column<int>(nullable: false),
                    DifferentiatedCare = table.Column<string>(nullable: true),
                    DurationOfDrugs = table.Column<string>(nullable: true),
                    VisitBy = table.Column<string>(nullable: true),
                    ARVDrugForHIVRegiment2 = table.Column<string>(nullable: true),
                    ARVDrugForHIVRegiment1 = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClinicalVisits", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClientDemographics");

            migrationBuilder.DropTable(
                name: "ClinicalVisits");
        }
    }
}
