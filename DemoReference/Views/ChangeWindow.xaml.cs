using DemoReference.Models;
using DemoReference.Enums;
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
    /// Логика взаимодействия для ChangeWindow.xaml
    /// </summary>
    public partial class ChangeWindow : Window
    {
        private IServiceProvider _serviceProvider;
        private TestDBConext _context;
        private Equipment _equipment;
        public ChangeWindow(IServiceProvider serviceProvider, Equipment equipment)
        {
            InitializeComponent();

            _serviceProvider = serviceProvider;
            _context = serviceProvider.GetRequiredService<TestDBConext>();
            _equipment = equipment;
            StatusLoader();
            StartingValuesLoader();
        }

        private void StatusLoader()
        {
            cbStatus.ItemsSource = EquipmentState.GetValues(typeof(EquipmentState));
        }

        private void StartingValuesLoader()
        {
            tbNumber.Text = _equipment.InventoryNumber;
            tbName.Text = _equipment.Name;
            tbType.Text = _equipment.Type;
            tbDescription.Text = _equipment.Description;
            cbStatus.SelectedItem = _equipment.State;
        }

        private void Change_Click(object sender, RoutedEventArgs e)
        {
            string num = tbNumber.Text;
            string name = tbName.Text;
            string type = tbType.Text;
            string descrip = tbDescription.Text;
            EquipmentState state = (EquipmentState)cbStatus.SelectedItem;

            if (string.IsNullOrWhiteSpace(num) || string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(type) || string.IsNullOrWhiteSpace(descrip) || state == null)
            {
                MessageBox.Show("Заполните все поля");
                return;
            }
            else
            {
                var equip = _context.Equipments.Find(_equipment.Id);

                equip.InventoryNumber = num;
                equip.Name = name;
                equip.Type = type;
                equip.Description = descrip;
                equip.State = state;
                equip.UserId = null;

                _context.Equipments.Update(equip);
                _context.SaveChanges();
            }

            var mainWindow = new AdminMainWindow(_serviceProvider);
            mainWindow.Show();
            this.Close();

        }
    }
}
