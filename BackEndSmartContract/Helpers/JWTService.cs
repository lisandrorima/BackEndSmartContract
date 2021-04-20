using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;

namespace BackEndSmartContract.Helpers
{
	
	public class JWTService
	{
		private string SecureKey = "This is the private key used to encrypt JWT";

		public string Generate(int id)
		{
			var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(SecureKey));
			var credentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256Signature);
			var header = new JwtHeader(credentials);
			var payload = new JwtPayload(id.ToString(), null, null, null, DateTime.Now.AddMinutes(60));

			var securityToken = new JwtSecurityToken(header, payload);

			return new JwtSecurityTokenHandler().WriteToken(securityToken);
		}

		public JwtSecurityToken Verify(string jwt)
		{
			JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();

			var key = Encoding.ASCII.GetBytes(SecureKey);
			tokenHandler.ValidateToken(jwt,
				new TokenValidationParameters
				{
					IssuerSigningKey = new SymmetricSecurityKey(key),
					ValidateIssuerSigningKey = true,
					ValidateIssuer = false,
					ValidateAudience = false
				},
				out SecurityToken validatedToken);

			return (JwtSecurityToken)validatedToken;
		}

	}
}
