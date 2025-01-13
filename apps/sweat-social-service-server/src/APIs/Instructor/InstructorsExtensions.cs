using SweatSocialService.APIs.Dtos;
using SweatSocialService.Infrastructure.Models;

namespace SweatSocialService.APIs.Extensions;

public static class InstructorsExtensions
{
    public static Instructor ToDto(this InstructorDbModel model)
    {
        return new Instructor
        {
            CreatedAt = model.CreatedAt,
            Id = model.Id,
            UpdatedAt = model.UpdatedAt,
        };
    }

    public static InstructorDbModel ToModel(
        this InstructorUpdateInput updateDto,
        InstructorWhereUniqueInput uniqueId
    )
    {
        var instructor = new InstructorDbModel { Id = uniqueId.Id };

        if (updateDto.CreatedAt != null)
        {
            instructor.CreatedAt = updateDto.CreatedAt.Value;
        }
        if (updateDto.UpdatedAt != null)
        {
            instructor.UpdatedAt = updateDto.UpdatedAt.Value;
        }

        return instructor;
    }
}
