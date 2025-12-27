using Domain.Entities;

namespace Domain.Persistance
{
    public interface ICourseRepository
    {
        Task<Course?> GetByIdAsync(Guid courseId);

        Task<IEnumerable<Course>> GetByProfessorIdAsync(Guid professorId);
        Task<IEnumerable<Course>> GetByStudentIdAsync(Guid studentId);

        Task UpdateAsync(Course course);
    }
}
