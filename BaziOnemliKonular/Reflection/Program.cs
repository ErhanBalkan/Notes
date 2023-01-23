using System.Reflection;

var type = typeof(DortIslem); // Çalışacağımız tipi belirttik ve aldık

// DortIslem dortIslem = (DortIslem)Activator.CreateInstance(type,5,4); // instance oluşturduk- gelen tipe göre Çalışma anında new'ledik.
// DortIslem döneceğini bildiğimiz için cast ettik.

// System.Console.WriteLine(dortIslem.Topla2()); 

var instance = Activator.CreateInstance(type,5,4);

// var result = instance.GetType().GetMethod("Topla2").Invoke(instance, null);

/*
Ama üstteki gibi instance tipini her zaman bilemeyebiliriz.
böylece instance'ın tipini aldık GetType()
Daha sonra GetMethod ile parametre olarak verdiğimiz metodunu çağırdık.
Ve daha sonra Invoke metodu ile çalıştırdık parametredeki null metodun parametresinin olmadığını belirtir.
parametrede tekrar instance verme sebebimiz GetMethod metodunun sadece metot bilgisine eriştiği için
yani neresi için o metodu çalıştıracağını bilmez ve tekrar instance bilgisini bekler.
Örnekleyelim ;
*/

MethodInfo methodInfo = instance.GetType().GetMethod("Topla2");
// GetMethod sadece methodinfo alır.
System.Console.WriteLine(methodInfo.Invoke(instance,null));
// Burası da metodu instance için çalıştır parametresi yok anlamı taşır.

// TÜM METODLARA ERİŞMEK.
var metodlar = type.GetMethods();
foreach (var info in metodlar)
{
    System.Console.WriteLine($"Metod adı : {info.Name}");
    // Metodların parametrelerine ulaşmak
    foreach (var parameterInfo in info.GetParameters())
    {
        System.Console.WriteLine($"Parametre : {parameterInfo.Name}");
    }
}

class DortIslem
{
    int _sayi1;
    int _sayi2;

    public DortIslem(int sayi1, int sayi2)
    {
        _sayi1 = sayi1;
        _sayi2 = sayi2;
    }

    public int Topla(int sayi1, int sayi2)
    {
        return sayi1 + sayi2;
    }
    public int Carp(int sayi1, int sayi2)
    {
        return sayi1 * sayi2;
    }

    public int Topla2()
    {
        return _sayi1 + _sayi2;
    }
    public int Carp2()
    {
        return _sayi1 * _sayi2;
    }
}