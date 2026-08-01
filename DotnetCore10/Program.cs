using DotnetCore10;
using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

public interface GenericClass<T> where T : struct
{
    T GetById(int id);

    void Add(T entity);
}

public static class StringExtensions2
{
    public static string Reverse(this string str)
    {
        if (string.IsNullOrEmpty(str)) return str;
        char[] arr = str.ToCharArray();
        Array.Reverse(arr);
        return new string(arr);
    }
}
// String extension: add hyphen after every 2 characters
public static class StringExtensions
{
    public static string AddHyphensEvery2(this string input)
    {
        if (string.IsNullOrEmpty(input))
            return input;

        var sb = new StringBuilder(input.Length + input.Length / 2);
        for (int i = 0; i < input.Length; i++)
        {
            sb.Append(input[i]);
            // after every 2 characters (i is zero-based)
            if ((i + 1) % 2 == 0 && i != input.Length - 1)
                sb.Append('-');
        }

        return sb.ToString();
    }
}

public class ImplementGenerics<T> : GenericClass<T> where T : struct
{
    private readonly Dictionary<int, T> _entity = new Dictionary<int, T>();

    public T GetById(int id)
    {
        _entity.TryGetValue(id, out var value);

        return value;
    }

    public void Add(T entity)
    {
        _entity.Add(_entity.Count + 1, entity);
    }

    public IEnumerable<T> GetAll()
    {
        return _entity.Values;
    }


    public IEnumerable<T> GetAll(Func<T, bool> predicate)
    {
        if (predicate == null) return GetAll();

        return _entity.Values.Where(predicate);
    }

}

public struct User
{
    public string Name { get; set; }

    public int Id { get; set; }

    public double salary { get; set; }

}
public class Program
{
    public static async Task Main(string[] args)
    {
        //var no = Console.ReadLine();
        //switch (no)
        //{
        //    case "1":
        //        Console.WriteLine("Dhanaraja");
        //        break;
        //    case "7":
        //        Console.WriteLine("Ronaldo");
        //        break;
        //    default:
        //        Console.WriteLine("No Match");
        //        break;

        //}
        "data".AddHyphensEvery2();
        ReflectionClass.RunDemo();
        TestExpressionMethod();
        // LINQ join example between Employee, Department and Salary
        TestLinqJoin();
        // Demonstrate different join types
        JoinTypes();
        // Demo: string extension to add hyphen after every 2 characters
        var sample = "ABCDEFGHIJ";
        Console.WriteLine($"\nOriginal: {sample}");
        Console.WriteLine($"Hyphenated: {sample.AddHyphensEvery2()}");

        // Entity Framework demonstration (AsNoTracking and CompileQuery)
        // Note: Requires Microsoft.EntityFrameworkCore and Microsoft.EntityFrameworkCore.InMemory packages
        await DemonstrateEntityFrameworkAsync();
        Console.WriteLine("Hello World!");
        User u = new User { Name = "John Doe", Id = 1, salary = 20000 };
        ImplementGenerics<User> user = new ImplementGenerics<User>();
        user.Add(u);
        User u2 = new User { Name = "Vin", Id = 2, salary = 20000 };
        user.Add(u2);

        User u3 = new User { Name = "Pr", Id = 3, salary = 24000 };
        user.Add(u3);

        var gu = user.GetById(2);
        Console.WriteLine($"User Name: {gu.Name} ID : {gu.Id}");

        var ss = user.GetAll()
            .Where(x => x.Id > 1)
            .GroupBy(x => x.salary)
            .OrderByDescending(x => x.Key)
            .Skip(1)
            .Select(x => x.First())
            .FirstOrDefault();

        var s1 = user.GetAll()
            .GroupBy(x => x.salary)
            .OrderByDescending(x => x.Key)
            .Skip(1)
            .Select(x => x.First())
            .FirstOrDefault();
        Console.WriteLine($"User Name: {s1.Name} ID : {s1.Id} Salary : {s1.salary}");


        var v = Calculate(new[] { 10, 20, 30 });
        Console.WriteLine($"Sum: {v.sum}, Average: {v.avg}");
        Console.WriteLine($"User Name: {ss.Name} ID : {ss.Id} Salary : {ss.salary}");

        await TestAsyncMethod();
        await TestAsyncMethod2();

        var t1 = TestAsyncMethod();
        var t2 = TestAsyncMethod();
        Task.WaitAll(t1, t2);
        Console.WriteLine("All Async Methods Completed");
    }

    public static (int sum, double avg) Calculate(int[] numbers)
    {
        int sum = numbers.Sum();
        double avg = numbers.Average();
        return (sum, avg);
    }

    static void TestExpressionMethod() => Console.WriteLine("Expression Bodied Method");

    public async static Task TestAsyncMethod()
    {
        await Task.Delay(5000);
        Console.WriteLine("Async Method");
    }

    public async static Task TestAsyncMethod2()
    {
        await Task.Delay(5000);
        Console.WriteLine("Async Method2");
    }

