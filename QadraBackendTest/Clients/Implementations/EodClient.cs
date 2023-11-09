using QadraBackendTest.Clients.Interfaces;
using QadraBackendTest.Models;

namespace QadraBackendTest.Clients.Implementations;

public class EodClient : IEodClient
{
    public async Task<List<EodQuote>> GetInstrumentQuotes(string datasourceIdentifier)
    {
        return new List<EodQuote>
        {
            new EodQuote { Date = DateTime.Today.AddDays(-3), Close = 100f },
            new EodQuote { Date = DateTime.Today.AddDays(-2), Close = 110f },
            new EodQuote { Date = DateTime.Today.AddDays(-1), Close = 107f }
        };
    }
}