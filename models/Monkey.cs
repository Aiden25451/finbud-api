
using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;

namespace FinbudApi.Models;

[Table("monkeys")]
public class Monkey : BaseModel
{
    [PrimaryKey("id", false)]
    public int Id { get; set; }

    [Column("name")]
    public string Name { get; set; } = String.Empty;

    [Column("type")]
    public string Type { get; set; } = String.Empty;

    [Column("age")]
    public int Age { get; set; }

    [Column("user_id")]
    public string UserId { get; set; } = String.Empty;

    [Column("created_at")]
    public DateTime CreatedAt { get; set; }
}