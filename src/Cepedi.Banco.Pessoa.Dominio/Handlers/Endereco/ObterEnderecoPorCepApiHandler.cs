using System.Text.Json.Serialization;
using Cepedi.Banco.Pessoa.Compartilhado.Requests;
using Cepedi.Banco.Pessoa.Compartilhado.Responses;
using Cepedi.Banco.Pessoa.Dominio.Repository;
using MediatR;
using Microsoft.Extensions.Logging;
using OperationResult;
using System.Text.Json;

namespace Cepedi.Banco.Pessoa.Dominio.Handlers;

public class ObterEnderecoPorCepApiHandler : IRequestHandler<ObterEnderecoPorCepRequest, Result<ObterEnderecoPorCepResponse>>
{
    private readonly ILogger<ObterEnderecoPorCepRequestHandler> _logger;
    public ObterEnderecoPorCepApiHandler(ILogger<ObterEnderecoPorCepRequestHandler> logger)
    {
        _logger = logger;
    }
    public async Task<Result<ObterEnderecoPorCepResponse>> Handle(ObterEnderecoPorCepRequest request, CancellationToken cancellationToken)
    {
        var valor = request.Cep;
        string url = $"https://viacep.com.br/ws/{valor}/json/";

        var httpClient = new HttpClient();

        var response = await httpClient.GetAsync(url);

        var content = await response.Content.ReadAsStringAsync();

        var endereco = JsonSerializer.Deserialize<ObterEnderecoPorCepResponse>(content);

        if (response == null)
        {
            return Result.Error<ObterEnderecoPorCepResponse>(new Compartilhado.Exceptions.SemResultadosExcecao());
        }
        return Result.Success(endereco);
    }
}


// using System.Net.Http;
// using System.Text.Json;
// using System.Threading;
// using System.Threading.Tasks;
// using Cepedi.Banco.Pessoa.Compartilhado.Requests;
// using Cepedi.Banco.Pessoa.Compartilhado.Responses;
// using Cepedi.Banco.Pessoa.Dominio.Entidades;
// using MediatR;
// using OperationResult;

// namespace Cepedi.Banco.Pessoa.Dominio.Handlers;
// public class ObterEnderecoPorCepApiHandler : IRequestHandler<ObterEnderecoPorCepRequest, Result<ObterEnderecoPorCepResponse>>
// {QD
//     private readonly HttpClient _httpClient;

//     public ObterEnderecoPorCepApiHandler(HttpClient httpClient)
//     {
//         _httpClient = httpClient;
//     }

//     public async Task<Result<EnderecoEntity>> Handle(ObterEnderecoPorCepRequest,Q CancellationToken cancellationToken)
//     {
//         var response = await _httpClient.GetAsync($"https://viacep.com.br/ws/{request}/json/");

//         if (!response.IsSuccessStatusCode)
//         {
//             return Result.Error<EnderecoEntity>(new Exception("Erro ao buscar CEP"));
//         }

//         var endereco = await JsonSerializer.DeserializeAsync<EnderecoEntity>(await response.Content.ReadAsStreamAsync());

//         return Result.Success(endereco);
//     }
// }
