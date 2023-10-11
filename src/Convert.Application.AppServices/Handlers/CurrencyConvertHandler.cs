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
        
        var currencyToConvertValue = currencyToConvert.Equals("RUB")? 1: currencyDictionary
            .Where(valute => valute.Key == currencyToConvert)
            .Select(valute => valute.Value.Value)
            .FirstOrDefault();
        
        var targetCurrencyValue =targetCurrency.Equals("RUB")? 1: currencyDictionary
            .Where(valute => valute.Key == targetCurrency)
            .Select(valute => valute.Value.Value)
            .FirstOrDefault();
        
        if (currencyToConvertValue.Equals(0) || targetCurrencyValue.Equals(0))
        {
        }

        decimal currencyRatio = currencyToConvertValue/targetCurrencyValue;
        decimal convertResult = amount*currencyRatio;
        return Task.FromResult(convertResult);
    }
}

