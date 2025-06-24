using DemoReference.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoReference.Services
{
    public class TrackerService
    {
        private TestDBConext _context;
        private User _user;
        public TrackerService(TestDBConext context)
        {
            _context = context;
        }

        public void SetTrackedUser(User user)
        {
            _user = user;
        }

        public int GetTrackedUser()
        {
            return _user.Id;
        }
    }
}
