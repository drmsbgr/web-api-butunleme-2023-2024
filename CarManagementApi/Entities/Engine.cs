namespace CarManagementApi.Entities;

public class Engine
{
    public int Id { get; set; }
    public int HorsePower { get; set; }
    public int CylinderCount { get; set; }
    public string FuelType { get; set; } = string.Empty;
}

public record EngineDto
{
    public int HorsePower { get; init; }
    public int CylinderCount { get; init; }
    public string FuelType { get; init; } = string.Empty;
}