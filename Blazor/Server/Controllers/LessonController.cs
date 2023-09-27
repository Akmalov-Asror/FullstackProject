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
    public async Task<IActionResult> GetOne(int id)
    {
        var lessons = await _lessonRepository.GetLessonsByCourseId(id);
        return Ok(lessons);
    }


    [HttpGet("lesson")]
    public async Task<IActionResult> GetOneLesson(int id)
    {
        var lesson = await _lessonRepository.GetLessonById(id);
        return Ok(lesson);
    }


    [HttpGet("task")]
    public async Task<IActionResult> GetLessonAndTask(int id)
    {
        var lessons = await _lessonRepository.GetLessonAndTaskByCourseId(id);
        return Ok(lessons);
    }
}