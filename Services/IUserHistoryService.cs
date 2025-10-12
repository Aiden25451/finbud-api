using FinbudApi.Dto.UserHistory;

namespace FinbudApi.Services;

public interface IUserHistoryService
{
    Task<UserHistoryResponseDTO?> CreateUserHistoryAsync(CreateUserHistoryDTO request, string userId);
    Task<UserHistoryResponseDTO?> GetUserHistoryByUserIdAsync(string userId);
    Task<UserHistoryResponseDTO?> UpdateUserHistoryByUserIdAsync(CreateUserHistoryDTO request, string userId);
    Task<bool> DeleteUserHistoryByUserIdAsync(string userId);
}