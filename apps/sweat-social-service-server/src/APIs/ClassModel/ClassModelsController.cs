using Microsoft.AspNetCore.Mvc;

namespace SweatSocialService.APIs;

[ApiController()]
public class ClassModelsController : ClassModelsControllerBase
{
    public ClassModelsController(IClassModelsService service)
        : base(service) { }
}
