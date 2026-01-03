using Domain.Entities;

namespace Domain.Persistance
{
    public interface ICourseRepository
    {
        Task AddAsync(Course course);
        Task<IEnumerable<Course>> GetAllCoursesAsync();
        Task<Course?> GetByIdAsync(Guid courseId);
        Task<IEnumerable<Course>> GetCoursesByProfessorIdAsync(Guid userId);
        Task<IEnumerable<Course>> GetCoursesByStudentIdAsync(Guid userId);
        Task UpdateAsync(Course course);
    }
}
