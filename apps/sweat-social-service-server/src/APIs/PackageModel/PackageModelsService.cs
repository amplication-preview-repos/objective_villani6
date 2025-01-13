using SweatSocialService.Infrastructure;

namespace SweatSocialService.APIs;

public class PackageModelsService : PackageModelsServiceBase
{
    public PackageModelsService(SweatSocialServiceDbContext context)
        : base(context) { }
}
