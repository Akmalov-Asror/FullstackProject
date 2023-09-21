using Blazor.Server.Data;
using Blazor.Shared;
using Microsoft.EntityFrameworkCore;

namespace Blazor.Server.Repository.Impl;

public class LessonRepository : ILessonRepository
{
    private readonly AppDbContext _context;

    public LessonRepository(AppDbContext context) => _context = context;

    public async Task<List<Lesson>> GetLessonByCourseIdAsync(int courseId)
    {
        var course = await _context.Lesson.Where(l => l.Course.Id == courseId).ToListAsync();
        return course;
    }
}