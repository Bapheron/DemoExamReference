using DemoReference.Models;
using DemoReference.Services;
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
    /// Логика взаимодействия для UserMainWindow.xaml
    /// </summary>
    public partial class UserMainWindow : Window
    {
        private readonly UserMainViewModel _viewModel;
        private IServiceProvider _serviceProvider;
        private readonly TestDBConext _context;
        private TrackerService _tracker;

        public UserMainWindow(IServiceProvider serviceProvider)
        {
            InitializeComponent();

            _viewModel = serviceProvider.GetRequiredService<UserMainViewModel>();
            DataContext = _viewModel;
            _serviceProvider = serviceProvider;
            _context = _serviceProvider.GetRequiredService<TestDBConext>();
            _tracker = _serviceProvider.GetRequiredService<TrackerService>();

            UserNameLoader();
        }

        private void UserNameLoader() 
        {
            var user = _context.Users.Find(_tracker.GetTrackedUser());
            tbUserName.Text = user.Surname;
        }

        private void Asign_Click(object sender, RoutedEventArgs e)
        {
            if (myDataGrid.SelectedItem != null)
            {
                Equipment equip = (Equipment)myDataGrid.SelectedItem;

                equip.UserId = _tracker.GetTrackedUser();

                _context.Equipments.Update(equip);
                _context.SaveChanges();
            }
            else
            {
                MessageBox.Show("Выберете запись для изменения");
                return;
            }

            var reloadWindow = new UserMainWindow(_serviceProvider);
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

            var reloadWindow = new UserMainWindow(_serviceProvider);
            reloadWindow.Show();
            this.Close();
        }

        private void ToEquipmentListPage_Click(object sender, RoutedEventArgs e)
        {
            var listWindow = new EquipmentListWindow(_serviceProvider);
            listWindow.Show();
            this.Close();
        }
    }
}
