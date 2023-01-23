# Diziler
## Dizi Nedir, Dizi Tanımlama, Dizilere Erişim ve Döngülerle Kullanımı
---
Aynı tipteki verileri bellekte yan yana saklamak istediğimizde dizilerden faydalanırız. Değişkenler kullanılarak karmaşık şekilde çözülebilecek problemler diziler yardımıyla çok daha kolay bir şekilde çözülebilir.

Dizi index'i 0'dan başlar. Yani 5 elemanlı bir dizinin ilk elemanı 0. indexte sonuncu elemanı 4. indextedir.
```
int[] sayilar = new int[10];
sayilar[2] = 12;
```
Yukarıda örnek bir dizi tanımlaması görüyoruz. Integer tipinde veri tutan 10 elemanlı bir dizi tanımladık. Ve dizinin 3. elemanına yani 2. indexine 12 değerini atadık.
`string[] renkler = {"Mavi","Kırmızı","Sarı","Yeşil"};`
Dizilerin elemanlarını dizi tanımı yapılırken verebiliriz. Yukarıdaki örnekte göreceğiniz üzere string tipinde bir dizi tanımladık. Ve elemanları bize bunun 4 elemanlı bir dizi olduğunu söylüyor.
Dizi tanımlandığı anda eleman sayısı belirlenmek zorunda değildir. Önce tanımı yapıp daha sonradan eleman sayısı da atanabilir. Ama bir dizinin büyüklüğü yani bellekte ne kadar yer kaplayacağı dizi kullanılmadan önce mutlaka belirlenmelidir.
```
int[] dizi;
dizi = new int[4];
```
Yukarıdaki örnekte önce integer tipinde "dizi" adında bir dizi tanımı yaptık. Alt satırda da bu dizinin 4 elemanlı bir dizi olacağını söyledik.
### Dizilere Erişim
Aşağıdaki örnekte de görebileceğiniz gibi dizilere index numaraları ile erişilebilir.
```
string[] renkler = {"Mavi","Kırmızı","Sarı","Yeşil"};
string renk = renkler[1]; // Kırmızı rengi getirir.
```
### Döngülerle Dizi Kullanımı
```
int[] sayiDizisi = new int[20];
int toplam = 0;
for (int i = 0; i < sayiDizisi.Length; i++)
  {
    Console.Write("Lütfen {0}. sayıyı girin:", i+1);
    sayiDizisi[i] = Convert.ToInt32(Console.ReadLine());
    toplam += sayiDizisi[i];
  }
double ortalama = toplam / 20;
Console.WriteLine("Sayıların ortalaması: " + ortalama);
Console.ReadLine();
```
Yukarıdaki örnekte bir for döngüsü içerisinde dizi kullanımını görüyoruz. Öncelikle 20 elemanlı bir dizi tanımladık. Ve bu 20 elemanın değerlerini kullanıcıdan console aracılığıyla aldık. For döngüsü kullanmasaydık 20 defa Console.ReadLine() yazmamız gerekiyordu. Bunun yerine döngülerin ve dizilerin gücünü birleştirerek sadece bir kaç satırda, okunabilir bir kod ile problemimizi çözdük.

---

# Array Sınıfı ve Methodları
Diziler System.Array sınıfından türerler. Array sınıfı da dizilerle yapılan işlemleri kolaylaştırmak için bir takım static hazır metotlar sunar. Bu metotlardan en sık kullanılan birkaçına yakından bakalım.
## Array.Sort
Diziler üzerinden sıralama işlemi yapar. Eğer string bir dizi ise alfabetik olarak olarak A'dan Z'ye sıralar. Eğer numeric bir dizi ise dizi elemanlarını küçükten büyüğe sıralar.
Örnek: `Array.Sort(sayiDizisi);`
## Array.Clear
Dizinin belirtilen elemanlarını varsayılan değerine getirir. Yani örneğin numeric bir dizi ise 0 olarak setler.
Örnek: Aşağıdaki örnek sayi dizisinin 2.indexinden başlayarak 2 tane elemanı temizler.
`Array.Clear(sayiDizisi,2,2);`
## Array.Reverse
Dizinin ortasını belirleyerek elemanlarını aynalar gibi düşünebilirsiniz. Yani dizinin ilk elemanı ile son elemanını yer değiştirir.
Örnek: `Array.Reverse(sayiDizisi);`
```
sayiDizisi elemanlarını {1,3,4,9,8,7} olarak düşünürsek; Reverse metodu uygulandığında dizi şöyle olur : {7,8,9,4,3,1}
```
## Array.IndexOf
Verilen dizinin verilen elemanının indexini getirir. Eğer dizi içerisinde elemanı bulamazsa -1 döner.
Örnek: `Array.IndexOf(sayiDizisi,7);`
## Array.Resize
Dizileri yeniden boyutlandırmak için kullanılır.
```
int[] sayiDizisi = {1,3,4,9,8,7};
Array.Resize<int>(ref sayiDizisi,12);
sayiDizisi[6] = 10;
```
Yukarıdaki örnekte başlangıçta 6 elemanlı olan sayiDizisi Resize metodu ile 12 elemanlı hale getirildi. Daha sonra 7. elemanına 10 değeri atandı. Diğer boş olan indexlerin değeri ise varsayılan olarak 0 atanır.
```
int[] sayiDizisi = {1,3,4,9,8,7};
Array.Resize<int>(ref sayiDizisi,3);
```
Yukarıdaki örnekte başlangıçta 6 elemanlı olan sayiDizisi Resize metodu ile 3 elemanlı hale getirildi. sondaki 3 eleman kırpıldı. Artık dizi şu şekilde: {1,3,4}