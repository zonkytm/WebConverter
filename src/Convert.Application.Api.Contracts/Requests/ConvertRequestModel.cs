namespace Convert.Application.Api.Contracts.Requests;

public class ConvertRequestModel
{
    
    /// <summary>
    /// Сумма которую нудно конвертировать.
    /// </summary>
    public decimal Amount { get; init; }
    
    /// <summary>
    /// Исходная валюта.
    /// </summary>
    public string CurrencyToConvert { get; init; }
    
    /// <summary>
    /// Валюта в которую будет конвертация.
    /// </summary>
    public string TargetCurrency { get; init; }
}