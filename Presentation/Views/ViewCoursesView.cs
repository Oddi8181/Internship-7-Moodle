using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Presentation.Session;

namespace Presentation.Views
{
    public class ViewCoursesView
    {
        private readonly AppDbContext _context;

        public ViewCoursesView(AppDbContext context)
        {
            _context = context;
        }

        public void Show()
        {
            Console.Clear();
            Console.WriteLine("=== MY COURSES ===");

            var studentId = CurrentUser.User!.Id;

            var courses = _context.Enrollments
                .Include(e => e.Course)
                .ThenInclude(c => c.StudyMaterials)
                .Where(e => e.UserId == studentId)
                .Select(e => e.Course)
                .ToList();

            foreach (var course in courses)
            {
                Console.WriteLine($"Course: {course.Name}");

                foreach (var material in course.StudyMaterials)
                {
                    Console.WriteLine($"  - {material.Name} ({material.Url})");
                }
            }

            Console.ReadKey();
        }
    }
}
