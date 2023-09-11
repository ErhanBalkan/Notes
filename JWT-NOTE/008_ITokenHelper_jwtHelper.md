# ITOKENHELPER ARAYÜZÜ

## ITokenHelper.cs
İnterface olarak oluşturuyoruz çünkü bugün JWT kullanıyoruz yarın farklı bir teknoloji kullanabiliriz.
Klasörlerken bunu JWT dışında yapılması önerilir ama karmaşıklık olmaması için hepsi bir yerde olacak.
```c#
using Core.Entities.Concrete;

namespace Core.Utilities.Security.JWT;
public interface ITokenHelper
{
    AccessToken CreateToken(User user, List<OperationClaim> operationClaims);
}
```
---
## JwtHelper.cs

```c#
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Core.Entities.Concrete;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Core.Utilities.Security.JWT;
public class JwtHelper : ITokenHelper
{
    public IConfiguration Configuration {get;}
    private readonly TokenOptions _tokenOptions;
    private DateTime _accessTokenExpiration;

    public JwtHelper(IConfiguration configuration)
    {
        Configuration = configuration;
        _tokenOptions = Configuration.GetSection("TokenOptions").Get<TokenOptions>();  
        // Microsoft.Extensions.Configuration.Binder - Get metodu için gerekli paket.  
        // Configuration dosyasındaki TokenOptions bilgilerini kendi oluşturduğumuz TokenOptions nesnesi ile bind ederek alıyoruz.
    }

    public AccessToken CreateToken(User user, List<OperationClaim> operationClaims)
    {
        SecurityKey securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_tokenOptions.SecurityKey));
        SigningCredentials signingCredentials = new(securityKey, SecurityAlgorithms.HmacSha512Signature);
        _accessTokenExpiration = DateTime.Now.AddMinutes(_tokenOptions.AccessTokenExpiration);
        var jwt = CreateJwtSecurityToken(_tokenOptions,user,signingCredentials,operationClaims);
        var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
        var token = jwtSecurityTokenHandler.WriteToken(jwt);
        return new AccessToken{
            Token = token,
            Expiration = _accessTokenExpiration
        };

    }

    public JwtSecurityToken CreateJwtSecurityToken
    (
        TokenOptions tokenOptions,
        User user,
        SigningCredentials signingCredentials,
        List<OperationClaim> operationClaims
    )
    {
        var jwt = new JwtSecurityToken(
            issuer: tokenOptions.Issuer,
            audience: tokenOptions.Audience,
            expires: _accessTokenExpiration,
            notBefore: DateTime.Now,
            claims: SetClaims(user, operationClaims),
            signingCredentials: signingCredentials
        );
        return jwt;
    }

    private IEnumerable<Claim> SetClaims(User user, List<OperationClaim> operationClaims){        
        var claims = new List<Claim>
        {
            new(ClaimTypes.Email, user.Email),
            new(ClaimTypes.Name, $"{user.FirstName} {user.LastName}"),
            new(ClaimTypes.NameIdentifier, user.Id.ToString()),
        };
        // Select ile sadece operationClaims nesnesinin Name değerlerini barındıran bir liste döndürür.
        operationClaims.Select(c => c.Name).ToList().ForEach(role => claims.Add(new Claim(ClaimTypes.Role, role)));
        return claims;
    }
}
```