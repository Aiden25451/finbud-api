namespace FinbudApi.Dto.UserAchievement;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

public class UpdateUserAchievementDTO
{
    
    public string UserAchievementStatus {get; set;} = string.Empty;

    public int UserAchievementProgressValue { get; set; } = -1;

    public int UserAchievementGoalValue { get; set; } = -1;
    
    public Int16 UserAchievementBoolean {get; set;} = -1;
    [Required]
    public int AchievementId {get; set;} = 0;
}