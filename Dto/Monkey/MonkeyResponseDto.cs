
namespace FinbudApi.Dto.Monkey;

public class MonkeyResponseDto
{
    public long Id { get; set; }
    public required string Name { get; set; }
    public required string Type { get; set; }
    public required int Age { get; set; }
    public required string UserId { get; set; }
    public DateTime CreatedAt { get; set; }
}