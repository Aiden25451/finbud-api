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

        return createduserinfo.UserInfoEntityToGetUserInfoDTO();
    }

//     public async Task<MonkeyResponseDto?> GetMonkeyByIdAsync(int id)
//     {
//         var monkey = await _context.GetMonkeyByIdAsync(id);

//         if (monkey == null) return null;

//         return monkey.MonkeyEntityToMonkeyResponseDto();
//     }

//     public async Task<bool> DeleteMonkeyAsync(int id)
//     {
//         return await _context.DeleteMonkeyAsync(id);
//     }
}