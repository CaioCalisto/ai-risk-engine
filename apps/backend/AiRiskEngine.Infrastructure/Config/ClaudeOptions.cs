namespace AiRiskEngine.Infrastructure.Config;

public class ClaudeOptions
{
    public string ApiKey { get; set; } = null!;
    public string BaseUrl { get; set; } = null!;
    public string Model { get; set; } = null!;
    public string Version { get; set; } = null!;
    public int MaxTokens { get; set; }
    public string InstructionsFolder { get; set; } = null!;
    public string InstructionsFileName { get; set; } = null!;
}