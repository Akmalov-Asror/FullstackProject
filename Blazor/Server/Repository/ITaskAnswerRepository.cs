using Blazor.Server.Dto;
using Task = System.Threading.Tasks.Task;

namespace Blazor.Server.Repository
{
    public interface ITaskAnswerRepository
    {
        Task AddTaskAnswerAsync(TaskAnswerDTO taskAnswer);
    }
}
