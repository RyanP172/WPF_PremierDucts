using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WiredBrainCoffee.CustomersApp.Model;

namespace WiredBrainCoffee.CustomersApp.Data
{
    public  interface IProductDataProvider
    {
        Task<IEnumerable<Product>?>GetAllAsync();

    }
}
