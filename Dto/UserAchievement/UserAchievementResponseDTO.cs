namespace FinbudApi.Dto.UserAchievement;
using System.ComponentModel.DataAnnotations;

public class UserAchievementResponseDTO
{
    // [Required]
    // public List<int> UserHistory { get; set; } = new List<int>{1};

    [Required]
    public int UserAchievementId {get; set;} = 0;

    [Required]
    public string UserAchievementStatus {get; set;} = null;
    
    public int UserAchievementValue {get; set;} = 0;

    [Required]
    public int AchievementId {get; set;} = 0; 
}