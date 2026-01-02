namespace Domain.Entities
{
    public class Enrollment
    {
        public Guid Id { get; private set; }

        public Guid UserId { get; private set; }
        public User Student { get; private set; }

        public Guid CourseId { get; private set; }
        public Course Course { get; private set; }
        public DateTime CreatedAt { get; internal set; }

        private Enrollment()
        {
            
        }
        public Enrollment(User student, Course course)
        {
            Id = Guid.NewGuid();
            Student = student;
            UserId = student.Id;
            Course = course;
            CourseId = course.Id;
        }
    }
}