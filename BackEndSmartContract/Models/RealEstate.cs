using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace BackEndSmartContract.Models
{
	public class RealEstate
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int? ID { get; set; }
		public string Address { get; set; }
		public int RentFee { get; set; }
		public int RentDurationDays { get; set; }
		public int RentPaymentSchedule { get; set; }
		public float SqMtrs { get; set; }
		public string Description { get; set; }
		public int Rooms { get; set; }
		public int BedRoomQty { get; set; }
		public int BathRoomQty { get; set; }
		public bool Garage { get; set; }
		public bool Available { get; set; }
		public User User { get; set; }
	}
}
