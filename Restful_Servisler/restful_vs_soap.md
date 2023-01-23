`SOAP (Simple Object Access Protocol)` uygulamalar ile web servislerin bilgi aktarımını sağlayan `XML` tabanlı bir protokoldür. Yani web servise giden bilgi `XML` olarak gönderilir, web servis bu bilgiyi yorumlar ve sonucunu `XML` olarak geri döndürür. `SOAP` tabanlı bir web servisin, gönderilen `XML` verisini nasıl yorumlayacağının tanımlanması gerekir. Bu web servis tanımlaması `WSDL` standardı ile yapılır.

---

# REST VS SOAP

## REST

* `XML`, `JSON`, `CSV` gibi farklı veri tipleri çalışabilir. `JSON`, `XML`'e göre çok küçük olduğu için oldukça hızlıdır.
* Basit yapısı nedeniyle kullanımı kolaydır ve hızlı çalışır.
* Güvenlik yazılımın bir parçasıdır. `İletişim seviyesinde güvenlik(Transport level security)` `token` aracılığıyla yapılır.
* Sunucuyla iletişim kurabilmek için sadece `URL` yeterlidir. `URL` size response olarak `JSON` ya da `XML` döner. Siz dönen veriyi `parse` edersiniz ve entegrasyon sağlanmış olur.
* Sunucu istemci ile ilgili bilgi saklamaz. Durum bilgisi `client` tarafında saklanır.

## SOAP
* `XML` veri tipi ile çalışır. `XML` çok büyük olduğu için network üzerinde yavaş taşınır.
* `REST` servislere göre implementasyonu ve kullanımı daha zordur. Ve daha yavaştır.
* Kendi içinde güvenlik protokolü vardır. Geliştiricinin efor sarfetmesine gerek yoktur.
* Sunucuyla iletişim kurabilmek için istemcinin sunucudaki `WSDL` dosyasını saklaması gereklidir. `Proxy` sınıflarının oluşturulması gerekir ve uzak metotları çağırabilmek için tanımlar yapmanız gerekir.
* Sunucu ve istemci arasında köprü olan `WSDL` dosyası vardır. Değişiklik yapıldığında istemcinin haberinin olması gerekir.

---

# Rest Servislerde İletişim Seviyesinde Güvenlik

Genellikle bir ön çağrı yapılarak, istemci sunucuya kendisini tanıtan bir istekte bulunur. Sunucu client'a yetki vermek isterse client'ın gnderdiği bilgilere istinaden bir token oluşturur. Ve istemcinin sonraki isteklerde token içerisinde belirtilen süre boyunca bu token ile birlikte gelmesi beklenir. Token geçerli olduğu sürece sunucu istemciyi tanır ve request'lerine cevap verir.