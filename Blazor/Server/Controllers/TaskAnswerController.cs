using Blazor.Server.Dto;
using Blazor.Server.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Blazor.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskAnswerController : ControllerBase
    {
        private readonly ITaskAnswerRepository _taskAnswerRepository;

        public TaskAnswerController(ITaskAnswerRepository taskAnswerRepository)
        {
            _taskAnswerRepository = taskAnswerRepository;
        }

        [HttpPost]
        public async Task<ActionResult> AddTaskAnswer(TaskAnswerDTO taskAnswerDto)
        {
            await _taskAnswerRepository.AddTaskAnswerAsync(taskAnswerDto);
            return Ok();
        }
    }
}
