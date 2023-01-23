//******** Action'dan farkı geriye değer dönmesidir. ********
static int Topla(int x, int y) => x + y;
System.Console.WriteLine(Topla(2,3));

// <parameter1,parameter2,returnType>
Func<int,int,int> add = Topla;
System.Console.WriteLine(add(3,4));

// parametresiz metotlara delegelik yapar ama int döndürür.
Func<int> getRandomNumber = delegate(){
    Random rnd = new Random();
    return rnd.Next(1,100);
};
System.Console.WriteLine(getRandomNumber());

// Bir diğer yazım şekli (actiona benziyor)
Func<int> getRandomNumber2 = () => new Random().Next(1,100);