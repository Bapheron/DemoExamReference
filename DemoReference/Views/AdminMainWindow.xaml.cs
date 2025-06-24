using DemoReference.Models;
using DemoReference.ViewModels;
using Microsoft.EntityFrameworkCore;
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
    /// Логика взаимодействия для AdminMainWindow.xaml
    /// </summary>
    public partial class AdminMainWindow : Window
    {
        private readonly AdminMainViewModel _viewModel;
        private IServiceProvider _serviceProvider;
        private TestDBConext _context;

        public AdminMainWindow(IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _viewModel = serviceProvider.GetRequiredService<AdminMainViewModel>();
            DataContext = _viewModel;
            _serviceProvider = serviceProvider;
            _context = _serviceProvider.GetRequiredService<TestDBConext>();
        }

        private void Asign_Click(object sender, RoutedEventArgs e)
        {
            if (myDataGrid.SelectedItem != null && myDataGrid2.SelectedItem != null)
            {
                Equipment equip = (Equipment)myDataGrid.SelectedItem;
                User userToAsign = (User)myDataGrid2.SelectedItem;

                equip.UserId = userToAsign.Id;

                _context.Equipments.Update(equip);
                _context.SaveChanges();
            }
            else
            {
                MessageBox.Show("Выберете запись для изменения");
                return;
            }

            var reloadWindow = new AdminMainWindow(_serviceProvider);
            reloadWindow.Show();
            this.Close();
        }

        private void Unasign_Click(object sender, RoutedEventArgs e)
        {
            if (myDataGrid.SelectedItem != null)
            {
                Equipment equip = (Equipment)myDataGrid.SelectedItem;

                equip.UserId = null;

                _context.Equipments.Update(equip);
                _context.SaveChanges();
            }
            else
            {
                MessageBox.Show("Выберете запись для изменения");
                return;
            }

            var reloadWindow = new AdminMainWindow(_serviceProvider);
            reloadWindow.Show();
            this.Close();
        }

        private void ToAddPage_Click(object sender, RoutedEventArgs e)
        {
            var addWindow = new AddWindow(_serviceProvider);
            addWindow.Show();
            this.Close();
        }

        private void ToChangePage_Click(object sender, RoutedEventArgs e)
        {
            if (myDataGrid.SelectedItem != null)
            {
                Equipment equip = (Equipment)myDataGrid.SelectedItem;
                var changeWindow = new ChangeWindow(_serviceProvider, equip);
                changeWindow.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Выберете запись для изменения");
                return;
            }
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if (myDataGrid.SelectedItem != null)
            {
                Equipment equip = (Equipment)myDataGrid.SelectedItem;

                _context.Equipments.Remove(equip);
                _context.SaveChanges();

                var reloadWindow = new AdminMainWindow(_serviceProvider);
                reloadWindow.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Выберете запись для изменения");
                return;
            }
        }
    }
}
