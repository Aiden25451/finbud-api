
using System.Security.Claims;
using FinbudApi.Dto.UserInfo;
using FinbudApi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FinbudApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserInfoController : ControllerBase
{
    private readonly IUserInfoService _userInfoService;

    public UserInfoController(IUserInfoService userInfoService)
    {
        _userInfoService = userInfoService;
    }

    [HttpGet("test-private")]
    [Authorize]
    public IActionResult TestPrivate()
    {
        return StatusCode(200,"Private controller is working!");
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> CreateUserInfo([FromBody] CreateUserInfoDTO request)
    {
        if (!ModelState.IsValid)
            return StatusCode(400,ModelState);

        var currentUserId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

        if (currentUserId == null)
            return StatusCode(401);

        var userInfoResponse = await _userInfoService.CreateUserInfoAsync(request, currentUserId);
        return StatusCode(200,userInfoResponse);
    }

    [HttpGet("{userId}")]
    [Authorize]
    public async Task<IActionResult> GetUserInfoByUserId(string userId)
    {
        var userinfo = await _userInfoService.GetUserInfoByUserIdAsync(userId);
        if (userinfo == null)
            return StatusCode(404);

        return StatusCode(200,userinfo);
    }

    [HttpPut]
    [Authorize]
    public async Task<IActionResult> Update_UserInfo_Username([FromBody] UpdateUsernameDTO request)
    {
        if (!ModelState.IsValid)
            return StatusCode(400, ModelState);

        var currentUserId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

        if (currentUserId == null)
            return StatusCode(401);

        var userInfoResponse = await _userInfoService.UpdateUserInfoUsernameAsync(request, currentUserId);
        
        return StatusCode(200,userInfoResponse);
    }

    [HttpDelete("{userId}")]
    [Authorize]
    public async Task<IActionResult> DeleteUserInfo(string userId)
    {
        var deleted = await _userInfoService.DeleteUserInfoAsync(userId);
        if (!deleted)
            return StatusCode(404);

        return StatusCode(204);
    }
}