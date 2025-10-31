namespace FinbudApi.Dto.UserInfo;
using System.ComponentModel.DataAnnotations;

public class UsernameResponseDTO
{
    [MaxLength(100)]
    [Required]
    public string UserName { get; set; }

}


