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

        public void Run()
        {
            Menu.PrintMenu(_handleStudent);
        }

    }
}
