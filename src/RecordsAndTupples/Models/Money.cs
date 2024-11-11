using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecordsAndTupples.Models
{

  // aşağıdaki ile aynı yazım şekli
  public record Location
  {
    public int X { get; init; }
    public int Y { get; init; }

  }

  public record Money(decimal Amount, string Currency); // Default Contructor yöntemi

}
