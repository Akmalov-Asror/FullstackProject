using Blazor.Server.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Blazor.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeedbackController : ControllerBase
    {
        private readonly IFeedbackRepository _feedbackRepository;

        public FeedbackController(IFeedbackRepository feedbackRepository) => _feedbackRepository = feedbackRepository;

        [HttpGet("one")]
        public async Task<IActionResult> GetOne(int id) => Ok(await _feedbackRepository.GetFeedbackListAsync(id));
    }
}
