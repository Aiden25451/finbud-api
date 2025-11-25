using FinbudApi.Data;
using FinbudApi.Dto.UserInfo;
using FinbudApi.Mapping;

namespace FinbudApi.Services;

public class UserInfoService : IUserInfoService
{
    private readonly SupabaseDbContext _context;

    public UserInfoService(SupabaseDbContext context)
    {
        _context = context;
    }

    public async Task<GetUserInfoDTO?> CreateUserInfoAsync(CreateUserInfoDTO request, string userId)
    {

        var userinfo = request.CreateUserInfoDtoToUserInfoEntity(userId);

        var createduserinfo = await _context.CreateUserInfoAsync(userinfo);

        if(createduserinfo == null) return null;

        return createduserinfo.UserInfoEntityToGetUserInfoDTO();
    }

    public async Task<GetUserInfoDTO?> GetUserInfoByUserIdAsync(string userId)
    {
        var userinfo = await _context.GetUserInfoByUserIdAsync(userId);

        if (userinfo == null) return null;

        return userinfo.UserInfoEntityToGetUserInfoDTO();
    }

    public async Task<GetUserInfoDTO?> UpdateUserInfoUsernameAsync(UpdateUsernameDTO request, string userId)
    {
        var userinfo = request.UpdateUserInfoUsernameDtoToUserInfoEntity(userId);

        var updateduserinfo = await _context.UpdateUserInfoUsernameAsync(userinfo);

        if(updateduserinfo == null) return null;

        return updateduserinfo.UserInfoEntityToGetUserInfoDTO();
    }

    public async Task<GetUserInfoDTO?> UpdateUserInfoUserProfilePictureAsync(UpdateUserProfilePictureDTO request, string userId)
    {
        var userinfo = request.UpdateUserInfoUserProfilePictureDtoToUserInfoEntity(userId);

        var updateduserinfo = await _context.UpdateUserInfoUserProfilePictureAsync(userinfo);

        if(updateduserinfo == null) return null;

        return updateduserinfo.UserInfoEntityToGetUserInfoDTO();
    }

    public async Task<bool> DeleteUserInfoAsync(string userId)
    {
        return await _context.DeleteUserInfoAsync(userId);
    }
}