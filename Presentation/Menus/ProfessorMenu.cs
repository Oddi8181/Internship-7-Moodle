using Application.Courses.Add;
using Application.Courses.PublishAnnouncement;
using Infrastructure.Persistence;
using Presentation.Session;
using Presentation.Views;
using static Application.Courses.AddMaterial.AddMaterialHandler;

namespace Presentation.Menus
{
    public class ProfessorMenu
    {
        private readonly AddCourseHandler _addCourse;
        private readonly PublishAnnouncementHandler _publishAnnouncement;
        private readonly AddStudyMaterialHandler _addMaterial;
        private readonly AppDbContext _context;

        public ProfessorMenu(
            AddCourseHandler addCourse,
            AddStudyMaterialHandler addMaterial,
            AppDbContext context,
            PublishAnnouncementHandler publishAnnouncement)
        {
            _addCourse = addCourse;
            _addMaterial = addMaterial;
            _context = context;
            _publishAnnouncement = publishAnnouncement; 
        }

        public void Show()
        {
            Console.Clear();
            Console.WriteLine("=== PROFESSOR MENU ===");
            Console.WriteLine("1. Add course");
            Console.WriteLine("2. Add study material");
            Console.WriteLine("3. View my courses");
            Console.WriteLine("0. Logout");

            switch (Console.ReadLine())
            {
                case "1":
                    AddCourseView.Show(_addCourse);
                    break;

                case "2":
                    AddMaterialView.Show(_addMaterial);
                    break;
                case "3":
                    AddAnnouncementView.Show(_publishAnnouncement); 
                    break;

                case "4":
                    var courses = _context.Courses
                        .Where(c => c.ProfessorId == CurrentUser.User!.Id)
                        .ToList();

                    foreach (var c in courses)
                        Console.WriteLine($"{c.Id} - {c.Name}");

                    Console.ReadKey();
                    break;

                case "0":
                    CurrentUser.Logout();
                    break;
            }
        }
    }
}
