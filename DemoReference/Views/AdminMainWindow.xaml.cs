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

        private void ToAddPage_Click(object sender, RoutedEventArgs e)
        {
            var addWindow = new AddWindow(_serviceProvider);
            addWindow.Show();
            this.Close();
        }

        private void ToChangePage_Click(object sender, RoutedEventArgs e)
        {
           if(myDataGrid.SelectedItem != null)
            {
                BuilderJobDuties builderJobDuties = (BuilderJobDuties)myDataGrid.SelectedItem;
                var changeWindow = new ChangeWindow(_serviceProvider, builderJobDuties);
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
            BuilderJobDuties builderJobDuties = (BuilderJobDuties)myDataGrid.SelectedItem;

            _context.BuilderJobDuties.Remove(builderJobDuties);
            _context.SaveChanges();
            
            var reloadWindow = new AdminMainWindow(_serviceProvider);
            reloadWindow.Show();
            this.Close();
        }
    }
}
