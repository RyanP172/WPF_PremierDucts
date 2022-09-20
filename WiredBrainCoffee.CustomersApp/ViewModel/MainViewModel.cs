using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WiredBrainCoffee.CustomersApp.Command;

namespace WiredBrainCoffee.CustomersApp.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        //private readonly CustomerViewModel _customerViewModel;
        //private readonly ProductsViewModel _productsViewModel;

        private ViewModelBase? _selectedViewModel;

        public MainViewModel(CustomerViewModel customerViewModel, ProductsViewModel productsViewModel)
        {
            CustomerViewModel = customerViewModel;
            ProductsViewModel = productsViewModel;

            //SelectedViewModel = _customerViewModel;
            SelectedViewModel = CustomerViewModel;
            SelectViewModelCommand = new DelegateCommand(SelectViewModel);
        }



        public ViewModelBase? SelectedViewModel
        {
            get => _selectedViewModel;
            set
            {
                _selectedViewModel = value;
                RaisePropertyChanged();
            }
        }
        public CustomerViewModel CustomerViewModel { get; }
        public ProductsViewModel ProductsViewModel { get; }

        public DelegateCommand SelectViewModelCommand { get;  }

        public async override Task LoadAsync()
        {
            if(SelectedViewModel != null)
            {
                await SelectedViewModel.LoadAsync();
            }

        }
        /// <summary>
        /// In order to pass a ViewModel as a parameter to this method
        /// the UI need to know the detail of view model. 
        /// Hence need to change the private field to public properties
        /// </summary>
        /// <param name="parameter"></param>
        private async void SelectViewModel(object? parameter)
        {
            SelectedViewModel = parameter as ViewModelBase;
            await LoadAsync();
        }

    }
}
