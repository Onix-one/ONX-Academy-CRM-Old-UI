using System.Collections.Generic;
using ProjectX.BLL.Models;

namespace ProjectX.MVC.ViewModel
{
    public class SpecializationViewModel

    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public List<Course> Courses { get; set; }
    }
}
