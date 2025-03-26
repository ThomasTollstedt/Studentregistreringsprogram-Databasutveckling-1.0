
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Studentregistreringsprogram_Databas
{
    public class HandleStudent
    {
        private readonly ApplicationDbContext _dbContext;

        public HandleStudent(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;

        }
        public void CreateStudent(SystemUser loggedInUser) // Skapa en student genom user input och lägg till i databasen
        {
            Console.Clear();
            var student = new Student();
            Console.WriteLine("Ange förnamn: ");
            student.FirstName = Console.ReadLine();
            Console.WriteLine("Ange efternamn: ");
            student.LastName = Console.ReadLine();
            Console.WriteLine("Ange stad: ");
            student.City = Console.ReadLine();
            _dbContext.Add(student);
            _dbContext.SaveChanges();
            Console.WriteLine("Student inlagd i databas!");

            Menu.PrintMenu(this, loggedInUser);
        }

        public void ChangeStudent(SystemUser loggedInUser) // Ändra en students information genom user input och uppdatera i databasen
        {
            Console.Clear();
            Console.WriteLine("Vilken student önskar du ändra informationen kring?\n Ange förnamn och därefter efternamn");

            var std = _dbContext.Students.Where(s => s.FirstName == Console.ReadLine() && s.LastName == Console.ReadLine()).FirstOrDefault<Student>(); // Hitta studenten i databasen

            if (std == null) // Om studenten inte hittas i databasen
            {
                Console.WriteLine("Angiven student kan ej hittas i systemet, försök igen.");
                return;
            }
            Console.WriteLine("Vilken information önskar du ändra?\nAnge1 för förnamn, 2 för efternamn eller 3 för stad");

            if (!int.TryParse(Console.ReadLine(), out int choice))
            {
                Console.WriteLine("Felaktig inmatning, försök igen");
                return;
            }


            switch (choice) // Menyval för val av information att ändra
            {
                case 1:
                    Console.WriteLine("Ange nytt förnamn: ");
                    std.FirstName = Console.ReadLine();
                    break;
                case 2:
                    Console.WriteLine("Ange nytt efternamn");
                    std.LastName = Console.ReadLine();
                    break;
                case 3:
                    Console.WriteLine("Ange ny stad");
                    std.City = Console.ReadLine();
                    break;
                default:
                    Console.WriteLine("Felaktig inmatning, försök igen.");
                    break;
            }
            _dbContext.SaveChanges();
            Console.WriteLine("Ändringarna har sparats!\n\n");
            Menu.PrintMenu(this, loggedInUser); // Återgå till huvudmenyn
        }

        public void ListStudents(SystemUser loggedInUser) // Lista samtliga studenter i databasen
        {
            Console.Clear();
            Console.WriteLine("Följande studenter är registrerade");
            Console.WriteLine();
            foreach (var item in _dbContext.Students.OrderBy(s => s.FirstName)) // Loopa igenom samtliga studenter i databasen och skriv ut
            {
                Console.WriteLine($"{item.FirstName}, {item.LastName} , {item.City}"); // Skriv ut studentens förnamn, efternamn och stad
            }
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Slut på studenter i listan");
            Console.WriteLine();
            Console.WriteLine();
            Menu.PrintMenu(this, loggedInUser); // Återgå till huvudmenyn

        }
    }
}
