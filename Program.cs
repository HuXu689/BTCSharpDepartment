using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTCSharpDepartment
{
    class Program
    {
        static void Main(string[] args)
        {
            bool continueProgram = true;
            while (continueProgram)
            {
                Console.WriteLine("Nguyen Xuan Huynh - 21115053120322:");
                Console.WriteLine("1. Hien thi muc luong cao nhat va thap nhat");
                Console.WriteLine("2. Thuc hien Group Join va Left Join");
                Console.WriteLine("3. Hien thi do tuoi cao nhat va thap nhat cua nhan vien");
                Console.Write("Nhap lua chon: ");

                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        DisplayMaxAndMinSalary();
                        break;
                    case "2":
                        PerformGroupAndLeftJoin();
                        break;
                    case "3":
                        DisplayMaxAndMinAge();
                        break;
                    default:
                        Console.WriteLine("Lua chon khong hop le.");
                        break;
                }

                Console.Write("Nhap 'Y' de tiep tuc: ");
                string tieptuc = Console.ReadLine();
                continueProgram = tieptuc == "y" || tieptuc == "Y";
                Console.WriteLine();
                Console.Clear();
            }
        }

        private static void DisplayMaxAndMinSalary()
        {
            var employees = Employee.getEmployees();
            var departments = Department.getDepartments();

            var maxSalaryEmployee = employees.OrderByDescending(e => e.Salary).First();
            var minSalaryEmployee = employees.OrderBy(e => e.Salary).First();

            var maxSalaryDepartment = departments.FirstOrDefault(d => d.ID == maxSalaryEmployee.DepartmentID)?.Name;
            var minSalaryDepartment = departments.FirstOrDefault(d => d.ID == minSalaryEmployee.DepartmentID)?.Name;

            Console.WriteLine("Nhan vien co muc luong cao nhat:");
            PrintEmployeeDetails(maxSalaryEmployee, maxSalaryDepartment);

            Console.WriteLine("\nNhan vien co muc luong thap nhat:");
            PrintEmployeeDetails(minSalaryEmployee, minSalaryDepartment);
        }
        private static void PerformGroupAndLeftJoin()
        {
            var departments = Department.getDepartments();
            var employees = Employee.getEmployees();

            var departmentGroups = departments.GroupJoin(
                employees,
                d => d.ID,
                e => e.DepartmentID,
                (department, emps) => new { Department = department, Employees = emps.DefaultIfEmpty() });

            foreach (var deptGroup in departmentGroups)
            {
                Console.WriteLine($"Phong ban: {deptGroup.Department.Name}");
                foreach (var emp in deptGroup.Employees)
                {
                    string departmentName = deptGroup.Department.Name;
                    PrintEmployeeDetails(emp, departmentName);
                }
            }
        }
        private static void DisplayMaxAndMinAge()
        {
            var employees = Employee.getEmployees();
            var departments = Department.getDepartments();

            var oldestEmployee = employees.OrderByDescending(e => e.Age).First();
            var youngestEmployee = employees.OrderBy(e => e.Age).First();

            var oldestEmployeeDepartment = departments.FirstOrDefault(d => d.ID == oldestEmployee.DepartmentID)?.Name;
            var youngestEmployeeDepartment = departments.FirstOrDefault(d => d.ID == youngestEmployee.DepartmentID)?.Name;

            Console.WriteLine("Nhan vien lon tuoi nhat:");
            PrintEmployeeDetails(oldestEmployee, oldestEmployeeDepartment);

            Console.WriteLine("\nNhan vien tre tuoi nhat:");
            PrintEmployeeDetails(youngestEmployee, youngestEmployeeDepartment);
        }
        private static void PrintEmployeeDetails(Employee emp, string departmentName)
        {
            if (emp != null)
            {
                Console.WriteLine($"ID: {emp.ID}, Ten: {emp.Name}, Ngay sinh: {emp.BirthDate.ToString("dd/MM/yyyy")}, Luong: {emp.Salary.ToString("C")}, Phong: {departmentName}");
            }
            else
            {
                Console.WriteLine("Khong co nhan vien");
            }
        }
    }
}
