using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;

namespace FinbudApi.Models;

[Table("UserAchievement")]
public class UserAchievement : BaseModel
{
    // [PrimaryKey("user_achievement_id", false)]
    // [Column("user_achievement_id")]
    // public int UserAchievementId { get; set; } = 0;

    [Column("user_id")]
    public string UserId { get; set; } = String.Empty;

    [Column("user_achievement_status")]
    public string UserAchievementStatus {get; set;} = "INACTIVE";

    [Column("user_achievement_value")]
    public int UserAchievementValue {get; set;} = 0;

    [Column("achievement_id")]
    public int AchievementId {get; set;} = 0;
}