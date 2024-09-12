using Microsoft.Extensions.Options;

namespace QuanhDinner.Infrastructure.Authentication
{
    public class JWTTokenGenerator : IJWTTokenGenerator
    {
        private readonly IDateTimeProvider _dateTimeProvider;
        private readonly JWTSettings _jwtSettings;

        public JWTTokenGenerator(
            IDateTimeProvider dateTimeProvider,
            IOptions<JWTSettings> jwtOptions)
        {
            _dateTimeProvider = dateTimeProvider;
            _jwtSettings = jwtOptions.Value;
        }

        public string GenerateToken(Guid userId, string firstName, string lastName)
        {
            var signingCredentials = new SigningCredentials(
                new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(_jwtSettings.Secret)),
                SecurityAlgorithms.HmacSha256);

            var clamis = new[]
            {
                new Claim(JwtRegisteredClaimNames.Name, userId.ToString()),
                new Claim(JwtRegisteredClaimNames.GivenName, firstName),
                new Claim(JwtRegisteredClaimNames.FamilyName, lastName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            };

            var securityToken = new JwtSecurityToken(
                issuer: _jwtSettings.Issuer,
                expires: _dateTimeProvider.UTCNow.AddMinutes(_jwtSettings.ExpiryMinutes),
                claims: clamis,
                signingCredentials: signingCredentials,
                audience: _jwtSettings.Audience);

            return new JwtSecurityTokenHandler().WriteToken(securityToken);
        }
    }
}
