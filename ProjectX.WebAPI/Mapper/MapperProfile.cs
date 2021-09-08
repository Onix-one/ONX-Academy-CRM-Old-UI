using AutoMapper;
using ProjectX.BLL.Models;
using ProjectX.WebAPI.Model;

namespace AcademyCRM.Api.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Student, StudentModel>().ReverseMap();
            CreateMap<Teacher, TeacherModel>().ReverseMap();
            CreateMap<Course, CourseModel>().ReverseMap();
            CreateMap<Specialization, SpecializationModel>().ReverseMap();
            CreateMap<StudentRequest, StudentRequestModel>().ReverseMap();
            CreateMap<Group, GroupModel>()
                .ForMember(model => model.TeacherName,
                    map => map
                        .MapFrom(g => $"{g.Teacher.LastName} {g.Teacher.FirstName}"))
                .ReverseMap();



        }
    }

}
