using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_Management_System.Services
{
    public class AuthenticationService
    {
        public bool ValidateCredentials(string username, string password)
        {
            // Hardcoded credentials
            return username == "Admin" && password == "password";
        }
    }
}