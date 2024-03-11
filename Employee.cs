using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTCSharpDepartment
{
    public class Employee
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int DepartmentID { get; set; }
        public double Salary { get; set; }
        public DateTime BirthDate { get; set; }

        public int Age
        {
            get
            {
                var today = DateTime.Today;
                var age = today.Year - BirthDate.Year;
                if (BirthDate > today.AddYears(-age)) age--;
                return age;
            }
        }

        public static List<Employee> getEmployees()
        {
            return new List<Employee>()
        {
            new Employee { ID=1, Name="Nguyen Van Hoang", DepartmentID=1, Salary=70000, BirthDate=new DateTime(1995, 4, 25) },
            new Employee { ID=2, Name="Tran Thi Mai", DepartmentID=2, Salary=72000, BirthDate=new DateTime(1992, 8, 15) },
            new Employee { ID=3, Name="Pham Duc Anh", DepartmentID=1, Salary=68000, BirthDate=new DateTime(1998, 12, 1) },
            new Employee { ID=4, Name="Le Thi Hong", DepartmentID=3, Salary=71000, BirthDate=new DateTime(1994, 5, 19) },
            new Employee { ID=5, Name="Vu Đinh Long", DepartmentID=2, Salary=65000, BirthDate=new DateTime(1990, 3, 22) }
        };
        }
    }

}
