using Blazor.Server.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Blazor.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class LessonController : ControllerBase
{ 
    private readonly ILessonRepository _lessonRepository;
    public LessonController(ILessonRepository lessonRepository) => _lessonRepository = lessonRepository;
    [HttpGet("one")]
    public async Task<IActionResult> GetAll(int id) => Ok(await _lessonRepository.GetLessonByCourseIdAsync(id));
}