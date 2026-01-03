using Application.Common.Model;
using Domain.Entities;
using Domain.Enums;
using Domain.Persistance;

namespace Application.Courses.GetMyCourses
{
    public class GetMyCoursesHandler
    {
        private readonly ICourseRepository _courseRepository;
        public GetMyCoursesHandler(ICourseRepository repo)
        {
            _courseRepository = repo;
        }

        public async Task<Result<IEnumerable<Course>>> HandleAsync(GetMyCoursesCommand command)
        {
            IEnumerable<Course> courses;
            if (command.Role == Role.Proffesor)
            {
                courses = await _courseRepository.GetCoursesByProfessorIdAsync(command.UserId);
            }
            else if (command.Role == Role.Student)
            {
                courses = await _courseRepository.GetCoursesByStudentIdAsync(command.UserId);
            }
            else
            {
               return Result<IEnumerable<Course>>.Success(Enumerable.Empty<Course>());
            }
            return Result<IEnumerable<Course>>.Success(courses);
        }
    }
}
