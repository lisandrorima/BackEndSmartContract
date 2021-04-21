using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BackEndSmartContract.Models;
using Microsoft.AspNetCore.Cors;
using BackEndSmartContract.DTOs;
using AutoMapper;
using BackEndSmartContract.Helpers;
using BackEndSmartContract.Data;



namespace BackEndSmartContract.Controllers
{
    [Route("api")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly SmartPropDbContext _context;
        private readonly IMapper _mapper;
        private readonly JWTService _jwtService;


        public UserController(SmartPropDbContext context, IMapper mapper, JWTService jwtService)
        {
            _context = context;
            _mapper = mapper;
            _jwtService = jwtService;

        }

        // GET: api/User
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            return await _context.Users.ToListAsync();
        }

        // GET: api/User/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(int? id)
        {
            var user = await _context.Users.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }


        [HttpGet("GetAuthUser")]
        public async Task<ActionResult<User>> GetAuthUser()
        {
            try
            {
                var jwt = Request.Cookies["jwt"];
                var token = _jwtService.Verify(jwt);

                int userId = Convert.ToInt32(token.Issuer);

                var user = await _context.Users.FindAsync(userId);

                return Ok(user);
            }
            catch (Exception _)
            {
                return Unauthorized();
            }

        }

        // PUT: api/User/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(int? id, User user)
        {
            if (id != user.ID)
            {
                return BadRequest();
            }

            _context.Entry(user).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/User
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]

        public async Task<ActionResult<User>> PostUser([FromBody] User user)
        {
            Response.Headers.Add("Access-Control-Allow-Origin", "*");

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUser", new { id = user.ID }, user);
        }



        // DELETE: api/User/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int? id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserExists(int? id)
        {
            return _context.Users.Any(e => e.ID == id);
        }


        [HttpPost("register")]
        public async Task<ActionResult<User>> Register(RegisterUserDTO userdto)
        {

            var user = _mapper.Map<User>(userdto);
            user.Password = BCrypt.Net.BCrypt.HashPassword(userdto.Password);
            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUser", new { id = user.ID }, user);
        }


        [HttpPost("login")]
        public IActionResult Login(LoginDTO userdto)
        {


            var user = _context.Users.Where(u => u.Email == userdto.Email).FirstOrDefault();


            if (user == null) return BadRequest("Invalid Credentials");

            if (!BCrypt.Net.BCrypt.Verify(userdto.Password, user.Password))
            {
                return BadRequest("Invalid Credentials");
            }

            var jwt = _jwtService.Generate(user.ID.Value);

            Response.Cookies.Append("jwt", jwt, new CookieOptions
            {
                HttpOnly = true
            });
            return Ok("success");
        }


        [HttpPost("logout")]
        public  IActionResult Logout()
        {
           Response.Cookies.Delete("jwt");
            return Ok("Succesfully disconected");
        }




    }
}
