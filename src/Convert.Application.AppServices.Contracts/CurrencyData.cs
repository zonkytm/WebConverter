namespace Convert.Application.AppServices.Contracts;

public class CurrencyData
{
    public string Date { get; set; }
    public string PreviousDate { get; set; }
    public string PreviousURL { get; set; }
    public string Timestamp { get; set; }
    public Dictionary<string, CurrencyInfo> Valute { get; set; }
}