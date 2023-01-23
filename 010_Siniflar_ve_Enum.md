# Sinif Sözdizimi, Field ve Metot Tanımlama, Erişim Belirleyiciler
---
## Sınıf Nedir, Neden İhtiyaç Duyarız ?
Sınıflar Nesne Yönelimli Programlamanın en öneeli öğesidir. C# %100 nesne yönelimli bir dil olduğu için tüm metot ve özellikler sınıflar içerisinde yer alır.

Metotlardan bahsederken bütün işlemleri tek bir metot içerisinde yazmak yerine, parçalarına yani alt metotlara ayırmak kod tekrarını azaltırken okunabilirliği arttırır demiştik. Üstelik bu şekilde yazdığınız programların daha kolay genişleyebildiğini görürsünüz.

Aynı şekilde program geliştirirken bütün metotları tek bir sınıf içerisinde yazmak yerine benzer görevleri olan metotları tek bir sınıf içerisinde toplamak en doğru yaklaşımdır.

Bir sınıfın temelde 2 tipte öğesi vardır; field/özellik ve metotlar. Aşağıda örnek bir sınıf tanımının söz dizimini görebilirsiniz.

```
class SinifAdi
{
    [Erişim Belirleyici][Veri Tipi] ÖzellikAdı;
    [Erişim Belirleyici][Geri Dönüş Değerinin Tipi] MetotAdi([Parametreler])
    {
        //Metot Gövdesi
    }
}
```
## Erişim Belirleyiciler
Erişim belirleyiciler önüne geldiği öğenin projenin nerelerinden erişilebileceğini belirler. Öğeleri korur gibi düşünebilirsiniz.

```
1. Public : Her yerden erişilebilir.

2. Private : Sadece tanımlandığı sınıf içerisinden erişilebilir.

3. Internal : Sadece bulunduğu proje içerisinden erişilebilir

4. Protected : Sadece tanımlandığı sınıfta ya da o sınıfı miras alan sınıflardan erişilebilir.
```

---
---
--- 
---
---

# Constructor Kavramı
Bir sınıftan bir nesne oluşturulduğunda biz tanımlamasak bile arka planda çalışan varsayılan `yapıcı metotlara kurucu` yada `constructor` denir. Sınıf nesnesi ilk oluşturulduğunda yapılmasını istediğimiz işleri kurucu metotlar içerisinde yaparız.

Kurucu metot tanımlarken dikkat edilmesi gereken noktalar ise şu şekildedir:

```
1. Yapıcı metotların isimleri sınıf isimleri ile aynı olmak zorundadır.
2. Public olarak bildirilmeleri gerekir.
3. Geri dönüş değerleri yoktur.
```

Kurucu metotların imzasını değiştirerek `overload` edebiliriz yani aşırı yükleyebiliriz. Metotları anlatırken aşırı yüklemeden bahsetmiştik. 

## Varsayılan Kurucu Metot
Her sınıfın biz tanımlamasakta bir tane kurucu metotu vardır. Buna `varsayılan kurucu metot (default constructor)` denir.

Default constructor'ın görevi sınıfın içerindeki özelliklere ilk değer ataması yapılmadığında onların default değerlerini set etmektir. Şöyle düşünebilirsiniz; sınıf içerisinde string veri tipinde bir özellik varsa ve siz ilk değer atamasını yapmazsanız varsayılan kurucu onun atamasını arka planda `null` olarak yapar. Aynı integer tipinde bir özelliğin ilk değer atamasını 0 olarak yapar.

---
---
--- 
---
---

# Encapsulation Kavramı Ve Property

C#'ın %100 nesne yönelimli bir dil olduğundan bahsetmiştik. `Encapsulation` yani `Kapsülleme` kavramı bir özeliği başka sınıflardan saklamak ya da korumaktır.

Örneğin siz bir propery yani özellik tanımı yaptınız ve diğer sınıflar içerisinden erişilsin ama sadece okumak için erişilsin değeri dışarıdan değiştirilemesin istiyorsunuz. Bunu kapsülleme yaparak sağlayabilirsiniz. Kapsülleme işlemini ise property leri kullanarak yapabilirsiniz.

Kapsülleme sayesinden nesneler bilinçsiz olarak kullanımdan korunmuş olur. Fakat bazı durumlarda private field'lara erişmemiz ve özelliklerini değiştirmemiz gerekebilir. Bu durumda `Property Kavramı` devreye girer. Property bir field'ın değerini geri döndürmeye`(Get)` ve yeni bir değer`(Set)` atamaya olanak sağlar.

Örnek bir property kullanımı aşağıdaki gibidir:

```
class Ogrenci
{
    private string name; //field

    public string Name //property
    {
        get { return name; }
        set { name = value; }
    }
}
```

