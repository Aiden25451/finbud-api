using FinbudApi.Dto.Monkeys;

namespace FinbudApi.Services;

public interface IMonkeyService
{
    Task<int> CreateMonkeyAsync(CreateMonkeyRequestDto request);
    Task<ViewMonkeyDto?> GetMonkeyByIdAsync(int id);
    Task<bool> DeleteMonkeyAsync(int id);
}