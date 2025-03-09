using Newtonsoft.Json;
using Terceros.Applications.Configurations;
using Terceros.Applications.DTOs.People;
using Terceros.Applications.Gateways;
using Terceros.Applications.Interfaces.ICommon;

namespace Terceros.Services.People;

public class PeopleServices : IPeopleGateway
{
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly ILogServices _logServices;

    public PeopleServices(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task<PeopleDTO> GetPeople()
    {
        try
        {
            using var client = _httpClientFactory.CreateClient(ConfigHelper.ApiPeople!.HttpClientName);
            var url = ConfigHelper.ApiPeople.Endpoint.ToString();
            var httpsResponse = await client.GetAsync(url);

            if (httpsResponse.IsSuccessStatusCode)
            {
                var content = await httpsResponse.Content.ReadAsStringAsync();
                var resultDto = JsonConvert.DeserializeObject<PeopleDTO>(content);
                return resultDto!;
            }

            return null;
        }
        catch (Exception ex)
        {
            _logServices.LogError(ex.Message);
            throw;
        }
    }
}
