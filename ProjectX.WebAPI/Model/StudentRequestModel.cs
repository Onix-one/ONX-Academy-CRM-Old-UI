using System;
using ProjectX.BLL.Enums;

namespace ProjectX.WebAPI.Model
{
    public class StudentRequestModel : PersonModel
    {
        public DateTime Created { get; set; }
        public int CourseId { get; set; }
        public CourseModel Course { get; set; }
        public StudentType? Type { get; set; }
        public string? Comments { get; set; }
    }
}
