using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericClassAndCollections.Models
{
  // Tout : TResponse Nesnesi return Type
  // TIn : Methodun Parametre olarak içeri aldığı nesne
  // class,new() keyword ile abstract class, static class kabul etmiyoruz. class dışında bir yapırda gönderemeyiz.


  public abstract class Service<TRequest, TResponse>
    where TRequest : class, new()
    where TResponse : class, new()
  {
    /// <summary>
    /// Abstract üyeler, method'da her hangi bir body olmayan sadece method imzasının atıldığı bir tanımlama
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    public abstract TResponse Handle(TRequest request);

  }

  public class CreateProductRequest
  {
    [Required]
    public string? Name { get; set; }

  }

  public class CreateProductResponse
  {
    public Guid Id { get; set; }
    public DateTime CreatedAt { get; set; }
  }

  // Sadece interface tanımlarında in,out kullanabiliyoruz.
  public interface IService<in TIn, out TOut> { }

  public class ProductService : Service<CreateProductRequest, CreateProductResponse>
  {



    /// <summary>
    /// Product Entity Mappleme Encapsulation Edildi.
    /// ProductRepository ile veri tabanına ilgili kaydın yansımasını encapsulate ettik.
    /// </summary>
    /// <param name="request">TIn</param>
    /// <returns>Tout</returns>
    public override CreateProductResponse Handle(CreateProductRequest request)
    {
      // CreateProductRequest DTO
      ArgumentNullException.ThrowIfNullOrEmpty(request.Name);
      ArgumentNullException.ThrowIfNull(request);

      // Service bazlı hizlerler, dışardan gelen istekleri request formatında alıp içeride entity nesnelerine mapler. 
      var entity = new Product();
      entity.Name = request.Name;

      // alt hizmetleri tetikleriz. DAL (Data Access Layer)
      var repo = new ProductRepository();
      repo.Save(entity);

      Console.Out.WriteLine("Entity is Saved"); // UI Response olarak DTO (Data Transfer Object)
      return new() { Id = entity.Id, CreatedAt = DateTime.Now };
    }
  }


}
