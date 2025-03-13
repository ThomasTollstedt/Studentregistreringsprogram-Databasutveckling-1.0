﻿
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Studentregistreringsprogram_Databas
{
    class HandleStudent
    {

        public static void CreateStudent() // Skapa en student genom user input och lägg till i databasen
        {
            Console.Clear();
            var dbContext = new ApplicationDbContext();
            var student = new Student();
            Console.WriteLine("Ange förnamn: ");
            student.FirstName = Console.ReadLine();
            Console.WriteLine("Ange efternamn: ");
            student.LastName = Console.ReadLine();
            Console.WriteLine("Ange stad: ");
            student.City = Console.ReadLine();
            dbContext.Add(student);
            dbContext.SaveChanges();
            Console.WriteLine("Student inlagd i databas!");

            Menu.PrintMenu(); // Återgå till huvudmenyn
        }

        public static void ChangeStudent() // Ändra en students information genom user input och uppdatera i databasen
        {
            Console.Clear();
            Console.WriteLine("Vilken student önskar du ändra informationen kring?\n Ange förnamn och därefter efternamn");
            var dbContext = new ApplicationDbContext(); // Skapa en ny instans av databasen
            var std = dbContext.Students.Where(s => s.FirstName == Console.ReadLine() && s.LastName == Console.ReadLine()).FirstOrDefault<Student>(); // Hitta studenten i databasen

            if (std == null) // Om studenten inte hittas i databasen
            {
                Console.WriteLine("Angiven student kan ej hittas i systemet, försök igen.");
                return;
            }
            Console.WriteLine("Vilken information önskar du ändra?\nAnge1 för förnamn, 2 för efternamn eller 3 för stad");
            int choice = int.Parse(Console.ReadLine());

            switch (choice)
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
            dbContext.SaveChanges();
            Console.WriteLine("Ändringarna har sparat!\n\n");
            Menu.PrintMenu(); // Återgå till huvudmenyn
        }

        public static void ListStudents() // Lista samtliga studenter i databasen
        {
            Console.Clear();
            var dbContext = new ApplicationDbContext();


            Console.WriteLine("Följande studenter är registrerade");
            Console.WriteLine();
            foreach (var item in dbContext.Students.OrderBy(s => s.FirstName)) // Loopa igenom samtliga studenter i databasen och skriv ut
            {
                
                Console.WriteLine($"{item.FirstName}, {item.LastName} , {item.City}"); // Skriv ut studentens förnamn, efternamn och stad

            }
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Slut på studenter i listan");
            Console.WriteLine();
            Console.WriteLine();
            
            Menu.PrintMenu(); // Återgå till huvudmenyn
           
        }
    }
}
