using System;
using System.Collections.Generic;
using ProjectX.WebAPI.Enums;

namespace ProjectX.WebAPI.Model
{
    public class GroupModel
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public int? CourseId { get; set; }
        public CourseModel Course { get; set; }
        public int? TeacherId { get; set; }
        public TeacherModel Teacher { get; set; }
        public DateTime? StartDate { get; set; }
        public GroupStatus? Status { get; set; }
        public List<StudentModel> Students { get; set; }
        public string TeacherName { get; set; }

    }
}
