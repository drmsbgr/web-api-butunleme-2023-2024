namespace CarManagementApi.Entities;

public class Car
{
    public int Id { get; set; }
    public string Brand { get; set; } = string.Empty;
    public string Model { get; set; } = string.Empty;
    public int Year { get; set; }
    public decimal Price { get; set; }
    public int EngineId { get; set; } //foreign key
    public Engine? Engine { get; set; } // navigation property
}