Customer customer1 = new Customer{Id = 1, LastName = "Balkan", Age = 23};
CustomerDal customerDal = new CustomerDal();
customerDal.Add(customer1);
Console.ReadLine();

class Customer{
    public int Id { get; set; }   
    [RequiredProperty]
    public string FirstName { get; set; }   
    [RequiredProperty]
    public string LastName { get; set; }   
    [RequiredProperty]
    public int Age { get; set; }   
}

// veritabanında Customer tablosu
[ToTable("Customer")]
class CustomerDal{

    [Obsolete("Bu metodun yerine yeni AddNew metodunu kullan.")] 
    // Metodun eski bir metot olduğunu belirten hazır Attribute
    // parametre olarak mesajımızı belirtebiliriz.
    public void Add(Customer customer){
        System.Console.WriteLine($"{customer.Id} | {customer.FirstName} | {customer.LastName} | {customer.Age}");
    }

    public void AddNew(Customer customer){
        System.Console.WriteLine($"{customer.Id} | {customer.FirstName} | {customer.LastName} | {customer.Age}");
    }
}

// [AttributeUsage(AttributeTargets.All)] // Her şeyde bu attribute kullanılabilir. class-method-property...
// [AttributeUsage(AttributeTargets.Class)] // Bu attribute sadece class'larda kullanılabilir.
// [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)] // Bu attribute sadece property'lerde ve Field'lerde kullanılabilir.
// [AttributeUsage(AttributeTargets.Property, AllowMultiple = true)] // AllowMultiple true ise Bu attribute birden fazla kullanılabilir false ise sadece 1 kez kullanılabilir. 
[AttributeUsage(AttributeTargets.Property)] // Bu attribute sadece property'lerde kullanılabilir.

class RequiredPropertyAttribute : Attribute
{
    
}

[AttributeUsage(AttributeTargets.Class, AllowMultiple = true)] 
class ToTableAttribute : Attribute
{
    string _tableName;
    public ToTableAttribute(string tableName)
    {
        _tableName = tableName;
    }
}
