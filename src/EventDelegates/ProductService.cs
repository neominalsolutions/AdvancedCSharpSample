using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventDelegates
{
  // delegate ile servis içersinde berlirli bir durum meydana geldiğinde event fırlatarak işi delegate etme

  // Fiyat değişimi

  public record UpdatePrice(decimal NewPrice);

  public class Product
  {
    public decimal Price { get; set; }
    public string Name { get; set; }
  }

  // Event içinde taşınan bilgiler
  public class ProductPriceArgs : EventArgs
  {
    public decimal Newprice { get; set; }
    public decimal OldPrice { get; set; }
  }

  public delegate void ProductPriceEventHandler(ProductPriceArgs args);

  public class ProductService
  {
    // eventler delegate olmadan tanımlanamaz.
    private event ProductPriceEventHandler PriceChanged;

    public ProductService()
    {
      // bu event hangi methodu invoke edicek.
      PriceChanged += this.ProductService_PriceChanged; ;
    }

    private void ProductService_PriceChanged(ProductPriceArgs args)
    {
      Console.Out.WriteLine($"Event Fırlatıldı Yeni Fiyat: {args.Newprice}, Eski Fiyat: {args.OldPrice}");
    }

    //private void ProductService_PriceChanged(object? sender, EventArgs e)
    //{
    //  Console.Out.WriteLine("Event Fırlatıldı");
    //  Console.WriteLine(sender.ToString());
    //}

    public void UpdatePrice(UpdatePrice updatePrice)
    {
      var p = new Product();
      p.Price = updatePrice.NewPrice;
      // Event fırlatma kısmı
      PriceChanged.Invoke(new ProductPriceArgs { OldPrice = 0, Newprice = updatePrice.NewPrice });

    }

  }
}
