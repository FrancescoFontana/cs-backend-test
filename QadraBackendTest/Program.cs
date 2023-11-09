using QadraBackendTest.Models;

namespace QadraBackendTest;

public class Program
{
    public static async Task Main(string[] args)
    {
        // Init logic
        var quotesImporter = new QuotesImporter();

        // Start to import instruments
        var instruments = GetDummyInstruments();
        foreach (var i in instruments)
        {
            await quotesImporter.ImportInstrumentQuotes(i);
        }
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
