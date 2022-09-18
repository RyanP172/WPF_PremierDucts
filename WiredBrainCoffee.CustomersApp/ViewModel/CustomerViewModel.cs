using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using WiredBrainCoffee.CustomersApp.Command;
using WiredBrainCoffee.CustomersApp.Data;
using WiredBrainCoffee.CustomersApp.Model;


namespace WiredBrainCoffee.CustomersApp.ViewModel
{
    public class CustomerViewModel : ViewModelBase
    {
        private readonly ICustomerDataProvider _customerDataProvider;
        private CustomerItemViewModel? _selectedCustomer;
        private NavigationSide _navigationSide;

        public CustomerViewModel(ICustomerDataProvider customerDataProvider)
        {
            _customerDataProvider = customerDataProvider;
            AddCommand = new DelegateCommand(Add);
            MoveNavigationCommand = new DelegateCommand(MoveNavigation);
            DeleteCommand = new DelegateCommand(Delete, CanDelete);
        }

        

        /// <summary>
        /// ObservableCollection raised a CollectionChanged event 
        /// when add or remove customers from the collection
        /// </summary>
        public ObservableCollection<CustomerItemViewModel> Customers { get; } = new();//Expose the customer model to the UI
        public CustomerItemViewModel? SelectedCustomer
        { //Put ? after the type if the property can be null
            get => _selectedCustomer;
            set
            {
                _selectedCustomer = value;
                //RaisePropertyChanged("SelectedCustomer");//A nameof expression produces the name of a variable, type, or member as the string constant
                RaisePropertyChanged();
                RaisePropertyChanged(nameof(IsCustomerSelected));
                DeleteCommand.RaiseCanExecuteChanged();
            }
        }

        public bool IsCustomerSelected => SelectedCustomer != null;

        public NavigationSide NavigationDirection
        {
            get => _navigationSide;
            private set
            {
                _navigationSide = value;
                RaisePropertyChanged();
            }
        }
        public DelegateCommand AddCommand { get; }
        public DelegateCommand MoveNavigationCommand { get; }
        public DelegateCommand DeleteCommand { get; }

        public async override Task LoadAsync()
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
                    Customers.Add(new CustomerItemViewModel(c));
                }
            }
        }



        private void Add(object? parameter)
        {
            var customer = new Customer { FirstName = "New" };
            var customerItem = new CustomerItemViewModel(customer);
            Customers.Add(customerItem);
            SelectedCustomer = customerItem;//Data binding does not know about the changed
        }
        private void MoveNavigation(object? parameter)
        {
            NavigationDirection = NavigationDirection == NavigationSide.Left ? NavigationSide.Right : NavigationSide.Left;
        }

        private bool CanDelete(object? parameter) => SelectedCustomer != null;
        

        private void Delete(object? parameter)
        {
            if(SelectedCustomer != null)
            {
                Customers.Remove(SelectedCustomer);
                SelectedCustomer = null;
            }
        }

        public enum NavigationSide
        {
            Left,
            Right
        }
    }
}
