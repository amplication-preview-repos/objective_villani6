using SweatSocialService.APIs.Dtos;
using SweatSocialService.Infrastructure.Models;

namespace SweatSocialService.APIs.Extensions;

public static class ClassModelsExtensions
{
    public static ClassModel ToDto(this ClassModelDbModel model)
    {
        return new ClassModel
        {
            CreatedAt = model.CreatedAt,
            Id = model.Id,
            UpdatedAt = model.UpdatedAt,
        };
    }

    public static ClassModelDbModel ToModel(
        this ClassModelUpdateInput updateDto,
        ClassModelWhereUniqueInput uniqueId
    )
    {
        var classModel = new ClassModelDbModel { Id = uniqueId.Id };

        if (updateDto.CreatedAt != null)
        {
            classModel.CreatedAt = updateDto.CreatedAt.Value;
        }
        if (updateDto.UpdatedAt != null)
        {
            classModel.UpdatedAt = updateDto.UpdatedAt.Value;
        }

        return classModel;
    }
}
