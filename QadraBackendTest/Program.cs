using Microsoft.Extensions.DependencyInjection;
using QadraBackendTest.Clients.Implementations;
using QadraBackendTest.Clients.Interfaces;
using QadraBackendTest.Models;
using Instrument = QadraBackendTest.Models.Instrument;

namespace QadraBackendTest;

public class Program
{
    public static async Task Main(string[] args)
    {
        var services = new ServiceCollection();
        services
            .AddSingleton<IEodClient, EodClient>()
            .AddSingleton<IMsClient, MsClient>();

        IList<IQuoteProvider> providers = await LoadRequiredProviders(services.BuildServiceProvider());


        services.AddSingleton<QuotesImporter, QuotesImporter>();

        foreach (var provider in providers)
        {
            services.AddSingleton<IQuoteProvider>(provider);
        }

            
        var serviceProvider = services.BuildServiceProvider();



        // Init logic
        var quotesImporter = serviceProvider.GetService<QuotesImporter>();

        // Start to import instruments
        var instruments = GetDummyInstruments();
        foreach (var i in instruments)
        {
            await quotesImporter.ImportInstrumentQuotes(i);
        }
    }

    private static async Task<IList<IQuoteProvider>> LoadRequiredProviders(IServiceProvider serviceProvider)
    {
        var providers = new List<IQuoteProvider>();
        //add MS Client provider;
        var msProvider = new QuoteProvider("MS Client",
            serviceProvider,
            async (provider, instrument) =>
            {
                var msClient = provider.GetService<MsClient>();

                var quotes = await msClient.GetInstrumentQuotes(instrument.DatasourceIdentifier, instrument.Name);
                return quotes.Select(q => new QadraQuote() { Date = q.Date, Value = q.Value }).ToList();
            }
            ) ;

        providers.Add(msProvider);

        return providers;
    }

    private static List<Instrument> GetDummyInstruments()
    {
        return new List<Instrument>
        {
            new Instrument
            {
                Name = "Apple",
                Datasource = "EOD",
                DatasourceIdentifier = "AAPL"
            },
            new Instrument
            {
                Name = "Microsoft",
                Datasource = "MS",
                DatasourceIdentifier = "MSFT"
            }
        };
    }
}
