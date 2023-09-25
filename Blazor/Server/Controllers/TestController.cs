using Blazor.Server.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Blazor.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TestController : ControllerBase
{
    private readonly ITestRepository _testRepository;

    public TestController(ITestRepository testRepository) => _testRepository = testRepository;

    [HttpGet("one")]
    public async Task<IActionResult> GetTest(int id) => Ok(await _testRepository.GetTestListAsync(id));

}
