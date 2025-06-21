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
    /// Логика взаимодействия для ChangeWindow.xaml
    /// </summary>
    public partial class ChangeWindow : Window
    {
        private IServiceProvider _serviceProvider;
        private TestDBConext _context;
        private BuilderJobDuties _builderJobDuties;
        public ChangeWindow(IServiceProvider serviceProvider, BuilderJobDuties builderJobDuties)
        {
            InitializeComponent();

            _serviceProvider = serviceProvider;
            _context = serviceProvider.GetRequiredService<TestDBConext>();
            _builderJobDuties = builderJobDuties;

            BuildersLoader();
            DutiesLoader();
            StartingValuesLoader();
        }

        public void StartingValuesLoader()
        {
            cbBuilders.SelectedValue = _builderJobDuties.BuilderId;
            cbDuties.SelectedValue = _builderJobDuties.JobDutiesId;
        }

        public void BuildersLoader()
        {
            var builders = _context.Builders.ToList(); // Используем _context вместо создания нового
            cbBuilders.ItemsSource = builders;
            cbBuilders.DisplayMemberPath = "SecondName";
            cbBuilders.SelectedValuePath = "Id";
        }

        public void DutiesLoader()
        {
            var duties = _context.JobDuties.ToList(); // Используем _context вместо создания нового
            cbDuties.ItemsSource = duties;
            cbDuties.DisplayMemberPath = "Name";
            cbDuties.SelectedValuePath = "Id";
        }

        private void Change_Click(object sender, RoutedEventArgs e)
        {

            int builderId = (int)cbBuilders.SelectedValue;
            int dutieId = (int)cbDuties.SelectedValue;

            if (builderId <= 0 || dutieId <= 0)
            {
                MessageBox.Show("Заполните все поля");
                return;
            }
            else
            {

                var existingRecord = _context.BuilderJobDuties.Find(_builderJobDuties.Id);

                if (existingRecord == null)
                {
                    MessageBox.Show("Запись не найдена!");
                    return;
                }

                existingRecord.BuilderId = builderId;
                existingRecord.JobDutiesId = dutieId;

                _context.BuilderJobDuties.Update(existingRecord);
                _context.SaveChanges();
 
            }

            var mainWindow = new AdminMainWindow(_serviceProvider);
            mainWindow.Show();
            this.Close();

        }
    }
}
