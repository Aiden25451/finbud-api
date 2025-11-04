namespace FinbudApi.Dto.UserAchievement;
using System.ComponentModel.DataAnnotations;

public class UserAchievementResponseDTO
{
    [Required]
    public int UserAchievementId {get; set;} = 0;

    [Required]
    public string UserAchievementStatus {get; set;} = null;

    public int UserAchievementProgressValue { get; set; } = 0;

    public int UserAchievementGoalValue { get; set; } = 0;

    [Required]
    public Int16 UserAchievementBoolean {get; set;} = 0;

    [Required]
    public int AchievementId {get; set;} = 0; 
}