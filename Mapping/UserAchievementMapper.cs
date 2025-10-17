using FinbudApi.Dto.UserAchievement;
using FinbudApi.Models;

namespace FinbudApi.Mapping;

public static class UserAchievementMappingExtensions
{
    public static InsertUserAchievement CreateUserAchievementDtoToInsertUserAchievementEntity(this CreateUserAchievementDTO dto, string userId)
    {
        return new InsertUserAchievement
        {
            UserId = userId,
            UserAchievementStatus = dto.UserAchievementStatus,
            UserAchievementProgressValue = dto.UserAchievementProgressValue,
            UserAchievementGoalValue = dto.UserAchievementGoalValue,
            AchievementId = dto.AchievementId,
            UserAchievementBoolean = 0 
        };
    }

    public static UserAchievementResponseDTO UserAchievementEntityToUserAchievementResponseDTO(this UserAchievement userAchievement)
    {
        return new UserAchievementResponseDTO
        {
            UserAchievementStatus = userAchievement.UserAchievementStatus,
            UserAchievementProgressValue = userAchievement.UserAchievementProgressValue,
            UserAchievementGoalValue = userAchievement.UserAchievementGoalValue,
            AchievementId = userAchievement.AchievementId,
            UserAchievementId = userAchievement.UserAchievementId,
            UserAchievementBoolean = userAchievement.UserAchievementBoolean
        };
    }

    public static UserAchievement UpdateUserAchievementDtoToUserAchievementEntity(this UpdateUserAchievementDTO dto, string userId){
        
        return new UserAchievement
        {
            UserId = userId,
            UserAchievementStatus = dto.UserAchievementStatus,
            UserAchievementGoalValue = dto.UserAchievementGoalValue,
            UserAchievementProgressValue = dto.UserAchievementProgressValue,
            UserAchievementBoolean = dto.UserAchievementBoolean,
            AchievementId = dto.AchievementId
        };
    }

}
