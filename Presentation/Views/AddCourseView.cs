using Application.Courses.Add;
using Presentation.Session;

namespace Presentation.Views
{
    public static class AddCourseView
    {
        public static void Show(AddCourseHandler handler)
        {
            Console.Clear();
            Console.WriteLine("=== ADD COURSE ===");

            Console.Write("Course name: ");
            var name = Console.ReadLine();

            var command = new AddCourseCommand
            {
                Name = name!,
                ProfessorId = CurrentUser.User!.Id
            };

            var result = handler.Handle(command).Result;

            Console.WriteLine(result.IsSuccess
                ? "Course created."
                : "Failed to create course.");

            Console.ReadKey();
        }
    }
}
