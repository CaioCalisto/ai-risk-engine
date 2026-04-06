namespace AiRiskEngine.Application.DTOs;

public record RiskRequest(string UserId, string Country, int Age, decimal TransactionAmount);