using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Quic;
using System.Text;
using System.Threading.Tasks;

namespace Studentregistreringsprogram_Databas
{
    public class Menu
    {
        const string welcome = "Välkommen!\nVälj alternativ enligt nedan:";
        const string registerStudent = "1.Registrera ny student";
        const string changeStudent = "2.Ändra befintlig students information";
        const string listStudents = "3.Lista samtliga studenter";
        const string exitProgram = "4.Avsluta programmet";
        const string invalidInput = "Felaktig inmatning, försök igen";
        public static void PrintMenu(HandleStudent handleStudent, SystemUser loggedInUser)
        {

            Console.WriteLine($"{welcome}");
            Console.WriteLine("-----------------");
            Console.WriteLine($"{registerStudent}");
            Console.WriteLine($"{changeStudent}");
            Console.WriteLine($"{listStudents}");
            Console.WriteLine($"{exitProgram}");

            MenuInput(handleStudent, loggedInUser);
        }

        private static void MenuInput(HandleStudent handleStudent, SystemUser loggedInUser)
        {
            string answer;

            do
            {
                int menuSelection = 99;
                Console.WriteLine("Välj ett alternativ");


                while (!int.TryParse(Console.ReadLine(), out menuSelection)) //Hantera ev felaktig input från user
                {
                    Console.WriteLine("Ogiltligt val, försök igen.");
                    Console.WriteLine("Välj ett alternativ");
                }

                switch (menuSelection) //Menyval
                {
                    case 1:
                        handleStudent.CreateStudent(loggedInUser); //Anropa metod för att skapa student
                        break;
                    case 2:
                        if (loggedInUser.UserRole.RoleName == "Admin")
                        {
                            Console.WriteLine("Behörig!");
                            Thread.Sleep(2000);
                            handleStudent.ChangeStudent(loggedInUser); //Anropa metod för att ändra student

                        }
                        else
                        {
                            Console.WriteLine("Du har inte behörighet till denna funktion");
                        }

                        break;
                    case 3:
                        handleStudent.ListStudents(loggedInUser); //Anropa metod för att lista studenter
                        break;
                    case 4:
                        Console.WriteLine("Säker att du vill avsluta programmet?\nJ/N");

                        if (Console.ReadLine().ToLower() == "n")
                        {
                            PrintMenu(handleStudent, loggedInUser);
                        }
                        else
                        {
                            return;
                        }
                        break;
                    default: //Felaktig input
                        Console.WriteLine(invalidInput);
                        break;
                }

                if (menuSelection != 4)
                {
                    Console.WriteLine("Vill du fortsätta? (J/N)");
                    answer = Console.ReadLine().ToLower();

                }
                else
                {
                    answer = "n";

                }
            } while (answer == "J");
        }
    }
}


