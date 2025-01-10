namespace CarManagementApi.Entities;

public class Engine
{
    public int Id { get; set; }
    public int HorsePower { get; set; }
    public int CylinderCount { get; set; }
    public string FuelType { get; set; } = string.Empty;
}