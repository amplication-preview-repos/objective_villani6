using Microsoft.AspNetCore.Mvc;
using SweatSocialService.APIs;
using SweatSocialService.APIs.Common;
using SweatSocialService.APIs.Dtos;
using SweatSocialService.APIs.Errors;

namespace SweatSocialService.APIs;

[Route("api/[controller]")]
[ApiController()]
public abstract class InstructorsControllerBase : ControllerBase
{
    protected readonly IInstructorsService _service;

    public InstructorsControllerBase(IInstructorsService service)
    {
        _service = service;
    }

    /// <summary>
    /// Create one Instructor
    /// </summary>
    [HttpPost()]
    public async Task<ActionResult<Instructor>> CreateInstructor(InstructorCreateInput input)
    {
        var instructor = await _service.CreateInstructor(input);

        return CreatedAtAction(nameof(Instructor), new { id = instructor.Id }, instructor);
    }

    /// <summary>
    /// Delete one Instructor
    /// </summary>
    [HttpDelete("{Id}")]
    public async Task<ActionResult> DeleteInstructor(
        [FromRoute()] InstructorWhereUniqueInput uniqueId
    )
    {
        try
        {
            await _service.DeleteInstructor(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Find many Instructors
    /// </summary>
    [HttpGet()]
    public async Task<ActionResult<List<Instructor>>> Instructors(
        [FromQuery()] InstructorFindManyArgs filter
    )
    {
        return Ok(await _service.Instructors(filter));
    }

    /// <summary>
    /// Meta data about Instructor records
    /// </summary>
    [HttpPost("meta")]
    public async Task<ActionResult<MetadataDto>> InstructorsMeta(
        [FromQuery()] InstructorFindManyArgs filter
    )
    {
        return Ok(await _service.InstructorsMeta(filter));
    }

    /// <summary>
    /// Get one Instructor
    /// </summary>
    [HttpGet("{Id}")]
    public async Task<ActionResult<Instructor>> Instructor(
        [FromRoute()] InstructorWhereUniqueInput uniqueId
    )
    {
        try
        {
            return await _service.Instructor(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Update one Instructor
    /// </summary>
    [HttpPatch("{Id}")]
    public async Task<ActionResult> UpdateInstructor(
        [FromRoute()] InstructorWhereUniqueInput uniqueId,
        [FromQuery()] InstructorUpdateInput instructorUpdateDto
    )
    {
        try
        {
            await _service.UpdateInstructor(uniqueId, instructorUpdateDto);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }
}
