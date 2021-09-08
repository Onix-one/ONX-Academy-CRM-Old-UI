using ProjectX.BLL.Enums;

namespace ProjectX.BLL.Models
{
    public class Student : Person
    {
        public int? GroupId { get; set; }
        public Group Group { get; set; }
        public StudentType? Type { get; set; }
    }

}
