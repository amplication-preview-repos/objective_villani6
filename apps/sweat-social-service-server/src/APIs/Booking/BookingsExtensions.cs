using SweatSocialService.APIs.Dtos;
using SweatSocialService.Infrastructure.Models;

namespace SweatSocialService.APIs.Extensions;

public static class BookingsExtensions
{
    public static Booking ToDto(this BookingDbModel model)
    {
        return new Booking
        {
            CreatedAt = model.CreatedAt,
            Id = model.Id,
            UpdatedAt = model.UpdatedAt,
        };
    }

    public static BookingDbModel ToModel(
        this BookingUpdateInput updateDto,
        BookingWhereUniqueInput uniqueId
    )
    {
        var booking = new BookingDbModel { Id = uniqueId.Id };

        if (updateDto.CreatedAt != null)
        {
            booking.CreatedAt = updateDto.CreatedAt.Value;
        }
        if (updateDto.UpdatedAt != null)
        {
            booking.UpdatedAt = updateDto.UpdatedAt.Value;
        }

        return booking;
    }
}
