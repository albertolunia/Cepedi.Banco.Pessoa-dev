﻿using System.Text.Json.Serialization;
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

        var options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };

        var endereco = JsonSerializer.Deserialize<ObterEnderecoPorCepResponse>(content, options);

        if (response == null)
        {
            return Result.Error<ObterEnderecoPorCepResponse>(new Compartilhado.Exceptions.SemResultadosExcecao());
        }

        return Result.Success(endereco);
    }
}
