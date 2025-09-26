
namespace FinbudApi.Dto.Monkeys;

public class ViewMonkeyDto
{
    public long Id { get; set; }
    public string Name { get; set; } = String.Empty;
    public string Type { get; set; } = String.Empty;
    public int Age { get; set; }
    public DateTime CreatedAt { get; set; }
}