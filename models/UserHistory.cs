using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;

namespace FinbudApi.Models;

[Table("UserHistory")]
public class UserHistory : BaseModel
{
    [PrimaryKey("user_id", false)]
    [Column("user_id")]
    public string UserId { get; set; } = String.Empty;

    [Column("user_history")]
    public List<int> UserHistoryData { get; set; } = new List<int>();

    [Column("updated_at")]
    public DateTime UpdatedAt { get; set; }
}