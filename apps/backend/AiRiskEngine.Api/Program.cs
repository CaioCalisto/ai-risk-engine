using AiRiskEngine.Application.DTOs;
using AiRiskEngine.Application.Ports;
using AiRiskEngine.Application.UseCases;

var builder = WebApplication.CreateBuilder(args);

// Registra serviço no DI
builder.Services.AddScoped<IRiskService, EvaluateRiskUseCase>();

var app = builder.Build();

// Endpoint /risk/evaluate
app.MapPost("/risk/evaluate", async (RiskRequest request, IRiskService riskService) =>
{
    var response = await riskService.EvaluateRisk(request);
    return Results.Ok(response);
});

app.Run();