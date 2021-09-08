using System.Collections.Generic;

namespace ProjectX.WebAPI.Model
{
    public class CourseModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string NecessaryPreKnowledge { get; set; }
        public decimal Cost { get; set; }
        public int SpecializationId { get; set; }
        public SpecializationModel Specialization { get; set; }
        public List<GroupModel> Groups { get; set; }

    }
}
