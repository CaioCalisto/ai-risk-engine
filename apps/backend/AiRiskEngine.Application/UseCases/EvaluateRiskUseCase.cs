using AiRiskEngine.Application.DTOs;
using AiRiskEngine.Application.Ports;

namespace AiRiskEngine.Application.UseCases;

public class EvaluateRiskUseCase : IRiskService
{
    private readonly IRiskAiService _aiService;

        public EvaluateRiskUseCase(IRiskAiService aiService)
        {
            _aiService = aiService;
        }

        public async Task<RiskResponse> EvaluateRisk(RiskRequest request)
        {
            var aiScore = await _aiService.EvaluateAsync(request.UserId, request.Country, request.Age, request.TransactionAmount);

            return new RiskResponse(aiScore.Score, aiScore.Decision, aiScore.Reason);
        }
}