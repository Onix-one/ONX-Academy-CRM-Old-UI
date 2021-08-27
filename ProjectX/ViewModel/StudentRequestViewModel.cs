using System;

namespace ProjectX.MVC.ViewModel
{
    public class StudentRequestViewModel
    {
        public int Id { get; set; }
        public DateTime Created { get; set; }
        public int StudentId { get; set; }
        public StudentViewModel Student { get; set; }
        public int CourseId { get; set; }
        public CourseViewModel Course { get; set; }
        public string? Comments { get; set; }
    }
}
