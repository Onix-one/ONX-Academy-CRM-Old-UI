using ProjectX.WebAPI.Enums;

namespace ProjectX.WebAPI.Model
{
    public class StudentModel : PersonModel
    {
        public int? GroupId { get; set; }
        public GroupModel Group { get; set; }
        public StudentType? Type { get; set; }
    }
}

