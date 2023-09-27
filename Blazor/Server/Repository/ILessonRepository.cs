using Blazor.Shared;
using Task = System.Threading.Tasks.Task;

namespace Blazor.Server.Repository;

public interface ILessonRepository
{
    Task<List<Lesson>> GetLessonsByCourseId(int courseId);
    Task<Lesson> GetLessonById(int id);
    Task<List<Lesson>> GetLessonAndTaskByCourseId(int courseId);
}