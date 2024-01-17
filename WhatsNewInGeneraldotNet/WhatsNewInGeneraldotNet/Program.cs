// See https://aka.ms/new-console-template for more information
using System.Text.Json;

using WhatsNewInGeneraldotNet;

Console.WriteLine("Hello, World!");
using MemoryStream ms = new();
using Utf8JsonWriter writer = new(ms);

JsonMessage jsonMessage = new JsonMessage();
JsonSerializer.Serialize(jsonMessage, typeof(JsonMessage));
writer.Flush();

#region Index ve Range Konsepti
var collection = Enumerable.Range(0, 10);
collection.ToList().ForEach(x => Console.Write($"{x} "));
Console.WriteLine();
Console.WriteLine(".NET 6.0'da INDEX geldi!");
Console.WriteLine($"Sondan ikinci sayı {collection.ElementAt(^2)}");
Console.WriteLine("============= Bakın take'a ne oldu ?===========");
Console.WriteLine($" Take (3..6): {string.Join(",", collection.Take(3..6).ToList())} ");

Console.WriteLine("Eski yöntem: Skip.Take");
collection.Skip(3).Take(3).ToList().ForEach(n => Console.Write(n + " "));
Console.WriteLine();

Console.WriteLine($" Take (..^3): {string.Join(",", collection.Take(..^3).ToList())} ");
Console.WriteLine();
Console.WriteLine($" Take (^4..): {string.Join(",", collection.Take(^3..).ToList())} ");


//collection.Take(3..6).ToList()
#endregion

#region ..By Fonksiyonları:
var employees = new EmployeeService().GetEmployees();
var maxSalary = employees.Max(e => e.Salary);
var maxSalaryEmployee = employees.Where(e => e.Salary == maxSalary).FirstOrDefault();

var maxSalaryEmployeeSix = employees.MaxBy(e => e.Salary);
Console.WriteLine($"En fazla maaş: {maxSalaryEmployeeSix.Name} {maxSalaryEmployeeSix.Salary}");

var cities = employees.DistinctBy(e => e.City);
cities.ToList().ForEach(c => Console.WriteLine(c.City));
#endregion
var firstOrNegative = collection.FirstOrDefault(n => n > 10, -1);
var employeeInCity = employees.FirstOrDefault(e => e.City == "Samsun", new Employee { City = "Unknown" });

var employee = employees.ElementAt(^2);
employee.BirthDate = new DateOnly(1980, 7, 1);


