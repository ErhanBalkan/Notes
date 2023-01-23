# Metotlar
## Metot Nedir ?
Metotları programı küçük parçalara ayrıştırmak için kullanırız. Büyük bir işi tek bir metot içinde yazmak yerine küçük parçalara ayırarak yazmak daha doğru bir yaklaşımdır.

Bu bizi hem kod tekrarından kurtarır hem de daha okunabilir kod parçaları yazmamızı sağlar. Metotlar tek başlarına kullanılabilen yapılar değildir. Bir sınıf içerisinde yazılmalı ve ancak sınıfın nesnesi aracılığıyla erişilebilir olmalıdır. (Static sınıf metodlarına sinifAdi.metotIsmi şeklinde erişilebilir.)

Söz dizimi ise aşağıdaki gibidir:
```
erişim_belirteci geri_donus_tipi metot_adi(argüman/parametre)
{
	//komutlar;
}
```

Metotlat içerisinde tanımlanan değişkenler sadece metot içerisinden erişilebilirler. Programından başından sonuna kadar yaşamazlar. Metottan çıkıldığından lifetime ı yani yaşam süresi sona erer.

## Ref Kullanımı
Bir fonksiyona parametre aktarırken değer veya referans tipinde parametre verebiliriz.
```
Değer tipleri metoda bit bit kopyalanır. 
Yani int bir değişkeni parametre olarak değer tipinde bir fonksiyona verdiğimizde; 
fonksiyon çalışırken bellekten integer bir değişkeni saklayabilecek kadar
yer ayrılır ve gönderilen parametre orada saklanır Fonksiyon içerisinde
parametre üzerinde değişiklik yapıldığında ana değişken değişmez. 
Sadece kopyası üzerinde değişiklik yapılmış olur. 
Fonksiyon sonlandığındaysa bellekten silinir. Yani yaşam süresi sona erer.
```

Değer Tipleri şu şekildedir; 
```
int, long, float, double, decimal, char, bool, byte, short, struct, enum
```
```
Referans olarak bir atama yapıldığında ise fonksiyona ilgili 
değişkenin bellekteki adresi gönderilmiş gibi düşünebilirsiniz. 
Dolayısıyla fonksiyon asıl değişken üzerinde değişiklik yapar. 
Fonksiyon içerisinde bir değişiklik yapıldığında çağırıldığı yerdeki 
değişken de değişikliğe uğramış olur. Yani değeri değişir. 
Bu nedenle ref anahtar kelimesini kullanırken çok dikkatli olunmalıdır.
```
### Ref Kullanımının Özellikleri
* Referans olarak iletilmek istenen değişkenin önüne "ref" yazılmalıdır.
* ref olarak metoda verilen değişkenin mutlaka bir başlangıç değeri olmak zorundadır.

Örnek ref kullanımı ise şu şekildedir;
```
int x = 3;
int y = 4;
int sonuc = instance.ArttırVeTopla(ref x, ref y);

public int ArttırVeTopla (ref int x, ref int y)
{
    x+=1;
    y+=y;
    return (x+y);
}
```
## Metot Overloading ve Out Parametre Kullanımı
### Metot Overloading Nedir?
Method overloading yani metotların aşırı yüklenmesi metot imzasının değiştirilerek aynı isimdeki metodun birden farklı versiyonun yaratılmasıdır.
Örnek :
```
public void EkranaYazdir(int deger)
{
    Console.WriteLine(deger);
}

public void EkranaYazdir(string deger)
{
    Console.WriteLine(deger);
}

public void EkranaYazdir(string deger1,string deger2)
{
    Console.WriteLine(deger1 + deger2);
}
```
Yukarıda EkranaYazdir isimli metodun 3 overload versiyonunu görüyoruz. Parametre sayısı ve parametre veri tiplerini değiştirerek aşırı yüklemiş olduk.
```
ÖNEMLİ : Geri dönüş tipi metot imzasına dahil değildir. 
Yani sadece geri dönüş tipini değiştirerek bir metodu aşırı yükleyemeyiz. 
Derleyici hata verecektir.
```

