using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WiredBrainCoffee.CustomersApp.Model;

namespace WiredBrainCoffee.CustomersApp.Data
{
    public class CustomerDataProvider : ICustomerDataProvider
    {
        /// <summary>
        /// async and await is to implement Asynchronous Programming
        /// By using Asynchronous programming, the Application can continue with the other work 
        /// that does not depend on the completion of the entire task
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Customer>?> GetAllAsync()
        {
            await Task.Delay(100);//Demonstration server working time
            return new List<Customer>
            {
                new Customer{Id = 1, FirstName ="Julie", LastName ="Nguyen", IsDeveloper = true},
                new Customer{Id = 2, FirstName ="John", LastName ="Pham" },
                new Customer{Id = 3, FirstName ="Ryan", LastName ="Pham", IsDeveloper = true},
                new Customer{Id = 4, FirstName ="Peter", LastName ="Holman", IsDeveloper = true},
                new Customer{Id = 5, FirstName ="Daniel", LastName ="Le"},
                new Customer{Id = 6, FirstName ="Mick", LastName ="CQT"},
            };
        }
    }
}
