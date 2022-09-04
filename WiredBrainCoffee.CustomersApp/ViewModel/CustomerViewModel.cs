using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using WiredBrainCoffee.CustomersApp.Data;
using WiredBrainCoffee.CustomersApp.Model;

namespace WiredBrainCoffee.CustomersApp.ViewModel
{
    public class CustomerViewModel
    {
        private readonly ICustomerDataProvider _customerDataProvider;
        

        public CustomerViewModel(ICustomerDataProvider customerDataProvider)
        {
            _customerDataProvider = customerDataProvider;
        }

        /// <summary>
        /// ObservableCollection raised a CollectionChanged event 
        /// when add or remove customers from the collection
        /// </summary>
        public ObservableCollection<Customer> Customers { get; } = new();

        public async Task LoadAsync()
        {
            if (Customers.Any())
            {
                return;
            }


            var customers = await _customerDataProvider.GetAllAsync();
            if (customers != null)
            {
                foreach (var c in customers)
                {
                    Customers.Add(c);
                }
            }
        }
    }
}
