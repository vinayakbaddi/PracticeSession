using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication.Methods
{
    public partial class PartialMethod
    {
        partial void PartialMethodImpl();        

        //Error	1	No defining declaration found for implementing declaration of partial method 'ConsoleApplication.Methods.PartialMethod.PartialMethodImpl()'	
        //partial void PartialMethodImpl() 
        //{
        //    Console.WriteLine("this is it");
        //}

        //Error	1	Partial methods must have a void return type	
        //partial string PartialMethodWithReturn()
        //{
        //    Console.WriteLine("this is it");
        //    return string.Empty;
        //}

    }

}
