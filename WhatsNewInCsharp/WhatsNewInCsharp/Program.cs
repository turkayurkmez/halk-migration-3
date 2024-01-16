// See https://aka.ms/new-console-template for more information

#region namespace çözümleri
using System.Drawing;
using System.Runtime.CompilerServices;
using WhatsNewInCsharp;

Console.WriteLine("Hello, World!");

SqlConnection sqlConnection = new SqlConnection();
#endregion


#region lambda değişiklikleri
Func<int, bool> isEven = (int number) => number % 2 == 0;

List<int> list = new List<int>();
list.Where(isEven);

var isOdd = (int number) => number % 2 == 1;

object multiplyThree = (int x) => x % 3 == 0;

Delegate multiplyThree2 = (int x) => x % 3 == 0;

Func<int> read = Console.Read;
Action<string> write = Console.Write;

//sadece bir overload'ı olma durumunda maşntıklıdır.
var read2 = Console.Read;
//var write2 = Console.Write;

var answer = object (string response) => response == "yes" ? true : "fail";

Console.WriteLine($" gelen yanıt: {answer.Invoke("yes")} ");
Console.WriteLine($" gelen yanıt: {answer.Invoke("no")} ");







#endregion

#region struct üzerindeki farklar

#region önce record
var comments = new string[2];

ProductRecord productRecord = new ProductRecord("Ürün 1", 200, comments);
ProductRecord productRecord2 = new ProductRecord("Ürün 1", 270, comments);

Console.WriteLine($" İki farklı record karşılaştırılıyor: {productRecord == productRecord2}");
Console.WriteLine($" İki farklı record'un hashcode karşılaştırılıyor: {productRecord.GetHashCode() == productRecord2.GetHashCode()}");

Console.WriteLine($" İki farklı record'un referansları karşılaştırılıyor: {ReferenceEquals(productRecord, productRecord2)}");

Console.WriteLine($"1. record fiyat: {productRecord.price}, 2. si: {productRecord2.price}");




#endregion

Employee employee = new Employee("Türkay", "Ürkmez", 44);

#endregion


#region JSON tarzı Propety Pattern
object product = new Product
{
    Name = "Ürün 1",
    Price = 150,
    Vendor = new Vendor { CompanyName = "Samsung" }
};

//eğer product nesnesinin Markası Samsung ise...
if (product is Product { Vendor: { CompanyName: "Samsung" } })
{
    Console.WriteLine("Samsung'a ait");
}

if (product is Product { Vendor.CompanyName: "Samsung" })
{

}
#endregion

#region Caller expression attribute
Console.WriteLine("Test...");

void ConditionSample(bool condition,
          [CallerArgumentExpression(nameof(condition))] string? message = null)
{
    Console.WriteLine($"Koşulumuz: {message}");
}


ConditionSample(true);
int x = 3;
ConditionSample(x > 5);
ConditionSample(x < 4);


#endregion


#region yeni exception handler 
Console.WriteLine("Test");

void component(Product product)
{
    ArgumentNullException.ThrowIfNull(product);

}
#endregion


