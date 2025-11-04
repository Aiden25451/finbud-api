namespace FinbudApi.Dto.UserAchievement;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

public class CreateUserAchievementDTO
{
    [Required]
    public string UserAchievementStatus {get; set;} = null;

    public int UserAchievementProgressValue { get; set; } = 0;

    public int UserAchievementGoalValue { get; set; } = 0;
    
    public Int16 UserAchievementBoolean {get; set;} = 0;

    [Required]
    public int AchievementId {get; set;} = 0;
}