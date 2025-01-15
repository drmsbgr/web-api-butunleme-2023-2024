using CarManagementApi.Controllers.Contracts;
using CarManagementApi.Entities;
using CarManagementApi.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CarManagementApi.Controllers;

public class CarsController(RepositoryContext context) : ICarsController
{
    private readonly RepositoryContext _context = context;

    public void AddCars(CarDto[] cars)
    {
        var carList = new List<Car>();

        foreach (var car in cars)
        {
            carList.Add(new Car()
            {
                Id = car.Id,
                Brand = car.Brand,
                Model = car.Model,
                Year = car.Year,
                Price = car.Price,
                EngineId = car.EngineId,
            });
        }

        _context.Cars?.AddRange(carList);
        _context.SaveChanges();
    }

    public IQueryable<Car>? GetAllCars()
    {
        return _context.Cars?.Include(c => c.Engine).AsNoTracking();
    }

    public IQueryable<Car>? GetAllCarsWithPagination(int pageNo, int pageSize)
    {
        var carsPerPage = _context.Cars?
        .Skip((pageNo - 1) * pageSize)
        .Take(pageSize);
        return carsPerPage;
    }

    public void UpdateCar(int id, Car data)
    {
        var found = _context.Cars?.Find(id);
        if (found is null)
            return;

        found.Brand = data.Brand;
        found.Model = data.Model;
        found.Year = data.Year;
        found.Price = data.Price;
        found.EngineId = data.EngineId;

        _context.SaveChanges();
    }
}