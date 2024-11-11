using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaticAndExtensionClass
{
  public class ThreadSafeSingleton
  {
    private static readonly Lazy<ThreadSafeSingleton> instance = new Lazy<ThreadSafeSingleton>(() => new ThreadSafeSingleton());

    // Private constructor to prevent instantiation from other classes.
    private ThreadSafeSingleton()
    {
      Console.WriteLine("Singleton instance created.");
    }

    // Public static method to access the Singleton instance.
    public static ThreadSafeSingleton Instance => instance.Value;

    public void SomeMethod()
    {
      Console.WriteLine("Singleton method called.");
    }
  }
}