    // --- LINQ join example and sample data initialization ---
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int DepartmentId { get; set; }
    }

    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class Salary
    {
        public int EmployeeId { get; set; }
        public decimal Amount { get; set; }
    }

    static void TestLinqJoin()
    {
        var departments = new List<Department>
        {
            new Department { Id = 1, Name = "Engineering" },
            new Department { Id = 2, Name = "HR" },
            new Department { Id = 3, Name = "Finance" }
        };

        var employees = new List<Employee>
        {
            new Employee { Id = 1, Name = "Alice", DepartmentId = 1 },
            new Employee { Id = 2, Name = "Bob", DepartmentId = 2 },
            new Employee { Id = 3, Name = "Charlie", DepartmentId = 1 },
            new Employee { Id = 4, Name = "Diana", DepartmentId = 3 }
        };

        var salaries = new List<Salary>
        {
            new Salary { EmployeeId = 1, Amount = 90000 },
            new Salary { EmployeeId = 2, Amount = 60000 },
            new Salary { EmployeeId = 3, Amount = 95000 },
            new Salary { EmployeeId = 4, Amount = 70000 }
        };

        var sal2 = salaries
            .Select(x => x.Amount)
            .Distinct()
            .OrderByDescending(x => x)
            .Skip(1)
            .FirstOrDefault();
        Console.WriteLine($"Second salar is {sal2}");

        // Group employees by department and pick top 2 salaries per department
        var sal2G = from e in employees
                    join d in departments on e.DepartmentId equals d.Id
                    join s in salaries on e.Id equals s.EmployeeId
                    group new { Employee = e, Salary = s } by new { d.Id, d.Name } into g
                    select new
                    {
                        DepartmentId = g.Key.Id,
                        DepartmentName = g.Key.Name,
                        TopEmployees = g
                            .OrderByDescending(x => x.Salary.Amount)
                            .Take(2)
                            .Select(x => new { Id = x.Employee.Id, Name = x.Employee.Name, Amount = x.Salary.Amount })
                            .ToList()
                    };


        var empl = from e in employees
                   join d in departments on e.DepartmentId equals d.Id
                   join s in salaries on e.Id equals s.EmployeeId
                   select new { EmployeId = e.Id, EmployeeName = e.Name, DepartmentName = d.Name, SalaryAmount = s.Amount };

        // Join Employee -> Department -> Salary
        var employeeDetails = from e in employees
                              join d in departments on e.DepartmentId equals d.Id
                              join s in salaries on e.Id equals s.EmployeeId
                              select new { e.Id, e.Name, Department = d.Name, Salary = s.Amount };

        Console.WriteLine("\nEmployee - Department - Salary (joined results):");
        foreach (var item in employeeDetails)
        {
            Console.WriteLine($"Id:{item.Id} Name:{item.Name} Dept:{item.Department} Salary:{item.Salary}");
        }

        // Show employees belonging to a specific department (e.g., Engineering)
        var engineeringEmployees = from e in employees
                                   join d in departments on e.DepartmentId equals d.Id
                                   where d.Name == "Engineering"
                                   select new { e.Id, e.Name, Department = d.Name };

        Console.WriteLine("\nEmployees in Engineering department:");
        foreach (var emp in engineeringEmployees)
        {
            Console.WriteLine($"Id:{emp.Id} Name:{emp.Name} Dept:{emp.Department}");
        }
    }

    // Demonstrates cross, inner, self, left and right join using LINQ
    static void JoinTypes()
    {
        var departments = new List<Department>
        {
            new Department { Id = 1, Name = "Engineering" },
            new Department { Id = 2, Name = "HR" },
            new Department { Id = 3, Name = "Finance" }
        };

        var employees = new List<Employee>
        {
            new Employee { Id = 1, Name = "Alice", DepartmentId = 1 },
            new Employee { Id = 2, Name = "Bob", DepartmentId = 2 },
            new Employee { Id = 3, Name = "Charlie", DepartmentId = 1 },
            new Employee { Id = 4, Name = "Diana", DepartmentId = 3 },
            // Employee without a matching department to show unmatched in right-join simulation
            new Employee { Id = 5, Name = "Eve", DepartmentId = 999 }
        };

        Console.WriteLine("\n--- Cross Join (Cartesian product) ---");
        var cross = from e in employees
                    from d in departments
                    select new { Employee = e.Name, Department = d.Name };
        foreach (var item in cross.Take(10)) // limit output
            Console.WriteLine($"Employee:{item.Employee} Dept:{item.Department}");

        Console.WriteLine("\n--- Inner Join (match employees to their department) ---");
        var inner = from e in employees
                    join d in departments on e.DepartmentId equals d.Id
                    select new { e.Name, Department = d.Name };
        foreach (var item in inner)
            Console.WriteLine($"Employee:{item.Name} Dept:{item.Department}");

        Console.WriteLine("\n--- Self Join (pair colleagues in same department) ---");
        var self = from e1 in employees
                   from e2 in employees
                   where e1.Id != e2.Id && e1.DepartmentId == e2.DepartmentId
                   select new { Employee = e1.Name, Colleague = e2.Name, DeptId = e1.DepartmentId };
        foreach (var item in self)
            Console.WriteLine($"Employee:{item.Employee} Colleague:{item.Colleague} DeptId:{item.DeptId}");

        Console.WriteLine("\n--- Left Join (all departments, with their employees if any) ---");
        var left = from d in departments
                   join e in employees on d.Id equals e.DepartmentId into gj
                   from e in gj.DefaultIfEmpty()
                   select new { Department = d.Name, Employee = e != null ? e.Name : "(none)" };
        foreach (var item in left)
            Console.WriteLine($"Dept:{item.Department} Employee:{item.Employee}");

        Console.WriteLine("\n--- Right Join (simulate: all employees, include department when present) ---");
        // LINQ has no direct right join; simulate by swapping sides or doing left join from the other side
        var right = from e in employees
                    join d in departments on e.DepartmentId equals d.Id into gj
                    from d in gj.DefaultIfEmpty()
                    select new { Employee = e.Name, Department = d != null ? d.Name : "(no dept)" };
        foreach (var item in right)
            Console.WriteLine($"Employee:{item.Employee} Dept:{item.Department}");
    }

    // -------------------- Entity Framework demo --------------------
    // This demo uses EF Core's InMemory provider to show AsNoTracking and CompileQuery.
    // Add the packages: Microsoft.EntityFrameworkCore and Microsoft.EntityFrameworkCore.InMemory
    public class EmployeeEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int DepartmentId { get; set; }
        // Navigation property for eager loading via Include
        public DepartmentEntity Department { get; set; }
    }

    public class DepartmentEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        // Back-reference collection
        public ICollection<EmployeeEntity> Employees { get; set; }
    }

    public class AppDbContext : DbContext
    {
        public DbSet<EmployeeEntity> Employees { get; set; }
        public DbSet<DepartmentEntity> Departments { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    }

    public class EmployeeDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Department { get; set; }
    }

    // Compiled query example: prepares the expression once for repeated execution
    private static readonly Func<AppDbContext, int, IEnumerable<EmployeeDto>> _compiledByDept =
        EF.CompileQuery((AppDbContext ctx, int deptId) =>
            ctx.Employees
               .Where(e => e.DepartmentId == deptId)
               .Join(ctx.Departments, e => e.DepartmentId, d => d.Id,
                     (e, d) => new EmployeeDto { Id = e.Id, Name = e.Name, Department = d.Name })
        );

    private static async Task DemonstrateEntityFrameworkAsync()
    {
        var options = new DbContextOptionsBuilder<AppDbContext>()
            .UseInMemoryDatabase("EfDemoDb")
            .Options;

        using (var ctx = new AppDbContext(options))
        {
            // Seed data
            ctx.Departments.AddRange(new[] {
                new DepartmentEntity { Id = 1, Name = "Engineering" },
                new DepartmentEntity { Id = 2, Name = "HR" }
            });

            ctx.Employees.AddRange(new[] {
                new EmployeeEntity { Id = 1, Name = "Alice", DepartmentId = 1 },
                new EmployeeEntity { Id = 2, Name = "Bob", DepartmentId = 2 },
                new EmployeeEntity { Id = 3, Name = "Charlie", DepartmentId = 1 }
            });

            await ctx.SaveChangesAsync();

            Console.WriteLine("\nEF Core: Query with tracking (default)");
            var tracked = ctx.Employees.Where(e => e.DepartmentId == 1).ToList();
            Console.WriteLine($"Returned {tracked.Count} employees. Tracked entries: {ctx.ChangeTracker.Entries().Count()}");

            Console.WriteLine("\nEF Core: Query with AsNoTracking (no change tracking, better for read-only)");
            var notTracked = ctx.Employees.AsNoTracking().Where(e => e.DepartmentId == 1).ToList();
            Console.WriteLine($"Returned {notTracked.Count} employees. Tracked entries after AsNoTracking: {ctx.ChangeTracker.Entries().Count()}");

            Console.WriteLine("\nEF Core: Using compiled query for repeated execution (by department id)");
            var results = _compiledByDept(ctx, 1).ToList();
            foreach (var r in results)
            {
                Console.WriteLine($"Id:{r.Id} Name:{r.Name} Dept:{r.Department}");
            }

            Console.WriteLine("\nEF Core: Eager loading with Include (Employees with Department loaded)");
            var withInclude = ctx.Employees.Include(e => e.Department).Where(e => e.DepartmentId == 1).ToList();
            foreach (var e in withInclude)
            {
                Console.WriteLine($"Id:{e.Id} Name:{e.Name} Dept:{e.Department?.Name}");
            }

            Console.WriteLine("\nEF Core: Eager loading with Include + AsNoTracking (read-only)");
            //var includeNoTrack = ctx.Employees.Include(e => e.Department).AsNoTracking().Where(e => e.DepartmentId == 1).ToList();
            var includeNoTrack = ctx.Employees.AsNoTracking().Where(e => e.DepartmentId == 1).ToList();
            foreach (var e in includeNoTrack)
            {
                Console.WriteLine($"Id:{e.Id} Name:{e.Name} Dept:{e.Department?.Name}");
            }

        }
    }




}