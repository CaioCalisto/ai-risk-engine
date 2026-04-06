using AiRiskEngine.Application.DTOs;
using AiRiskEngine.Application.Ports;
using AiRiskEngine.Application.UseCases;
using AiRiskEngine.Infrastructure.AI;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IRiskAiService, MockRiskAiService>();
builder.Services.AddScoped<IRiskService, EvaluateRiskUseCase>();

var app = builder.Build();

// Endpoint /risk/evaluate
app.MapPost("/risk/evaluate", async (RiskRequest request, IRiskService riskService) =>
{
    var response = await riskService.EvaluateRisk(request);
    return Results.Ok(response);
});

app.Run();