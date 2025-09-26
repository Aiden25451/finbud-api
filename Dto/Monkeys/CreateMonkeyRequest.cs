using System.ComponentModel.DataAnnotations;

namespace FinbudApi.Dto.Monkeys;

public class CreateMonkeyRequestDto
{
    [Required]
    [MaxLength(100)]
    public string Name { get; set; } = String.Empty;

    [Required]
    [MaxLength(100)]
    public string Type { get; set; } = String.Empty;

    [Range(0, 100)]
    public int Age { get; set; }
}

