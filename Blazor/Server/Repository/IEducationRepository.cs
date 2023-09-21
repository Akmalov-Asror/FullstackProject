using Blazor.Shared;

namespace Blazor.Server.Repository
{
    public interface IEducationRepository
    { 
        Task<Education> GetEducationById(int courseId);
    }
}
