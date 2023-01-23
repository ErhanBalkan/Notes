# For Döngüsü ve Break Continue Anahtar Kelimeleri
Örnek bir for döngüsü 2 ifade, 1 koşuldan oluşur.
```
for(ifade1;kosul;ifade2)
{
    komut1;
    komut2;
}
```
* ifade1: Döngünün sayacının tanımlandığı ve atamasının yapıldığı ifadedir. Örneğin; int i=0;
* ifade2: Döngünün sayacının artırım ya da azaltım şeklini belirten ifadedir. Örneğin ; i++, i-- gibi.
* koşul: döngünün devam etme koşuludur. Bu koşul sağlandığı sürece döngü devam eder. Örneğin : i<=12;
---
ÖNEMLİ: For döngüsünü oluşturan bu 2 ifade 1 koşulun bir kısmı ya da tamamı boş bırakılabilir 
ama aralardaki " ; " işareti mutlaka kullanılmalıdır.
`for(;;) // Sonsuz döngüyü ifade eder.`
---
## Break Anahtar Kelimesi
Break ifadesi döngü içerisinden çıkmak istenildiğinde kullanılır.
```
for (int i; ;)// Sonsuz döngü
{
    a = Convert.ToChar(Console.ReadLine());
    if (i == 7)
        break;
}
//Kod burdan devam eder. 
```
Yukarıdaki örnekte console'dan girilen değer 7' ye eşit ise döngü sonlandırılır.
---
Not: İç içe döngüler kullanıldığında break ifadesi yalnızca içinde bulunduğu ilk döngüyü sonlandırır.
---
## Continue Anahtar Kelimesi
Kullanım amacı break ifadesine benzer ama continue sadece mevcut iterasyonu sonlandırır. Döngü bir sonraki iterasyondan devam eder.
```
for (int i = 1; i <= 10; i++)
{
    if (i % 2 == 0)
        continue;
    Console.WriteLine(i);
}
```
Yukarıdaki örnekte i çift sayıya eşit olduğunda döngünün o anki iterasyon sonlanacaktır. Bu durumda console'a 1 ile 10 arasındaki tek sayılar yazdırılacaktır.
---
---
---
# While ve ForEach Döngüleri
## While
Koşullar sağlandıkça komut satırlarının çalıştırılmasını sağlar. For döngüsünden farklı olarak iterasyon sayısı belli değildir.
```
int sayac = 1;
while (sayac <= 5)
{
    Console.WriteLine(sayac);
    sayac++;
}
```
Yukarıdaki örnekte bir while döngüsü görüyoruz. sayac başlangıçta 1 olarak verilmiş. Ve sayaç 5 den küçük veya 5'e eşit olduğu sürece console'a sayacın değerini yazdıracak. Ve her döngü sonunda sayacın değerini bir arttıracak.
## ForEach
Foreach döngüsü diziler ve koleksiyonlarla döngüsel işlemler yapmak için kullanılır. Yapısı while ve for döngüsünden biraz farklıdır. Döngünün ne kadar devam edeceğini kullanılan dizi veya koleksiyonun eleman sayısı belirler. Her bir elaman için bir iterasyon gerçekleşir.
Yazım şekli aşağıdaki gibidir:
```
foreach(değişkenTipi değişkenAdı in diziAdı)
{
    //Komutlar
}
```
Aşağıdaki örnekte foreach döngüsü kullanarak dizinin elemanlarını topladık.
```
int[] sayiDizisi = {2,4,5,1,2,4};
int toplam = 0 ;

foreach(int i in SayiDizisi)
{
    toplam += i ;
}
```