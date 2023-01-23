# AUTOFAC

## Autofac Nedir ?
`Autofac`, .Net tabanlı bir `IoC` kapsayıcıdır. Sınıflar birbirleriyle etkileşime girdiğinde, boyut ve karmaşıklık olarak büyüdükçe uygulamaların esnek kalmasını sağlayan aralarındaki `bağımlılıkları` yönetir. Katmanlı mimaride `Business` katmanında yazılır.

### Nuget package manager'dan paketleri indirmek
1. Autofac - .NET CLI => `dotnet add package Autofac`
2. Autofac.Extras.DynamicProxy - .NET CLI => `dotnet add package Autofac.Extras.DynamicProxy`
3. Autofac.Extensions.DependencyInjection .NET CLI => `add package Autofac.Extensions.DependencyInjection`

İkinci paketi kurduğumuzda `Castle.Core` yüklenmiş olacak. Bu sayede `Castle.DynamicProxy` namespace’inde yer alan `IInterceptor` gibi yapıları kullanabileceğiz.

Üçüncü paket ise `Program.cs` dosyasında yapılandırma yaparken `AutofacServiceProviderFactory` sınıfını kullanmamızı sağlayacak.

`Business` katmanı altında `DependencyResolvers` adında bir klasör oluşturulur. Bu klasör bizim bağımlılıkları yöneteceğimiz teknolojileri barındıracak biz `autofac` kullanacağımız için onun içinde de `Autofac klasörü` oluşturulur.

`Autofac klasörü` içinde `AutofacBusinessModule` adında bir `class` oluşturulur.
Bu `public` bir `class`'tır ve Module sınıfından miras alır. Bu `module` sınıfı `Autofac` paketine aittir o yüzden `using Autofac;` ile `import` etmemiz gerekir.

`WebAPI` projesinde `program.cs` dosyasında yaptığımız `IOC Container` yapısını `Autofac` ile bu şekilde yaparız. 

## AutofacBusinessModule 
```C#
using Autofac;
public class AutofacBusinessModule : Module
{
    protected override void Load(ContainerBuilder builder)
    { 
        /*
        biri senden IProductService isterse ona bitane ProductManager
        instance'i ver. Tek referans oluştur ve her isteyene aynı referansı ver.
        */
        builder.RegisterType<ProductManager>().As<IProductService>().SingleInstance();
        builder.RegisterType<EfProductDal>().As<IProductDal>().SingleInstance();
    }
}
```
---
## Program.cs Konfigürasyonu
```C#
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Business.DependencyResolvers.Autofac;
// Add services to the container.
// AUTOFAC build
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
builder.Host.ConfigureContainer<ContainerBuilder>(builder => {
    builder.RegisterModule(new AutofacBusinessModule());
});
```
Bu konfigürasyonda `Autofac` kullanmayı bırakıp farklı bir teknoloji kullanacaksak bu kodlarda değişecek 2 yer vardır onlar ;
```C#
new AutofacServiceProviderFactory()
```
ve
```C#
new AutofacBusinessModule()
```

---

## .NET IOC Container yapısını hatırlayalım ;
```C#
builder.Services.AddSingleton<IProductService,ProductManager>();
// Singleton tek referans oluşturur ve heryerde onu verir. içinde veri tutmayan yerlerde kullanılır.
// Constructorda biri IProductService isterse ona ProductManager referansını ver. 
builder.Services.AddSingleton<IProductDal,EfProductDal>();
```

---




