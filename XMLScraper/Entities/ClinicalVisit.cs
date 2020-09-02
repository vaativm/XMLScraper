using System;

namespace XMLScraper.Entities
{
    public class ClinicalVisit
    {
		public int Id { get; set; }
		public int MasterPatientVisitId { get; set; }
		public string ClientDrawsCode { get; set; }
		public int ClientIdentifier { get; set; }
		public int BPSystolic { get; set; }
		public int BPDiastolic { get; set; }
		public decimal Muac { get; set; }
		public decimal Weight { get; set; }
		public decimal Height { get; set; }
		public string WHOStage { get; set; }
		public int FamilyPlanningStatusId { get; set; }
		public int FPMethodId7 { get; set; }
		public DateTimeOffset EDD { get; set; }
		public DateTimeOffset LMP { get; set; }
		public string Outcome { get; set; }
		public int ScreeningValueId { get; set; }
		public int ScreeningValueId2 { get; set; }
		public int AdverseEventId { get; set; }
		public string EventName { get; set; }
		public string EventCause { get; set; }
		public string Severity { get; set; }
		public string Action { get; set; }
		public string LabName { get; set; }
		public DateTimeOffset SampleDate { get; set; }
		public string Reasons { get; set; }
		public string ResultValues { get; set; }
		public string ResultUnits { get; set; }
		public DateTimeOffset ResultDate { get; set; }
		public int PatientChronicIllnessViewId { get; set; }
		public string ChronicIllness { get; set; }
		public string Treatment { get; set; }
		public string Dose { get; set; }
		public string Duration { get; set; }
		public DateTimeOffset VisitDate { get; set; }
		public DateTimeOffset NextAppointmentDate { get; set; }
		public int VisitScheduled { get; set; }
		public string DifferentiatedCare { get; set; }
		public string DurationOfDrugs { get; set; }
		public string VisitBy { get; set; }
		public string ARVDrugForHIVRegiment2 { get; set; }
		public string ARVDrugForHIVRegiment1 { get; set; }
    }
}
