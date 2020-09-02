using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Linq;
using XMLScraper.Data;
using XMLScraper.Entities;

namespace XMLScraper
{
    class Program
    {
        static void Main(string[] args)
        {
            string defaultDecimalvalue = "0.00";
            string defaultIntValue ="0";
            string clientDrawsCode = "";
            int clientIdentifier = 0;
            string path = @"D:\Projects\Martin\XMLScraper\XMLScraper\Xmls";
            var files = Directory.GetFiles(path, "*.xml", SearchOption.AllDirectories);
            foreach (var file in Directory.GetFiles(path, "*", SearchOption.TopDirectoryOnly))
            {
                var root = XDocument.Load(file).Root;
                var clientDemographicsNode = root
                    .Element("IndividualReport")
                    .Element("ClientDemographics");

                var patientBaselineView = root
                    .Element("IndividualReport")
                    .Element("TrackerCapture")
                    .Element("EntryPointAndTransferStatus")
                    .Element("BaselineAssessmentAndTreatmentInitiation")
                    .Element("PatientBaselineView");

                var clinicalVisits = root
                    .Element("IndividualReport")
                    .Element("TrackerCapture")
                    .Elements("ClinicalVisit");

                Patient patient = new Patient();

                patient.ProcessPatientDemographics(clientDemographicsNode);
                patient.AddProcesspatientBaselineViewToDemographics(patientBaselineView);
                patient.PatientDemographics.Remove("Weight");

                using (var db = new XMLScraperDbContext())
                {
                    ClientDemographic clientDemographic = new ClientDemographic();

                    if (patient.PatientDemographics.ContainsKey("ClientDrawsCode"))
                    {
                        clientDrawsCode = patient.PatientDemographics["ClientDrawsCode"];
                        clientDemographic.ClientDrawsCode = clientDrawsCode;
                    }
                        
                    if (patient.PatientDemographics.ContainsKey("ClientIdentifier"))
                    {
                        if (patient.PatientDemographics["ClientIdentifier"] == string.Empty)
                        {
                            clientIdentifier = int.Parse(defaultIntValue);
                            clientDemographic.ClientIdentifier = clientIdentifier;
                        }

                        else
                        {
                            clientIdentifier = int.Parse(patient.PatientDemographics["ClientIdentifier"]);
                            clientDemographic.ClientIdentifier = clientIdentifier;
                        }
                            
                    }
                    if (patient.PatientDemographics.ContainsKey("First"))
                        clientDemographic.First = patient.PatientDemographics["First"];
                    if (patient.PatientDemographics.ContainsKey("Middle"))
                        clientDemographic.Middle = patient.PatientDemographics["Middle"];
                    if (patient.PatientDemographics.ContainsKey("Last"))
                        clientDemographic.Last = patient.PatientDemographics["Last"];
                    if (patient.PatientDemographics.ContainsKey("FacilityName"))
                        clientDemographic.FacilityName = patient.PatientDemographics["FacilityName"];
                    if (patient.PatientDemographics.ContainsKey("CountryCode"))
                        clientDemographic.CountryCode = patient.PatientDemographics["CountryCode"];
                    if (patient.PatientDemographics.ContainsKey("FacilityId"))
                        clientDemographic.FacilityId = patient.PatientDemographics["FacilityId"];
                    if (patient.PatientDemographics.ContainsKey("FacilityTypeCode"))
                        clientDemographic.FacilityTypeCode = patient.PatientDemographics["FacilityTypeCode"];
                    if (patient.PatientDemographics.ContainsKey("IdNumber"))
                        clientDemographic.IdNumber = patient.PatientDemographics["IdNumber"];
                    if (patient.PatientDemographics.ContainsKey("IdTypeCode"))
                        clientDemographic.IdTypeCode = patient.PatientDemographics["IdTypeCode"];
                    if (patient.PatientDemographics.ContainsKey("ClientDateOfBirth"))
                        clientDemographic.ClientDateOfBirth = DateTime.Parse(patient.PatientDemographics["ClientDateOfBirth"]);
                    if (patient.PatientDemographics.ContainsKey("ClientSexCode"))
                        clientDemographic.ClientSexCode = char.Parse(patient.PatientDemographics["ClientSexCode"]);
                    if (patient.PatientDemographics.ContainsKey("ClientOccupationCode"))
                        clientDemographic.ClientOccupationCode = patient.PatientDemographics["ClientOccupationCode"];
                    if (patient.PatientDemographics.ContainsKey("ClientMaritalStatusCode"))
                        clientDemographic.ClientMaritalStatusCode = char.Parse(patient.PatientDemographics["ClientMaritalStatusCode"]);
                    if (patient.PatientDemographics.ContainsKey("PhoneNumber"))
                        clientDemographic.PhoneNumber = patient.PatientDemographics["PhoneNumber"];
                    if (patient.PatientDemographics.ContainsKey("EnrollmentWHOStage"))
                        clientDemographic.EnrollmentWHOStage = patient.PatientDemographics["EnrollmentWHOStage"];
                    if (patient.PatientDemographics.ContainsKey("CD4Count"))
                        clientDemographic.CD4Count = patient.PatientDemographics["CD4Count"];
                    if (patient.PatientDemographics.ContainsKey("MUAC"))
                        clientDemographic.MUAC = patient.PatientDemographics["MUAC"];
                    if (patient.PatientDemographics.ContainsKey("PatientType"))
                    {
                        if (patient.PatientDemographics["PatientType"] == string.Empty)
                            clientDemographic.PatientType = int.Parse(defaultIntValue);
                        else
                            clientDemographic.PatientType = int.Parse(patient.PatientDemographics["PatientType"]);
                    }
                    if (patient.PatientDemographics.ContainsKey("Height"))
                    {
                        if(patient.PatientDemographics["Height"] == string.Empty)
                            clientDemographic.Height = decimal.Parse(defaultDecimalvalue);
                        else
                            clientDemographic.Height = decimal.Parse(patient.PatientDemographics["Height"]);
                    }
                        
                    if (patient.PatientDemographics.ContainsKey("ARTInitiationDate"))
                        clientDemographic.ARTInitiationDate = DateTime.Parse(patient.PatientDemographics["ARTInitiationDate"]);

                    db.Add(clientDemographic);
                    db.SaveChanges();
                }
                
                patient.ProcessPatientClinicalVisits(clinicalVisits);

                using (var db = new XMLScraperDbContext())
                {
                    foreach (var patientClinicalVisit in patient.PatientClinicalVisits)
                    {
                        ClinicalVisit clinicalVisit = new ClinicalVisit();
                        if (patientClinicalVisit.ContainsKey("MasterPatientVisitId"))
                        {
                            if (patientClinicalVisit["MasterPatientVisitId"] == string.Empty)
                                clinicalVisit.MasterPatientVisitId = int.Parse(defaultIntValue);
                            else
                                clinicalVisit.MasterPatientVisitId = int.Parse(patientClinicalVisit["MasterPatientVisitId"]);
                        }
                        clinicalVisit.ClientDrawsCode = clientDrawsCode;
                        clinicalVisit.ClientIdentifier = clientIdentifier;
                        if (patientClinicalVisit.ContainsKey("BPSystolic"))
                        {
                            if (patientClinicalVisit["BPSystolic"] == string.Empty)
                                clinicalVisit.BPSystolic = int.Parse(defaultIntValue);
                            else
                                clinicalVisit.BPSystolic = int.Parse(patientClinicalVisit["BPSystolic"]);
                        }
                        if (patientClinicalVisit.ContainsKey("BPDiastolic"))
                        {
                            if (patientClinicalVisit["BPDiastolic"] == string.Empty)
                                clinicalVisit.BPDiastolic = int.Parse(defaultIntValue);
                            else
                                clinicalVisit.BPDiastolic = int.Parse(patientClinicalVisit["BPDiastolic"]);
                        }
                        if (patientClinicalVisit.ContainsKey("Muac"))
                        {
                            if (patientClinicalVisit["Muac"] == string.Empty)
                                clinicalVisit.Muac = decimal.Parse(defaultDecimalvalue);
                            else
                                clinicalVisit.Muac = decimal.Parse(patientClinicalVisit["Muac"]);
                        }
                        if (patientClinicalVisit.ContainsKey("Weight"))
                        {
                            if (patientClinicalVisit["Weight"] == string.Empty)
                                clinicalVisit.Weight = decimal.Parse(defaultDecimalvalue);
                            else
                                clinicalVisit.Weight = decimal.Parse(patientClinicalVisit["Weight"]);
                        }

                        if (patientClinicalVisit.ContainsKey("Height"))
                        {
                            if (patientClinicalVisit["Height"] == string.Empty)
                                clinicalVisit.Height = decimal.Parse(defaultDecimalvalue);
                            else
                                clinicalVisit.Height = decimal.Parse(patientClinicalVisit["Height"]);
                        }
                        if (patientClinicalVisit.ContainsKey("WHOStage"))
                            clinicalVisit.WHOStage = patientClinicalVisit["WHOStage"];
                        if (patientClinicalVisit.ContainsKey("FamilyPlanningStatusId"))
                        {
                            if (patientClinicalVisit["FamilyPlanningStatusId"] == string.Empty)
                                clinicalVisit.FamilyPlanningStatusId = int.Parse(defaultIntValue);
                            else
                                clinicalVisit.FamilyPlanningStatusId = int.Parse(patientClinicalVisit["FamilyPlanningStatusId"]);
                        }
                        if (patientClinicalVisit.ContainsKey("FPMethodId7"))
                        {
                            if (patientClinicalVisit["FPMethodId7"] == string.Empty)
                                clinicalVisit.FPMethodId7 = int.Parse(defaultIntValue);
                            else
                                clinicalVisit.FPMethodId7 = int.Parse(patientClinicalVisit["FPMethodId7"]);
                        }
                       
                        if (patientClinicalVisit.ContainsKey("EDD"))
                            clinicalVisit.EDD = DateTime.Parse(patientClinicalVisit["EDD"]);
                        if (patientClinicalVisit.ContainsKey("LMP"))
                            clinicalVisit.LMP = DateTime.Parse(patientClinicalVisit["LMP"]);
                        if (patientClinicalVisit.ContainsKey("Outcome"))
                            clinicalVisit.Outcome = patientClinicalVisit["Outcome"];
                        if (patientClinicalVisit.ContainsKey("ScreeningValueId"))
                        {
                            if (patientClinicalVisit["ScreeningValueId"] == string.Empty)
                                clinicalVisit.ScreeningValueId = int.Parse(defaultIntValue);
                            else
                                clinicalVisit.ScreeningValueId = int.Parse(patientClinicalVisit["ScreeningValueId"]);
                        }
                        if (patientClinicalVisit.ContainsKey("ScreeningValueId2"))
                        {
                            if (patientClinicalVisit["ScreeningValueId2"] == string.Empty)
                                clinicalVisit.ScreeningValueId2 = int.Parse(defaultIntValue);
                            else
                                clinicalVisit.ScreeningValueId2 = int.Parse(patientClinicalVisit["ScreeningValueId2"]);
                        }
                        if (patientClinicalVisit.ContainsKey("AdverseEventId"))
                        {
                            if (patientClinicalVisit["AdverseEventId"] == string.Empty)
                                clinicalVisit.AdverseEventId = int.Parse(defaultIntValue);
                            else
                                clinicalVisit.AdverseEventId = int.Parse(patientClinicalVisit["AdverseEventId"]);
                        }
                        if (patientClinicalVisit.ContainsKey("EventName"))
                            clinicalVisit.EventName = patientClinicalVisit["EventName"];
                        if (patientClinicalVisit.ContainsKey("EventCause"))
                            clinicalVisit.EventCause = patientClinicalVisit["EventCause"];
                        if (patientClinicalVisit.ContainsKey("Severity"))
                            clinicalVisit.Severity = patientClinicalVisit["Severity"];
                        if (patientClinicalVisit.ContainsKey("Action"))
                            clinicalVisit.Action = patientClinicalVisit["Action"];
                        if (patientClinicalVisit.ContainsKey("LabName"))
                            clinicalVisit.Outcome = patientClinicalVisit["LabName"];
                        if (patientClinicalVisit.ContainsKey("SampleDate"))
                            clinicalVisit.SampleDate = DateTime.Parse(patientClinicalVisit["SampleDate"]);
                        if (patientClinicalVisit.ContainsKey("Reasons"))
                            clinicalVisit.Reasons = patientClinicalVisit["Reasons"];
                        if (patientClinicalVisit.ContainsKey("ResultValues"))
                            clinicalVisit.ResultValues = patientClinicalVisit["ResultValues"];
                        if (patientClinicalVisit.ContainsKey("ResultUnits"))
                            clinicalVisit.ResultUnits = patientClinicalVisit["ResultUnits"];
                        if (patientClinicalVisit.ContainsKey("ResultDate"))
                            clinicalVisit.ResultDate = DateTime.Parse(patientClinicalVisit["ResultDate"]);
                        if (patientClinicalVisit.ContainsKey("PatientChronicIllnessViewId"))
                            clinicalVisit.PatientChronicIllnessViewId = int.Parse(patientClinicalVisit["PatientChronicIllnessViewId"]);
                        if (patientClinicalVisit.ContainsKey("ChronicIllness"))
                            clinicalVisit.ChronicIllness = patientClinicalVisit["ChronicIllness"];
                        if (patientClinicalVisit.ContainsKey("Treatment"))
                            clinicalVisit.Treatment = patientClinicalVisit["Treatment"];
                        if (patientClinicalVisit.ContainsKey("Dose"))
                            clinicalVisit.Dose = patientClinicalVisit["Dose"];
                        if (patientClinicalVisit.ContainsKey("Duration"))
                            clinicalVisit.Duration = patientClinicalVisit["Duration"];
                        if (patientClinicalVisit.ContainsKey("VisitDate"))
                            clinicalVisit.VisitDate = DateTime.Parse(patientClinicalVisit["VisitDate"]);
                        if (patientClinicalVisit.ContainsKey("NextAppointmentDate"))
                            clinicalVisit.NextAppointmentDate = DateTime.Parse(patientClinicalVisit["NextAppointmentDate"]);
                        if (patientClinicalVisit.ContainsKey("VisitScheduled"))
                        {
                            if (patientClinicalVisit["VisitScheduled"] == string.Empty)
                                clinicalVisit.VisitScheduled = int.Parse(defaultIntValue);
                            else
                                clinicalVisit.VisitScheduled = int.Parse(patientClinicalVisit["VisitScheduled"]);
                        }
                        if (patientClinicalVisit.ContainsKey("DifferentiatedCare"))
                            clinicalVisit.DifferentiatedCare = patientClinicalVisit["DifferentiatedCare"];
                        if (patientClinicalVisit.ContainsKey("DurationOfDrugs"))
                            clinicalVisit.DurationOfDrugs = patientClinicalVisit["DurationOfDrugs"];
                        if (patientClinicalVisit.ContainsKey("VisitBy"))
                            clinicalVisit.VisitBy = patientClinicalVisit["VisitBy"];
                        if (patientClinicalVisit.ContainsKey("ARVDrugForHIVRegiment2"))
                            clinicalVisit.ARVDrugForHIVRegiment2 = patientClinicalVisit["ARVDrugForHIVRegiment2"];
                        if (patientClinicalVisit.ContainsKey("ARVDrugForHIVRegiment1"))
                            clinicalVisit.ARVDrugForHIVRegiment1 = patientClinicalVisit["ARVDrugForHIVRegiment1"];

                        db.Add(clinicalVisit);
                        db.SaveChanges();
                    }
                }
            }
        }
    }
    public class Patient
    {
        public Dictionary<string, string> ClinicalVisit { get; set; }
        public Dictionary<string, string> PatientDemographics { get; set; } = new Dictionary<string, string>();

