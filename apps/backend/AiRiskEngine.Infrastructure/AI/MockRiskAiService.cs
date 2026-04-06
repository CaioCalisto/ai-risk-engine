using AiRiskEngine.Application.Ports;
using AiRiskEngine.Domain.Entities;

namespace AiRiskEngine.Infrastructure.AI;

public class MockRiskAiService : IRiskAiService
{
    public Task<RiskScore> EvaluateAsync(string userId, string country, int age, decimal transactionAmount)
    {
        // lógica simulada
        int score = transactionAmount > 1000 ? 75 : 25;
        string decision = score > 50 ? "REVIEW" : "APPROVE";
        string reason = score > 50 ? "High transaction detected" : "Normal transaction";

        return Task.FromResult(new RiskScore { Score = score, Decision = decision, Reason = reason });
    }
}