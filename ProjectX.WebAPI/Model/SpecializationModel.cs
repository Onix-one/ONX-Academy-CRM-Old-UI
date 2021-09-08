using System.Collections.Generic;

namespace ProjectX.WebAPI.Model
{
    public class SpecializationModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string PNGName { get; set; }
        public string Description { get; set; }
        public List<CourseModel> Courses { get; set; }

    }
}
