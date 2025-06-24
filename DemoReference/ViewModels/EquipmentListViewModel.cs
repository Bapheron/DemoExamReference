using DemoReference.Models;
using DemoReference.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoReference.ViewModels
{
    public class EquipmentListViewModel
    {
        private readonly TestDBConext _context;

        private TrackerService _trackerService;

        private IServiceProvider _serviceProvider;

        private ObservableCollection<Equipment> _equipmentCollection;

        public ObservableCollection<Equipment> EquipmentCollection
        {
            get => _equipmentCollection;
            set => _equipmentCollection = value;
        }

        public EquipmentListViewModel(TestDBConext context, IServiceProvider serviceProvider)
        {
            _context = context;
            _serviceProvider = serviceProvider;
            _trackerService = serviceProvider.GetRequiredService<TrackerService>();
            LoadEvents();
        }

        private void LoadEvents()
        {
            var equipments = _context.Equipments
                .Include(b => b.User)
                .Where(b => b.UserId == _trackerService.GetTrackedUser())
                .ToList();

            EquipmentCollection = new ObservableCollection<Equipment>(equipments);
        }
    }
}
