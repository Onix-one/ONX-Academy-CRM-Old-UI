using AutoMapper;
using ProjectX.BLL.Models;
using ProjectX.WebAPI.Dto;

namespace ProjectX.WebAPI.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Student, StudentsDto>()
                .ForMember(_ => _.GroupId, 
                    _ => _.MapFrom(_ => _.GroupId))
                .ForMember(_ => _.GroupNumber,
                    _=>_.MapFrom(_=>_.Group.Number))
                .ForMember(_=>_.CourseId,
                   _=>_.MapFrom(_=>_.Group.CourseId))
                .ForMember(_ => _.CourseTitle,
                    _ => _.MapFrom(_ => _.Group.Course.Title))
                .ReverseMap();
        }
    }
}
