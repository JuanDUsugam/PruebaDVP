using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using PruebaDVP.Application.Interfaces.Infrastructure.Identity;
using PruebaDVP.Application.Models.Identity;
using PruebaDVP.Domain.Usuarios;
using PruebaDVP.Infra.Persistence.SQLSever.Context;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace PruebaDVP.Infra.Identity
{
    public class JwtGenerator : IJwtGenerator
    {
        private readonly JwtSettings _jwtSettings;
        private readonly AppDbContext _appDbContext;

        public JwtGenerator(IOptions<JwtSettings> jwtSettings, AppDbContext appDbContext)
        {
            _jwtSettings = jwtSettings.Value;
            _appDbContext = appDbContext;
        }

        public string CreateToken(Usuario usuario)
        {
            var jwtTokenHandler = new JwtSecurityTokenHandler();
            var symmetricSecuriyKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_jwtSettings.Key));

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim("userId", usuario.Identificador),
                    new Claim("nombreUsuario", usuario.NombreUsuario)

                }),
                Expires = DateTime.UtcNow.Add(_jwtSettings.ExpireTime),
                SigningCredentials = new SigningCredentials(symmetricSecuriyKey, SecurityAlgorithms.HmacSha256Signature),
            };

            var token = jwtTokenHandler.CreateToken(tokenDescriptor);
            return jwtTokenHandler.WriteToken(token);

        }
    }
}
