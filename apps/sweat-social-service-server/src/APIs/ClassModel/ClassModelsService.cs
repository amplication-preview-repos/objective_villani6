using SweatSocialService.Infrastructure;

namespace SweatSocialService.APIs;

public class ClassModelsService : ClassModelsServiceBase
{
    public ClassModelsService(SweatSocialServiceDbContext context)
        : base(context) { }
}
