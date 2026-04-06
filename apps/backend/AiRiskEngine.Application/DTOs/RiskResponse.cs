namespace AiRiskEngine.Application.DTOs;

public record RiskResponse(int Score, string Decision, string Reason);