namespace FinbudApi.Dto.UserInfo;
using System.ComponentModel.DataAnnotations;

public class GetUserInfoDTO
{
    [MaxLength(100)]
    public long Id { get; set; }

    [MaxLength(100)]
    public string UserName { get; set; }

    [MaxLength(100)]
    public DateTime CreatedAt { get; set; }

    [MaxLength(100)]
    public string UserEmail {get; set; }

    [Required]
    public required string UserId {get; set;}
}


