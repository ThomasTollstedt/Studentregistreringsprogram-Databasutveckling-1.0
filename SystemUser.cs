using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Studentregistreringsprogram_Databas
{
    public class SystemUser
    {
        public int SystemUserId { get; set; }
        public string UserName { get; set; }
        private string password; // Osäkert som det är nu, hasha?

        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        public int UserRoleId { get; set; } //Foreign Key?
        public UserRole UserRole { get; set; } //navigering

    }
}
