using Microsoft.AspNetCore.Mvc;

namespace SweatSocialService.APIs;

[ApiController()]
public class PackageModelsController : PackageModelsControllerBase
{
    public PackageModelsController(IPackageModelsService service)
        : base(service) { }
}
