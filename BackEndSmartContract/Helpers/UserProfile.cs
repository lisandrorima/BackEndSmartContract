using AutoMapper;
using BackEndSmartContract.DTOs;
using BackEndSmartContract.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEndSmartContract.Helpers
{
	public class UserProfile : Profile
	{
	
			public UserProfile()
			{
				CreateMap<RegisterUserDTO, User>();
				CreateMap<LoginDTO, User>();
				CreateMap<LoginDTO, User>().ReverseMap();
			}
		
	}
}
