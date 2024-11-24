using AutoMapper;
using projectcars.DTO.Brand;
using projectcars.DTO.Car;
using projectcars.DTO.City;
using projectcars.DTO.Generation;
using projectcars.DTO.Image;
using projectcars.DTO.Model;
using projectcars.DTO.Region;
using projectcars.Entities;
using projectcars.Models;

namespace projectcars
{
    public class DBMappings : Profile
    {
        public DBMappings() 
        {
            CreateMap<CarEntity, CarDTO>()
                .ForMember(dest => dest.GenerationName, opt => opt.MapFrom(src => src.GenerationEntity.GenerationName))
                .ForPath(dest => dest.ModelName, opt => opt.MapFrom(src => src.GenerationEntity.ModelEntity.ModelName))
                .ForPath(dest => dest.BrandName, opt => opt.MapFrom(src => src.GenerationEntity.ModelEntity.BrandEntity.BrandName))
                .ForPath(dest => dest.CityName, opt => opt.MapFrom(src => src.CityEntity.CityName))
                .ForPath(dest => dest.RegionName, opt => opt.MapFrom(src => src.CityEntity.RegionEntity.RegionName))
                .ForMember(dest => dest.Images, opt => opt.MapFrom(src => src.ImageEntities));


            CreateMap<BrandEntity, BrandDTO>()
                .ForMember(dest => dest.Image, opt => opt.MapFrom(src => src.ImageEntity));

            CreateMap<GenerationEntity, GenerationDTO>()
                .ForMember(dest => dest.Image, opt => opt.MapFrom(src => src.ImageEntity))
                .ForMember(dest => dest.ModelId, opt => opt.MapFrom(src => src.ModelId));

            CreateMap<ModelEntity, ModelDTO>()
                .ForMember(dest => dest.BrandId, opt => opt.MapFrom(src => src.BrandId));


            CreateMap<ImageEntity, ImageDTO>();
            CreateMap<CityEntity, CityDTO>();
            CreateMap<RegionEntity, RegionDTO>();
            CreateMap<UserEntity, User>();
        }
    }
}
