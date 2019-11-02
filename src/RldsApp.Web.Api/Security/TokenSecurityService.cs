using RldsApp.Common;
using RldsApp.Web.Api.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace RldsApp.Web.Api.Security
{
	public class TokenSecurityService : ITokenSecurityService
	{
		private readonly IConfiguration _configuration;
		private readonly ILogger<TokenSecurityService> _logger;

		public TokenSecurityService(IConfiguration configuration, ILogger<TokenSecurityService> logger)
		{
			_configuration = configuration;
			_logger = logger ?? throw new ArgumentNullException();
		}

		public string CreateToken(User user)
		{
			var claimsCollection = new List<Claim>();
			var tokenString = string.Empty;
			var expiration = DateTime.UtcNow.AddMinutes(20).ToLongTimeString();

			var key = Convert.FromBase64String(_configuration["Token:Key"]);
			var credentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256);

			claimsCollection.Add(new Claim(ClaimTypes.Name, user.Login));
			claimsCollection.Add(new Claim(ClaimTypes.GivenName, user.Firstname));
			claimsCollection.Add(new Claim(ClaimTypes.Surname, user.Lastname));

			user.Roles.ForEach(s =>
			{
				claimsCollection.Add(new Claim(ClaimTypes.Role, s.RoleName));
			});

			try
			{
				var tokenOptions = new JwtSecurityToken(
					issuer: _configuration["Token:Issuer"],
					audience: _configuration["Token:Issuer"],
					expires: DateTime.UtcNow.AddMinutes(30),
					signingCredentials: credentials,
					claims: claimsCollection
				);

				tokenString = new JwtSecurityTokenHandler().WriteToken(tokenOptions);

				_logger.LogInformation(Constants.Messages.TokenCreatedMessage);
			}
			catch (Exception ex)
			{
				_logger.LogError(ex.Message);
			}

			return tokenString;
		}
	}
}
