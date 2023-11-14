using QadraBackendTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QadraBackendTest.Clients.Interfaces
{
    public interface IQuoteProvider
    {
        Task<IList<QadraQuote>> GetInstrumentQuotes(Instrument instrument);
    }
}
