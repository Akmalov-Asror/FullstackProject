using Blazor.Server.Data;
using Blazor.Server.Dto;
using Blazor.Shared;
using Microsoft.EntityFrameworkCore;
using Task = System.Threading.Tasks.Task;

namespace Blazor.Server.Repository.Impl
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;
        public UserRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<User>> GetAllUsersAsync()
        {
            return await _context.User.ToListAsync();
        }

        public async Task<User> GetUserByIdAsync(string email)
        {
            var userFind =
                await _context.User.FirstOrDefaultAsync(u =>
                    u.Email == email);
            return userFind;
        }

        public async Task<User> AddUserAsync(UserDTO userDto)
        {
            User user = new User();
            user.FullName = userDto.FullName;
            user.Email = userDto.Email;
            user.Password = userDto.Password;

            _context.User.Add(user);
            await _context.SaveChangesAsync();

            return user;
        }

        public async Task UpdateUserAsync(User user)
        {
            var firstOrDefaultAsync = await _context.User.FirstOrDefaultAsync(u => u.Id == user.Id);

            if (firstOrDefaultAsync != null)
            {
                firstOrDefaultAsync.FullName = user.FullName;
                firstOrDefaultAsync.Email = user.Email;
                firstOrDefaultAsync.Password = user.Password;
                _context.Entry(firstOrDefaultAsync).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteUserAsync(int id)
        {
            var user = await _context.User.FindAsync(id);
            if (user != null)
            {
                _context.User.Remove(user);
                await _context.SaveChangesAsync();
            }
        }

        public Task<User> Login(LoginDTO loginDto)
        {
            var user = _context.User.FirstOrDefaultAsync(u => u.Email == loginDto.Email && u.Password == loginDto.Password);

            return user;
        }

        public async Task AddCourse(UserCourseDTO userCourseDto)
        {
            var async = await _context.User.Include(e => e.Courses).FirstOrDefaultAsync(e => e.Email == userCourseDto.Email);
            var courses = async.Courses;
            var firstOrDefaultAsync = await _context.Course.FirstOrDefaultAsync(c => c.Id == userCourseDto.CourseId);
            courses.Add(firstOrDefaultAsync);
            async.Courses = courses;
            _context.Entry(async).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task<List<Course>> GetUserCourses(string email)
        {
            var user = await _context.User
                .Include(e => e.Courses)
                .FirstOrDefaultAsync(e => e.Email == email) ?? throw new BadHttpRequestException("User Not found");

            List<Course> courseDtos = user.Courses.Select(course => new Course()
            {
                Id = course.Id,
                ImageUrl = course.ImageUrl,
                Title = course.Title,
                Description = course.Description,
                Price = course.Price
            }).ToList();

            return courseDtos;
        }
    }
}
