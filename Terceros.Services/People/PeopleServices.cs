using Newtonsoft.Json;
using Polly;
using Polly.Retry;
using System.Net;
using Terceros.Applications.Configurations;
using Terceros.Applications.DTOs.People;
using Terceros.Applications.Gateways;
using Terceros.Applications.Interfaces.ICommon;

namespace Terceros.Services.People;

public class PeopleServices : IPeopleGateway
{
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly ILogServicesInteractor _logServices;
    private readonly AsyncRetryPolicy<HttpResponseMessage> _politicaReintentos;

    public PeopleServices(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;

        _politicaReintentos = Policy<HttpResponseMessage>.Handle<HttpRequestException>()
            .OrResult(respuesta => respuesta.StatusCode == HttpStatusCode.InternalServerError 
                      || respuesta.StatusCode == HttpStatusCode.RequestTimeout)
            .WaitAndRetryAsync(retryCount:3, 
            intento => TimeSpan.FromSeconds(1 * intento), 
            onRetry:(exception, conteo, contexto) =>
            {
                _logServices.LogError("Hora del error: " + DateTime.Now);
            });
    }
    public async Task<PeopleDTO> GetPeople()
    {

        using var client = _httpClientFactory.CreateClient(ConfigHelper.ApiPeople!.HttpClientName);
        var url = ConfigHelper.ApiPeople.Endpoint.ToString();

        var httpsResponse = await _politicaReintentos.ExecuteAsync(async () =>
        {
            return await client.GetAsync(url);
        });

            var content = await httpsResponse.Content.ReadAsStringAsync();
            var resultDto = JsonConvert.DeserializeObject<PeopleDTO>(content);
        
        return resultDto!;
    }
}
