// See https://aka.ms/new-console-template for more information
using StaticAndExtensionClass;
using System.Data.SqlClient;

Console.WriteLine("Hello, World!");


#region StaticClass

// Logger.DefaultLogLevel = 2;
StaticClassSample.LogInfo("Info Log");
StaticClassSample.LogError("Error Log");

GuessCounter.Increment();
GuessCounter.Increment();


StaticClassSample.LogInfo(GuessCounter.Count.ToString());


GuessCounter.Decrement();

StaticClassSample.LogInfo(GuessCounter.Count.ToString());



// 3. örnek
string vall = PaymentTypes.Cash;



// 4.Örnek
// Static Class kullanmak yerine bir sınıfın tek bir instance üzerinden singleton instance ile yönetilmesini sağlayarak creational design pattern

Singleton.GetInstance().someBusinessLogic();
Singleton.GetInstance().someBusinessLogic();


// Thread Safe Singleton
ThreadSafeSingleton.Instance.SomeMethod();
ThreadSafeSingleton.Instance.SomeMethod();


// unmanagement resource
//using (SqlConnection cnn = new SqlConnection()) { }
//using (FileStream stream = new StreamReader(new Stream())) { }


  Console.ReadKey();

#endregion