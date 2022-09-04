using System.Windows;
using System.Windows.Controls;
using WiredBrainCoffee.CustomersApp.Data;
using WiredBrainCoffee.CustomersApp.ViewModel;

namespace WiredBrainCoffee.CustomersApp.View
{
    /// <summary>
    /// Interaction logic for CustomersView.xaml
    /// </summary>
    public partial class CustomersView : UserControl
    {
        private CustomerViewModel _viewModel;

        public CustomersView()
        {
            InitializeComponent();
            //Use the ViewModel for the Customer View
            _viewModel = new CustomerViewModel(new CustomerDataProvider());
            DataContext = _viewModel;
            //Create Loaded event for Customer View
            Loaded += CustomersView_Loaded;
        }

        private async void CustomersView_Loaded(object sender, RoutedEventArgs e)
        {
            await _viewModel.LoadAsync();//Now the _viewModel is assigned to the DataContext and this line of code is load data
        }

        private void ButtonMoveNavigation_Click(object sender, RoutedEventArgs e)
        {
            //    var column = (int)customerListGrid.GetValue(Grid.ColumnProperty);//GetValue method return Object, you need to cast in Int type because column is int
            //    var newColumn = column == 0 ? 2 : 0;//The actual value is 0, the new value is 2 or else, it's 0
            //    customerListGrid.SetValue(Grid.ColumnProperty, newColumn);
            //}
            var column = Grid.GetColumn(customerListGrid);//GetValue method return Object, you need to cast in Int type because column is int
            var newColumn = column == 0 ? 2 : 0;//The actual value is 0, the new value is 2 or else, it's 0
            Grid.SetColumn(customerListGrid, newColumn);
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.Add();
        }
    }
}
