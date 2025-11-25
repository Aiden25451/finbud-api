namespace FinbudApi.Dto.UserInfo;
using System.ComponentModel.DataAnnotations;

public class UpdateUserProfilePictureDTO
{
    [MaxLength(100)]
    [Required]
    public string UserProfilePicture { get; set; } = String.Empty;

}


