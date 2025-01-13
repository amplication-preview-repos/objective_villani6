using SweatSocialService.APIs.Common;
using SweatSocialService.APIs.Dtos;

namespace SweatSocialService.APIs;

public interface IInstructorsService
{
    /// <summary>
    /// Create one Instructor
    /// </summary>
    public Task<Instructor> CreateInstructor(InstructorCreateInput instructor);

    /// <summary>
    /// Delete one Instructor
    /// </summary>
    public Task DeleteInstructor(InstructorWhereUniqueInput uniqueId);

    /// <summary>
    /// Find many Instructors
    /// </summary>
    public Task<List<Instructor>> Instructors(InstructorFindManyArgs findManyArgs);

    /// <summary>
    /// Meta data about Instructor records
    /// </summary>
    public Task<MetadataDto> InstructorsMeta(InstructorFindManyArgs findManyArgs);

    /// <summary>
    /// Get one Instructor
    /// </summary>
    public Task<Instructor> Instructor(InstructorWhereUniqueInput uniqueId);

    /// <summary>
    /// Update one Instructor
    /// </summary>
    public Task UpdateInstructor(
        InstructorWhereUniqueInput uniqueId,
        InstructorUpdateInput updateDto
    );
}
