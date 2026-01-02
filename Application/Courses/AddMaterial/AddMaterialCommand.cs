namespace Application.Courses.AddMaterial
{
    public class AddMaterialCommand
    {
        public Guid CourseId { get; init; }
        public Guid ProfessorId { get; init; }
        public string Name { get; init; }
        public string Url { get; init; }

    }
}
