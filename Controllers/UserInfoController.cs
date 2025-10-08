
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

        if(userInfoResponse == null) return StatusCode(400, "User Info may already exist in Database.");

        return StatusCode(201,userInfoResponse);
    }

    [HttpGet]
    [Authorize]
    public async Task<IActionResult> GetUserInfoByUserId()
    {
        if (!ModelState.IsValid)
            return StatusCode(400,ModelState);

        var currentUserId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

        if (currentUserId == null)
            return StatusCode(401);

        var userinfo = await _userInfoService.GetUserInfoByUserIdAsync(currentUserId);
        if (userinfo == null)
            return StatusCode(404);

        return StatusCode(200,userinfo);
    }

    [HttpPut]
    [Authorize]
    public async Task<IActionResult> UpdateUserInfoUsername([FromBody] UpdateUsernameDTO request)
    {
        if (!ModelState.IsValid)
            return StatusCode(400, ModelState);

        var currentUserId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

        if (currentUserId == null)
            return StatusCode(401);

        var userInfoResponse = await _userInfoService.UpdateUserInfoUsernameAsync(request, currentUserId);
        
        if(userInfoResponse == null) return StatusCode(404, "User Info not found in database.");
        
        return StatusCode(200,userInfoResponse);
    }

    [HttpDelete]
    [Authorize]
    public async Task<IActionResult> DeleteUserInfo()
    {
        if (!ModelState.IsValid)
            return StatusCode(400,ModelState);

        var currentUserId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

        if (currentUserId == null)
            return StatusCode(401);

        var deleted = await _userInfoService.DeleteUserInfoAsync(currentUserId);
        if (!deleted)
            return StatusCode(404);

        return StatusCode(204);
    }
}