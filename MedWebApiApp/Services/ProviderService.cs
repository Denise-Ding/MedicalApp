using Shared.Models;

namespace MedWebApiApp.Services
{
    public interface IProviderService
    {
        IEnumerable<Provider> GetAllProviders();
        Provider? GetProviderByNumber(string name);
    }

    public class ProviderService : IProviderService
    {
        private readonly IDataSourceService _dataSource;

        public ProviderService(IDataSourceService datasource)
        {
            _dataSource = datasource ?? throw new ArgumentNullException(nameof(datasource));
        }

        public IEnumerable<Provider> GetAllProviders()
        {
            // should cache this
            return _dataSource.GetAllProviders().ToList();
        }

        public Provider? GetProviderByNumber(string number)
        {
            return GetAllProviders()
                                            .Where(p => p.Number.ToLower() == number.ToLower())
                                            .FirstOrDefault();
        }
    }

}
