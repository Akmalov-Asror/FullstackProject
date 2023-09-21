using Blazor.Shared;
using Task = System.Threading.Tasks.Task;

namespace Blazor.Server.Repository
{
    public interface IContactRepository
    {
        Task AddTaskAnswerAsync(Contact contact);
    }
}
