namespace FinbudApi.Dto.UserInfo;
using System.ComponentModel.DataAnnotations;

public class CreateUserInfoDTO
{
    [Required]
    [MaxLength(100)]
    public required string UserName { get; set; }
}