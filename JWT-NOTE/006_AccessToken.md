# ACCESSTOKEN

## AccessToken.cs
```c#
namespace Core.Utilities.Security.JWT;
public class AccessToken
{
    public string Token { get; set; } 
    public DateTime Expiration { get; set; } // Geçerlilik süresi
}
```
---
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
## 