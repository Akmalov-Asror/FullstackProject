using Blazor.Server.Data;
using Blazor.Server.Dto;
using Blazor.Shared;
using Task = System.Threading.Tasks.Task;

namespace Blazor.Server.Repository.Impl
{
    public class TaskAnswerRepository : ITaskAnswerRepository
    {
        private readonly AppDbContext _context;

        public TaskAnswerRepository(AppDbContext context) => _context = context;

        public async Task AddTaskAnswerAsync(TaskAnswerDTO taskAnswerDto)
        {
            TaskAnswer taskAnswer = new TaskAnswer();
            taskAnswer.Answer = taskAnswerDto.Answer;
            taskAnswer.Task = await _context.Task.FindAsync(taskAnswerDto.TaskId) ?? throw new BadHttpRequestException("Task not found");

            _context.TaskAnswer.Add(taskAnswer);
            await _context.SaveChangesAsync();
        }
    }
}
