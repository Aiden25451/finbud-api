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
            UserId = userinfo.UserId,
        };
    }
}
