using QadraBackendTest.Models.Base;

namespace QadraBackendTest.Models;

public class EodQuote : QuoteBase
{
    public float Close { get; set; }

    public override void Print()
    {
        Console.WriteLine(Date);
        Console.WriteLine(Close);
    }
}