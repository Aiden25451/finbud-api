using FinbudApi.Dto.UserAchievement;
using FinbudApi.Models;

namespace FinbudApi.Mapping;

public static class UserAchievementMappingExtensions
{
    public static UserAchievement CreateUserAchievementDtoToUserAchievementEntity(this CreateUserAchievementDTO dto, string userId)
    {
        return new UserAchievement
        {
            // UserAchievementId = 0,
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
            // UserAchievementId= userAchievement.UserAchievementId,
            UserAchievementStatus = userAchievement.UserAchievementStatus,
            UserAchievementValue = userAchievement.UserAchievementValue,
            AchievementId = userAchievement.AchievementId,
        };
    }

    public static UserAchievement UpdateUserAchievementDtoToUserAchievementEntity(this UpdateUserAchievementDTO dto, string userId){
        // string newStatus = 
        
        return new UserAchievement
        {
            UserId = userId,
            UserAchievementStatus = dto.UserAchievementStatus,
            UserAchievementValue = dto.UserAchievementValue,
            AchievementId = dto.AchievementId
        };
    }

}
