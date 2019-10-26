using ApplicationCore.Entities;
using ApplicationCore.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationInfrastructure
{
    public class CleanService : ICleanService
    {
        public void Clean()
        {
            Console.WriteLine("Does sth magical");
        }


        CleanStatus ICleanService.CleanStatus()
        {
            return new CleanStatus()
            {
                Cleaned = true
            };
        }
    }
}
