using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ProjectX.BLL.Enums;

namespace ProjectX.MVC.ViewModel
{
    public class GroupViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "This field cannot be empty")]
        public string Number { get; set; }
        public int? CourseId { get; set; }
        public CourseViewModel Course { get; set; }
        public int? TeacherId { get; set; }
        public TeacherViewModel Teacher { get; set; }
        public DateTime StartDate { get; set; }
        public GroupStatus? Status { get; set; }
        public List<StudentViewModel> Students { get; set; }
        public string TeacherName { get; set; }
    }
}
