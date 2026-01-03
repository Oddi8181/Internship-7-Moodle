using Application.Authentication.Login;
using Application.Authentication.Register;
using Application.Courses.Add;
using Application.Courses.AddStudent;
using Application.Courses.PublishAnnouncement;
using Microsoft.Extensions.DependencyInjection;
using Presentation.Menus;
using Presentation.Seed;
using Presentation.Views;

namespace Presentation
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPresentation(this IServiceCollection services)
        {
            
            services.AddScoped<MainMenu>();
            services.AddScoped<AuthMenu>();
            services.AddScoped<StudentMenu>();
            services.AddScoped<ProfessorMenu>();
            services.AddScoped<AdminMenu>();

            
            services.AddScoped<DatabaseSeeder>();

            
            services.AddScoped<LoginHandler>();
            services.AddScoped<RegisterHandler>();
            services.AddScoped<AddCourseHandler>();
            services.AddScoped<PublishAnnouncementHandler>();
            services.AddScoped<AddStudentHandler>();

           
            services.AddScoped<LoginValidator>();
            services.AddScoped<RegisterValidator>();
            services.AddScoped<PublishAnnouncementValidator>();
            services.AddScoped<AddStudentValidator>();

            services.AddScoped<LoginView>();
            services.AddScoped<RegisterView>();
            services.AddScoped<AddMaterialView>();
            services.AddScoped<SendMessageView>();
            services.AddScoped<ViewCoursesView>();


            return services;
        }
    }
}
