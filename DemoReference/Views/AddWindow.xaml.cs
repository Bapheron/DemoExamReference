using DemoReference.Models;
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
    /// Логика взаимодействия для AddWindow.xaml
    /// </summary>
    public partial class AddWindow : Window
    {
        private IServiceProvider _serviceProvider;
        private TestDBConext _context;

        public AddWindow(IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _serviceProvider = serviceProvider;
            _context = _serviceProvider.GetRequiredService<TestDBConext>();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            string fName = tbFName.Text;
            string sName = tbSName.Text;
            string patro = tbPatronymic.Text;

            if (string.IsNullOrWhiteSpace(fName) || string.IsNullOrWhiteSpace(sName) || string.IsNullOrWhiteSpace(patro))
            {
                MessageBox.Show("Заполните все поля");
                return;
            }
            else
            {
                var builder = new Builder();

                builder.FirstName = fName;
                builder.SecondName = sName;
                builder.Patronymic = patro;

                _context.Builders.Add(builder);
                _context.SaveChanges();
            }

            MessageBox.Show("Строитель добавлен");
            var mainWindow = new AdminMainWindow(_serviceProvider);
            mainWindow.Show();
            this.Close();
        }
    }
}
