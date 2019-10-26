using ApplicationCore.Entities;
using ApplicationCore.Interface;
using System;
using System.Threading.Tasks;

namespace ApplicationInfrastructure
{
    public class DemoService : IDemoService
    {
        private ICleanService _cleanService;

        public DemoService(ICleanService cleanService)
        {
            _cleanService = cleanService;
        }
        public Task<DrinkKanji> Serve()
        {
            Console.WriteLine("Here");
            var status = _cleanService.CleanStatus();

            Console.Write("status is {0}", status.Cleaned);

            return Task.FromResult<DrinkKanji>(new DrinkKanji() { Name = "Ragi" });
        }
    }
}
