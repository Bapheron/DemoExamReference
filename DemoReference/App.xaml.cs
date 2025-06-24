using DemoReference.Models;
using DemoReference.Services;
using DemoReference.ViewModels;
using DemoReference.Views;
using Microsoft.Extensions.DependencyInjection;
using System.Configuration;
using System.Data;
using System.Windows;

namespace DemoReference
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {

           

            var services = new ServiceCollection();

            services.AddDbContext<TestDBConext>();

            services.AddSingleton<AuthService>();
            services.AddSingleton<TrackerService>();

            services.AddTransient<LoginWindow>();

            services.AddTransient<UserMainViewModel>();
            services.AddTransient<AdminMainViewModel>();
            services.AddTransient<EquipmentListViewModel>();


            var serviceProvider = services.BuildServiceProvider();

            var loginWindow = serviceProvider.GetRequiredService<LoginWindow>();
            loginWindow.Show();
        }
    }

}
