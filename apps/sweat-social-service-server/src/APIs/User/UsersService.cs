using SweatSocialService.Infrastructure;

namespace SweatSocialService.APIs;

public class UsersService : UsersServiceBase
{
    public UsersService(SweatSocialServiceDbContext context)
        : base(context) { }
}
