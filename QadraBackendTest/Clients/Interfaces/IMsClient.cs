using QadraBackendTest.Models;
using QadraBackendTest.Models.Base;

namespace QadraBackendTest.Clients.Interfaces;

public interface IMsClient
{
    Task<List<MsQuote>> GetInstrumentQuotes(string datasourceIdentifier, string name);
}