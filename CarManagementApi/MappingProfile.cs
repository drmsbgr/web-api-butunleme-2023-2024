using AutoMapper;
using CarManagementApi.Entities;

namespace CarManagementApi;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<CarDto, Car>().ReverseMap();
        CreateMap<EngineDto, Engine>().ReverseMap();
    }
}