        public List<Dictionary<string, string>> PatientClinicalVisits = new List<Dictionary<string, string>>();
        public void ProcessPatientDemographics(XElement element)
        {
            // For simplicity, argument validation not performed

            foreach (XElement patientDemographic in element.Elements())
            {
                if (!patientDemographic.HasElements)
                {
                    PatientDemographics.Add(patientDemographic.Name.LocalName, patientDemographic.Value);
                }
                else
                {
                    ProcessPatientDemographics(patientDemographic);
                }
            }
        }
        public void AddProcesspatientBaselineViewToDemographics(XElement patientBaselineView)
        {
            foreach (XElement element in patientBaselineView.Elements())
            {
                if (!element.HasElements)
                {
                    PatientDemographics.Add(element.Name.LocalName, element.Value);
                }
                else
                {
                    AddProcesspatientBaselineViewToDemographics(element);
                }
            }
        }
        public void ProcessPatientClinicalVisits(IEnumerable<XElement> elements)
        {
            
            foreach (var patientClinicalVisit in elements)
            {
                ClinicalVisit = new Dictionary<string, string>();
                ProcessPatientClinicalVisit(patientClinicalVisit);
                PatientClinicalVisits.Add(ClinicalVisit);
            }
        }

        public void ProcessPatientClinicalVisit(XElement clinicalVisit)
        {
            foreach (XElement visit in clinicalVisit.Elements())
            {
                if (!visit.HasElements)
                {
                    if (!ClinicalVisit.ContainsKey(visit.Name.LocalName))
                        ClinicalVisit.Add(visit.Name.LocalName, visit.Value);
                    else if(visit.Name.LocalName == "ScreeningValueId")
                    {
                        ClinicalVisit.Add("ScreeningValueId2", visit.Value);
                    }
                }
                else
                {
                    ProcessPatientClinicalVisit(visit);
                }
            }
        }
    }
}
