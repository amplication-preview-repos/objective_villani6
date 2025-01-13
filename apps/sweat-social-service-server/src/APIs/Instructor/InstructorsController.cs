using Microsoft.AspNetCore.Mvc;

namespace SweatSocialService.APIs;

[ApiController()]
public class InstructorsController : InstructorsControllerBase
{
    public InstructorsController(IInstructorsService service)
        : base(service) { }
}
