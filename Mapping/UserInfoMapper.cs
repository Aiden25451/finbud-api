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
            UserEmail = dto.UserEmail,
        };
    }

    public static GetUserInfoDTO UserInfoEntityToGetUserInfoDTO(this UserInfo userinfo)
    {
        return new GetUserInfoDTO
        {
            Id = userinfo.Id,
            UserName = userinfo.UserName,
            CreatedAt = userinfo.CreatedAt,
            UserEmail = userinfo.UserEmail,
            UserId = userinfo.UserId,
        };
    }
}
