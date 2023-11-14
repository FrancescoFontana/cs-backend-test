using QadraBackendTest.Clients.Implementations;
using QadraBackendTest.Clients.Interfaces;
using QadraBackendTest.Models;

namespace QadraBackendTest;

public class QuotesImporter
{
    IEnumerable<IQuoteProvider> _quoteProviders;

    public QuotesImporter(IEnumerable<IQuoteProvider>  quoteProviders)
    {
        _quoteProviders = quoteProviders;
    }

    public async Task<IList<QadraQuote>> ImportInstrumentQuotes(Instrument instrument)
    {
        var allQuotes = new List<QadraQuote>();
        foreach(var provider in _quoteProviders)
        {
            var quotes = await provider.GetInstrumentQuotes(instrument);
            allQuotes.AddRange(quotes);
        }

        // Todo: Implement logic
        foreach(var quote in allQuotes)
            Console.WriteLine($"Instrument: {instrument.Name}, Quote Date: {quote.Date}, Quote Value: {quote.Value}");

        return allQuotes;
    }


    public async Task<IList<QadraQuote>> ImportInstrumentQuotes(IEnumerable<Instrument> instruments)
    {
        List<QadraQuote> quotes = new List<QadraQuote>();
        foreach(var instrument in instruments)
        {
            var instrumentQuotes = await ImportInstrumentQuotes(instrument);
            quotes.AddRange(instrumentQuotes);
            // Todo: Implement logic
            foreach (var quote in instrumentQuotes)
                Console.WriteLine($"Instrument: {instrument.Name}, Quote Date: {quote.Date}, Quote Value: {quote.Value}");

        }

        return quotes;
    }
}