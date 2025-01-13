using Microsoft.EntityFrameworkCore;
using SweatSocialService.APIs;
using SweatSocialService.APIs.Common;
using SweatSocialService.APIs.Dtos;
using SweatSocialService.APIs.Errors;
using SweatSocialService.APIs.Extensions;
using SweatSocialService.Infrastructure;
using SweatSocialService.Infrastructure.Models;

namespace SweatSocialService.APIs;

public abstract class InstructorsServiceBase : IInstructorsService
{
    protected readonly SweatSocialServiceDbContext _context;

    public InstructorsServiceBase(SweatSocialServiceDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Create one Instructor
    /// </summary>
    public async Task<Instructor> CreateInstructor(InstructorCreateInput createDto)
    {
        var instructor = new InstructorDbModel
        {
            CreatedAt = createDto.CreatedAt,
            UpdatedAt = createDto.UpdatedAt
        };

        if (createDto.Id != null)
        {
            instructor.Id = createDto.Id;
        }

        _context.Instructors.Add(instructor);
        await _context.SaveChangesAsync();

        var result = await _context.FindAsync<InstructorDbModel>(instructor.Id);

        if (result == null)
        {
            throw new NotFoundException();
        }

        return result.ToDto();
    }

    /// <summary>
    /// Delete one Instructor
    /// </summary>
    public async Task DeleteInstructor(InstructorWhereUniqueInput uniqueId)
    {
        var instructor = await _context.Instructors.FindAsync(uniqueId.Id);
        if (instructor == null)
        {
            throw new NotFoundException();
        }

        _context.Instructors.Remove(instructor);
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Find many Instructors
    /// </summary>
    public async Task<List<Instructor>> Instructors(InstructorFindManyArgs findManyArgs)
    {
        var instructors = await _context
            .Instructors.ApplyWhere(findManyArgs.Where)
            .ApplySkip(findManyArgs.Skip)
            .ApplyTake(findManyArgs.Take)
            .ApplyOrderBy(findManyArgs.SortBy)
            .ToListAsync();
        return instructors.ConvertAll(instructor => instructor.ToDto());
    }

    /// <summary>
    /// Meta data about Instructor records
    /// </summary>
    public async Task<MetadataDto> InstructorsMeta(InstructorFindManyArgs findManyArgs)
    {
        var count = await _context.Instructors.ApplyWhere(findManyArgs.Where).CountAsync();

        return new MetadataDto { Count = count };
    }

    /// <summary>
    /// Get one Instructor
    /// </summary>
    public async Task<Instructor> Instructor(InstructorWhereUniqueInput uniqueId)
    {
        var instructors = await this.Instructors(
            new InstructorFindManyArgs { Where = new InstructorWhereInput { Id = uniqueId.Id } }
        );
        var instructor = instructors.FirstOrDefault();
        if (instructor == null)
        {
            throw new NotFoundException();
        }

        return instructor;
    }

    /// <summary>
    /// Update one Instructor
    /// </summary>
    public async Task UpdateInstructor(
        InstructorWhereUniqueInput uniqueId,
        InstructorUpdateInput updateDto
    )
    {
        var instructor = updateDto.ToModel(uniqueId);

        _context.Entry(instructor).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.Instructors.Any(e => e.Id == instructor.Id))
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
