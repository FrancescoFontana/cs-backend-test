using QadraBackendTest.Models.Base;

namespace QadraBackendTest.Models;

public class MsQuote : QuoteBase
{
    public float? Value { get; set; }

    public override void Print()
    {
        Console.WriteLine(Date);
        Console.WriteLine(Value);
    }
}