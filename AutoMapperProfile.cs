using AutoMapper;

namespace AutoMapperDemo
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile() 
        {
            CreateMap<SuperHero, SuperHeroDto>();        
            CreateMap<SuperHeroDto, SuperHero>();
        }
    }
}
