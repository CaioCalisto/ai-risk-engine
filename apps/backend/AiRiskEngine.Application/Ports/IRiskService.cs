using AiRiskEngine.Application.DTOs;

namespace AiRiskEngine.Application.Ports;

public interface IRiskService
{
    Task<RiskResponse> EvaluateRisk(RiskRequest request);
}