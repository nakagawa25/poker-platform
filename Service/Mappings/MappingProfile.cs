using AutoMapper;
using Domain.DTOs;
using Domain.Entities;

namespace Service.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Category, CategoryDTO>()
                .ForMember(dest => dest.Stages, opt => opt.MapFrom(src =>
                    src.Stages.Select(stage => new StageDTO
                    {
                        Id = stage.Id,
                        Name = stage.Name,
                        CategoryId = stage.CategoryId,
                    })))
                .ReverseMap();

            CreateMap<Stage, StageDTO>()
                .ForMember(dest => dest.CategoryName, 
                           opt => opt.MapFrom(src => src.Category.Name))
                .ReverseMap();

            CreateMap<Image, ImageDTO>().ReverseMap();
            CreateMap<Player, PlayerDTO>().ReverseMap();
            CreateMap<Rank, RankDTO>().ReverseMap();
            CreateMap<User, UserDTO>().ReverseMap();
        }
    }
}
