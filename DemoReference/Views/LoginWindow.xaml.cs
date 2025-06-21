using DemoReference.Services;
using DemoReference.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace DemoReference.Views
{
    /// <summary>
    /// Логика взаимодействия для LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        private readonly AuthService _authService;
        private IServiceProvider _serviceProvider;
        public LoginWindow(IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _authService = serviceProvider.GetRequiredService<AuthService>();
            _serviceProvider = serviceProvider;
        }

        private void Enter_Click(object sender, RoutedEventArgs e)
        {
            string login = tbLogin.Text;
            string password = tbPass.Text;

            if (string.IsNullOrWhiteSpace(login) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Введите имя пользователя и пароль");
                return;
            }

            if (_authService.AdminLogin(login, password))
            {
                var mainWindow = new AdminMainWindow(_serviceProvider);
                mainWindow.Show();
                this.Close();
            }
            else if (_authService.UserLogin(login, password))
            {
                var mainWindow = new UserMainWindow(_serviceProvider);
                mainWindow.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Неверное имя пользователя или пароль");
            }
        }

        private void ToRegistrationPage_Click(object sender, RoutedEventArgs e)
        {
            var mainWindow = new RegistrationWindow(_serviceProvider);
            mainWindow.Show();
            this.Close();
        }
    }
}
