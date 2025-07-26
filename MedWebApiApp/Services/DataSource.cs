namespace MedWebApiApp.Services
{
    public class DataSource
    {
        private string defaultDataFilesFolder = "DataFolder";
        private string defaultProviderFileName = "defaultProvider.txt";

        public DataSource()
        {
            Console.WriteLine("DataSource constructor called");

            try
            {
                //LoadData();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading data: {ex.Message}");

            }

        }

    }
}
