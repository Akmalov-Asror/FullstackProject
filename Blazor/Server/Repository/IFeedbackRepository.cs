using Blazor.Shared;

namespace Blazor.Server.Repository
{
    public interface IFeedbackRepository
    {
        Task<List<Feedback>> GetFeedbackListAsync(int educationId);
    }
}
