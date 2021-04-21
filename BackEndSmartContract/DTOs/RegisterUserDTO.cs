using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEndSmartContract.DTOs
{
	public class RegisterUserDTO
	{
		
			public int PersonalID { get; set; }
			public string Email { get; set; }
			public string Name { get; set; }
			public string Surname { get; set; }
			public string Password { get; set; }
			public string WalletAddress { get; set; }
		
	}
}
