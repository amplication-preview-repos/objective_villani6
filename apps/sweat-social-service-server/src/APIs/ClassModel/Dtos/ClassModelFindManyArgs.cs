using Microsoft.AspNetCore.Mvc;
using SweatSocialService.APIs.Common;
using SweatSocialService.Infrastructure.Models;

namespace SweatSocialService.APIs.Dtos;

[BindProperties(SupportsGet = true)]
public class ClassModelFindManyArgs : FindManyInput<ClassModel, ClassModelWhereInput> { }
