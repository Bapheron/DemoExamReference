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
    /// Логика взаимодействия для EquipmentListWindow.xaml
    /// </summary>
    public partial class EquipmentListWindow : Window
    {
        private IServiceProvider _serviceProvider;
        private TestDBConext _context;
        private TrackerService _trackerService;
        private EquipmentListViewModel _equipmentListViewModel;

        public EquipmentListWindow(IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _serviceProvider = serviceProvider;
            _context = _serviceProvider.GetRequiredService<TestDBConext>();
            _trackerService = _serviceProvider.GetRequiredService<TrackerService>();
            _equipmentListViewModel = _serviceProvider.GetRequiredService<EquipmentListViewModel>();
            DataContext = _equipmentListViewModel;

            UserNameLoader();
        }

        private void UserNameLoader()
        {
            var user = _context.Users.Find(_trackerService.GetTrackedUser());
            tbUserName.Text = user.Surname;
        }

        private void Return_Click(object sender, RoutedEventArgs e)
        {
            var returnWindow = new UserMainWindow(_serviceProvider);
            returnWindow.Show();
            this.Close();
        }
    }
}
