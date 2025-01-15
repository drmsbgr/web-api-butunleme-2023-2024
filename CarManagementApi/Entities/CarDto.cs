namespace CarManagementApi.Entities;

public record CarDto
{
    public int Id { get; init; }
    public string Brand { get; init; } = string.Empty;
    public string Model { get; init; } = string.Empty;
    public int Year { get; init; }
    public decimal Price { get; init; }
    public int EngineId { get; init; }
}