using FinbudApi.Dto.UserHistory;
using FinbudApi.Models;

namespace FinbudApi.Mapping;

public static class UserHistoryMappingExtensions
{
    public static UserHistory CreateUserHistoryDtoToUserHistoryEntity(this CreateUserHistoryDTO dto, string userId)
    {
        return new UserHistory
        {
            UserHistoryData = dto.UserHistory,
            UpdatedAt = DateTime.UtcNow,
            UserId = userId,
        };
    }

    public static UserHistoryResponseDTO UserHistoryEntityToUserHistoryResponseDTO(this UserHistory userHistory)
    {
        return new UserHistoryResponseDTO
        {
            UserHistory = userHistory.UserHistoryData,
        };
    }

}
