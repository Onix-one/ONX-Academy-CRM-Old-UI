using System.Collections.Generic;

namespace ProjectX.MVC.ViewModel
{
    public class SpecializationViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string PNGName { get; set; }
        public string Description { get; set; }
        public List<CourseViewModel> Courses { get; set; }
    }
}
