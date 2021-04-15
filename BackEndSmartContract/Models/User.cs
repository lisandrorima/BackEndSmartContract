using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace BackEndSmartContract.Models
{
	public class User
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.None)]
		public int ID{ get; set; }
		public int PersonalID { get; set; }
		public string Email { get; set; }

		[Column(TypeName = "NVARCHAR(100)")]
		public string Name { get; set; }

		[Column(TypeName = "NVARCHAR(100)")]
		public string Surname { get; set; }

		[Column(TypeName = "NVARCHAR(42)")]
		public string WalletAdress { get; set; }
	}
}
