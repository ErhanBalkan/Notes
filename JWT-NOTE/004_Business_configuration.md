# BUSİNESS KONFİGÜRASYONU

## IUserService.cs
```c#
using Core.Entities.Concrete;

namespace Business.Abstract;
public interface IUserService
{
    List<OperationClaim> GetClaims(User user);
    void Add(User user);
    User GetByMail(string email);
}
```

IUserDal ile oluşturduğumuz metodu kullanmak için GetClaims metodunu servisimizde de oluşturduk. Ekleme ve mail ile kullanıcı çekme metodumuzu
da yazdık.
---

## UserManager.sc
```c#
using Business.Abstract;
using DataAccess.Abstract;
using Core.Entities.Concrete;

namespace Business.Concrete;
public class UserManager : IUserService
{
    private readonly IUserDal _userDal;

    public UserManager(IUserDal userDal)
    {
        _userDal = userDal;
    }

    public void Add(User user)
    {
        _userDal.Add(user);
    }

    public User GetByMail(string email)
    {
        return _userDal.Get(u => u.Email == email);
    }

    public List<OperationClaim> GetClaims(User user)
    {
        return _userDal.GetClaims(user);
    }
}
```