﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using XMLScraper.Data;

namespace XMLScraper.Data.Migrations
{
    [DbContext(typeof(XMLScraperDbContext))]
    [Migration("20200825203246_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("XMLScraper.Entities.ClientDemographic", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTimeOffset>("ARTInitiationDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("CD4Count")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset>("ClientDateOfBirth")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("ClientDrawsCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ClientIdentifier")
                        .HasColumnType("int");

                    b.Property<string>("ClientMaritalStatusCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(1)");

                    b.Property<string>("ClientOccupationCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClientSexCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(1)");

                    b.Property<string>("CountryCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EnrollmentWHOStage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FacilityId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FacilityName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FacilityTypeCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("First")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Height")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("IdNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IdTypeCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Last")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MUAC")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Middle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PatientType")
                        .HasColumnType("int");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ClientDemographics");
                });

            modelBuilder.Entity("XMLScraper.Entities.ClinicalVisit", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ARVDrugForHIVRegiment1")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ARVDrugForHIVRegiment2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Action")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("AdverseEventId")
                        .HasColumnType("int");

                    b.Property<int>("BPDiastolic")
                        .HasColumnType("int");

                    b.Property<int>("BPSystolic")
                        .HasColumnType("int");

                    b.Property<string>("ChronicIllness")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClientDrawsCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ClientIdentifier")
                        .HasColumnType("int");

                    b.Property<string>("DifferentiatedCare")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Dose")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Duration")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DurationOfDrugs")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset>("EDD")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("EventCause")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EventName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("FPMethodId7")
                        .HasColumnType("int");

                    b.Property<int>("FamilyPlanningStatusId")
                        .HasColumnType("int");

                    b.Property<decimal>("Height")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTimeOffset>("LMP")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("LabName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MasterPatientVisitId")
                        .HasColumnType("int");

                    b.Property<decimal>("Muac")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTimeOffset>("NextAppointmentDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Outcome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PatientChronicIllnessViewId")
                        .HasColumnType("int");

                    b.Property<string>("Reasons")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset>("ResultDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("ResultUnits")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ResultValues")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset>("SampleDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<int>("ScreeningValueId")
                        .HasColumnType("int");

                    b.Property<int>("ScreeningValueId2")
                        .HasColumnType("int");

                    b.Property<string>("Severity")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Treatment")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("VisitBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset>("VisitDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<int>("VisitScheduled")
                        .HasColumnType("int");

                    b.Property<string>("WHOStage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Weight")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("ClinicalVisits");
                });
#pragma warning restore 612, 618
        }
    }
}
