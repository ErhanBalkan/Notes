# FluentValidation ile Doğrulama
Doğrulama işlemlerini yapmamızı sağlayan bir pakettir.
Eğer bir nesne doğrulamadan geçer ise `business` kodlarından geçer.

1. `Business` katmanında yeni bir `ValidationRules` adında `klasör` oluşturulur.
Bu klasör bizim doğrulama teknolojilerimizi barındıracak.
2. Onun içinde de `FluentValidation` adında klasör oluşturulur.
3. Onun içinde de hangi nesne için doğrulama yapılacaksa sonuna `Validator` eklenecek şekilde bir class oluşturulur. `ör : ProductValidator`
```C#
using Entities.Concrete;
using FluentValidation;
namespace Business.ValidationRules.FluentValidation;
public class ProductValidator : AbstractValidator<Product>{
    // Kurallar Constructor içerisine yazılır.
    public ProductValidator(){
        // Product nesnesinin ProductName özelliği minimum 2 karakter olmalıdır.
        RuleFor(p => p.ProductName).MinimumLength(2);
        // Product nesnesinin ProductName özelliği boş geçilemez.
        RuleFor(p => p.ProductName).NotEmpty();
        // Product nesnesinin UnitPrice özelliği boş geçilemez.
        RuleFor(p => p.UnitPrice).NotEmpty();
        // Product nesnesinin UnitPrice özelliği 0'dan büyük olmalıdır.
        RuleFor(p => p.UnitPrice).GreaterThan(0);
        // Product nesnesinin CategoryId özelliği 1 ise UnitPrice değeri 10'dan büyük olmalıdır.
        RuleFor(p => p.UnitPrice).GreaterThanOrEqualTo(10).When(p => p.CategoryId == 1);
        // Hazırda bulunmayan kendi özel kuralımızı yazmak istersek ;
        RuleFor(p => p.ProductName).Must(StartWithA).WithMessage("Ürünler A harfi ile başlamalıdır.");
    }
    // A ile başlıyorsa true başlamıyorsa false dönecek.
    private bool StartWithA(string arg) => return arg.StartsWith("A");
}
```

Doğrulamalarımızı bu sınıf içinde gerçekleştiririz.

## Nasıl Kullanılır ?

```C#
// FluentValidaton için kötü kod yazımı
// Product sınıfı için bir doğrulama context'i oluşturduk ve parametresine Product nesnesi verdik.
var context = new ValidationContext<Product>(product);
ProductValidator productValidator = new ProductValidator();
var result = productValidator.Validate(context);
if (!result.IsValid)
    throw new ValidationException(result.Errors);
```

Bu kodu birçok yerde kullanabiliriz ve bu kodda değişen sadece 2 yer var onlar
da `Product` olan yerler ve `ProductValidator` kısmıdır.
## Temiz kod yazmaya başlayalım 
1. `Core` katmanında `CrossCuttingConcerns` adında bir klasör oluşturulur.
Bu klasör bizim `doğrulama`, `loglama`,`yetkilendirme` vb. işlemlerimizi tutacak.
2. O klasörün altında `Validation` adında bir klasör oluşturulur.
3. O klasör içinde de `ValidationTool` adında bir class oluşturulur.
`(FluentValidation klasörü oluşturulup onun içinde de bu class oluşturulabilir.)`

```C#
using FluentValidation;
namespace Core.CrossCuttingConcerns.Validation;
public static class ValidationTool{
    public static void Validate(IValidator validator, object entity){
        // Product sınıfı için bir doğrulama context'i oluşturduk ve parametresine Product nesnesi verdik.
        var context = new ValidationContext<object>(entity);
        var result = validator.Validate(context);
        if (!result.IsValid)
            throw new ValidationException(result.Errors);
    }
}
```
`IValidator` FluentValidation içinde bir Interface'dir. Bizim oluşturduğumuz
`ProductValidator` sınıfı `AbstractValidator` sınıfından implemente ediyordu.
Bu `AbstractValidator` sınıfı da `IValidator`'dan implemente ediliyor. Böylece `IValidator` bizim `Validator` sınıfımızın referansını tutabilir ve içerisinde `Validate` metodu da mevcut.

Bu işlemlerden sonra Business içerisinde şu şekilde kullanabiliriz ;
```C#
ValidationTool.Validate(new ProductValidator(),product);
```