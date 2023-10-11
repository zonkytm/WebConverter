using Convert.Application.AppServices.Contracts;
using Convert.Application.AppServices.Contracts.HttpClient;
using Microsoft.Extensions.Options;

namespace Convert.Application.Host;

public class CBRService:ICBRService
{
    private readonly HttpClient _httpClient;

    public CBRService(HttpClient httpClient,IOptions<CBRSettings> cbrSettings)
    {
        _httpClient = httpClient;
        _httpClient.BaseAddress = new Uri(cbrSettings.Value.BaseUrl);
    }
    
    public async Task<CurrencyData> GetCurrencyData()
    { 
        var response = await _httpClient.GetFromJsonAsync<CurrencyData>("daily_json.js");
        return response;
    }
}