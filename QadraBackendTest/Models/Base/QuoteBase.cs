namespace QadraBackendTest.Models.Base;

public abstract class QuoteBase
{
    public DateTime Date { get; set; }

    public abstract void Print();
}