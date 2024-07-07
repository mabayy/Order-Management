using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Order_Management.Models;

namespace Order_Management.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly AppDBContext _context;

        public UserController(AppDBContext context)
        {
            _context = context;
        }

        // POST: api/user/register
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] UserProfile model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Hash the password
            model.Password = HashPassword(model.Password);

            _context.UserProfile.Add(model);
            await _context.SaveChangesAsync();

            return Ok(new { Message = "User registered successfully" });
        }

        // POST: api/user/login
        [HttpPost("login")]
        public IActionResult Login([FromBody] Login model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Find the user by email
            var user = _context.UserProfile.SingleOrDefault(u => u.Email == model.Email);

            // Verify the password
            if (user != null && VerifyPassword(model.Password, user.Password))
            {
                return Ok(new { Message = "Login successful" });
            }

            return Unauthorized(new { Message = "Invalid login attempt" });
        }

        // Helper method to hash password
        private string HashPassword(string password)
        {            
            return BCrypt.Net.BCrypt.HashPassword(password);
        }

        // Helper method to verify password
        private bool VerifyPassword(string password, string hashedPassword)
        {           
            return BCrypt.Net.BCrypt.Verify(password, hashedPassword);
        }
    }
}
