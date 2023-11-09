using QadraBackendTest.Models;

namespace QadraBackendTest.Clients.Interfaces;

public interface IEodClient
{
    Task<List<EodQuote>> GetInstrumentQuotes(string datasourceIdentifier);
}