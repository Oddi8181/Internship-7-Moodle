using Application.Courses.AddMaterial;
using static Application.Courses.AddMaterial.AddMaterialHandler;

namespace Presentation.Views
{
    public class AddMaterialView
    {
        public static void Show(AddStudyMaterialHandler handler)
        {
            Console.Clear();

            Console.Write("Course ID: ");
            var courseId = Guid.Parse(Console.ReadLine()!);

            Console.Write("Material name: ");
            var name = Console.ReadLine();

            Console.Write("URL: ");
            var url = Console.ReadLine();

            var result = handler.Handle(new AddMaterialCommand
            {
                CourseId = courseId,
                Name = name!,
                Url = url!
            }).Result;

            Console.WriteLine(result.IsSuccess
                ? "Material added."
                : "Error.");

            Console.ReadKey();
        }
    }
}
