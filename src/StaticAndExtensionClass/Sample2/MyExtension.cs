using CommonLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaticAndExtensionClass
{
  // Extension Methodlar için kullanılan sınıflarda static olarak tanımlanır
  public static partial  class MyExtension
  {
    public static string GetFullName(this Person person)
    {
      return $"{person.Name.Trim()} {person.SurName.Trim().ToUpper()}";
    }

  }
}
