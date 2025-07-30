using PatientDetails;
using PatientDetails.Patients_Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace PatientDetails
{
    class Receipt
    {
        public static void Main(string[] args)
        {

            Num n = new Num();
            string[] menuItems = {
            "Register Patient",
            "Appointment",
            "Search by Patient ID or Patient Name",
            "Exit"
        };
            int selectedIndex = 0;
            Arrow arrowHandler = new Arrow();
            bool running = true;

            while (running)
            {
                Console.Clear();
                DisplayMenu(menuItems, selectedIndex);

                ConsoleKeyInfo keyInfo = Console.ReadKey(true); 
                ConsoleKey key = keyInfo.Key;

                if (key == ConsoleKey.UpArrow || key == ConsoleKey.DownArrow)
                {
                    selectedIndex = arrowHandler.HandleArrowKey(key, menuItems, selectedIndex);
                }
                else if (key == ConsoleKey.Enter)
                {
                    
                    Console.Clear();
                    Console.WriteLine($"You selected: {menuItems[selectedIndex]}");
                    n.opn(selectedIndex+1);


                    if (selectedIndex == menuItems.Length - 1) 
                    {
                        running = false;
                    }
                    else
                    {
                        Console.WriteLine("Press any key to return to menu...");
                        Console.ReadKey(true);
                    }
                }
                else if (key >= ConsoleKey.D1 && key <= ConsoleKey.D4)
                {
                    int userChoice = key - ConsoleKey.D0; 

                    if (userChoice >= 1 && userChoice <= menuItems.Length)
                    {
                         selectedIndex = userChoice - 1; 
                        Console.Clear();
                        Console.WriteLine($"You selected: {menuItems[selectedIndex]}");

                        n.opn(userChoice); 

                        if (userChoice == menuItems.Length)
                        {
                            running = false;
                        }
                        else
                        {
                            Console.WriteLine("Press any key to return to menu...");
                            Console.ReadKey(true);
                        }
                    }
                }

                else if (key == ConsoleKey.Escape)
                {
                    Console.Clear();
                    Console.WriteLine("Exiting...");
                    break;
                }
            }

            Console.WriteLine("Program Ended. Press any key...");
            Console.ReadKey();
        }
        static void DisplayMenu(string[] items, int selectedIndex)
        {
          
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("=== Hospital Management Menu ===");
            Console.ResetColor();

            for (int i = 0; i < items.Length; i++)
            {
                
                if (i == selectedIndex)
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.BackgroundColor = ConsoleColor.Cyan;
                    Console.WriteLine($">> {i + 1}. {items[i]}");
                    Console.ResetColor();
                }
                else
                {
                    Console.WriteLine($"   {i + 1}. {items[i]}");
                }
            }

            Console.WriteLine("Use ↑ ↓ arrows or 1-4 keys. Press Enter to select, Esc to exit.");
        }
    }
}
