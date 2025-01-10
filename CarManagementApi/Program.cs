using CarManagementApi.Controllers;
using CarManagementApi.Controllers.Contracts;
using CarManagementApi.Entities;
using CarManagementApi.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<ICarsController, CarsController>();
builder.Services.AddDbContext<RepositoryContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("sqlite")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("api/cars/", (ICarsController carsController) =>
{
    var cars = carsController.GetAllCars();
    if (cars is not null && cars.Any())
        return Results.Ok(cars);

    return Results.NoContent();
})
.Produces<IQueryable<Car>>(StatusCodes.Status200OK)
.Produces(StatusCodes.Status204NoContent);

app.MapPost("api/cars", (ICarsController controller, Car[] datas) =>
{
    controller.AddCars(datas);
});

app.MapGet("api/cars/page/{pageNumber}", (ICarsController carsController, int pageNumber, int pageSize) =>
{
    var cars = carsController.GetAllCarsWithPagination(pageNumber, pageSize);
    if (cars is not null && cars.Any())
        return Results.Ok(cars);
    return Results.NoContent();
})
.Produces<IQueryable<Car>>(StatusCodes.Status200OK)
.Produces(StatusCodes.Status204NoContent);

app.MapPut("api/cars/{id}", (ICarsController carsController, int id, Car updatedData) =>
{
    carsController.UpdateCar(id, updatedData);
});

app.Run();
