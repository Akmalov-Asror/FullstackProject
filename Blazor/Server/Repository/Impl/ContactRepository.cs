using Blazor.Server.Data;
using Blazor.Shared;
using Task = System.Threading.Tasks.Task;

namespace Blazor.Server.Repository.Impl
{
    public class ContactRepository : IContactRepository
    {
        private readonly AppDbContext _context;

        public ContactRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddTaskAnswerAsync(Contact contact)
        { 
            _context.Contact.Add(contact);
           await _context.SaveChangesAsync();
        }
    }
}
