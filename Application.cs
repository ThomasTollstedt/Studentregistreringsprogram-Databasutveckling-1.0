using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Studentregistreringsprogram_Databas
{
    public class Application
    {

        private readonly ApplicationDbContext _dbContext;
        private readonly HandleStudent _handleStudent;

        public Application()
        {
            _dbContext = new ApplicationDbContext();
            _handleStudent = new HandleStudent(_dbContext);

        }

        public SystemUser Login(ApplicationDbContext dbCtx)
        {
            SystemUser user = null;
            do
            {
                Console.WriteLine("Ange användarnamn");
                string username = Console.ReadLine();
                Console.WriteLine("Ange lösenord");
                string password = Console.ReadLine();
                user = _dbContext.SystemUsers
                    .Include (u => u.UserRole)
                    .FirstOrDefault(u => u.UserName == username && u.Password == password);
                if (user == null)
                {
                    Console.WriteLine("Felaktigt användarnamn och/eller lösenord");
                }

            }
            while (user == null);
            return user;

        }
        //public void Run(SystemUser user)
        //{
        //    //inloggning för att sedan köra Menu.PrintMenu nedan
            
        //    Menu.PrintMenu(_handleStudent, user);
        //}


    }
}
