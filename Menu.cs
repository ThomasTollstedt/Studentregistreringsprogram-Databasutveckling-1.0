using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Linq;
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
        public static void PrintMenu()
        {

            Console.WriteLine($"{welcome}");
            Console.WriteLine("-----------------");
            Console.WriteLine($"{registerStudent}");
            Console.WriteLine($"{changeStudent}");
            Console.WriteLine($"{listStudents}");
            Console.WriteLine($"{exitProgram}");

            MenuInput();
        }

        public static void MenuInput()
        {
            string answer;

            do
            {
                int menuSelection = 99;
                Console.WriteLine("Välj ett alternativ");


                while (!int.TryParse(Console.ReadLine(), out menuSelection))
                {
                    Console.WriteLine("Ogiltligt val, försök igen.");
                    Console.WriteLine("Välj ett alternativ");
                }



                switch (menuSelection)
                {
                    case 1:
                        HandleStudent.CreateStudent();
                        break;
                    case 2:
                        HandleStudent.ChangeStudent();
                        break;
                    case 3:
                        HandleStudent.ListStudents();
                        break;
                    case 4:
                        Console.WriteLine("Programmet avslutas.");
                        return; //Avslutar programmet
                    default:
                        Console.WriteLine(invalidInput);
                        PrintMenu();
                        break;
                }

                Console.WriteLine("Säker att du vill avsluta programmet?\nJ/N"); //Läggas på annat håll för att inte välja avsluta och därefter behöva input J/N för att avsluta igen?
                answer = Console.ReadLine().ToLower();
                if (answer != "n")
                {
                    break;
                }
            } while (answer == "n");
            
                if (answer == "n")
                {
                    PrintMenu();
                }
            
           

        }
    }
}
