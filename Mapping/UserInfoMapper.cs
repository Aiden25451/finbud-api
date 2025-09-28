using FinbudApi.Dto.UserInfo;
using FinbudApi.Models;

namespace FinbudApi.Mapping;

public static class UserInfoMappingExtensions
{
    public static UserInfo CreateUserInfoDtoToUserInfoEntity(this CreateUserInfoDTO dto, string userId)
    {
        return new UserInfo
        {
            Username = dto.Username,
            CreatedAt = DateTime.UtcNow,
        };
    }

    public static GetUserInfoDTO UserInfoEntityToGetUserInfoDTO(this UserInfo userinfo)
    {
        return new GetUserInfoDTO
        {
            Id = userinfo.Id,
            Username = userinfo.Username,
            CreatedAt = userinfo.CreatedAt,
        };
    }
}
