using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;

namespace FinbudApi.Models;

[Table("UserInfo")]
public class UserInfo : BaseModel
{
    [PrimaryKey("id", false)]
    public int Id { get; set; }

    [Column("username")]
    public string Username { get; set; } = String.Empty;

    [Column("created_at")]
    public DateTime CreatedAt { get; set; }
}