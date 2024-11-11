using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericClassAndCollections.Models
{
  public abstract class Entity<TKey>
    where TKey : IComparable
  {
    public TKey Id { get; set; }
  }

  public class Product : Entity<Guid>
  {
    //public Guid ID { get; set; }
    public string Name { get; set; }

    public Product()
    {
      Id = Guid.NewGuid();
    }
  }

  public class Category : Entity<int>
  {
    //public int ID { get; set; }
  }



}
