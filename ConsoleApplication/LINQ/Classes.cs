using System.Collections.Generic;
using System.Linq;

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

 

}
