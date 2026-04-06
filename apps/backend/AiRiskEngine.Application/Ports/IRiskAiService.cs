using AiRiskEngine.Domain.Entities;

namespace AiRiskEngine.Application.Ports;

public interface IRiskAiService
{
    Task<RiskScore> EvaluateAsync(string userId, string country, int age, decimal transactionAmount);
}