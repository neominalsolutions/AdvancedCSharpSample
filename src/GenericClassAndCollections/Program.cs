// See https://aka.ms/new-console-template for more information
using GenericClassAndCollections.Models;

Console.WriteLine("Hello, World!");


#region GenericClass

Product p = new Product();
p.Id = Guid.NewGuid();

Category c = new Category();
c.Id = 1;

ProductRepository productRepository = new();
productRepository.Save(p);

CategoryRepository categoryRepository = new();
categoryRepository.Save(c);


CreateProductRequest request = new();
request.Name = "Ürün-1";

ProductService productService = new();
CreateProductResponse response = productService.Handle(request);




#endregion