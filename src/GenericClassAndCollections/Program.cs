
// See https://aka.ms/new-console-template for more information
using GenericClassAndCollections.Models;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.ObjectModel;

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


#region Collections

List<int> numbers = [1, 2, 3, 4, 5, 6];
numbers.Add(7);
var newNumbers = numbers.Prepend(11).ToList();


int n1 = numbers[0];

List<Product> plist = [new Product { Name = "P1" }, new Product { Name = "P2" }];
 
var readOnlyList = plist.AsReadOnly();
plist.Find(x => x.Name.StartsWith("P1"));

plist.Where(x => x.Name.Contains("P"));


Collection<string> names = ["Ali", "Ayşe", "Can"];



// Stack, LIFO
Stack<int> numbers2 = new();
numbers2.Push(3);
numbers2.Push(5);
numbers2.Peek();
numbers2.Pop();
var s1 = numbers2.Prepend(11).ToList();
var s2 = numbers2.Append(12).ToList();



// Queue, FIFO
Queue<string> fruits = new();
fruits.Enqueue("apple");
fruits.Enqueue("orange");
fruits.Dequeue();
fruits.Peek();




// HashSet

HashSet<int> points = [45,55,78,96];
points.Add(45); // aynı değeri value type için listeye gönderirsek bu değerin eklenmesini engeller. Unique Listler.
// ICollection interface sahip olduğu tüm özelliklere sahip.

var p11 = new Product() { Name = "P11" };
var p12 = p11;


HashSet<Product> products = new(); // reference type için ise aynı referansa sahiplerse bu referansın unique bir şekilde listede tutulmasını sağlıyor.
products.Add(p11);
products.Add(p12);


// Dictionary: key value pair olarak veri saklamak için yaygın kullandığımız bir generic liste
Dictionary<string, int> grades = new();
grades.Add("fen bilgisi", 75);
grades.Add("matematik", 100);

// aynı key tekrar kullanılamaz, key bazlı uniqueleme yapar.
//grades.Add("matematik", 85);


Dictionary<string, object> paths = new();
paths.Add("/api/products/2", new { count = 1, date = DateTime.Now });
paths.Add("/api/products/1", new Product { Name = "P22"});
paths.Add("/api/products/3", 1);

var value = paths["/api/products/1"];


Dictionary<string, Product> productDic = new();
productDic.Add("QR-100", new Product { Name = "P1" });
productDic.Add("QR-200", new Product { Name = "P2" });

string val1 = productDic["QR-100"].Name;


productDic.ToList().ForEach(item =>
{
  Console.Out.WriteLine($"Key: {item.Key} Value: {item.Value.Name}");
});


Console.ReadKey();

ArrayList arrayList = new();
arrayList.Add(1);
arrayList.Add(new Category());
arrayList.Add(true);

// Not: Collection sınıfları Thread Safe çalışmazlar, Asenkron, Paralel Programlama yaparken Concurency List gibi Thread Safe çalışan collection ifadeleri kullanmayı tercih ederiz.


#endregion
