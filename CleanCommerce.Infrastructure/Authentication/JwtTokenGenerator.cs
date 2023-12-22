using CleanCommerce.Application.Common.Interfaces.Authentication;
using CleanCommerce.Application.Common.Interfaces.Services;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace CleanCommerce.Infrastructure.Authentication
{
    public class JwtTokenGenerator : IJwtTokenGenerator
    {
        private readonly IDateTimeProvider _dateTimeProvider;
        private readonly JwtSettings _jwtSettings;
        public JwtTokenGenerator(IDateTimeProvider dateTimeProvider, IOptions<JwtSettings> jwtOptions)
        {
            _dateTimeProvider = dateTimeProvider;
            _jwtSettings = jwtOptions.Value;
        }

        public string GenerateJwtToken(Guid userId,
                                       string firstName,
                                       string lastName,
                                       List<string> roles)
        {
            var signingCredentials = new SigningCredentials(
                new SymmetricSecurityKey(Encoding.Unicode.GetBytes(_jwtSettings.Secret)),
                SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, userId.ToString()),
                new Claim(JwtRegisteredClaimNames.GivenName, firstName),
                new Claim(JwtRegisteredClaimNames.FamilyName, lastName)
            };
            roles.ForEach(r => claims.Add(new Claim(ClaimTypes.Role, r)));

            var securityToken = new JwtSecurityToken(issuer: _jwtSettings.Issuer,
                                                     audience: _jwtSettings.Audience,
                                                     expires: _dateTimeProvider.UtcNow.AddMinutes(_jwtSettings.TokenExpiryMinutes),
                                                     claims: claims,
                                                     signingCredentials: signingCredentials);

            return new JwtSecurityTokenHandler().WriteToken(securityToken);
        }
    }
}
