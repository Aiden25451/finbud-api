using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;

namespace FinbudApi.Models;

[Table("UserAchievement")]
public class InsertUserAchievement : BaseModel
{
    [Column("user_id")]
    public string UserId { get; set; } = String.Empty;

    [Column("user_achievement_status")]
    public string UserAchievementStatus {get; set;} = "INACTIVE";

    [Column("user_achievement_progress_value")]
    public int UserAchievementProgressValue { get; set; } = 0;
    
    
    [Column("user_achievement_goal_value")]
    public int UserAchievementGoalValue {get; set;} = 0;

    [Column("achievement_id")]
    public int AchievementId { get; set; } = 0;

    [Column("user_achievement_boolean")]
    public Int16 UserAchievementBoolean {get; set;} = 0;
}