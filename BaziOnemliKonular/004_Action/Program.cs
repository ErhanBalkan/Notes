int Topla(int sayi1, int sayi2) => sayi1 + sayi2;

HandleException(() => {
    Topla(2,3);
});
// Sürekli try catch yazmaktansa bu şekilde bi yapı oluşturup
// her yerde kullanabiliriz.
static void HandleException(Action action){
    try{
        action.Invoke(); 
        // parametre olarak verilen metodu çalıştırır.
    }catch(Exception exception){
        System.Console.WriteLine(exception.Message);
    }
}