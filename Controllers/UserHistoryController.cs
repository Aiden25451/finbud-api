
using System.Security.Claims;
using FinbudApi.Dto.UserHistory;
using FinbudApi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FinbudApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserHistoryController : ControllerBase
{
    private readonly IUserHistoryService _userHistoryService;

    public UserHistoryController(IUserHistoryService userHistoryService)
    {
        _userHistoryService = userHistoryService;
    }

    [HttpGet("test-private")]
    [Authorize]
    public IActionResult TestPrivate()
    {
        return StatusCode(200,"Private controller is working!");
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> CreateUserHistory([FromBody] CreateUserHistoryDTO request)
    {
        if (!ModelState.IsValid)
            return StatusCode(400,ModelState);

        var currentUserId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

        if (currentUserId == null)
            return StatusCode(401);

        var userHistoryResponse = await _userHistoryService.CreateUserHistoryAsync(request, currentUserId);

        if(userHistoryResponse == null)
            return StatusCode(400, "Could not create user history. Check that user does not already have history.");

        return StatusCode(201, userHistoryResponse);
    }

    [HttpGet]
    [Authorize]
    public async Task<IActionResult> GetUserHistory()
    {
        if (!ModelState.IsValid)
            return StatusCode(400,ModelState);

        var currentUserId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

        if (currentUserId == null)
            return StatusCode(401);

        var userhistory = await _userHistoryService.GetUserHistoryByUserIdAsync(currentUserId);
        if (userhistory== null)
            return StatusCode(404);

        return StatusCode(200,userhistory);
    }

    [HttpPut]
    [Authorize]
    public async Task<IActionResult> UpdateUserHistory([FromBody] CreateUserHistoryDTO request)
    {
        if (!ModelState.IsValid)
            return StatusCode(400,ModelState);

        var currentUserId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

        if (currentUserId == null)
            return StatusCode(401);

        var userHistoryResponse = await _userHistoryService.UpdateUserHistoryByUserIdAsync(request, currentUserId);

        if(userHistoryResponse == null)
            return StatusCode(400,"Could not update user history. Ensure user history exists.");
        
        return StatusCode(200,userHistoryResponse);
    }

    [HttpDelete]
    [Authorize]
    public async Task<IActionResult> DeleteUserHistory()
    {
        if (!ModelState.IsValid)
            return StatusCode(400,ModelState);

        var currentUserId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

        if (currentUserId == null)
            return StatusCode(401);

        var deleted = await _userHistoryService.DeleteUserHistoryByUserIdAsync(currentUserId);
        if (!deleted)
            return StatusCode(404);

        return StatusCode(204);
    }
}