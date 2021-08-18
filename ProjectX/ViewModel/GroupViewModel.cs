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
        public int? TeacherId { get; set; }
        public string TeacherName { get; set; }
        public List<StudentViewModel> Students { get; set; }
        [Required(ErrorMessage = "This field cannot be empty")]
        public DateTime StartDate { get; set; }
        public GroupStatus? Status { get; set; }
    }
}
