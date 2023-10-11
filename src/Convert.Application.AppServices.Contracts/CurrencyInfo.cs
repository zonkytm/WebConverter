namespace Convert.Application.AppServices.Contracts;

public class CurrencyInfo
{
    public string ID { get; set; }
    public int NumCode { get; set; }
    public string CharCode { get; set; }
    public int Nominal { get; set; }
    public string Name { get; set; }
    public decimal Value { get; set; }
}