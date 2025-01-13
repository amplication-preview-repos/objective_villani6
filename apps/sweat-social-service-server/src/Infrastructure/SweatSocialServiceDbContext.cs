using Microsoft.EntityFrameworkCore;
using SweatSocialService.Infrastructure.Models;

namespace SweatSocialService.Infrastructure;

public class SweatSocialServiceDbContext : DbContext
{
    public SweatSocialServiceDbContext(DbContextOptions<SweatSocialServiceDbContext> options)
        : base(options) { }

    public DbSet<ClassModelDbModel> ClassModels { get; set; }

    public DbSet<MembershipDbModel> Memberships { get; set; }

    public DbSet<BookingDbModel> Bookings { get; set; }

    public DbSet<InstructorDbModel> Instructors { get; set; }

    public DbSet<PackageModelDbModel> PackageModels { get; set; }

    public DbSet<UserDbModel> Users { get; set; }
}
