

using EventDelegates;

public static class Program
{

  public static void Main(string[] args)
  {

    EmailSender emailSender = new();
    //emailSender.Send("Mesaj");
    SmsSender smsSender = new();
    //smsSender.Send("Mesaj");

    // 1. kullanım şekli sıralı method çalıştırma durumlarında kullanılır.
    MessageHandler messageHandler = new(emailSender.Send);
    messageHandler += smsSender.Send; // delegate multi-casting 

    // 1. Yöntem
    messageHandler("Mesaj");

    // 2. Yöntem
    // messageHandler.Invoke("Mesaj");

    // Action tipi ile delegate tanımlanama
    // Action delegateler Tin parametre alıp void tipinde tanımlanır

    Action<string> actionDelegate = message =>
    {
     
      Console.Out.WriteLine(message);
    };

    // actionDelegate.Invoke("Mesaj1");

    // 2. Yöntem Method içerisinde başka methodu tetikleyeceğimiz durumlarda method içerisinde ilgili methodu delegate edebilir.
    Send(actionDelegate);

    // Function tipinin, Actiondan farkı değer döndürmesi
    Func<int,bool> isEven = number => {
      return number % 2 == 0;
    };


    // 3. kullanım Func delegate (Lambda Expression olarak yazılırlar)
    List<int> numbers = [1, 3, 7, 8, 12];

    var evenNumbers = numbers.FindAll(new Predicate<int>(isEven));


    // 4. yöntem Custom Event yapısı

    ProductService productService = new();
    productService.UpdatePrice(new UpdatePrice(300));


  } 

  static void Send(Action<string> action)
  {
    action.Invoke("Deneme");
  }




}


