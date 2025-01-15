using CarManagementApi.Entities;

namespace CarManagementApi.Controllers.Contracts;

public interface ICarsController
{
    IQueryable<Car>? GetAllCars();
    IQueryable<Car>? GetAllCarsWithPagination(int pageNo, int pageSize);
    void AddCars(CarDto[] cars);
    void UpdateCar(int id, Car data);
}