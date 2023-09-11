# TOKENOPTİONS
Configuration dosyasındaki bilgileri bu sınıf ile bind ederek alacağız.

## TokenOptions.cs
```c#
namespace Core.Utilities.Security.JWT;
public class TokenOptions
{
    public string Audience { get; set; }
    public string Issuer { get; set; }
    public int AccessTokenExpiration { get; set; }
    public string SecurityKey { get; set; }
}
```

## appsettings.json
API katmanındaki dosyamız.
```json
{
  "TokenOptions":{
    "Audience": "www.erhan.com",
    "Issuer": "www.erhan.com",
    "AccessTokenExpiration": 10,
    "SecurityKey": "mysecretsecuritykeymysecretsecuritykey"
  },
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*"
}

```