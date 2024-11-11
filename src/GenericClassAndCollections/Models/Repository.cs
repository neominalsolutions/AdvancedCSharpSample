using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericClassAndCollections.Models
{
  // TEntity: TIn1
  // TKey: TIn2
  public abstract class Repository<TEntity, TKey> 
    where TEntity:Entity<TKey>,new()
    where TKey:IComparable
  {

    public virtual void Save(TEntity entity)
    {
      Console.Out.WriteLine("Entity Save");
    }

  }

  public class CategoryRepository:Repository<Category,int>
  {
    public override void Save(Category entity)
    {
      Console.Out.WriteLine($"Insert Into Category(Id) Values({entity.Id})");
      base.Save(entity);
    }
  }

  public class ProductRepository: Repository<Product,Guid>
  {
    public override void Save(Product entity)
    {
      Console.Out.WriteLine($"Insert Into Product(Id) Values({entity.Id})");
      base.Save(entity);
    }
  }

}
