using System;
using ProjectX.BLL.Enums;

namespace ProjectX.MVC.ViewModel
{
    public class StudentRequestViewModel : PersonViewModel
    {
        public DateTime? Created { get; set; }
        public int CourseId { get; set; }
        public CourseViewModel Course { get; set; }
        public StudentType? Type { get; set; }
        public string? Comments { get; set; }
    }
}
