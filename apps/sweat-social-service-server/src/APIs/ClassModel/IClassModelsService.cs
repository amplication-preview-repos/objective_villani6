using SweatSocialService.APIs.Common;
using SweatSocialService.APIs.Dtos;

namespace SweatSocialService.APIs;

public interface IClassModelsService
{
    /// <summary>
    /// Create one Class
    /// </summary>
    public Task<ClassModel> CreateClassModel(ClassModelCreateInput classmodel);

    /// <summary>
    /// Delete one Class
    /// </summary>
    public Task DeleteClassModel(ClassModelWhereUniqueInput uniqueId);

    /// <summary>
    /// Find many Classes
    /// </summary>
    public Task<List<ClassModel>> ClassModels(ClassModelFindManyArgs findManyArgs);

    /// <summary>
    /// Meta data about Class records
    /// </summary>
    public Task<MetadataDto> ClassModelsMeta(ClassModelFindManyArgs findManyArgs);

    /// <summary>
    /// Get one Class
    /// </summary>
    public Task<ClassModel> ClassModel(ClassModelWhereUniqueInput uniqueId);

    /// <summary>
    /// Update one Class
    /// </summary>
    public Task UpdateClassModel(
        ClassModelWhereUniqueInput uniqueId,
        ClassModelUpdateInput updateDto
    );
}
