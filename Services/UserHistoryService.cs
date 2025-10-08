using FinbudApi.Data;
using FinbudApi.Dto.UserHistory;
using FinbudApi.Mapping;

namespace FinbudApi.Services;

public class UserHistoryService : IUserHistoryService
{
    private readonly SupabaseDbContext _context;

    public UserHistoryService(SupabaseDbContext context)
    {
        _context = context;
    }

    public async Task<UserHistoryResponseDTO?> CreateUserHistoryAsync(CreateUserHistoryDTO request, string userId)
    {

        var userhistory = request.CreateUserHistoryDtoToUserHistoryEntity(userId);

        var createduserhistory = await _context.CreateUserHistoryAsync(userhistory);

        if(createduserhistory == null) return null;

        return createduserhistory.UserHistoryEntityToUserHistoryResponseDTO();
    }

    public async Task<UserHistoryResponseDTO?> GetUserHistoryByUserIdAsync(string userId)
    {
        var userhistory = await _context.GetUserHistoryByUserIdAsync(userId);

        if (userhistory == null) return null;

        return userhistory.UserHistoryEntityToUserHistoryResponseDTO();
    }

    public async Task<UserHistoryResponseDTO?> UpdateUserHistoryByUserIdAsync(CreateUserHistoryDTO request, string userId)
    {
        var userhistory = request.CreateUserHistoryDtoToUserHistoryEntity(userId);

        var updateduserhistory = await _context.UpdateUserHistoryByUserIdAsync(userhistory);

        if(updateduserhistory == null) return null;

        return updateduserhistory.UserHistoryEntityToUserHistoryResponseDTO();
    }

    public async Task<bool> DeleteUserHistoryByUserIdAsync(string userId)
    {
        return await _context.DeleteUserHistoryAsync(userId);
    }
}