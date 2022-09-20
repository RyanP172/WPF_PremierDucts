using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows;
using WiredBrainCoffee.CustomersApp.Data;
using WiredBrainCoffee.CustomersApp.ViewModel;

namespace WiredBrainCoffee.CustomersApp
{

    public partial class App : Application
    {
        private readonly ServiceProvider _serviceProvider;//readonly as it is initialize in a constructor

        public App()
        {
            ServiceCollection services = new();
            ConfigureServices(services);
            _serviceProvider = services.BuildServiceProvider();
        }

        private void ConfigureServices(ServiceCollection services)
        {
            services.AddTransient<MainWindow>();
            services.AddTransient<MainViewModel>();
            services.AddTransient<CustomerViewModel>();
            services.AddTransient<ProductsViewModel>();
            services.AddTransient<ICustomerDataProvider, CustomerDataProvider>();
            //When ICustomerDataProvider is needed, it pass in an instance of CustomerDataProvider
            services.AddTransient<IProductDataProvider, ProductDataProvider>();

        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var mainWindow = _serviceProvider.GetService<MainWindow>();
            mainWindow?.Show();
        }
    }
}
