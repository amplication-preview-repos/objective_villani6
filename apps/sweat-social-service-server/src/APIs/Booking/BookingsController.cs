using Microsoft.AspNetCore.Mvc;

namespace SweatSocialService.APIs;

[ApiController()]
public class BookingsController : BookingsControllerBase
{
    public BookingsController(IBookingsService service)
        : base(service) { }
}
