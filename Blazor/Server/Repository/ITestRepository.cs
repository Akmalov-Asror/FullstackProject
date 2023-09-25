using Blazor.Shared;
namespace Blazor.Server.Repository;

public interface ITestRepository
{
    Task<List<Test>> GetTestListAsync(int lessonId);
}
