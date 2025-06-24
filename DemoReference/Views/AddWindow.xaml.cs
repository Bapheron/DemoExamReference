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
            string num = tbNumber.Text;
            string name = tbName.Text;
            string type = tbType.Text;
            string descrip = tbDescription.Text;

            if (string.IsNullOrWhiteSpace(num) || string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(type) || string.IsNullOrWhiteSpace(descrip))
            {
                MessageBox.Show("Заполните все поля");
                return;
            }
            else
            {
                var equip = new Equipment();

                equip.InventoryNumber = num;
                equip.Name = name;
                equip.Type = type;
                equip.Description = descrip;
                equip.PublicationDate = DateOnly.FromDateTime(DateTime.Now);
                equip.State = Enums.EquipmentState.inStock;
                equip.UserId = null;

                _context.Equipments.Add(equip);
                _context.SaveChanges();
            }

            MessageBox.Show("Экипировка добавлена");
            var mainWindow = new AdminMainWindow(_serviceProvider);
            mainWindow.Show();
            this.Close();
        }
    }
}
