using SweatSocialService.APIs;

namespace SweatSocialService;

public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Add services to the container.
    /// </summary>
    public static void RegisterServices(this IServiceCollection services)
    {
        services.AddScoped<IBookingsService, BookingsService>();
        services.AddScoped<IClassModelsService, ClassModelsService>();
        services.AddScoped<IInstructorsService, InstructorsService>();
        services.AddScoped<IMembershipsService, MembershipsService>();
        services.AddScoped<IPackageModelsService, PackageModelsService>();
        services.AddScoped<IUsersService, UsersService>();
    }
}
