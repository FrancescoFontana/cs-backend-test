using QadraBackendTest.Clients.Interfaces;
using QadraBackendTest.Models;
using System.Reflection;

namespace QadraBackendTest.Clients.Implementations
{
    public class QuoteProvider: IQuoteProvider
    {
        public string Name { get; set; }

        private Func<IServiceProvider, Instrument, Task<IList<QadraQuote>>> _converter;
        IServiceProvider _serviceProvider;

        public QuoteProvider(string name, IServiceProvider serviceProvider, Func<IServiceProvider, Instrument, Task<IList<QadraQuote>>> converter)
        {
            Name = name;
            _serviceProvider = serviceProvider;
            _converter = converter;       
        }

        public async Task<IList<QadraQuote>> GetInstrumentQuotes(Instrument instrument)
        {
            return await _converter(_serviceProvider, instrument);
        }
    }
}
