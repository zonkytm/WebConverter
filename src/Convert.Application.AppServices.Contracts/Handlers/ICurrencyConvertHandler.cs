namespace Convert.Application.AppServices.Contracts.Handlers;

public interface ICurrencyConvertHandler
{
    Task<decimal> Handle(decimal amount, string currencyToConvert, string targetCurrency);
}