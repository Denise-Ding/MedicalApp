using CsvHelper.Configuration;
using Shared.Helpers.MedWebApiApp.Helpers;

namespace Shared.Models
{
    public class Provider
    {
        public string Name { get; set; }
        public string Number { get; set; }
        public string Hospital { get; set; }
        public bool Doctor { get; set; }

    }


    public sealed class ProviderMap : ClassMap<Provider>
    {
        public ProviderMap()
        {
            Map(m => m.Name)     // validate name
                .Index(0);
            Map(m => m.Number)  // validate provider number
                .Index(1);
            Map(m => m.Hospital)  // empty hospital?
                .Index(2);
            Map(m => m.Doctor)
                .Index(3)
                .TypeConverter<YesNoBooleanConverter>();

        }
    }
}