### Out Parametre Kullanımı
Out anahtar kelimesi ref anahtar kelimesi ile aynı işi yapıyor diyebiliriz. Arada sadece birkaç fark var.

Out Kullanımının Özellikleri:
* Out olarak kullanılmak istenen değişken önüne mutlaka "out" yazılmalıdır.
* out değişkeninin bir ilk değeri olmak zorunda değildir. Hatırlarsanız bu ref kullanırken zorunluydu.

Örnek out kullanımı:

```
instance.Toplam(4,8, out int toplam);

public int Toplam (int a, int b,  out int toplam)
{
    toplam = a+b;
    return toplam;
}
```

## Extension ve Rekürsif Metotlar
### Extension(Genişletilmiş) Metot Kullanımı
Extension Metotların kelime anlamı genişletilebilir metotlardır. C# 3.0 ile hayatımıza giren, aynı kodu defalarca yazmak yerine, bir kere yazıp her yerden erişebileceğimiz kolay kullanımı olan metotlardır.

Extension metot yazarken dikkat etmemiz gereken bir kaç kural vardır. Şu şekilde :

1. Static bir class içerisinde static bir metot olarak yazılmalılar.
2. Extension metod da tanımlı parametrelerden sadece 1 tanesi this ile tanımlanabilir.

Küçük bir örnek ile kullanımını görelim.
```
public static class MyExtensionClass
{
    public static bool IsEventNumber(this int value)
    {
        if(value %2 == 0)
            return true;
        else
            return false;
    }
}
```

Yukarıdaki örnekte static class içerisinde IsEventNumber adında bir extension metot görüyoruz. Metodun kendisi de static keywordü ile tanımlandı. this keywordünün uygulandığı parametreye bakarsak, integer ver tipindeki değişkenlere uygulanabilir is extension metot olduğunu görüyoruz. Sayısının çift olup olmaması durumuna göre de geriye bool bir değer dönüyor.

Extension metotların kullanımını oturtmanın en kolay yolu öncelikle işi yapacak olan metodu istenileni karşılayacak şekilde yazmaktır. Daha sonradan class ve metodu static yaparak ve genişletilecek veri tipine bağlı parametrenin başına this anahtar kelimesi ekleyerek kullanabilirsiniz.

Yukarıdaki extension metodun örnek kullanımı ise şu şekildedir.

```
int deger = 123;
bool isEven = deger.IsEvenNumber();
``` 

### Rekürsif(Yinelemeli) Metot Kullanımı
Rekürsif metotlar ilk öğrenildiğinde içselleştirilmesi ve kullanılması zor metotlardır. Ama yazılımın ilerleyen yıllarında kullanımı oturur ve bir çok soruna rekürsif metotları kullanarak çözüm getirebilirsiniz. O nedenle acele etmemek gerek :)

Çok sık olmasa da bazen fonksiyonun kendi kendini çağırmasına ihtiyaç duyarız. For döngüsü karmaşık bir kod yazarak da bu ihtiyacı karşılamak mümkün. Rekürsif fonksiyonlar ise tam da bu ihtiyaç için ortaya koyulmuştur.

Rekürsif fonksiyon kendi kendini çağırma yeteneğine sahip olduğu için kullanırken çok dikkatli olmak gerek. En büyük sorunlardan biri sonsuz döngüye neden olması. Bu da System.StackOverflowException olarak bilinen hataya neden olur. Yani belleğin stack bölgesinde bu fonksiyon çağrımı için ayrılan alan tükenmiştir. Yinelemeli olarak yaptığınız işe bağlı olarak risk de artar.

Aşağıdaki örneği inceleyerek ve hatta kağıt üzerinde yazarak yinelemeli fonksiyonların kullanımını daha iyi oturtabilirsiniz.

```
static int FibonacciSerisi(int sayi)
{  
    if (sayi==0)
        return 0;
    else if (sayi==1)
        return 1;
    else
        return FibonacciSerisi(sayi-1)+FibonacciSerisi(sayi-2);
}
```