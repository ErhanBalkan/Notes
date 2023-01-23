Product p1 = new Product(50);
p1.ProductName = "Hard Disk";
Product p2 = new Product(50);
p2.ProductName = "GSM";
p2.StockControlEvent += p2_StockControlEvent;

void p2_StockControlEvent()
{
    System.Console.WriteLine("P2 about to finish!!!");
}

for (int i = 0; i < 10; i++)
{
    p1.Sell(10);
    p2.Sell(10);
    System.Console.ReadLine();
}


// Eventler delegelerin kullanımıyla yapılacak bir işlemdir.
public delegate void StockControl();
public class Product{
    int _stock;
    public Product(int stock) => _stock = stock;
    // Event oluşturmak
    public event StockControl StockControlEvent;
    public string ProductName { get; set; }
    public int Stock { 
        get{return _stock;} 
        set{
            _stock = value;
            if (value <= 15 && StockControlEvent != null){
                StockControlEvent();
            }
        } 
        }

    public void Sell(int amount){
        Stock -= amount;
        System.Console.WriteLine($"{ProductName} Stock amount : {Stock}");
    }
}