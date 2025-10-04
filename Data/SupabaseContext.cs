using FinbudApi.Models;
using System;

namespace FinbudApi.Data;

public class SupabaseDbContext
{
    private readonly Supabase.Client _client;

    public SupabaseDbContext(Supabase.Client client)
    {
        _client = client;
    }

    // MONKEY 
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


    // USER INFO
    public async Task<UserInfo> CreateUserInfoAsync(UserInfo userinfo)
    {
        var response = await _client.From<UserInfo>().Insert(userinfo);
        return response.Models.First();
    }

    public async Task<UserInfo> UpdateUserInfoUsernameAsync(UserInfo userinfo)
    {
        string userid = userinfo.UserId.ToString();
        string username = userinfo.UserName.ToString();

        var entry = await _client
        .From<UserInfo>()
        .Where(u => u.UserId == userid)            
        .Set(x => x.UserName, username)
        .Update();

        var response = await _client
            .From<UserInfo>()
            .Where(n => n.UserId == userinfo.UserId)
            .Get();
        
        return response.Models.FirstOrDefault();
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


    // USER HISTORY
    public async Task<UserHistory> CreateUserHistoryAsync(UserHistory userHistory)
    {
        try{
            var response = await _client.From<UserHistory>().Insert(userHistory);
        return response.Models.First();
        }
        catch(Exception ex)
        {
            Console.WriteLine("Error creating user history: " + ex.Message);
            return null;
        }
        
    }

    public async Task<UserHistory?> GetUserHistoryByUserIdAsync(string userId)
    {
        var response = await _client
            .From<UserHistory>()
            .Where(n => n.UserId == userId)
            .Get();

        return response.Models.FirstOrDefault();
    }

    public async Task<UserHistory> UpdateUserHistoryByUserIdAsync(UserHistory userHistory)
    {
        string userid = userHistory.UserId.ToString();
        List<int> userhistorydata = userHistory.UserHistoryData;

        var entry = await _client
        .From<UserHistory>()
        .Where(u => u.UserId == userid)            
        .Set(x => x.UserHistoryData, userhistorydata)
        .Update();

        var response = await _client
            .From<UserHistory>()
            .Where(n => n.UserId == userHistory.UserId)
            .Get();
        
        return response.Models.FirstOrDefault();
    }

    public async Task<bool> DeleteUserHistoryAsync(string userId)
    {
        try
        {
            await _client
                .From<UserHistory>()
                .Where(n => n.UserId == userId)
                .Delete();

            
            Console.WriteLine("Deleted user history for userId: " + userId);
            return true; 
        } 
        catch
        {
            return false;
        }
    }
}