using FinbudApi.Dto.UserInfo;

namespace FinbudApi.Services;

public interface IUserInfoService
{
    Task<GetUserInfoDTO?> CreateUserInfoAsync(CreateUserInfoDTO request, string userId);
    // Task<GetUserInfoDTO?> GetMonkeyByIdAsync(int id);
    // Task<bool> DeleteMonkeyAsync(int id);
}