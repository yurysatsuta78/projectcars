using AutoMapper;
using projectcars.Entities;
using projectcars.Models;

namespace projectcars
{
    public class DBMappings : Profile
    {
        public DBMappings() 
        {
            CreateMap<CarEntity, Car>();
        }
    }
}
