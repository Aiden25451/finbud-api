namespace FinbudApi.Contracts;

public class CreateMonkeyRequest
{
    public string Name { get; set; }
    public string Type { get; set; }
    public int Age { get; set; }
}

public class MonkeyResponse
{
    public long Id { get; set; }
    public string Name { get; set; }
    public string Type { get; set; }
    public int Age { get; set; }
    public DateTime CreatedAt { get; set; }
}