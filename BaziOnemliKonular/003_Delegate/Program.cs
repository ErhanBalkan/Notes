CustomerManager cm = new CustomerManager();
Matematik mat = new Matematik();
MyDelegate myDelegate = cm.SendMessage;
myDelegate += cm.ShowAlert;
// Delegeler yapılacak işleri bir araya toplar
// ve sırayla çalıştırır.
myDelegate -= cm.SendMessage;
// Eklemeler ve çıkarmalar yapılabilir.
myDelegate(); // Sonra hepsi tek delegede çalıştırılır.
// ----------------------------------------------------
MyDelegate2 myDelegate2 = cm.SendMessage2;
myDelegate2 += cm.ShowAlert2;
myDelegate2("Hello");
// MyDelegate2'deki 2 metoda aynı parametre gider.
// ----------------------------------------------------
MyDelegate3 myDelegate3 = mat.Topla;
myDelegate3 += mat.Carp;
var sonuc = myDelegate3(2,3);
// bu sonuç bize çarpma sonucu döner. çünkü return eden
// delegeler en son çalışan delegenin değerini döner.

public delegate void MyDelegate(); // Delegate
public delegate void MyDelegate2(string text); // Parametreli Delegate
public delegate int MyDelegate3(int n1, int n2); // int dönen parametreli delegate
public class CustomerManager{
    public void SendMessage(){
        System.Console.WriteLine("Hello");}
    public void ShowAlert(){
        System.Console.WriteLine("Be careful!");}   
    public void SendMessage2(string message){
        System.Console.WriteLine(message);}
    public void ShowAlert2(string alert){
        System.Console.WriteLine(alert);}    
}
public class Matematik{
    public int Topla(int sayi1,int sayi2){
        return sayi1 + sayi2;}
    public int Carp(int sayi1,int sayi2){
        return sayi1 * sayi2;}
}