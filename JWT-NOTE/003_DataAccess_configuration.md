# DATAACCESS KONFİGÜRASYONU

## IUserDal.cs
```c#
using Core.DataAccess;
using Core.Entities.Concrete;

namespace DataAccess.Abstract;
public interface IUserDal : IEntityRepository<User>
{
    List<OperationClaim> GetClaims(User user);
}
```

IEntityRepository'e ek olarak biz kendimiz bir de `GetClaims` adında bir metot oluşturduk. Bu metot ile verilen kullanıcının claim'lerine
ulaşabileceğiz.
---

## EfUserDal.cs
```c#
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Context.SqlServer;
using Core.Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework;
public class EfUserDal : EfEntityRepository<User, NorthwindContextBySqlServer>, IUserDal
{
    public List<OperationClaim> GetClaims(User user)
    {
        using NorthwindContextBySqlServer context = new();
        IQueryable<OperationClaim> result = 
        from operationClaim in context.OperationClaims
        join UserOperationClaim in context.UserOperationClaims
        on operationClaim.Id equals UserOperationClaim.OperationClaimId
        where UserOperationClaim.UserId == user.Id
        select new OperationClaim{
            Id = operationClaim.Id,
            Name = operationClaim.Name
        };

        return result.ToList();
    }
}
```
Burada da zaten EfEntityRepository'imiz vardı biz IUserDal ile kendimiz User'a özel bir metot eklemiştik o metodu override ettik ve yazdık.
