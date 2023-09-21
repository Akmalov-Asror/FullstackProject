using Blazor.Server.Repository;
using Blazor.Shared;
using Microsoft.AspNetCore.Mvc;

namespace Blazor.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IContactRepository _contactRepository;

        public ContactController(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }

        [HttpPost]
        public async Task<IActionResult> AddContact(Contact contact)
        {
            await _contactRepository.AddTaskAnswerAsync(contact);
            return Ok();
        }
    }
}
