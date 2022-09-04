using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using WiredBrainCoffee.CustomersApp.Data;
using WiredBrainCoffee.CustomersApp.Model;


namespace WiredBrainCoffee.CustomersApp.ViewModel
{
    public class CustomerViewModel : ViewModelBase
    {
        private readonly ICustomerDataProvider _customerDataProvider;
        private Customer? _selectedCustomer;

        public CustomerViewModel(ICustomerDataProvider customerDataProvider)
        {
            _customerDataProvider = customerDataProvider;
        }

        /// <summary>
        /// ObservableCollection raised a CollectionChanged event 
        /// when add or remove customers from the collection
        /// </summary>
        public ObservableCollection<Customer> Customers { get; } = new();
        public Customer? SelectedCustomer
        { //Put ? after the type if the property can be null
            get => _selectedCustomer;
            set
            {
                _selectedCustomer = value;
                //RaisePropertyChanged("SelectedCustomer");//A nameof expression produces the name of a variable, type, or member as the string constant
                RaisePropertyChanged();
            }
        }


        public event PropertyChangedEventHandler? PropertyChanged;

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

        internal void Add()
        {
            var customer = new Customer { FirstName = "New" };
            Customers.Add(customer);
            SelectedCustomer = customer;//Data binding does not know about the changed
        }

        
    }
}
