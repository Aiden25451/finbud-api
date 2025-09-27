using System.ComponentModel.DataAnnotations;

namespace FinbudApi.Dto.Monkey;

public class CreateMonkeyDto
{
    [Required]
    [MaxLength(100)]
    public required string Name { get; set; }

    [Required]
    [MaxLength(100)]
    public required string Type { get; set; }

    [Required]
    [Range(0, 100)]
    public required int Age { get; set; }
}

