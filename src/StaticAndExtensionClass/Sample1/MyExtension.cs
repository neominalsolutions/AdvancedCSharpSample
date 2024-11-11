using CommonLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaticAndExtensionClass
{

  public class RedisCache : ICache
  {
    public void Clear()
    {
      Console.Out.Write("Clear");
    }
  }

  public  static partial class MyExtension
  {
    public static void Set(this ICache cache, string key, string value)
    {
      Console.Out.Write($"Key : ${key}");
    }
  }
}
