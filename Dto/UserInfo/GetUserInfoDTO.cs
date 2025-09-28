namespace FinbudApi.Dto.UserInfo;
using System.ComponentModel.DataAnnotations;

public class GetUserInfoDTO
{
    public long Id { get; set; }
    public required string Username { get; set; }
    public DateTime CreatedAt { get; set; }
}


public class CreateUserInfoDTO
{
    [Required]
    [MaxLength(100)]
    public required string Username { get; set; }
}

