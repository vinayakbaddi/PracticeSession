using System;
using System.Collections.Generic;
using System.Linq;

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
    public static void Main(string[] args)
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
    }

    public static (int sum, double avg) Calculate(int[] numbers)
    {
        int sum = numbers.Sum();
        double avg = numbers.Average();
        return (sum, avg);
    }

    static void TestExpressionMethod()=> Console.WriteLine("Expression Bodied Method");
}