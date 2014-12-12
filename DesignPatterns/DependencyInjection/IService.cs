using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignPatterns.DependencyInjection
{
    public interface IService
    {
        void Serve();
    }

    public class Service : IService
    {
        public void Serve()
        {
            Console.WriteLine(" Service called ");
        }
    }

    public class ClientConstructorInjection
    {
        private IService service;

        public ClientConstructorInjection(IService service) 
        {
            this.service = service;
        }

        public void Start()
        {
            service.Serve();
        }
    }

    public class DIService
    {
        public static void Execute()
        { 
            ClientConstructorInjection clientConstructorInjection = new ClientConstructorInjection(new Service());
            clientConstructorInjection.Start();
        }
    }
}
