using SweatSocialService.Infrastructure;

namespace SweatSocialService.APIs;

public class BookingsService : BookingsServiceBase
{
    public BookingsService(SweatSocialServiceDbContext context)
        : base(context) { }
}
