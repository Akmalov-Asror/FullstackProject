using Blazor.Shared;

namespace Blazor.Server.Repository
{
    public interface IResultRepository
    {
        Task<List<Result>> GetResultListAsync(int educationId);
    }
}
