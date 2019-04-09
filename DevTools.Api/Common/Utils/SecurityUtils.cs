using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using DevTools.Api.Common.Consts;
using DevTools.Api.Entities;
using DevTools.Api.Models.Configuration;
using System.Text;
using NgNet.Date;

namespace DevTools.Api.Common.Utils
{
	public static class SecurityUtils
	{
		public static string IssueToken(AppSettings appSettings, User user)
		{
			var tokenHandler = new JwtSecurityTokenHandler();
			var tokenDescriptor = new SecurityTokenDescriptor
			{
				Subject = new ClaimsIdentity(new Claim[]
			  {
					new Claim(JwtClaimTypes.Audience, appSettings.Authentication.Jwt.ValidAudience),
					new Claim(JwtClaimTypes.Issuer, appSettings.Authentication.Jwt.ValidIssuer),
					new Claim(JwtClaimTypes.Id, user.Id.ToString()),
					new Claim(JwtClaimTypes.Name, user.UserName),
					new Claim(JwtClaimTypes.Email, user.Email),
					new Claim(JwtClaimTypes.DateOfIssue, DateTime.Now.ToUnixTimestamp().ToString())
			  }),
				Expires = DateTime.Now.AddHours(appSettings.Authentication.Jwt.ExpiredHours),
				SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.ASCII.GetBytes(appSettings.Authentication.Jwt.IssuerSigningKey)), SecurityAlgorithms.HmacSha256Signature)
			};
			var token = tokenHandler.CreateToken(tokenDescriptor);
			var tokenString = tokenHandler.WriteToken(token);
			return tokenString;
		}
	}
}
