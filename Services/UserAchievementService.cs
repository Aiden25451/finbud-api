using FinbudApi.Data;
using FinbudApi.Dto.UserAchievement;
using FinbudApi.Models;
using FinbudApi.Mapping;

namespace FinbudApi.Services;

public class UserAchievementService : IUserAchievementService
{
    private readonly SupabaseDbContext _context;

    public UserAchievementService(SupabaseDbContext context)
    {
        _context = context;
    }

    public async Task<UserAchievementResponseDTO?> CreateUserAchievementAsync(CreateUserAchievementDTO request, string userId)
    {

        var userachievement = request.CreateUserAchievementDtoToUserAchievementEntity(userId);

        var createduserachievement = await _context.CreateUserAchievementAsync(userachievement);

        if(createduserachievement == null) return null;

        return createduserachievement.UserAchievementEntityToUserAchievementResponseDTO();
    }

    public async Task<List<UserAchievementResponseDTO>?> GetUserAchievementsAsync(string userId)
    {
        var userAchievements = await _context.GetUserAchievementsAsync(userId);

        if (userAchievements == null) return null;

        Console.WriteLine("count: " + userAchievements.Count);
        

        var mappedUserAchievements = new List<UserAchievementResponseDTO>();

        for(int i = 0; i< userAchievements.Count; i++){
            mappedUserAchievements.Add(userAchievements[i].UserAchievementEntityToUserAchievementResponseDTO());
        }

        return mappedUserAchievements;
    }

    public async Task<UserAchievementResponseDTO> GetUserAchievementByAchievementIdAsync(string userId, int achievementId)
    {
        var userAchievement = await _context.GetUserAchievementByAchievementIdAsync(userId, achievementId);

        if (userAchievement == null) return null;

      

        return userAchievement.UserAchievementEntityToUserAchievementResponseDTO();
    }

    public async Task<UserAchievementResponseDTO?> UpdateUserAchievementByAchievementIdAsync(UpdateUserAchievementDTO request, string userId)
    {
        var userAchievement = request.UpdateUserAchievementDtoToUserAchievementEntity(userId);

        var updateduserachievement = await _context.UpdateUserAchievementByAchievementIdAsync(userAchievement);

        if(updateduserachievement == null) return null;

        return updateduserachievement.UserAchievementEntityToUserAchievementResponseDTO();
    }
}