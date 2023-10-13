namespace Convert.Application.Api.Contracts.Responses;

public class ConvertResponseModel
{
    /// <summary>
    /// Сумма после конвертации.
    /// </summary>
    public decimal ConvertedAmount { get; set; }
    
    /// <summary>
    /// Валюта после конвертации.
    /// </summary>
    public string? ConvertedCurrency { get; set; }
}