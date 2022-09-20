using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WiredBrainCoffee.CustomersApp.Model;

namespace WiredBrainCoffee.CustomersApp.Data
{
    public class ProductDataProvider : IProductDataProvider
    {
        public async Task<IEnumerable<Product>?> GetAllAsync()
        {
            await Task.Delay(100);//Simulate a bit of server work
            return new List<Product>()
            {
                new Product{Name ="Cappuchino", Description="Espresso with milk and milk foam"},
                new Product{Name ="Latte", Description ="Espresso with strong flavor"},
                new Product{Name ="Mocha", Description="Espresso with hot chocolate and milk foam"}
            };
        }

    
    }
}
