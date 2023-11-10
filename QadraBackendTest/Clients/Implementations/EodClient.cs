using QadraBackendTest.Clients.Interfaces;
using QadraBackendTest.Models;
using QadraBackendTest.Models.Base;

namespace QadraBackendTest.Clients.Implementations;

public class EodClient : IDataSourceClient
{
    public async Task<List<QuoteBase>> GetInstrumentQuotes(IDictionary<string, string>? queryParameters = null)
    {
        return new List<QuoteBase>
        {
            new EodQuote { Date = DateTime.Today.AddDays(-3), Close = 100f },
            new EodQuote { Date = DateTime.Today.AddDays(-2), Close = 110f },
            new EodQuote { Date = DateTime.Today.AddDays(-1), Close = 107f }
        };
    }
}