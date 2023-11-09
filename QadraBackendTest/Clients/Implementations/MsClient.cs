using QadraBackendTest.Clients.Interfaces;
using QadraBackendTest.Models;

namespace QadraBackendTest.Clients.Implementations;

public class MsClient : IMsClient
{
    public async Task<List<MsQuote>> GetInstrumentQuotes(string datasourceIdentifier, string name)
    {
        return new List<MsQuote>
        {
            new MsQuote { Date = DateTime.Today.AddDays(-4), Value = 0 },
            new MsQuote { Date = DateTime.Today.AddDays(-3), Value = 100f },
            new MsQuote { Date = DateTime.Today.AddDays(-2), Value = null },
            new MsQuote { Date = DateTime.Today.AddDays(-1), Value = 107f },
        };
    }
}