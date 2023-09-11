# LOGİN VE REGİSTER İÇİN DTO 

## UserForLoginDto.cs
```c#
using Core.Entities;

namespace Entities.DTOs;
public class UserForLoginDto : IDto
{
    public string Email { get; set; }
    public string Password { get; set; }
}
```
---
## UserForRegisterDto.cs
```c#
using Core.Entities;

namespace Entities.DTOs;
public class UserForRegisterDto : IDto
{
    public string Email { get; set; }
    public string Password { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
}
```

Bunları API katmanında Login ve Register operasyonlarını yazarken kullanacağız.