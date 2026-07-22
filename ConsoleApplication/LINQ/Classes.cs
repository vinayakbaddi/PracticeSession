using System.Collections.Generic;
using System.Linq;
using System;

namespace ConsoleApplication.LINQ
{
    public class ListOfParentClass
    {

        public List<ChildClass> ChildClasses { get; set; }
    }

    public class ChildClass
    {
        public int Id { get; set; }

    }

    public class PlayWithClassesForLinq
    {
        public void Play()
        {
            var listOfParentClasses = new List<ListOfParentClass>()
            {
                new ListOfParentClass()
                {
                    ChildClasses = new List<ChildClass>()
                    {
                        new ChildClass()
                        {
                            Id = 1
                        },
                        new ChildClass()
                        {
                            Id = 6
                        },
                        new ChildClass()
                        {
                            Id = 6
                        }
                    }
                },
                new ListOfParentClass()
                {
                    ChildClasses = new List<ChildClass>()
                    {
                        new ChildClass()
                        {
                            Id = 3
                        }
                    }
                },
                new ListOfParentClass()
                {
                    ChildClasses = new List<ChildClass>()
                    {
                        new ChildClass()
                        {
                            Id = 6
                        }
                    }
                }
            };

            System.Console.WriteLine(FindCount(listOfParentClasses));

            
        }

        public int FindCount(List<ListOfParentClass> listOfParentClasses)
        {

            var count = listOfParentClasses.Select(x => x.ChildClasses).ToList();
            var data = count.Select(x => x.Where(y => y.Id == 1)).ToList();

            var count2 = listOfParentClasses.SelectMany(x => x.ChildClasses).Count(y => y.Id == 6);


            return count2;

        }
    }

    public class LinqMethods
    {

        public static void Run()
        {
            Queries();
            // run join demo
            LinqJoinDemo.Run();
        }
        public static void Execute()
        {
            IList<short> shortList = new List<short>(){10,20,30};
            IList<int> intList = new List<int>() { 10, 20, 30 };

            Console.WriteLine(shortList.Sum(x=>(short)x)); // Doesn't work unless converted

            //var printDataWithDelegates = shortList(x=> delegate(x) { Console.WriteLine(x) };);

            Console.WriteLine(intList.Sum()); 
        }

    // New demo classes for join queries
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int AddressId { get; set; }
    }

    public class Address
    {
        public int Id { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
    }

    public class Order
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public decimal Amount { get; set; }
    }

    public static class LinqJoinDemo
    {
        public static void Run()
        {
            // initialize sample data
            var addresses = new List<Address>
            {
                new Address { Id = 1, City = "Hubballi", Street = "MG Road" },
                new Address { Id = 2, City = "Bengaluru", Street = "Brigade Road" },
                new Address { Id = 3, City = "Hubballi", Street = "KHB Colony" }
            };

            var customers = new List<Customer>
            {
                new Customer { Id = 1, Name = "Alice", AddressId = 1 },
                new Customer { Id = 2, Name = "Bob", AddressId = 2 },
                new Customer { Id = 3, Name = "Charlie", AddressId = 3 },
                new Customer { Id = 4, Name = "Diana", AddressId = 2 }
            };

            var orders = new List<Order>
            {
                new Order { Id = 1, CustomerId = 1, Amount = 120.50m },
                new Order { Id = 2, CustomerId = 1, Amount = 50.00m },
                new Order { Id = 3, CustomerId = 2, Amount = 200.00m },
                new Order { Id = 4, CustomerId = 3, Amount = 10.00m },
                new Order { Id = 5, CustomerId = 3, Amount = 15.00m },
                new Order { Id = 6, CustomerId = 3, Amount = 5.00m },
                new Order { Id = 7, CustomerId = 4, Amount = 300.00m }
            };

            Console.WriteLine("--- LINQ Join Demo ---");

            // Customer with highest single order value
            var maxOrder = orders.OrderByDescending(o => o.Amount).FirstOrDefault();
            if (maxOrder != null)
            {
                var customer = customers.FirstOrDefault(c => c.Id == maxOrder.CustomerId);
                Console.WriteLine($"Customer with highest single order value: {customer?.Name} (Order #{maxOrder.Id}, Amount: {maxOrder.Amount:C})");
            }

            // Customer with maximum number of orders
            var customerWithMostOrders = orders.GroupBy(o => o.CustomerId)
                .Select(g => new { CustomerId = g.Key, OrderCount = g.Count(), Total = g.Sum(x => x.Amount) })
                .OrderByDescending(x => x.OrderCount)
                .FirstOrDefault();

            if (customerWithMostOrders != null)
            {
                var cust = customers.FirstOrDefault(c => c.Id == customerWithMostOrders.CustomerId);
                Console.WriteLine($"Customer with maximum orders: {cust?.Name} (Orders: {customerWithMostOrders.OrderCount}, Total: {customerWithMostOrders.Total:C})");
            }

            // Customers from city Hubballi (join customers with addresses)
            var hubballiCustomers = from c in customers
                                    join a in addresses on c.AddressId equals a.Id
                                    where a.City.Equals("Hubballi", StringComparison.OrdinalIgnoreCase)
                                    select new { c.Name, a.City, a.Street };

            Console.WriteLine("Customers from Hubballi:");
            foreach (var hc in hubballiCustomers)
            {
                Console.WriteLine($"- {hc.Name} (City: {hc.City}, Street: {hc.Street})");
            }

            Console.WriteLine();
        }
    }

        public static void Queries()
        { 
            Employee employee = new Employee();
            employee.Id = 1;
            employee.Name = "John";
            employee.Age = 30;
            employee.Gender = "male";

            Employee e2 = new Employee();
            e2.Id = 2;
            e2.Age = 32;
            e2.Gender = "female";
            e2.Name = "Jane";

            Department d1 = new Department();
            d1.Id = 1;
            d1.Name = "IT";
            d1.Employees = new List<Employee>();
            d1.Employees.Add(employee);
            d1.Employees.Add(e2);

            //Department d2 = new Department();
            //d2.Id = 2;
            //d2.Name = "Accounts";
            //d2.Employees = new List<Employee>();
            //d2.Employees.Add(e2);

            var age = d1.Employees.Max(x => x.Age);


        }
    }

    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
    }

    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Employee> Employees { get; set; }
    }



}
