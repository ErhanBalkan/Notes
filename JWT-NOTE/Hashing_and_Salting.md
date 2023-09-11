# Hashing And Salting
Biz burada parolayı hash'leyeceğiz. Bu ne anlama geliyor ?

Bize kullanıcı kayıt olurken bir şifre verecek. Biz bu şifreye önce `Salting` uygulayacağız. Yani `tuzlayacağız.`
Örneğin bize parola olarak `erhan123` geldi. Biz buna şifreleme algoritması ile ek bişeyler ekleyeceğiz. Yani şifre `IAIASJZXerhan123` tarzı bişey olacak.(Örnek olarak)

Daha sonra tuzladığımız bu şifreye `Hashing` uygulayacağız. Hashing de bize bir text'in benzersiz ifadesini oluşturur.
Şifre gün sonunda tamamen karışık karakterlerden oluşan hiçbir şey anlaşılmayan bir şifre olarak elimize geçer.

Böylece şifreler çalınsa bile eğer sadece hashing uygulamış olsaydık bir nebze bulunabilirdi ama tuzlama da yaptığımız için şifrenin bulunması imkansız hale geldi.