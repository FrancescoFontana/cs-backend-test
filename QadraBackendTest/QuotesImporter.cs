using QadraBackendTest.Clients.Factories;
using QadraBackendTest.Models;

namespace QadraBackendTest;

public class QuotesImporter
{
    public async Task ImportInstrumentQuotes(Instrument instrument)
    {
        // Todo: Implement logic
        Console.WriteLine(instrument.Name);

        var client = DataSourceFactory.GetClientByName(instrument.Name);

        var quotes = await client.GetInstrumentQuotes();

        foreach (var quote in quotes)
        {
            quote.Print();
        }
    }
}