using FinbudApi.Dto.Monkey;

namespace FinbudApi.Services;

public interface IMonkeyService
{
    Task<MonkeyResponseDto?> CreateMonkeyAsync(CreateMonkeyDto request, string userId);
    Task<MonkeyResponseDto?> GetMonkeyByIdAsync(int id);
    Task<bool> DeleteMonkeyAsync(int id);
}