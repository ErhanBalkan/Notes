# ENTİTY KONFİGÜRASYONU

## User.cs
```c#
namespace Core.Entities.Concrete;
public class User : IEntity
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public byte[] PasswordSalt { get; set; }
    public byte[] PasswordHash { get; set; }
    public bool Status { get; set; }
}
```

## OperationClaim.cs
```c#
namespace Core.Entities.Concrete;
public class OperationClaim : IEntity
{
    public int Id { get; set; }
    public string Name { get; set; }
}
```

## UserOperationClaim.cs
```c#
namespace Core.Entities.Concrete;
public class UserOperationClaim : IEntity
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public int OperationClaimId { get; set; }
}
```