using Blazor.Server.Data;
using Blazor.Shared;
using Microsoft.EntityFrameworkCore;

namespace Blazor.Server.Repository.Impl
{
    public class FeedbackRepository : IFeedbackRepository
    {
        private readonly AppDbContext _context;
        public FeedbackRepository(AppDbContext context) => _context = context;
        public async Task<List<Feedback>> GetFeedbackListAsync(int educationId) => await _context.Feedback.Include(e => e.Education).Include(u => u.User).Where(f=> f.Education.Id== educationId).ToListAsync();
    }
}
