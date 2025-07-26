namespace MedWebApiApp.Models
{
    public class UserLevel
    {
        public string User { get; set; }
        public string ViewProviderNumbers { get; set; }
        public string ViewProviderLocations { get; set; }
        public string ViewTreatmentDetails { get; set; }
        public string EditTreatment { get; set; }
        public bool ViewClientName { get; set; }
        public bool ViewClientMedicalRecordNumber { get; set; }
        public bool ViewPracticeInformation { get; set; }

    }
}
