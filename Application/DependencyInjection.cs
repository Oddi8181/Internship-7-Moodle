using Microsoft.Extensions.DependencyInjection;
using Application.Authentication.Login;
using Application.Authentication.Register;
using Application.Courses.AddStudent;
using Application.Courses.AddMaterial;
using Application.Courses.PublishAnnouncement;

namespace Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        
        services.AddScoped<LoginHandler>();
        services.AddScoped<RegisterHandler>();

        
        services.AddScoped<AddStudentHandler>();
        services.AddScoped<AddMaterialHandler.AddStudyMaterialHandler>();
        services.AddScoped<PublishAnnouncementHandler>();
        services.AddScoped<PublishAnnouncementValidator>();

        return services;
    }
}
