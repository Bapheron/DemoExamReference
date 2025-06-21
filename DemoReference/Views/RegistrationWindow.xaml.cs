using DemoReference.Models;
using DemoReference.Services;
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
    /// Логика взаимодействия для RegistrationWindow.xaml
    /// </summary>
    public partial class RegistrationWindow : Window
    {
        private IServiceProvider _serviceProvider;
        private TestDBConext _context;
        public RegistrationWindow(IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _serviceProvider = serviceProvider;
            _context = _serviceProvider.GetRequiredService<TestDBConext>();
        }

        private void Confrim_Click(object sender, RoutedEventArgs e)
        {
   
            string login = tbLogin.Text;
            string password = tbPass.Text;

            if (string.IsNullOrWhiteSpace(login) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Заполните все поля");
                return;
            }
            else
            {
                var user = new User();

                user.Login = login;
                user.Password = password;
                user.Role = Enums.UserRole.ordinary_user;

                _context.Users.Add(user);
                _context.SaveChanges();
            }

            var loginWindow = new LoginWindow(_serviceProvider);
            loginWindow.Show();
            this.Close();
        }
    }
}
