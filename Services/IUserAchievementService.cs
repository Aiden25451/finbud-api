using FinbudApi.Dto.UserAchievement;

namespace FinbudApi.Services;

public interface IUserAchievementService
{
    Task<UserAchievementResponseDTO?> CreateUserAchievementAsync(CreateUserAchievementDTO request, string userId);
    Task<List<UserAchievementResponseDTO>?> GetUserAchievementsAsync(string userId);
    Task<UserAchievementResponseDTO> GetUserAchievementByAchievementIdAsync(string userId, int achievementId);
    Task<UserAchievementResponseDTO?> UpdateUserAchievementByAchievementIdAsync(UpdateUserAchievementDTO request, string userId);
}