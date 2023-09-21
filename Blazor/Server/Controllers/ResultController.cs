using Blazor.Server.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Blazor.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResultController : ControllerBase
    {
        private readonly IResultRepository _resultRepository;

        public ResultController(IResultRepository resultRepository) => _resultRepository = resultRepository;

        [HttpGet("one")]
        public async Task<IActionResult> GetOne(int id) => Ok(await _resultRepository.GetResultListAsync(id));
    }
}
