using API;
using System.Runtime.CompilerServices;
[assembly:
InternalsVisibleTo("TestProject"), InternalsVisibleTo("GUI")]

internal class Currency
{
    public int Id { get; set; }
    public string Name { get; set; }
    public double ExchangeRate { get; set; }
    public string Date { get; set; }

    public Currency() { }

    public Currency(string name, double exchangeRate, string date)
    {
        Name = name;
        ExchangeRate = exchangeRate;
        Date = date;
    }

    public override string ToString()
    {
        return $"Currency: {Name}, Value: {ExchangeRate}, Date: {Date}";
    }
}