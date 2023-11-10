using System.Collections.Generic;
using System.Threading.Tasks;
using NUnit.Framework;
using QadraBackendTest.Clients.Implementations;

namespace QadraBackendTest.Tests;

public class EodClientTests
{
    private EodClient _sut;

    [SetUp]
    public void Setup()
    {
        _sut = new EodClient();
    }

    [Test]
    public async Task Test1()
    {
        var query = new Dictionary<string, string>
        {
            { "datasourceIdentifier", "AAPL" } //arthuredgarov
        };

        var result = await _sut.GetInstrumentQuotes(query);

        Assert.AreEqual(3, result.Count);
    }
}