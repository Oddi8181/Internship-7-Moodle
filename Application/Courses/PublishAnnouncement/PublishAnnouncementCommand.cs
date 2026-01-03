namespace Application.Courses.PublishAnnouncement
{
    public class PublishAnnouncementCommand
    {
        public Guid CourseId { get; init; }
        public Guid ProfessorId { get; init; }
        public string Title { get; init; } 
        public string Content { get; init; } 
    }
}
