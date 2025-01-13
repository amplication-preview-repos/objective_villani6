using Microsoft.AspNetCore.Mvc;
using SweatSocialService.APIs;
using SweatSocialService.APIs.Common;
using SweatSocialService.APIs.Dtos;
using SweatSocialService.APIs.Errors;

namespace SweatSocialService.APIs;

[Route("api/[controller]")]
[ApiController()]
public abstract class ClassModelsControllerBase : ControllerBase
{
    protected readonly IClassModelsService _service;

    public ClassModelsControllerBase(IClassModelsService service)
    {
        _service = service;
    }

    /// <summary>
    /// Create one Class
    /// </summary>
    [HttpPost()]
    public async Task<ActionResult<ClassModel>> CreateClassModel(ClassModelCreateInput input)
    {
        var classModel = await _service.CreateClassModel(input);

        return CreatedAtAction(nameof(ClassModel), new { id = classModel.Id }, classModel);
    }

    /// <summary>
    /// Delete one Class
    /// </summary>
    [HttpDelete("{Id}")]
    public async Task<ActionResult> DeleteClassModel(
        [FromRoute()] ClassModelWhereUniqueInput uniqueId
    )
    {
        try
        {
            await _service.DeleteClassModel(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Find many Classes
    /// </summary>
    [HttpGet()]
    public async Task<ActionResult<List<ClassModel>>> ClassModels(
        [FromQuery()] ClassModelFindManyArgs filter
    )
    {
        return Ok(await _service.ClassModels(filter));
    }

    /// <summary>
    /// Meta data about Class records
    /// </summary>
    [HttpPost("meta")]
    public async Task<ActionResult<MetadataDto>> ClassModelsMeta(
        [FromQuery()] ClassModelFindManyArgs filter
    )
    {
        return Ok(await _service.ClassModelsMeta(filter));
    }

    /// <summary>
    /// Get one Class
    /// </summary>
    [HttpGet("{Id}")]
    public async Task<ActionResult<ClassModel>> ClassModel(
        [FromRoute()] ClassModelWhereUniqueInput uniqueId
    )
    {
        try
        {
            return await _service.ClassModel(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Update one Class
    /// </summary>
    [HttpPatch("{Id}")]
    public async Task<ActionResult> UpdateClassModel(
        [FromRoute()] ClassModelWhereUniqueInput uniqueId,
        [FromQuery()] ClassModelUpdateInput classModelUpdateDto
    )
    {
        try
        {
            await _service.UpdateClassModel(uniqueId, classModelUpdateDto);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }
}
