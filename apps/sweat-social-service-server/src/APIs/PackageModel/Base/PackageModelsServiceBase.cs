using Microsoft.EntityFrameworkCore;
using SweatSocialService.APIs;
using SweatSocialService.APIs.Common;
using SweatSocialService.APIs.Dtos;
using SweatSocialService.APIs.Errors;
using SweatSocialService.APIs.Extensions;
using SweatSocialService.Infrastructure;
using SweatSocialService.Infrastructure.Models;

namespace SweatSocialService.APIs;

public abstract class PackageModelsServiceBase : IPackageModelsService
{
    protected readonly SweatSocialServiceDbContext _context;

    public PackageModelsServiceBase(SweatSocialServiceDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Create one Package
    /// </summary>
    public async Task<PackageModel> CreatePackageModel(PackageModelCreateInput createDto)
    {
        var packageModel = new PackageModelDbModel
        {
            CreatedAt = createDto.CreatedAt,
            UpdatedAt = createDto.UpdatedAt
        };

        if (createDto.Id != null)
        {
            packageModel.Id = createDto.Id;
        }

        _context.PackageModels.Add(packageModel);
        await _context.SaveChangesAsync();

        var result = await _context.FindAsync<PackageModelDbModel>(packageModel.Id);

        if (result == null)
        {
            throw new NotFoundException();
        }

        return result.ToDto();
    }

    /// <summary>
    /// Delete one Package
    /// </summary>
    public async Task DeletePackageModel(PackageModelWhereUniqueInput uniqueId)
    {
        var packageModel = await _context.PackageModels.FindAsync(uniqueId.Id);
        if (packageModel == null)
        {
            throw new NotFoundException();
        }

        _context.PackageModels.Remove(packageModel);
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Find many Packages
    /// </summary>
    public async Task<List<PackageModel>> PackageModels(PackageModelFindManyArgs findManyArgs)
    {
        var packageModels = await _context
            .PackageModels.ApplyWhere(findManyArgs.Where)
            .ApplySkip(findManyArgs.Skip)
            .ApplyTake(findManyArgs.Take)
            .ApplyOrderBy(findManyArgs.SortBy)
            .ToListAsync();
        return packageModels.ConvertAll(packageModel => packageModel.ToDto());
    }

    /// <summary>
    /// Meta data about Package records
    /// </summary>
    public async Task<MetadataDto> PackageModelsMeta(PackageModelFindManyArgs findManyArgs)
    {
        var count = await _context.PackageModels.ApplyWhere(findManyArgs.Where).CountAsync();

        return new MetadataDto { Count = count };
    }

    /// <summary>
    /// Get one Package
    /// </summary>
    public async Task<PackageModel> PackageModel(PackageModelWhereUniqueInput uniqueId)
    {
        var packageModels = await this.PackageModels(
            new PackageModelFindManyArgs { Where = new PackageModelWhereInput { Id = uniqueId.Id } }
        );
        var packageModel = packageModels.FirstOrDefault();
        if (packageModel == null)
        {
            throw new NotFoundException();
        }

        return packageModel;
    }

    /// <summary>
    /// Update one Package
    /// </summary>
    public async Task UpdatePackageModel(
        PackageModelWhereUniqueInput uniqueId,
        PackageModelUpdateInput updateDto
    )
    {
        var packageModel = updateDto.ToModel(uniqueId);

        _context.Entry(packageModel).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.PackageModels.Any(e => e.Id == packageModel.Id))
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
