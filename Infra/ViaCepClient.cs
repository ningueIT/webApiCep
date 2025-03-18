using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;

public class ViaCepClient
{
    private readonly HttpClient _httpClient;

    public ViaCepClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<CepResponse?> GetCepInfoAsync(string cep)
    {
        string url = $"https://viacep.com.br/ws/{cep}/json/";
        var response = await _httpClient.GetAsync(url);

        if (!response.IsSuccessStatusCode)
            return null;

        var cepInfo = await response.Content.ReadFromJsonAsync<CepResponse>();

        if (cepInfo != null)
        {
            cepInfo.IsAcre = cepInfo.uf == "AC";
        }

        return cepInfo;

        var json = await response.Content.ReadAsStringAsync();
        return JsonSerializer.Deserialize<CepResponse>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });


    }
}

