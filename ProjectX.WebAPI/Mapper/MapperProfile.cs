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
                .ForMember(model => model.GroupId, 
                    map => map
                        .MapFrom(_ => _.GroupId))
                .ForMember(model => model.GroupNumber,
                    map => map
                        .MapFrom(_=>_.Group.Number))
                .ForMember(model => model.CourseId,
                    map => map
                        .MapFrom(_=>_.Group.CourseId))
                .ForMember(model => model.CourseTitle,
                    map => map
                        .MapFrom(_ => _.Group.Course.Title))
                .ReverseMap();
            CreateMap<Course, CoursesDto>()
                .ForMember(model => model.SpecializationId,
                    map => map
                        .MapFrom(_ => _.SpecializationId))
                .ForMember(model => model.SpecializationName,
                    map => map
                        .MapFrom(_ => _.Specialization.Title))
                .ReverseMap();
        }
    }
}
