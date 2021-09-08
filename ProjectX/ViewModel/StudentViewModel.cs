using ProjectX.BLL.Enums;

namespace ProjectX.MVC.ViewModel
{
    public class StudentViewModel : PersonViewModel
    {
        public int? GroupId { get; set; }
        public GroupViewModel Group { get; set; }
        public StudentType? Type { get; set; }

    }
}
