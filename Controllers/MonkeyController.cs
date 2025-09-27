
using System.Security.Claims;
using FinbudApi.Dto.Monkey;
using FinbudApi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FinbudApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MonkeyController : ControllerBase
{
    private readonly IMonkeyService _monkeyService;

    public MonkeyController(IMonkeyService monkeyService)
    {
        _monkeyService = monkeyService;
    }

    [HttpGet("test")]
    public IActionResult Test()
    {
        return Ok("Controller is working!");
    }

    [HttpGet("test-private")]
    [Authorize]
    public IActionResult TestPrivate()
    {
        return Ok("Private controller is working!");
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> CreateMonkey([FromBody] CreateMonkeyDto request)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var currentUserId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

        if (currentUserId == null)
            return Unauthorized();

        var monkeyResponse = await _monkeyService.CreateMonkeyAsync(request, currentUserId);
        return Ok(monkeyResponse);
    }

    [HttpGet("{id:int}")]
    [Authorize]
    public async Task<IActionResult> GetMonkey(int id)
    {
        var monkey = await _monkeyService.GetMonkeyByIdAsync(id);
        if (monkey == null)
            return NotFound();

        return Ok(monkey);
    }

    [HttpDelete("{id:int}")]
    [Authorize]
    public async Task<IActionResult> DeleteMonkey(int id)
    {
        var deleted = await _monkeyService.DeleteMonkeyAsync(id);
        if (!deleted)
            return NotFound();

        return NoContent();
    }
}