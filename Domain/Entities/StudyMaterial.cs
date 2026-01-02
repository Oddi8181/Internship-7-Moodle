namespace Domain.Entities
{
    public class StudyMaterial
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public DateTime CreatedAt { get; set; }
        public Guid CourseId { get; set; }
        public Course Course { get; set; }

        private StudyMaterial()
        {

        }
        public StudyMaterial(string name, string url, Course course)
        {
            Id = Guid.NewGuid();
            Name = name;
            Url = url;
            createdAt = DateTime.UtcNow;
            Course = course;
            CourseId = course.Id;
        }

    }
}
