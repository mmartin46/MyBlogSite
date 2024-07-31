using AutoMapper;
using Portfolio.Data;
using Portfolio.Models;

namespace Portfolio.Mapping
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Apps, AppModel>();
        }
    }
}
