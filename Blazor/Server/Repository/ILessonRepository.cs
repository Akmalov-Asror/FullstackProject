using Blazor.Shared;
using Task = System.Threading.Tasks.Task;

namespace Blazor.Server.Repository;

public interface ILessonRepository
{
    Task<List<Lesson>> GetLessonByCourseIdAsync(int courseId);
}