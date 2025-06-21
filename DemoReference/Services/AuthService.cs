using DemoReference.Enums;
using DemoReference.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoReference.Services
{
    public class AuthService
    {
        private readonly TestDBConext _context;

        public AuthService(TestDBConext context)
        {
            _context = context;
        }

        public bool UserLogin(string login, string password)
        {
            return _context.Users.Any(u => u.Login == login && u.Password == password);
        }

        public bool AdminLogin(string login, string password)
        {
            return _context.Users.Any(u => u.Login == login && u.Password == password && u.Role == UserRole.administrator);

        }
    }
}
