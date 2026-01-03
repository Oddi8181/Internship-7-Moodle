using Domain.Entities;

namespace Presentation.Session
{
    public static class CurrentUser
    {
        public static User? User { get; set; }

        public static void Logout()
        {
            User = null;
        }
    }
}
