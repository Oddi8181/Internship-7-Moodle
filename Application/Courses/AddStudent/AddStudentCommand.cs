namespace Application.Courses.AddStudent
{
    public class AddStudentCommand
    {
        public Guid CourseId { get; set; }
        public Guid StudentId { get; set; }
    }
}
