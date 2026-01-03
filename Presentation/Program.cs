using Infrastructure;
using Presentation.Menus;
using Presentation.Seed;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Presentation;
using Application;

var host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((context, services) =>
    {
        services.AddInfrastructure(context.Configuration);
        services.AddApplication();
        services.AddPresentation();
    })
    .Build();


using (var scope = host.Services.CreateScope())
{
    var seeder = scope.ServiceProvider.GetRequiredService<DatabaseSeeder>();
    await seeder.SeedAsync();
}


var mainMenu = host.Services.GetRequiredService<MainMenu>();
mainMenu.Show();
