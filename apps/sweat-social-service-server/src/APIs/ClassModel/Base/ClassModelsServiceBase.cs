using Microsoft.EntityFrameworkCore;
using SweatSocialService.APIs;
using SweatSocialService.APIs.Common;
using SweatSocialService.APIs.Dtos;
using SweatSocialService.APIs.Errors;
using SweatSocialService.APIs.Extensions;
using SweatSocialService.Infrastructure;
using SweatSocialService.Infrastructure.Models;

namespace SweatSocialService.APIs;

public abstract class ClassModelsServiceBase : IClassModelsService
{
    protected readonly SweatSocialServiceDbContext _context;

    public ClassModelsServiceBase(SweatSocialServiceDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Create one Class
    /// </summary>
    public async Task<ClassModel> CreateClassModel(ClassModelCreateInput createDto)
    {
        var classModel = new ClassModelDbModel
        {
            CreatedAt = createDto.CreatedAt,
            UpdatedAt = createDto.UpdatedAt
        };

        if (createDto.Id != null)
        {
            classModel.Id = createDto.Id;
        }

        _context.ClassModels.Add(classModel);
        await _context.SaveChangesAsync();

        var result = await _context.FindAsync<ClassModelDbModel>(classModel.Id);

        if (result == null)
        {
            throw new NotFoundException();
        }

        return result.ToDto();
    }

    /// <summary>
    /// Delete one Class
    /// </summary>
    public async Task DeleteClassModel(ClassModelWhereUniqueInput uniqueId)
    {
        var classModel = await _context.ClassModels.FindAsync(uniqueId.Id);
        if (classModel == null)
        {
            throw new NotFoundException();
        }

        _context.ClassModels.Remove(classModel);
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Find many Classes
    /// </summary>
    public async Task<List<ClassModel>> ClassModels(ClassModelFindManyArgs findManyArgs)
    {
        var classModels = await _context
            .ClassModels.ApplyWhere(findManyArgs.Where)
            .ApplySkip(findManyArgs.Skip)
            .ApplyTake(findManyArgs.Take)
            .ApplyOrderBy(findManyArgs.SortBy)
            .ToListAsync();
        return classModels.ConvertAll(classModel => classModel.ToDto());
    }

    /// <summary>
    /// Meta data about Class records
    /// </summary>
    public async Task<MetadataDto> ClassModelsMeta(ClassModelFindManyArgs findManyArgs)
    {
        var count = await _context.ClassModels.ApplyWhere(findManyArgs.Where).CountAsync();

        return new MetadataDto { Count = count };
    }

    /// <summary>
    /// Get one Class
    /// </summary>
    public async Task<ClassModel> ClassModel(ClassModelWhereUniqueInput uniqueId)
    {
        var classModels = await this.ClassModels(
            new ClassModelFindManyArgs { Where = new ClassModelWhereInput { Id = uniqueId.Id } }
        );
        var classModel = classModels.FirstOrDefault();
        if (classModel == null)
        {
            throw new NotFoundException();
        }

        return classModel;
    }

    /// <summary>
    /// Update one Class
    /// </summary>
    public async Task UpdateClassModel(
        ClassModelWhereUniqueInput uniqueId,
        ClassModelUpdateInput updateDto
    )
    {
        var classModel = updateDto.ToModel(uniqueId);

        _context.Entry(classModel).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.ClassModels.Any(e => e.Id == classModel.Id))
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
