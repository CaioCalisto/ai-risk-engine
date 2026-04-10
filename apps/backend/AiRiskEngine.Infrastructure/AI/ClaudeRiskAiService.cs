using System.Text;
using System.Text.Json;
using Microsoft.Extensions.Options;
using AiRiskEngine.Application.Ports;
using AiRiskEngine.Domain.Entities;
using AiRiskEngine.Infrastructure.Config;

namespace AiRiskEngine.Infrastructure.AI;

public class ClaudeRiskAiService : IRiskAiService
{
    private readonly HttpClient _httpClient;
    private readonly ClaudeOptions _options;

    public ClaudeRiskAiService(HttpClient httpClient, IOptions<ClaudeOptions> options)
    {
        _httpClient = httpClient;
        _options = options.Value;
    }

    public async Task<RiskScore> EvaluateAsync(string userId, string country, int age, decimal transactionAmount)
    {
        var basePath = Directory.GetCurrentDirectory();
        var instructionsPath = Path.Combine(basePath, _options.InstructionsFolder, _options.InstructionsFileName);

        var instructions = await File.ReadAllTextAsync(instructionsPath);

        var inputJson = JsonSerializer.Serialize(new
        {
            userId,
            country,
            age,
            transactionAmount
        });

        var prompt = $"{instructions}\n\nInput:\n{inputJson}";

        var requestBody = new
        {
            model = _options.Model,
            max_tokens = _options.MaxTokens,
            messages = new[]
            {
                new {
                    role = "user",
                    content = prompt
                }
            }
        };

        var request = new HttpRequestMessage(HttpMethod.Post, _options.BaseUrl);
        request.Headers.Add("x-api-key", _options.ApiKey);
        request.Headers.Add("anthropic-version", _options.Version);

        request.Content = new StringContent(
            JsonSerializer.Serialize(requestBody),
            Encoding.UTF8,
            "application/json"
        );

        var response = await _httpClient.SendAsync(request);
        var responseContent = await response.Content.ReadAsStringAsync();

        using var doc = JsonDocument.Parse(responseContent);
        var text = doc
            .RootElement
            .GetProperty("content")[0]
            .GetProperty("text")
            .GetString();

        var risk = JsonSerializer.Deserialize<RiskScore>(text!);

        return risk!;
    }
}
