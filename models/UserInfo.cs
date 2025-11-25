using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;

namespace FinbudApi.Models;

[Table("UserInfo")]
public class UserInfo : BaseModel
{
    [PrimaryKey("user_id", false)]
    [Column("user_id")]
    public string UserId { get; set; } = String.Empty;

    [Column("username")]
    public string UserName { get; set; } = String.Empty;

    [Column("created_at")]
    public DateTime CreatedAt { get; set; }

    [Column("user_profile_picture")]
    public string UserProfilePicture { get; set; } = String.Empty;
}