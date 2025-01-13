using SweatSocialService.Infrastructure;

namespace SweatSocialService.APIs;

public class MembershipsService : MembershipsServiceBase
{
    public MembershipsService(SweatSocialServiceDbContext context)
        : base(context) { }
}
