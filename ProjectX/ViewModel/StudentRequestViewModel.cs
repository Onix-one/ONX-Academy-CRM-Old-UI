using System;
using System.ComponentModel.DataAnnotations;
using ProjectX.BLL.Enums;

namespace ProjectX.MVC.ViewModel
{
    public class StudentRequestViewModel : PersonViewModel
    {
        public DateTime? Created { get; set; }

        [Required(ErrorMessage = "This field cannot be empty")]
        public int CourseId { get; set; }
        [Required(ErrorMessage = "This field cannot be empty")]
        public CourseViewModel Course { get; set; }
        public StudentType? Type { get; set; }
        public string? Comments { get; set; }
    }
}
