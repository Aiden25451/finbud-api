namespace FinbudApi.Dto.UserInfo;
using System.ComponentModel.DataAnnotations;

public class UpdateUsernameDTO
{
    [MaxLength(100)]
    [Required]
    public string UserName { get; set; } = String.Empty;

}


