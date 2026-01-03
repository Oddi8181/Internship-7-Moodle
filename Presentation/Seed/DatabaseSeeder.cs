using Application.Common.Validation;
using Domain.Entities;
using Domain.Enums;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Presentation.Seed
{
    public class DatabaseSeeder
    {
        private readonly AppDbContext _context;

        public DatabaseSeeder(AppDbContext context)
        {
            _context = context;
        }

        public async Task SeedAsync()
        {
            if (await _context.Users.AnyAsync())
                return;

            var admin = new User(
                firstName: "Admin",
                lastName: "Admin",
                email: "admin@moodle.com",
                passwordHash: PasswordHasher.Hash("Admin123"),
                role: Role.Admin
            );

            var professor = new User(
                firstName: "Ivan",
                lastName: "Ivan",
                email: "prof@moodle.com",
                passwordHash: PasswordHasher.Hash("Prof123"),
                role: Role.Professor
            );

            var student = new User(
                firstName: "Marko",
                lastName: "Marko",
                email: "student@moodle.com",
                passwordHash: PasswordHasher.Hash("Student123"),
                role: Role.Student
            );


            var course = new Course(
                "Programiranje 1",
                professor
            );

            var material = new StudyMaterial(
                "Uvod u C#",
                "https://example.com/csharp",
                course
            );

            _context.Users.AddRange(admin, professor, student);
            _context.Courses.Add(course);
            _context.Materials.Add(material);

            await _context.SaveChangesAsync();
        }
    }
}
