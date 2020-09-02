using System;

namespace XMLScraper.Entities
{
    public class ClientDemographic
    {
		public int Id { get; set; }
	    public string ClientDrawsCode { get; set; }
		public int ClientIdentifier { get; set; }
		public string First { get; set; }
		public string Middle { get; set; }
		public string Last { get; set; }
		public string FacilityName { get; set; }
		public string CountryCode { get; set; }
		public string FacilityId { get; set; }
		public string FacilityTypeCode { get; set; }
		public string IdNumber { get; set; }
		public string IdTypeCode { get; set; }
		public DateTimeOffset ClientDateOfBirth { get; set; }
		public char ClientSexCode { get; set; }
		public string ClientOccupationCode { get; set; }
		public char ClientMaritalStatusCode { get; set; }
		public string PhoneNumber { get; set; }
		public string EnrollmentWHOStage { get; set; }
		public string CD4Count { get; set; }
		public string MUAC { get; set; }
		public int PatientType { get; set; }
		public decimal Height { get; set; }
		public DateTimeOffset ARTInitiationDate { get; set; }
    }
}
