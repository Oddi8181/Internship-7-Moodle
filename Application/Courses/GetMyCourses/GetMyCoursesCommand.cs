using Domain.Enums;

namespace Application.Courses.GetMyCourses
{
    public class GetMyCoursesCommand
    {
        public Guid UserId { get; init; }
        public Role Role { get; init; }
    }
}
