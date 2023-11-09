using QadraBackendTest.Models;

namespace QadraBackendTest.Clients.Interfaces;

public interface IMsClient
{
    Task<List<MsQuote>> GetInstrumentQuotes(string datasourceIdentifier, string name);
}