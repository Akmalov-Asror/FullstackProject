using Blazor.Server.Dto;
using Blazor.Server.Repository;
using MailKit.Security;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using MimeKit.Text;
using SmtpClient = MailKit.Net.Smtp.SmtpClient;

namespace Blazor.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository) => _userRepository = userRepository;

        [HttpPost]
        public async Task<IActionResult> Create(UserDTO userDto)
        {

            var checkUser = await _userRepository.GetUserByIdAsync(userDto.Email);
            if (checkUser == null)
            {
                return Ok(await _userRepository.AddUserAsync(userDto));
            }
            return BadRequest("User already exists");
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDTO loginDto)
        {

            var checkUser = await _userRepository.Login(loginDto);
            if (checkUser == null)
            {
                return BadRequest("Incorrect Email or Password");
            }
            return Ok(checkUser);
        }

        [HttpGet("course")]
        public async Task<IActionResult> GetuserCourse(string email)
        {
            var userCourses =  await _userRepository.GetUserCourses(email);

            return Ok(userCourses);
        }

         [HttpPost("email")]
        public async Task<IActionResult> ForgetPassword(EmailDTO emailDto)
        {
           var async = await _userRepository.GetUserByIdAsync(emailDto.Email);

            if (async == null)
            {
                return BadRequest("User Not Registered");
            }

            Random random = new Random();
            int otp = random.Next(10000000, 99999999);

            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse("ismoilnigmatov98@gmail.com"));
            email.To.Add(MailboxAddress.Parse(emailDto.Email));
            email.Subject = "Your verification code";
            email.Body = new TextPart(TextFormat.Html) { Text = "Your verification code is " + otp};

            var smpt = new SmtpClient();
            await smpt.ConnectAsync("smtp.gmail.com", 587, SecureSocketOptions.StartTls);
            await smpt.AuthenticateAsync("ismoilnigmatov98@gmail.com", "jrmljzzmtlbsynkk");
            await smpt.SendAsync(email);
            await smpt.DisconnectAsync(true);

            async.Password = otp.ToString();

            await _userRepository.UpdateUserAsync(async);

            return Ok();
        }

        [HttpPost("course")]
        public async Task<IActionResult> AddCourse(UserCourseDTO userCourseDto)
        {
            await _userRepository.AddCourse(userCourseDto);
            return Ok();
        }
    }
}
