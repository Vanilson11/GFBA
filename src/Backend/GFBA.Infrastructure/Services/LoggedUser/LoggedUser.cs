using GFBA.Domain.Entities;
using GFBA.Domain.Security.Tokens;
using GFBA.Domain.Services.LoggedUser;
using GFBA.Infrastructure.DataAccess;
using Microsoft.EntityFrameworkCore;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace GFBA.Infrastructure.Services.LoggedUser;
internal class LoggedUser : ILoggedUser
{
    private readonly GFBADbContext _context;
    private readonly ITokenProvider _tokenProvider;

    public LoggedUser(GFBADbContext context, ITokenProvider tokenProvider)
    {
        _context = context;
        _tokenProvider = tokenProvider;
    }
    public async Task<Usuario> Get()
    {
        var token = _tokenProvider.GetTokenOnRequest();
        var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
        var jwtSecurityToken = jwtSecurityTokenHandler.ReadJwtToken(token);
        var userIdentifier = jwtSecurityToken.Claims.First(claim => claim.Type == ClaimTypes.Sid).Value;

        return await _context.Usuarios.AsNoTracking().FirstAsync(user => user.Id == Guid.Parse(userIdentifier));
    }
}
