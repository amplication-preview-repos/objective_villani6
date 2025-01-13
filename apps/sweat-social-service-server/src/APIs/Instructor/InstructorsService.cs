using SweatSocialService.Infrastructure;

namespace SweatSocialService.APIs;

public class InstructorsService : InstructorsServiceBase
{
    public InstructorsService(SweatSocialServiceDbContext context)
        : base(context) { }
}
