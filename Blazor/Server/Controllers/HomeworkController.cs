using Blazor.Server.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Blazor.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeworkController : ControllerBase
    {
        private readonly IHomeworkRepository _homeworkRepository;

        public HomeworkController(IHomeworkRepository homeworkRepository)
        {
            _homeworkRepository = homeworkRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var homeworks = await _homeworkRepository.GetAllHomeworkAsync();
            return Ok(homeworks);
        }

        [HttpGet("one")]
        public async Task<IActionResult> GetOne(int id)
        {
            var homework = await _homeworkRepository.GetHomeworkByIdAsync(id);
            return Ok(homework);
        }
        [HttpGet("task")]
        public async Task<IActionResult> GetHomeworkByTask(int id)
        {
            var homework = await _homeworkRepository.GetHomeworkByTaskId(id);
            return Ok(homework);
        }
    }
}
