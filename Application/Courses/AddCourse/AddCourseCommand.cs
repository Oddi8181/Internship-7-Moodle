namespace Application.Courses.Add
{
    public class AddCourseCommand
    {
        public string Name { get; init; } = null!;
        public Guid ProfessorId { get; init; }
    }
}
