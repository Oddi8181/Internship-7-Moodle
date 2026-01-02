using Domain.Entities;

namespace Domain.Persistance
{
    public interface ICourseRepository
    {
        Task<IEnumerable<Course>> GetAllCoursesAsync();
        Task<Course?> GetByIdAsync(Guid courseId);
        Task<IEnumerable<Course>> GetCoursesByProffesorIdAsync(Guid userId);
        Task<IEnumerable<Course>> GetCoursesByStudentIdAsync(Guid userId);
        Task UpdateAsync(Course course);
    }
}
