using FinbudApi.Dto.UserInfo;
using FinbudApi.Models;

namespace FinbudApi.Mapping;

public static class UserInfoMappingExtensions
{
    public static UserInfo CreateUserInfoDtoToUserInfoEntity(this CreateUserInfoDTO dto, string userId)
    {
        return new UserInfo
        {
            UserName = dto.UserName,
            CreatedAt = DateTime.UtcNow,
            UserId = userId,
        };
    }

    public static GetUserInfoDTO UserInfoEntityToGetUserInfoDTO(this UserInfo userinfo)
    {
        return new GetUserInfoDTO
        {
            UserName = userinfo.UserName,
            CreatedAt = userinfo.CreatedAt,
            UserProfilePicture = userinfo.UserProfilePicture
        };
    }

    public static UserInfo UpdateUserInfoUsernameDtoToUserInfoEntity(this UpdateUsernameDTO dto, string userId)
    {
        return new UserInfo
        {
            UserName = dto.UserName,
            UserId = userId,
        };
    }

    public static UserInfo UpdateUserInfoUserProfilePictureDtoToUserInfoEntity(this UpdateUserProfilePictureDTO dto, string userId)
    {
        return new UserInfo
        {
            UserProfilePicture = dto.UserProfilePicture,
            UserId = userId,
        };
    }



}
