using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecordsAndTupples.Models
{
  public class Account
  {
    public string AccountNumber { get; init; } // Immutable olarak kullanıldı.

    public Account(string accountNumber)
    {
      ArgumentNullException.ThrowIfNullOrEmpty(accountNumber);
      AccountNumber = accountNumber;
    }
  }

  public class MoneyClass
  {
    public decimal Amount { get; set; } // Miktar
    public string Currency { get; set; } // Para Birimi


  }

}
