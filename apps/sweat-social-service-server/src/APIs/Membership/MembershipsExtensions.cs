using SweatSocialService.APIs.Dtos;
using SweatSocialService.Infrastructure.Models;

namespace SweatSocialService.APIs.Extensions;

public static class MembershipsExtensions
{
    public static Membership ToDto(this MembershipDbModel model)
    {
        return new Membership
        {
            CreatedAt = model.CreatedAt,
            Id = model.Id,
            UpdatedAt = model.UpdatedAt,
        };
    }

    public static MembershipDbModel ToModel(
        this MembershipUpdateInput updateDto,
        MembershipWhereUniqueInput uniqueId
    )
    {
        var membership = new MembershipDbModel { Id = uniqueId.Id };

        if (updateDto.CreatedAt != null)
        {
            membership.CreatedAt = updateDto.CreatedAt.Value;
        }
        if (updateDto.UpdatedAt != null)
        {
            membership.UpdatedAt = updateDto.UpdatedAt.Value;
        }

        return membership;
    }
}
