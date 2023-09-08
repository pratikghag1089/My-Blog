using Microsoft.AspNetCore.Identity;

namespace Blog.API.Services.Contract
{
    public interface ITokenService
    {
        string CreateJwtToken(IdentityUser user, List<string> roles);
    }
}
