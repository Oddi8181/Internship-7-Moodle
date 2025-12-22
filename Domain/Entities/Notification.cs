namespace Domain.Entities
{
    public class Notification
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }

        public Guid CourseId { get; set; }
        public Course Course { get; set; }

        private Notification()
        {
            
        }
        public Notification(string title, string content, Course course)
        {
            Id  = Guid.NewGuid();
            Title = title;
            Content = content;
            CreatedAt = DateTime.UtcNow;
            Course = course;
            CourseId = course.Id;
        }
    }
}
