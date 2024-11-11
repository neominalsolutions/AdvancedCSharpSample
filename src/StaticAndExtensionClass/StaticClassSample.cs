using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaticAndExtensionClass
{


  public enum LogLevel
  {
    Information = 1,
    Warning = 2,
    Eror = 3
  }


  /// <summary>
  /// 1. Örnek
  /// </summary>
  public static class StaticClassSample
  {
    public const int DefaultLogLevel = 1; // Information
    // Const tanımlı ifadeler kod bloğu içerisinde güncellenemez.

    // uygulama ilk ayağa kalktığında 1 defalık tetiklenir. sonra hep aynı isnstance üzerinden çalışır
    static StaticClassSample()
    {

    }

    public static void LogInfo(string message)
    {
      Console.Out.WriteLine(message);
    }

    public static void LogError(string message)
    {
      Console.Out.WriteLine(message);
    }

  }


  // Uygulama genelinde global bir değişken tanımı yaptık. Uygulama restart edilene kadar Count değeri korunacaktır. Thread Safe çalışmaz. Multi Thread programalama için uygun değil. Onun için Interlock denilen bir sınıf inceleyeceğiz.
  /// <summary>
  /// 2. Örnek
  /// </summary>
  public static class GuessCounter
  {
    private static int count = 0;

    // getter property
    public static int Count => count;

    public static void Increment()
    {
      count++;
    }

    public static void Reset()
    {
      count = 0;
    }

    public static void Decrement()
    {
      count--;
    }

  }


  // static sınıflar sınıf içerisinde const veya static üye olmalıdır.
  /// <summary>
  /// 3. Örnek
  /// </summary>
  public static class PaymentTypes
  {
    public const string Cash = "nakit";
    public const string Credit = "kredi kartı";
    public const string VirtualWallet = "sanal cüzdan";
  }

}
