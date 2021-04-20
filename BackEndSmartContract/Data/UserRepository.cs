using BackEndSmartContract.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEndSmartContract.Data
{
	public class UserRepository : IUserRepository
	{
		private readonly SmartPropDbContext _context;

		public UserRepository(SmartPropDbContext context)
		{
			_context = context;
		}
		public User Create(User user)
		{
			_context.Users.Add(user);
			user.ID = _context.SaveChanges();

			return user;
		}

		public User GetByEmail(string email)
		{
			return _context.Users.FirstOrDefault(u => u.Email==email);
		}
	}
}
