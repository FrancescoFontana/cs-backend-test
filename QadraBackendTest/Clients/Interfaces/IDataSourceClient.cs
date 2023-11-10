using QadraBackendTest.Models.Base;

namespace QadraBackendTest.Clients.Interfaces;

public interface IDataSourceClient
{
    Task<List<QuoteBase>> GetInstrumentQuotes(IDictionary<string, string>? queryParameters = null);
}