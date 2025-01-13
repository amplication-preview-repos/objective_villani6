using Microsoft.EntityFrameworkCore;
using SweatSocialService.APIs;
using SweatSocialService.APIs.Common;
using SweatSocialService.APIs.Dtos;
using SweatSocialService.APIs.Errors;
using SweatSocialService.APIs.Extensions;
using SweatSocialService.Infrastructure;
using SweatSocialService.Infrastructure.Models;

namespace SweatSocialService.APIs;

public abstract class MembershipsServiceBase : IMembershipsService
{
    protected readonly SweatSocialServiceDbContext _context;

    public MembershipsServiceBase(SweatSocialServiceDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Create one Membership
    /// </summary>
    public async Task<Membership> CreateMembership(MembershipCreateInput createDto)
    {
        var membership = new MembershipDbModel
        {
            CreatedAt = createDto.CreatedAt,
            UpdatedAt = createDto.UpdatedAt
        };

        if (createDto.Id != null)
        {
            membership.Id = createDto.Id;
        }

        _context.Memberships.Add(membership);
        await _context.SaveChangesAsync();

        var result = await _context.FindAsync<MembershipDbModel>(membership.Id);

        if (result == null)
        {
            throw new NotFoundException();
        }

        return result.ToDto();
    }

    /// <summary>
    /// Delete one Membership
    /// </summary>
    public async Task DeleteMembership(MembershipWhereUniqueInput uniqueId)
    {
        var membership = await _context.Memberships.FindAsync(uniqueId.Id);
        if (membership == null)
        {
            throw new NotFoundException();
        }

        _context.Memberships.Remove(membership);
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Find many Memberships
    /// </summary>
    public async Task<List<Membership>> Memberships(MembershipFindManyArgs findManyArgs)
    {
        var memberships = await _context
            .Memberships.ApplyWhere(findManyArgs.Where)
            .ApplySkip(findManyArgs.Skip)
            .ApplyTake(findManyArgs.Take)
            .ApplyOrderBy(findManyArgs.SortBy)
            .ToListAsync();
        return memberships.ConvertAll(membership => membership.ToDto());
    }

    /// <summary>
    /// Meta data about Membership records
    /// </summary>
    public async Task<MetadataDto> MembershipsMeta(MembershipFindManyArgs findManyArgs)
    {
        var count = await _context.Memberships.ApplyWhere(findManyArgs.Where).CountAsync();

        return new MetadataDto { Count = count };
    }

    /// <summary>
    /// Get one Membership
    /// </summary>
    public async Task<Membership> Membership(MembershipWhereUniqueInput uniqueId)
    {
        var memberships = await this.Memberships(
            new MembershipFindManyArgs { Where = new MembershipWhereInput { Id = uniqueId.Id } }
        );
        var membership = memberships.FirstOrDefault();
        if (membership == null)
        {
            throw new NotFoundException();
        }

        return membership;
    }

    /// <summary>
    /// Update one Membership
    /// </summary>
    public async Task UpdateMembership(
        MembershipWhereUniqueInput uniqueId,
        MembershipUpdateInput updateDto
    )
    {
        var membership = updateDto.ToModel(uniqueId);

        _context.Entry(membership).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.Memberships.Any(e => e.Id == membership.Id))
            {
                throw new NotFoundException();
            }
            else
            {
                throw;
            }
        }
    }
}
