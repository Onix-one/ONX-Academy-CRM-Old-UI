using System;

namespace ProjectX.BLL.Models
{
    public class StudentRequest
    {
        public int Id { get; set; }
        public DateTime Created { get; set; }
        public int StudentId { get; set; }
        public Student Student { get; set; }
        public int CourseId { get; set; }
        public Course Course{ get; set; }
        public string? Comments { get; set; }
    }
}
