namespace AiRiskEngine.Domain.Entities;

public class RiskScore
{
    public int Score { get; set; }
    public string Decision { get; set; } = null!;
    public string Reason { get; set; } = null!;
}