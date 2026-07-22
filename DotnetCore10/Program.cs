using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public interface GenericClass<T> where T : struct
{
    T GetById(int id);

    void Add(T entity);
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
        TestExpressionMethod();
        // LINQ join example between Employee, Department and Salary
        TestLinqJoin();
        Console.WriteLine("Hello World!");
        User u = new User { Name = "John Doe", Id = 1, salary= 20000 };
        ImplementGenerics<User> user= new ImplementGenerics<User>();
        user.Add(u);
        User u2 = new User { Name = "Vin", Id = 2, salary = 20000 };
        user.Add(u2);

        User u3 = new User { Name = "Pr", Id = 3, salary = 24000 };
        user.Add(u3);

        var gu= user.GetById(2);
        Console.WriteLine($"User Name: {gu.Name} ID : {gu.Id}");

        var ss= user.GetAll()
            .Where(x=> x.Id>1)
            .GroupBy(x => x.salary)
            .OrderByDescending(x => x.Key)
            .Skip(1)
            .Select(x => x.First())
            .FirstOrDefault();

        var s1 = user.GetAll()
            .GroupBy(x=> x.salary)
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

    static void TestExpressionMethod()=> Console.WriteLine("Expression Bodied Method");

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
}