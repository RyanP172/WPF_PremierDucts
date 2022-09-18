using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WiredBrainCoffee.CustomersApp.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private readonly CustomerViewModel _customerViewModel;
        private ViewModelBase? _selectedViewModel;

        public MainViewModel(CustomerViewModel customerViewModel)
        {
            _customerViewModel = customerViewModel;
            SelectedViewModel = _customerViewModel;
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

        public async override Task LoadAsync()
        {
            if(SelectedViewModel != null)
            {
                await SelectedViewModel.LoadAsync();
            }

        }

    }
}
