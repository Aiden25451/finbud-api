namespace FinbudApi.Dto.UserAchievement;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

public class UpdateUserAchievementDTO
{
    
    public string UserAchievementStatus {get; set;} = string.Empty;

    public int UserAchievementValue {get; set;} = -1;

    [Required]
    public int AchievementId {get; set;} = 0;
}