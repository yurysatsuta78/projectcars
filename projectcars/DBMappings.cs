using AutoMapper;
using projectcars.Entities;
using projectcars.Models;
using System.Data;

namespace projectcars
{
    public class DBMappings : Profile
    {
        public DBMappings() 
        {
            CreateMap<CarEntity, Car>();
            CreateMap<BrandEntity, Brand>();
            CreateMap<ModelEntity, Model>();
            CreateMap<GenerationEntity, Generation>()
                .ForMember(dest => dest.Model, opt => opt.MapFrom(src => src.ModelEntity));
        }
    }
}
