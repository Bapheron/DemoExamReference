using DemoReference.Models;
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

        private ObservableCollection<User> _userCollection;

        public ObservableCollection<User> UserCollection
        {
            get => _userCollection;
            set => _userCollection = value;

        }

        public UserMainViewModel(TestDBConext context)
        {
            _context = context;
            LoadEvents();
        }

        private void LoadEvents()
        {
            var users = _context.Users
                .Where(u => u.Role == Enums.UserRole.ordinary_user)
                .ToList();

            UserCollection = new ObservableCollection<User>(users);
        }

    }
}
