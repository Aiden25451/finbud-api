using FinbudApi.Models;

namespace FinbudApi.Data;

public class SupabaseDbContext
{
    private readonly Supabase.Client _client;

    public SupabaseDbContext(Supabase.Client client)
    {
        _client = client;
    }

    public async Task<Monkey> CreateMonkeyAsync(Monkey monkey)
    {
        var response = await _client.From<Monkey>().Insert(monkey);
        return response.Models.First();
    }

    public async Task<Monkey?> GetMonkeyByIdAsync(int id)
    {
        var response = await _client
            .From<Monkey>()
            .Where(n => n.Id == id)
            .Get();

        return response.Models.FirstOrDefault();
    }

    public async Task<bool> DeleteMonkeyAsync(int id)
    {
        try
        {
            await _client
                .From<Monkey>()
                .Where(n => n.Id == id)
                .Delete();
            return true;
        }
        catch
        {
            return false;
        }
    }

    public async Task<UserInfo> CreateUserInfoAsync(UserInfo userinfo)
    {
        var response = await _client.From<UserInfo>().Insert(userinfo);
        return response.Models.First();
    }

    public async Task<UserInfo?> GetUserInfoByUserIdAsync(string userId)
    {
        var response = await _client
            .From<UserInfo>()
            .Where(n => n.UserId == userId)
            .Get();

        return response.Models.FirstOrDefault();
    }

    public async Task<bool> DeleteUserInfoAsync(string userId)
    {
        try
        {
            await _client
                .From<UserInfo>()
                .Where(n => n.UserId == userId)
                .Delete();
            return true;
        }
        catch
        {
            return false;
        }
    }
}