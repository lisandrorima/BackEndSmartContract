using BackEndSmartContract.Data;
using BackEndSmartContract.Helpers;
using BackEndSmartContract.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEndSmartContract.Controllers
{
	[Route("api")]
	[ApiController]
	public class AuthController : ControllerBase
	{
		private readonly IUserRepository _repository;
		private readonly JWTService _jwtService;

		public AuthController(IUserRepository repository, JWTService jwtService)
		{
			_repository = repository;
			_jwtService = jwtService;
		}

		[HttpPost("register")]
		public IActionResult Register(User dtoUser)
		{
			var user = dtoUser;
			user.Password = BCrypt.Net.BCrypt.HashPassword(dtoUser.Password);
			_repository.Create(user);

			return Ok("success");
		}

		[HttpPost("login")]
		public IActionResult Login(LoginDTO dto)
		{

			var user = _repository.GetByEmail(dto.Email);


			if (user == null) return BadRequest("Invalid Credentials");

			if (!BCrypt.Net.BCrypt.Verify(dto.Password, user.Password))
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
	}
}
