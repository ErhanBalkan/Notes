# IAUTHSERVİCE AND AUTHMANAGER

## IAuthService.cs
```c#
using Core.Entities.Concrete;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Security.JWT;
using Entities.DTOs;

namespace Business.Abstract;
public interface IAuthService
{
    IDataResult<User> Register(UserForRegisterDto userForRegisterDto);
    IDataResult<User> Login(UserForLoginDto userForLoginDto);
    IResult UserExists(string email);
    IDataResult<AccessToken> CreateAccessToken(User user);
}
```
Hash oluşturmak için bir helper yazacağız.
## HashingHelper.cs
```c#
using System.Security.Cryptography;
using System.Text;

namespace Core.Utilities.Security.Hashing;
public class HashingHelper
{
    public static void CreatePasswordHash
    (
        string password,
        out byte[] passwordHash,
        out byte[] passwordSalt
    ){
        using var hmac = new HMACSHA512();
        passwordSalt = hmac.Key;
        passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
    }

    public static bool VerifyPasswordHash
    (
        string password,
        byte[] passwordHash,
        byte[] passwordSalt
    ){
        using var hmac = new HMACSHA512(passwordSalt);
        var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
        for(int i = 0; i < computedHash.Length; i++){
            if(computedHash[i] != passwordHash[i])
                return false;
        }
        return true;
    }
}
```

## AuthManager.cs
```c#
using Business.Abstract;
using Core.Entities.Concrete;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete.Error;
using Core.Utilities.Results.Concrete.Success;
using Core.Utilities.Security.Hashing;
using Core.Utilities.Security.JWT;
using Entities.DTOs;

namespace Business.Concrete;
public class AuthManager : IAuthService
{
    private readonly IUserService _userService;
    private readonly ITokenHelper _tokenHelper;

    public AuthManager(IUserService userService, ITokenHelper tokenHelper)
    {
        _userService = userService;
        _tokenHelper = tokenHelper;
    }

    public IDataResult<AccessToken> CreateAccessToken(User user)
    {
        var claims = _userService.GetClaims(user);
        var accessToken = _tokenHelper.CreateToken(user, claims);
        return new SuccessDataResult<AccessToken>(accessToken,"AccessToken created.");
    }

    public IDataResult<User> Login(UserForLoginDto userForLoginDto)
    {
        var userToCheck = _userService.GetByMail(userForLoginDto.Email);
        if(userToCheck == null)
            return new ErrorDataResult<User>("User not found.");
        if(!HashingHelper.VerifyPasswordHash(userForLoginDto.Password,userToCheck.PasswordHash,userToCheck.PasswordSalt))
            return new ErrorDataResult<User>("the password is incorrect.");
        return new SuccessDataResult<User>(userToCheck, "Login is successful.");
    }

    public IDataResult<User> Register(UserForRegisterDto userForRegisterDto)
    {
        byte[] passwordHash, passwordSalt;
        HashingHelper.CreatePasswordHash(userForRegisterDto.Password, out passwordHash, out passwordSalt);
        User user = new()
        {
             Email = userForRegisterDto.Email,
             FirstName = userForRegisterDto.FirstName,
             LastName = userForRegisterDto.LastName,
             PasswordHash = passwordHash,
             PasswordSalt = passwordSalt,
             Status = true
        };
        _userService.Add(user);
        return new SuccessDataResult<User>(user, "Register is successful.");
    }

    public IResult UserExists(string email)
    {
        if(_userService.GetByMail(email) != null)
            return new ErrorResult("User exists.");
        return new SuccessResult();
    }
}
```