using CsvHelper.Configuration;
using Shared.Models;
using System.Globalization;

namespace MedWebApiApp.Services
{
    public interface IDataSourceService
    {
        IEnumerable<Provider> GetAllProviders();
    }

    public class DataSourceService : IDataSourceService
    {
        private const string DefaultDataFilesFolder = "Data";
        private const string DefaultProviderFileName = "Providers.csv";
        private string _currentDirectory = string.Empty;
        private List<Provider> _providerRecords = new();

        public DataSourceService()
        {
            Console.WriteLine("Reading data ...");  // file files

            _currentDirectory = Directory.GetCurrentDirectory();

            ReadProviders();

            // Read Patients and other data files 
            // Even UserLevels can be configured if stored in data file

        }

        private void ReadProviders()
        {
            try
            {

                string readFilePath = Path.Combine(_currentDirectory, DefaultDataFilesFolder, DefaultProviderFileName);

                var config = new CsvConfiguration(CultureInfo.InvariantCulture)
                {
                    IgnoreBlankLines = false,
                    InjectionCharacters = new[] { '=', '+', '-', '@', '%', '#', '*', '^', '/', ')' }, // Characters to check
                    InjectionOptions = InjectionOptions.Strip,  // Escape the injection characters
                };

                using (var reader = new StreamReader(readFilePath))
                using (var csv = new CsvHelper.CsvReader(reader, CultureInfo.InvariantCulture))
                {
                    // provide type conversion
                    csv.Context.RegisterClassMap<ProviderMap>();
                    _providerRecords = csv.GetRecords<Provider>()
                                                              .ToList();

                    if (_providerRecords.Any())
                    {
                        Console.WriteLine($"Loaded {_providerRecords.Count} providers from {readFilePath}");
                    }
                    else
                    {
                        Console.WriteLine("No providers found in the file.");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error reading UserLevels.csv: {ex.Message}");
            }
        }

        public IEnumerable<Provider> GetAllProviders()
        {
            return _providerRecords;
        }
    }
}
