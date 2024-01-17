using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhatsNewInGeneraldotNet
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Salary { get; set; }
        public string City { get; set; }

        public DateOnly BirthDate { get; set; }

    }
    public class EmployeeService
    {
        private List<Employee> employees;

        public List<Employee> GetEmployees()
        {
            return new()
            {
                new(){ Id=1, Name="Gizem", City="İstanbul", Salary=75000},
                new(){ Id=2, Name="Erhan", City="Antalya", Salary=74500},
                new(){ Id=1, Name="Türkay", City="Eskişehir", Salary=70000},
                new(){ Id=1, Name="Ömer Faruk", City="İstanbul", Salary=74000}
            };
        }
    }
}
