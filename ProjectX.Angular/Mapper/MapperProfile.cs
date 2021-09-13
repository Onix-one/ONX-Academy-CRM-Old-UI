using AutoMapper;
using ProjectX.Angular.Dto;
using ProjectX.BLL.Models;

namespace ProjectX.Angular.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Course, CourseDto>()
                .ForMember(_ => _.Specialization,
                    _ => _.MapFrom(_ => _.Specialization.Title))
                .ReverseMap();
        }
    }
}