Yukarıda Ogrenci sınıfı içerisinde "name" isminde private bir field tanımı görüyorsunuz. Yani bu field'a sınıf dışında bir yerden erişilemez. Altındaysa "Name" isminde "name" field'ını geri döndüren `Get metodu` ve "name" field ına yeni değer atamasını yapabilen bir `Set metodu` barındıran bir property tanımı görüyoruz.

Burada property tanımlayarak "name" field'ını sınıf dışından yapılabilecek bilinçsiz atamalardan koruduk. Public property nin set metodu içerisinde bu field'a atanabilecek verileri kontrol edebilir ve müdahale edebiliriz.

Aşağıdaki örnekte yaş olarak negatif bir değer atamasına engel olan property tanımını görebilirsiniz.

```
class Person
{
    private int age=0;
    public int Age
    {
        get { return age; }
        set {
            if (value > 0)
            age = value;
        }
    }
}
```

---
---
--- 
---
---


# Static Sınıf ve Üyeler

## Static Üyeler
Bir sınıfın static olamayan üyelerine nesneler aracılığıyla erişirken static olan metotlara ve özelliklere ise nesne oluşturmadan o sınıfın ismi aracılığıyla erişiriz.

```
class Ogrenci
{
    public static int OgrenciSayisi = 0;
    public string Isim;
    public string Soyisim;
    public Ogrenci()
    {
        OgrenciSayisi++;
    }
}

class Program
{
    static void Main(string[] args)
    {
        //Static sınıf üyesine erişim
        Console.WriteLine("Öğrenci sayısı: {0}",Ogrenci.OgrenciSayisi);

        //Static olmayan sinif üyesine erişim
        Ogrenci ogrenci1 = new Ogrenci();
        ogrenci1.Isim = "Deniz";
        ogrenci1.Soyisim = "Arda";
        
        Ogrenci ogrenci2 = new Ogrenci();
        ogrenci2.Isim = "Ayşe";
        ogrenci2.Soyisim = "Yılmaz";

        Console.WriteLine("Öğrenci Sayısı: {0}", Ogrenci.OgrenciSayisi);
    }
}
```

Yukarıda hem static hemde static olmayan sınıf üyesine sahip bir sınıf tanımı ve program içerisinden kullanımı görüyorsunuz. Static olmayan üyeler nesne bazında yaratılırken static sınıf üyeleri uygulama çalıştığı sürece kendilerine atanan veriyi tutarlar. Yani yukarıdaki örnek için konuşursak, "Isim" ve "Soyisim" her nesne yaratıldığında başlangıç değeri olarak null alır, ataması yapıldığındaysa nesne bazında değerini tutar. Ama "Ogrenci Sayısı" field'ı program boyunca nesne yaratıldıkça öğrenci sayısının değerini 1 arttırarak bu veriyi korur.

Yukarıdaki örnekte de görebileceğiniz gibi bir özelliği static yapmak için geri dönüş tipi ya da veri tipinden önce erişim belirleyiciden sonra `"static"` anahtar kelimesini koymanız yeterlidir.

Normal metotlar gibi kurucu metotları da static olarak tanımlayabiliriz. Sınıfın static üyelerinin başlangıç değerlerini static kurucular aracılığıyla yapabiliriz. Parametre almazlar ve erişim belirleyicileri yoktur.

## Static Sınıflar

Metotlar ve özellikler gibi sınıflar da static anahtar kelimesi ile oluşturulabilirler. Yukarıdaki örnekte de görebileceğiniz üzere normal sınıflar içerisinde static metotlar ve üyeler kullanabiliriz. Peki o halde neden sınıfları static yapma ihtiyacımız olsun? Buna okunabilirliği arttırmak için diyebiliriz.

Bir sınıfın tüm üyeleri static ise sınıfı da static yapmak kullanımı kolaylaştıran bir yaklaşım olur.

---
---
--- 
---
---

# Enum
Uygulama geliştirirken sabit değerlerle çalışmak durumunda kalırız. Bu noktalarda okunabilirliği yüksek bir program yazmak istiyorsak enum'lardan faydalanırız.

"enum" anahtar kelimesi enumeration yani numaralandırma kelimesinden gelir. Sayısal verilerı string ifadelerle saklamanızı sağlar. Okunabilirliğe katkısı da tam olarak burdan gelir diyebiliriz.

```
enum Gunler 
{
    Pazartesi, 
    Sali, 
    Carsamba, 
    Persembe, 
    Cuma, 
    Cumartesi, 
    Pazar
};
```

Yukarıda Gunler enum'ını görüyorsunuz. Enum lar default olarak 1'den başlar.

`Gunler.Pazartesi` ifadesi ile Pazartesi'nin string ifadesine erişebiliriz. Eğer Pazartesinin 1. gün oldugu bilgisine ihtiyacımız varsa o da şu şekildedir: `(int)Gunler.Pazartesi`