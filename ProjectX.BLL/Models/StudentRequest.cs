using System;
using ProjectX.BLL.Enums;

namespace ProjectX.BLL.Models
{
    public class StudentRequest : Person
    {
        public DateTime Created { get; set; }
        public int CourseId { get; set; }
        public Course Course { get; set; }
        public StudentType? Type { get; set; }
        public string? Comments { get; set; }
    }
}
