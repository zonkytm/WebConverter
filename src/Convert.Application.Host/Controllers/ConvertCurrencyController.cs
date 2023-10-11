using Convert.Application.Api.Contracts.Requests;
using Convert.Application.Api.Contracts.Responses;
using Convert.Application.AppServices.Contracts.Handlers;
using Microsoft.AspNetCore.Mvc;

namespace Convert.Application.Host.Controllers;

[Route("/[controller]/")]
public class ConvertCurrencyController:Controller
{
    private readonly ICurrencyConvertHandler _convertHandler;

    public ConvertCurrencyController(ICurrencyConvertHandler convertHandler)
    {
        _convertHandler = convertHandler;
    }

    [HttpPost("/convert")]
    public Task<ConvertResponseModel> Convert([FromBody]ConvertRequestModel currencyToConvert)
    {
        var convertedValue = _convertHandler.Handle(currencyToConvert.Amount, currencyToConvert.CurrencyToConvert,
            currencyToConvert.TargetCurrency).Result;
        
        var response = new ConvertResponseModel
        {
            ConvertedAmount = convertedValue,
            ConvertedCurrency = currencyToConvert.TargetCurrency
        };
        return Task.FromResult(response);
    }
}