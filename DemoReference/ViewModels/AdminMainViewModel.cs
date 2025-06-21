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

        private ObservableCollection<BuilderJobDuties> _builderJobDutiesCollection;

        public ObservableCollection<BuilderJobDuties> BuilderJobDutiesCollection
        {
            get => _builderJobDutiesCollection;
            set => _builderJobDutiesCollection = value;

        }

        public AdminMainViewModel(TestDBConext context)
        {
            _context = context;
            LoadEvents();
        }

        private void LoadEvents()
        {
            var builderJDuties = _context.BuilderJobDuties
                .Include(b => b.Builder)
                .Include(b => b.JobDuties)
                .Include(b => b.User)
                .ToList();

            BuilderJobDutiesCollection = new ObservableCollection<BuilderJobDuties>(builderJDuties);
        }
    }
}
