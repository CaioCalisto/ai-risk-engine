using AiRiskEngine.Application.DTOs;
using AiRiskEngine.Application.Ports;
using AiRiskEngine.Application.UseCases;
using AiRiskEngine.Infrastructure.AI;
using AiRiskEngine.Infrastructure.Config;

var builder = WebApplication.CreateBuilder(args);

var useMock = builder.Configuration.GetValue<bool>("UseMockAi");
if (useMock)
{
    builder.Services.AddScoped<IRiskAiService, MockRiskAiService>();
}
else
{
    builder.Services.AddHttpClient<IRiskAiService, ClaudeRiskAiService>(client =>
    {
        client.Timeout = TimeSpan.FromSeconds(10);
    });
}
builder.Services.AddScoped<IRiskService, EvaluateRiskUseCase>();
builder.Services.Configure<ClaudeOptions>(builder.Configuration.GetSection("Claude"));


var app = builder.Build();

// Endpoint /risk/evaluate
app.MapPost("/risk/evaluate", async (RiskRequest request, IRiskService riskService) =>
{
    var response = await riskService.EvaluateRisk(request);
    return Results.Ok(response);
});

app.Run();