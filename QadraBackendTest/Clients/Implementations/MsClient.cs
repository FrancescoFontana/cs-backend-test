using QadraBackendTest.Clients.Interfaces;
using QadraBackendTest.Models;
using QadraBackendTest.Models.Base;

namespace QadraBackendTest.Clients.Implementations;

public class MsClient : IDataSourceClient
{
    public async Task<List<QuoteBase>> GetInstrumentQuotes(IDictionary<string, string>? queryParameters = null)
    {
        return new List<QuoteBase>
        {
            new MsQuote { Date = DateTime.Today.AddDays(-4), Value = 0 },
            new MsQuote { Date = DateTime.Today.AddDays(-3), Value = 100f },
            new MsQuote { Date = DateTime.Today.AddDays(-2), Value = null },
            new MsQuote { Date = DateTime.Today.AddDays(-1), Value = 107f },
        };
    }
}