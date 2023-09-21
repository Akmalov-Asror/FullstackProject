using Blazor.Server.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Blazor.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CourseController : ControllerBase
{
    private readonly ICourseRepository _courseRepository;

    public CourseController(ICourseRepository courseRepository)
    {
        _courseRepository = courseRepository;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var courses = await _courseRepository.GetAll();
        return Ok(courses);
    }

    [HttpGet("one")]
    public async Task<IActionResult> GetEducation(int id)
    {
        var course = await _courseRepository.Get(id);
        return Ok(course);
    }
}