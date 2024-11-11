using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventDelegates
{
  public delegate void MessageHandler(string message);

  public class EmailSender : ISender
  {
    public void Send(string message)
    {
      Console.Out.WriteLine("Email sending...");
    }
  }

  public class SmsSender : ISender
  {
    public void Send(string message)
    {
      Console.Out.WriteLine("Sms sending...");
    }
  }

  public interface ISender
  {
    void Send(string message); // MessageHandler Delegate üzerinden tetiklenebilir.
  }
}
