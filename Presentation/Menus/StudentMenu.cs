using Infrastructure.Persistence;
using Presentation.Session;
using Presentation.Views;

namespace Presentation.Menus
{
    public class StudentMenu
    {
        private readonly ViewCoursesView _viewCourses;
        private readonly SendMessageView _sendMessage;

        public StudentMenu(
            ViewCoursesView viewCourses,
            SendMessageView sendMessage)
        {
            _viewCourses = viewCourses;
            _sendMessage = sendMessage;
        }



        public void Show()
        {
            Console.Clear();
            Console.WriteLine("=== STUDENT MENU ===");
            Console.WriteLine("1. View my courses");
            Console.WriteLine("2. Send message");
            Console.WriteLine("0. Logout");

            switch (Console.ReadLine())
            {
                case "1":
                    _viewCourses.Show();
                    break;

                case "2":
                    _sendMessage.Show();
                    break;

                case "0":
                    CurrentUser.Logout();
                    break;
            }
        }
    }
}
