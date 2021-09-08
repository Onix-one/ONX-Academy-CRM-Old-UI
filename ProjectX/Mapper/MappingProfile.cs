using AutoMapper;
using ProjectX.BLL.Models;
using ProjectX.MVC.ViewModel;

namespace ProjectX.MVC.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Person, PersonViewModel>().ReverseMap();
            CreateMap<Student, StudentViewModel>().ReverseMap();
            CreateMap<Teacher, TeacherViewModel>().ReverseMap();
            CreateMap<Course, CourseViewModel>().ReverseMap();
            CreateMap<Specialization, SpecializationViewModel>().ReverseMap();
            CreateMap<StudentRequest, StudentRequestViewModel>().ReverseMap();
            CreateMap<Group, GroupViewModel>()
                .ForMember(model => model.TeacherName, 
                    map => map
                        .MapFrom(g => $"{g.Teacher.LastName} {g.Teacher.FirstName}"))
                .ReverseMap();
        }
    }
}
