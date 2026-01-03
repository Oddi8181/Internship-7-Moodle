using Domain.Enums;
using Presentation.Session;

namespace Presentation.Menus
{
    public class MainMenu
    {
        private readonly AuthMenu _authMenu;
        private readonly StudentMenu _studentMenu;
        private readonly ProfessorMenu _professorMenu;
        private readonly AdminMenu _adminMenu;

        public MainMenu(
            AuthMenu authMenu,
            StudentMenu studentMenu,
            ProfessorMenu professorMenu,
            AdminMenu adminMenu)
        {
            _authMenu = authMenu;
            _studentMenu = studentMenu;
            _professorMenu = professorMenu;
            _adminMenu = adminMenu;
        }

        public void Show()
        {
            while (true)
            {
                Console.Clear();

                if (CurrentUser.User == null)
                {
                    _authMenu.Show();
                }
                else
                {
                    switch (CurrentUser.User.Role)
                    {
                        case Role.Student:
                            _studentMenu.Show();
                            break;
                        case Role.Professor:
                            _professorMenu.Show();
                            break;
                        case Role.Admin:
                            _adminMenu.Show();
                            break;
                    }
                }
            }
        }
    }
}
