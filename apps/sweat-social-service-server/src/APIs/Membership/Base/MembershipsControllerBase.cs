using Microsoft.AspNetCore.Mvc;
using SweatSocialService.APIs;
using SweatSocialService.APIs.Common;
using SweatSocialService.APIs.Dtos;
using SweatSocialService.APIs.Errors;

namespace SweatSocialService.APIs;

[Route("api/[controller]")]
[ApiController()]
public abstract class MembershipsControllerBase : ControllerBase
{
    protected readonly IMembershipsService _service;

    public MembershipsControllerBase(IMembershipsService service)
    {
        _service = service;
    }

    /// <summary>
    /// Create one Membership
    /// </summary>
    [HttpPost()]
    public async Task<ActionResult<Membership>> CreateMembership(MembershipCreateInput input)
    {
        var membership = await _service.CreateMembership(input);

        return CreatedAtAction(nameof(Membership), new { id = membership.Id }, membership);
    }

    /// <summary>
    /// Delete one Membership
    /// </summary>
    [HttpDelete("{Id}")]
    public async Task<ActionResult> DeleteMembership(
        [FromRoute()] MembershipWhereUniqueInput uniqueId
    )
    {
        try
        {
            await _service.DeleteMembership(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Find many Memberships
    /// </summary>
    [HttpGet()]
    public async Task<ActionResult<List<Membership>>> Memberships(
        [FromQuery()] MembershipFindManyArgs filter
    )
    {
        return Ok(await _service.Memberships(filter));
    }

    /// <summary>
    /// Meta data about Membership records
    /// </summary>
    [HttpPost("meta")]
    public async Task<ActionResult<MetadataDto>> MembershipsMeta(
        [FromQuery()] MembershipFindManyArgs filter
    )
    {
        return Ok(await _service.MembershipsMeta(filter));
    }

    /// <summary>
    /// Get one Membership
    /// </summary>
    [HttpGet("{Id}")]
    public async Task<ActionResult<Membership>> Membership(
        [FromRoute()] MembershipWhereUniqueInput uniqueId
    )
    {
        try
        {
            return await _service.Membership(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Update one Membership
    /// </summary>
    [HttpPatch("{Id}")]
    public async Task<ActionResult> UpdateMembership(
        [FromRoute()] MembershipWhereUniqueInput uniqueId,
        [FromQuery()] MembershipUpdateInput membershipUpdateDto
    )
    {
        try
        {
            await _service.UpdateMembership(uniqueId, membershipUpdateDto);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }
}
