using Domain.Entities;
using Domain.Persistance;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

public class CourseRepository : ICourseRepository
{
    private readonly AppDbContext _context;

    public CourseRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Course>> GetAllCoursesAsync()
        => await _context.Courses
            .Include(x => x.StudyMaterials)
            .Include(x => x.Enrollments)
            .AsNoTracking()
            .ToListAsync();
    


    public Task<Course?> GetByIdAsync(Guid id)
        => _context.Courses
            .Include(x => x.Enrollments)
            .Include(x => x.Notifications)
            .Include(x => x.StudyMaterials)
            .FirstOrDefaultAsync(x => x.Id == id);

    public async Task<IEnumerable<Course>> GetCoursesByProfessorIdAsync(Guid professorId)
        => await _context.Courses
            .Where(x => x.ProfessorId == professorId)
            .ToListAsync();

    public async Task<IEnumerable<Course>> GetCoursesByStudentIdAsync(Guid studentId)
        => await _context.Enrollments
            .Where(x => x.UserId == studentId)
            .Select(x => x.Course)
            .ToListAsync();



    public async Task UpdateAsync(Course course)
    {
        _context.Courses.Update(course);
        await _context.SaveChangesAsync();
    }
}
