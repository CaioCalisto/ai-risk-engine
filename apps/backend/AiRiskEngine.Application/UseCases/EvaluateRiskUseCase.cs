using AiRiskEngine.Application.DTOs;
using AiRiskEngine.Application.Ports;

namespace AiRiskEngine.Application.UseCases;

public class EvaluateRiskUseCase : IRiskService
{
    public Task<RiskResponse> EvaluateRisk(RiskRequest request)
    {
        // mock
        int score = request.TransactionAmount > 1000 ? 70 : 30;
        string decision = score > 50 ? "REVIEW" : "APPROVE";
        string reason = score > 50 ? "High transaction amount" : "Normal transaction";

        return Task.FromResult(new RiskResponse(score, decision, reason));
    }
}