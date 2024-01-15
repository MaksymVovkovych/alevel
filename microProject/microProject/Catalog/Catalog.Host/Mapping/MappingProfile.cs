using AutoMapper;
using Catalog.Host.Data.Entity;

namespace Catalog.Host.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<CarDto, Car>()
            .ForMember(dest => dest.Brand, opt => opt.MapFrom(src => src.Brand));

        CreateMap<BrandDto, Brand>();
    }
}