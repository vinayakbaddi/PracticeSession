using ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Interface
{
    public interface IDemoService
    {
        Task<DrinkKanji> Serve();
    }
}
