using FinbudApi.Dto.UserInfo;

namespace FinbudApi.Services;

public interface IUserInfoService
{
    Task<GetUserInfoDTO?> CreateUserInfoAsync(CreateUserInfoDTO request, string userId);
    Task<GetUserInfoDTO?> GetUserInfoByUserIdAsync(string userId);
    Task<GetUserInfoDTO?> UpdateUserInfoUsernameAsync(UpdateUsernameDTO request, string userId);
    Task<GetUserInfoDTO?> UpdateUserInfoUserProfilePictureAsync(UpdateUserProfilePictureDTO request, string userId);
    Task<bool> DeleteUserInfoAsync(string userId);
}