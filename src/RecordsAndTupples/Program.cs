// See https://aka.ms/new-console-template for more information
using RecordsAndTupples.Models;

class RegisterViewModel
{
  public ProductViewModel ProductViewModel { get; set; }
  public CategoryViewModel CategoryView { get; set; }
}

class ProductViewModel
{

}

class CategoryViewModel
{

}
public class Program
{


  public static void Main(string[] args)
  {
    Console.WriteLine("Hello, World!");


    #region Tupples

    // Anonim Veri demeti
    // Herhangi bir sınıf açmadan değerleri generic olarak içerisinde tutmamızı sağlayan bir veri kapsayıcı görevi görüyor.
    // 1. Yöntem
    var person = Tuple.Create<string, int, bool>("ali", 35, false); // construction

    // decontruction
    string personName = person.Item1;
    int age = person.Item2;
    bool married = person.Item3;

    // 2.Yöntem
    var user = ("test@test.com", "ali.tan");
    string email = user.Item1;
    string username = user.Item2;

    // 3.Yöntem

    static (string name, string surname) GetIdentity(string name, string surname)
    {
      return (name, surname);
    }

    var identity = GetIdentity("ali", "tan");

    Console.Out.WriteLine($"name: {identity.name}, surname: {identity.surname}");

    // 4.Yöntem
    // MVC de view birden fazla nesne gönderirken View Model amaçlı kullanıyoruz.
    var pwithCategory = new Tuple<ProductViewModel, CategoryViewModel>(new ProductViewModel(), new CategoryViewModel());

    // sadece RegisterView ait başka hiçbir yerde referansı olmayan bir model açmak durumda kalıcaz.


    #endregion


    #region Records

    // Mutable  => state değişebilen, herhangi bir anda set edilebilen tip. Entity
    // Immutable => ReadOnly, Init işlemi sadece Consture üzerinden olup, nesneni state bir daha değişmeyen, record , Request Nesneleri veya DTO // Barkod Number, TC No, Account Number, IBAN 

    // Request (DTO) Immutable => Entity (Mutable) Mapliyoruz.  => Entity olarak veritabanına aktarılır. 

    var m = new MoneyClass(); // Heap de referans
    m.Amount = 1001;
    m.Currency = "$";

    m.Currency = "TL";
    m.Amount = 1000;

    var m2 = new MoneyClass(); // Heap de başka bir referans
    m2.Amount = 1000;
    m2.Currency = "TL";

    m.Equals(m2); // True or False ? Referans eşitliğine bakılır. False döner.

    // Referans type değerler farklı referans bölgelerini kullandıklarından hash code farkıdır.
    Console.Out.WriteLine(m.GetHashCode());
    Console.Out.WriteLine(m2.GetHashCode());

    // Recordlar Value Object yani değer nesneleri olarak kullanılırlar.

    var mr = new Money(100, "TL"); // Immutable
    //mr.Amount = 200; 
    var mr2 = new Money(100, "$");

    // with ile nesne değerini güncelleme
    // with ile var olan value object değerini başkar bir record'a tanımlayabiliriz.
     mr2 = mr with { Amount = 50, Currency = "TL" };


    // record compare işlemlerinde value based çalışır.
    mr.Equals(mr2); // true döner. Record tipi referans yerine value eşitliğine bakar.

    // Not: Aynı değerler aynı hash code oluşturur.
    Console.Out.WriteLine(mr.GetHashCode());
    Console.Out.WriteLine(mr2.GetHashCode());


    // 2.Kullanım
    var location = new Location { X = 10, Y = 20 };
    // location.X = 100;


    // Immutable Class with init property
    Account account = new("887877878");
    // account.AccountNumber = "98787878";

    #endregion


  }
}





