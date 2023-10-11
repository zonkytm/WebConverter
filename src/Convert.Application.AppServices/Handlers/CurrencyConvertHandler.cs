using Convert.Application.AppServices.Contracts.Handlers;
using Convert.Application.AppServices.Contracts.HttpClient;

namespace Convert.Application.AppServices.Handlers;

public class CurrencyConvertHandler : ICurrencyConvertHandler
{
    private readonly ICBRService _cbr;

    public CurrencyConvertHandler(ICBRService cbr)
    {
        _cbr = cbr;
    }

    public Task<decimal> Handle(decimal amount, string currencyToConvert, string targetCurrency)
    {
        var cbrData = _cbr.GetCurrencyData().Result;
        var currencyDictionary = cbrData.Valute;
        
        var currencyToConvertValue = currencyDictionary
            .Where(valute => valute.Key == currencyToConvert)
            .Select(valute => valute.Value.Value)
            .FirstOrDefault();
        
        var targetCurrencyValue = currencyDictionary
            .Where(valute => valute.Key == targetCurrency)
            .Select(valute => valute.Value.Value)
            .FirstOrDefault();
        if (currencyToConvert.Equals(0) || targetCurrency.Equals(0))
        {
        }

        decimal currencyRatio = targetCurrencyValue / currencyToConvertValue;
        decimal convertResult = amount * currencyRatio;
        return Task.FromResult(convertResult);
    }
}

