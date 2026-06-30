using System;
using System.Collections.Generic;
using System.Text;

namespace PrototypePattern2
{
    public class EmployeeProfile : IEmployeePrototype
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string Role { get; set; }
        public decimal Salary { get; set; }
        public IEmployeePrototype Clone()
        {
            return new EmployeeProfile
            {
                Name = this.Name,
                Address = this.Address,
                Role = this.Role,
                Salary = this.Salary
            };
        }
        public void DisplayProfile()
        {
            Console.WriteLine($"Name: {Name} | Address: {Address} | Role: {Role} | Salary: ${Salary}");
        }
    }
}
