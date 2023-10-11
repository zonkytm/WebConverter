namespace Convert.Application.AppServices.Contracts.HttpClient;

public interface ICBRService
{
    public Task<CurrencyData> GetCurrencyData();
}