using FinbudApi.Data;
using FinbudApi.Dto.Monkeys;
using FinbudApi.Models;

namespace FinbudApi.Services;

public class MonkeyService : IMonkeyService
{
    private readonly SupabaseDbContext _context;

    public MonkeyService(SupabaseDbContext context)
    {
        _context = context;
    }

    public async Task<int> CreateMonkeyAsync(CreateMonkeyRequestDto request)
    {
        var monkey = new Monkey
        {
            Name = request.Name,
            Type = request.Type,
            Age = request.Age,
        };

        var createdMonkey = await _context.CreateMonkeyAsync(monkey);
        return createdMonkey.Id;
    }

    public async Task<ViewMonkeyDto?> GetMonkeyByIdAsync(int id)
    {
        var monkey = await _context.GetMonkeyByIdAsync(id);
        if (monkey == null) return null;

        return new ViewMonkeyDto
        {
            Id = monkey.Id,
            Name = monkey.Name,
            Type = monkey.Type,
            Age = monkey.Age,
            CreatedAt = monkey.CreatedAt
        };
    }

    public async Task<bool> DeleteMonkeyAsync(int id)
    {
        return await _context.DeleteMonkeyAsync(id);
    }
}