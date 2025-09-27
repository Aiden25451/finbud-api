using FinbudApi.Data;
using FinbudApi.Dto.Monkey;
using FinbudApi.Mapping;

namespace FinbudApi.Services;

public class MonkeyService : IMonkeyService
{
    private readonly SupabaseDbContext _context;

    public MonkeyService(SupabaseDbContext context)
    {
        _context = context;
    }

    public async Task<MonkeyResponseDto?> CreateMonkeyAsync(CreateMonkeyDto request, string userId)
    {

        var monkey = request.CreateMonkeyDtoToMonkeyEntity(userId);

        var createdMonkey = await _context.CreateMonkeyAsync(monkey);

        return createdMonkey.MonkeyEntityToMonkeyResponseDto();
    }

    public async Task<MonkeyResponseDto?> GetMonkeyByIdAsync(int id)
    {
        var monkey = await _context.GetMonkeyByIdAsync(id);

        if (monkey == null) return null;

        return monkey.MonkeyEntityToMonkeyResponseDto();
    }

    public async Task<bool> DeleteMonkeyAsync(int id)
    {
        return await _context.DeleteMonkeyAsync(id);
    }
}