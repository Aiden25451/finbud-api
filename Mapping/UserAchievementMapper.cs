using FinbudApi.Dto.UserAchievement;
using FinbudApi.Models;

namespace FinbudApi.Mapping;

public static class UserAchievementMappingExtensions
{
    public static UserAchievement CreateUserAchievementDtoToUserAchievementEntity(this CreateUserAchievementDTO dto, string userId)
    {
        return new UserAchievement
        {
            UserId = userId,
            UserAchievementStatus = dto.UserAchievementStatus,
            UserAchievementValue = dto.UserAchievementValue,
            AchievementId = dto.AchievementId,
        };
    }

    public static UserAchievementResponseDTO UserAchievementEntityToUserAchievementResponseDTO(this UserAchievement userAchievement)
    {
        return new UserAchievementResponseDTO
        {
            UserAchievementStatus = userAchievement.UserAchievementStatus,
            UserAchievementValue = userAchievement.UserAchievementValue,
            AchievementId = userAchievement.AchievementId,
        };
    }

    public static UserAchievement UpdateUserAchievementDtoToUserAchievementEntity(this UpdateUserAchievementDTO dto, string userId){
        
        return new UserAchievement
        {
            UserId = userId,
            UserAchievementStatus = dto.UserAchievementStatus,
            UserAchievementValue = dto.UserAchievementValue,
            AchievementId = dto.AchievementId
        };
    }

}
