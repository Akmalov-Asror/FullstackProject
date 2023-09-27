using Blazor.Shared;

namespace Blazor.Server.Repository;

public interface IHomeworkRepository
{
    Task<List<Homework>> GetAllHomeworkAsync();
    Task<Homework> GetHomeworkByIdAsync(int id);
    Task<Homework> GetHomeworkByTaskId(int taskId);
}