

using FinbudApi.Dto.Monkey;
using FinbudApi.Models;

namespace FinbudApi.Mapping;

public static class MonkeyMappingExtensions
{
    public static Monkey CreateMonkeyDtoToMonkeyEntity(this CreateMonkeyDto dto, string userId)
    {
        return new Monkey
        {
            Name = dto.Name,
            Type = dto.Type,
            Age = dto.Age,
            UserId = userId,
            CreatedAt = DateTime.UtcNow,
        };
    }

    public static MonkeyResponseDto MonkeyEntityToMonkeyResponseDto(this Monkey monkey)
    {
        return new MonkeyResponseDto
        {
            Id = monkey.Id,
            Name = monkey.Name,
            Type = monkey.Type,
            Age = monkey.Age,
            UserId = monkey.UserId,
            CreatedAt = monkey.CreatedAt,
        };
    }
}
