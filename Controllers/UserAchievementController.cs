
using System.Security.Claims;
using FinbudApi.Dto.UserAchievement;
using FinbudApi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FinbudApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserAchievementController : ControllerBase
{
    private readonly IUserAchievementService _userAchievementService;

    public UserAchievementController(IUserAchievementService userAchievementService)
    {
        _userAchievementService = userAchievementService;
    }

    [HttpGet("test-private")]
    [Authorize]
    public IActionResult TestPrivate()
    {
        return StatusCode(200,"Private controller is working!");
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> CreateUserAchievement([FromBody] CreateUserAchievementDTO request)
    {
        if (!ModelState.IsValid)
            return StatusCode(400,ModelState);

        var currentUserId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

        if (currentUserId == null)
            return StatusCode(401);

        var userAchievementResponse = await _userAchievementService.CreateUserAchievementAsync(request, currentUserId);

        if(userAchievementResponse == null) return StatusCode(400, "Achievement may already exist for this user.");

        return StatusCode(201,userAchievementResponse);
    }

    [HttpGet]
    [Authorize]
    public async Task<IActionResult> GetUserAchievements()
    {
        if (!ModelState.IsValid)
            return StatusCode(400,ModelState);

        var currentUserId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

        if (currentUserId == null)
            return StatusCode(401);

        var userachievements = await _userAchievementService.GetUserAchievementsAsync(currentUserId);
        if (userachievements == null)
            return StatusCode(404);

        return StatusCode(200,userachievements);
    }

    [HttpGet("AchievementId")]
    [Authorize]
    public async Task<IActionResult> GetUserAchievementByAchievementId(int AchievementId)
    {
        if (!ModelState.IsValid)
            return StatusCode(400,ModelState);

        var currentUserId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

        if (currentUserId == null)
            return StatusCode(401);

        var userachievement = await _userAchievementService.GetUserAchievementByAchievementIdAsync(currentUserId, AchievementId);
        if (userachievement == null)
            return StatusCode(404, "This user does not have an achievement of the given Achievement ID.");

        return StatusCode(200,userachievement);
    }

    [HttpPut]
    [Authorize]
    public async Task<IActionResult> UpdateUserAchievementByAchievementId([FromBody] UpdateUserAchievementDTO request)
    {
        if (!ModelState.IsValid)
            return StatusCode(400, ModelState);

        var currentUserId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

        if (currentUserId == null)
            return StatusCode(401);

        var userAchievementResponse = await _userAchievementService.UpdateUserAchievementByAchievementIdAsync(request, currentUserId);
        
        if(userAchievementResponse == null) return StatusCode(404, "User Achievement not found in database.");
        
        return StatusCode(200,userAchievementResponse);
    }
}