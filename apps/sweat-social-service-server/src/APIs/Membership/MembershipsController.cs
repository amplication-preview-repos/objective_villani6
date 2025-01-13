using Microsoft.AspNetCore.Mvc;

namespace SweatSocialService.APIs;

[ApiController()]
public class MembershipsController : MembershipsControllerBase
{
    public MembershipsController(IMembershipsService service)
        : base(service) { }
}
