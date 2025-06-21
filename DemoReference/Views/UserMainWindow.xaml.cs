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
    /// Логика взаимодействия для UserMainWindow.xaml
    /// </summary>
    public partial class UserMainWindow : Window
    {
        private readonly UserMainViewModel _viewModel;
        private IServiceProvider _serviceProvider;
        public UserMainWindow(IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _viewModel = serviceProvider.GetRequiredService<UserMainViewModel>();
            DataContext = _viewModel;
            _serviceProvider = serviceProvider;
        }
    }
}
