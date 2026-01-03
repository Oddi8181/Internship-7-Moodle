using Application.Courses.PublishAnnouncement;
using Presentation.Session;

namespace Presentation.Views
{
    public class AddAnnouncementView
    {
        public static void Show(PublishAnnouncementHandler handler)
        {
            Console.Clear();
            Console.Write("Announcement title: ");
            var title = Console.ReadLine();

            Console.WriteLine("Announcement content");
            var content = Console.ReadLine();

            var result = handler.HandleAsync(new PublishAnnouncementCommand
            {
                Title = title!,
                Content =content!,
                ProfessorId = CurrentUser.User!.Id
            }).Result;

            Console.WriteLine(result.IsSuccess
                ? "Announcement added."
                : "Error.");

            Console.ReadKey();
        }
    }
}
