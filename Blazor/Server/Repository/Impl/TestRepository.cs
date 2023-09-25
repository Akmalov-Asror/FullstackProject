using Blazor.Server.Data;
using Blazor.Shared;
using Microsoft.EntityFrameworkCore;

namespace Blazor.Server.Repository.Impl;

public class TestRepository : ITestRepository
{
    private readonly AppDbContext _context;
    public TestRepository(AppDbContext context) => _context = context;

    public async Task<List<Test>> GetTestListAsync(int lessonId) => await _context.Test.Include(e => e.Lesson).Where(f => f.Lesson.Id == lessonId).ToListAsync();
}
