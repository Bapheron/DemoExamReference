using DemoReference.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoReference.ViewModels
{
    internal class AdminMainViewModel
    {
        private readonly TestDBConext _context;

        private ObservableCollection<Equipment> _equipmentCollection;
        private ObservableCollection<User> _userCollection;


        public ObservableCollection<Equipment> EquipmentCollection
        {
            get => _equipmentCollection;
            set => _equipmentCollection = value;

        }
        public ObservableCollection<User> UserCollection
        {
            get => _userCollection;
            set => _userCollection = value;

        }

        public AdminMainViewModel(TestDBConext context)
        {
            _context = context;
            LoadEvents();
            LoadUsers();
        }

        private void LoadEvents()
        {
            var equipments = _context.Equipments
                .Include(b => b.User)
                .ToList();

            EquipmentCollection = new ObservableCollection<Equipment>(equipments);
        }

        private void LoadUsers()
        {
            var users = _context.Users
                .Where(u => u.RoleId == 2)
                .ToList();

            UserCollection = new ObservableCollection<User>(users);
        }
    }
}
