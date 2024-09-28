using AutoMapper;
using projectcars.DTO.Brand;
using projectcars.DTO.Car;
using projectcars.DTO.Generation;
using projectcars.DTO.Image;
using projectcars.DTO.Model;
using projectcars.Entities;
using projectcars.Models;

namespace projectcars
{
    public class DBMappings : Profile
    {
        public DBMappings() 
        {
            //CreateMap<CarEntity, Car>()
            //    .ForMember(dest => dest.Generation, opt => opt.MapFrom(src => src.GenerationEntity));
            //CreateMap<BrandEntity, Brand>();
            //CreateMap<ModelEntity, Model>();
            //CreateMap<GenerationEntity, Generation>()
            //    .ForMember(dest => dest.Model, opt => opt.MapFrom(src => src.ModelEntity));

            CreateMap<CarEntity, CarDTO>()
                .ForMember(dest => dest.Generation, opt => opt.MapFrom(src => src.GenerationEntity))
                .ForPath(dest => dest.Generation.Model, opt => opt.MapFrom(src => src.GenerationEntity.ModelEntity))
                .ForPath(dest => dest.Generation.Model.Brand, opt => opt.MapFrom(src => src.GenerationEntity.ModelEntity.BrandEntity))
                .ForMember(dest => dest.Images, opt => opt.MapFrom(src => src.ImageEntities));
            CreateMap<BrandEntity, CarBrandDTO>();
            CreateMap<ModelEntity, CarModelDTO>();
            CreateMap<GenerationEntity, CarGenerationDTO>();
            CreateMap<BrandEntity, BrandDTO>()
                .ForMember(dest => dest.Image, opt => opt.MapFrom(src => src.ImageEntity));
            CreateMap<ImageEntity, ImageDTO>();
            CreateMap<ModelEntity, ModelDTO>();
            CreateMap<GenerationEntity, GenerationDTO>()
                .ForMember(dest => dest.Image, opt => opt.MapFrom(src => src.ImageEntity));
        }
    }
}
