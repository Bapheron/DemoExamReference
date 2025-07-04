﻿using DemoReference.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoReference.ViewModels
{
    public class UserMainViewModel
    {
        private readonly TestDBConext _context;

        private ObservableCollection<Equipment> _equipmentCollection;

        public ObservableCollection<Equipment> EquipmentCollection
        {
            get => _equipmentCollection;
            set => _equipmentCollection = value;

        }

        public UserMainViewModel(TestDBConext context)
        {
            _context = context;
            LoadEvents();
        }

        private void LoadEvents()
        {
            var equipments = _context.Equipments
                .Include(b => b.User)
                .ToList();

            EquipmentCollection = new ObservableCollection<Equipment>(equipments);
        }

    }
}
