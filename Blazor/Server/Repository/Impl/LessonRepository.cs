using Blazor.Server.Data;
using Blazor.Shared;
using Microsoft.EntityFrameworkCore;

namespace Blazor.Server.Repository.Impl;

public class LessonRepository : ILessonRepository
{
    private readonly AppDbContext _context;

    public LessonRepository(AppDbContext context) => _context = context;

    public async Task<List<Lesson>> GetLessonsByCourseId(int courseId)
    {
        var course = await _context.Lesson.Where(l => l.Course.Id == courseId).ToListAsync();
        return course;
    }
    public async Task<Lesson> GetLessonById(int id)
    {
        return await _context.Lesson.FirstOrDefaultAsync(l => l.Id == id);
    }
    public async Task<List<Lesson>> GetLessonAndTaskByCourseId(int courseId)
    {
        return await _context.Lesson.Include(l => l.Tasks).Where(l => l.Course.Id == courseId).ToListAsync();
    }
}