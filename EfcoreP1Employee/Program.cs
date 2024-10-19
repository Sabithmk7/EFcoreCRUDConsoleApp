using EfcoreP1Employee.Models;
using Microsoft.EntityFrameworkCore;

namespace EfcoreP1Employee
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (var context = new EmloyeeDbContext())
            {
                var employee = GetEmployeeById(context, 5);
                Console.WriteLine($"{employee.Name} | {employee.Email} | {employee.Departments?.Name} | {employee.Departments?.Location}");
            }
        }
        static List<Employees> GetAllEmployees(EmloyeeDbContext context)
        {
            return context.Employees
                .Include(e => e.Departments)
                .ToList();
        }

        static Employees GetEmployeeById(EmloyeeDbContext context, int id)
        {
            return context.Employees
                .Include(e => e.Departments)
                .FirstOrDefault(e => e.Id == id);
        }

        static void AddEmployee(EmloyeeDbContext context, string name, string email, string gender, int salary, int departmentId)
        {
            var employee = new Employees
            {
                Name = name,
                Email = email,
                Gender = gender,
                Salary = salary,
                DepartmentId = departmentId
            };
            context.Employees.Add(employee);
            context.SaveChanges();
            Console.WriteLine("Employee added successfully.");
        }

        static void UpdateEmployee(EmloyeeDbContext context, int id, string name, string email, string gender, int salary, int departmentId)
        {
            var employee = context.Employees.Find(id);
            if (employee != null)
            {
                employee.Name = name;
                employee.Email = email;
                employee.Gender = gender;
                employee.Salary = salary;
                employee.DepartmentId = departmentId;
                context.SaveChanges();
                Console.WriteLine("Employee updated successfully.");
            }
            else
            {
                Console.WriteLine("Employee not found.");
            }
        }

        static void DeleteEmployee(EmloyeeDbContext context, int id)
        {
            var employee = context.Employees.Find(id);
            if (employee != null)
            {
                context.Employees.Remove(employee);
                context.SaveChanges();
                Console.WriteLine("Employee deleted successfully.");
            }
            else
            {
                Console.WriteLine("Employee not found.");
            }
        }

        static List<Employees> GetEmployeesBySalary(EmloyeeDbContext context, int salary)
        {
            return context.Employees
                .Include(e => e.Departments)
                .Where(e => e.Salary > salary)
                .ToList();
        }

        static List<Departments> GetAllDepartments(EmloyeeDbContext context)
        {
            return context.Departments.ToList();
        }

        static Departments GetDepartmentById(EmloyeeDbContext context, int id)
        {
            return context.Departments.Find(id);
        }

        static void AddDepartment(EmloyeeDbContext context, string name, string location)
        {
            var department = new Departments
            {
                Name = name,
                Location = location
            };
            context.Departments.Add(department);
            context.SaveChanges();
            Console.WriteLine("Department added successfully.");
        }

        static void UpdateDepartment(EmloyeeDbContext context, int id, string name, string location)
        {
            var department = context.Departments.Find(id);
            if (department != null)
            {
                department.Name = name;
                department.Location = location;
                context.SaveChanges();
                Console.WriteLine("Department updated successfully.");
            }
            else
            {
                Console.WriteLine("Department not found.");
            }
        }

        static void DeleteDepartment(EmloyeeDbContext context, int id)
        {
            var department = context.Departments.Find(id);
            if (department != null)
            {
                context.Departments.Remove(department);
                context.SaveChanges();
                Console.WriteLine("Department deleted successfully.");
            }
            else
            {
                Console.WriteLine("Department not found.");
            }
        }
    }
}
