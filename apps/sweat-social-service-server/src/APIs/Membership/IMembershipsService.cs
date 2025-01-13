using SweatSocialService.APIs.Common;
using SweatSocialService.APIs.Dtos;

namespace SweatSocialService.APIs;

public interface IMembershipsService
{
    /// <summary>
    /// Create one Membership
    /// </summary>
    public Task<Membership> CreateMembership(MembershipCreateInput membership);

    /// <summary>
    /// Delete one Membership
    /// </summary>
    public Task DeleteMembership(MembershipWhereUniqueInput uniqueId);

    /// <summary>
    /// Find many Memberships
    /// </summary>
    public Task<List<Membership>> Memberships(MembershipFindManyArgs findManyArgs);

    /// <summary>
    /// Meta data about Membership records
    /// </summary>
    public Task<MetadataDto> MembershipsMeta(MembershipFindManyArgs findManyArgs);

    /// <summary>
    /// Get one Membership
    /// </summary>
    public Task<Membership> Membership(MembershipWhereUniqueInput uniqueId);

    /// <summary>
    /// Update one Membership
    /// </summary>
    public Task UpdateMembership(
        MembershipWhereUniqueInput uniqueId,
        MembershipUpdateInput updateDto
    );
}
