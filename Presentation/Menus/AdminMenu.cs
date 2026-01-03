using Application.Common.Validation;
using Domain.Entities;
using Domain.Enums;
using Infrastructure.Persistence;
using Presentation.Session;

namespace Presentation.Menus
{
    public class AdminMenu
    {
        private readonly AppDbContext _context;

        public AdminMenu(AppDbContext context)
        {
            _context = context;
        }

        public void Show()
        {
            Console.Clear();
            Console.WriteLine("=== ADMIN MENU ===");
            Console.WriteLine("1. View all users");
            Console.WriteLine("2. Create professor");
            Console.WriteLine("0. Logout");

            switch (Console.ReadLine())
            {
                case "1":
                    foreach (var u in _context.Users)
                        Console.WriteLine($"{u.Email} - {u.Role}");
                    Console.ReadKey();
                    break;

                case "2":
                    Console.Write("First name: ");
                    var first = Console.ReadLine();

                    Console.Write("Last name: ");
                    var last = Console.ReadLine();

                    Console.Write("Email: ");
                    var email = Console.ReadLine();

                    Console.Write("Password: ");
                    var password = Console.ReadLine();

                    var professor = new User(
                        first!,
                        last!,
                        email!,
                        PasswordHasher.Hash(password!),
                        Role.Professor
                    );

                    _context.Users.Add(professor);
                    _context.SaveChanges();

                    Console.WriteLine("Professor created.");
                    Console.ReadKey();
                    break;

                case "0":
                    CurrentUser.Logout();
                    break;
            }
        }
    }
}
