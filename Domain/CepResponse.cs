using System.Text.Json.Serialization;

public class CepResponse
{
    public string cep { get; set; }

    public string logradouro { get; set; }

    public string complemento { get; set; }

    public string bairro { get; set; }

    public string localidade { get; set; }

    public string uf { get; set; }
    public string Estado { get; set; }
    public bool IsAcre {  get; set; }
}