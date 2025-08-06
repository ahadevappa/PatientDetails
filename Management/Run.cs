using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arrow;

namespace PatientDetails.Patients_Data

{
    internal class Run
    {
        public void run()
        {
            Num n = new Num();
            string[] menuItems = {
            "Register Patient",
            "Appointment",
            "Search by Patient ID or Patient Name",
            "Exit"
        };
            int selectedIndex = 0;
            int lastSelectedIndex = -1;
            Arrow1 arrowHandler = new Arrow1();
            bool running = true;

            Console.CursorVisible = false;
            Console.Clear();
            DisplayMenu(menuItems, selectedIndex);

            while (running)
            {
                ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                ConsoleKey key = keyInfo.Key;

                if (key == ConsoleKey.UpArrow || key == ConsoleKey.DownArrow)
                {
                    selectedIndex = arrowHandler.HandleArrowKey(key, menuItems, selectedIndex);

                    if (selectedIndex != lastSelectedIndex)
                    {
                        Console.SetCursorPosition(0, 0);
                        DisplayMenu(menuItems, selectedIndex);
                        lastSelectedIndex = selectedIndex;
                    }
                }
                else if (key == ConsoleKey.Enter)
                {
                    Console.Clear();
                    Console.WriteLine($"You selected: {menuItems[selectedIndex]}");
                    n.opn(selectedIndex + 1);

                    if (selectedIndex == menuItems.Length - 1)
                    {
                        running = false;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("Press any key to return to menu...");
                        Console.ReadKey(true);
                        Console.Clear();
                        DisplayMenu(menuItems, selectedIndex);
                        lastSelectedIndex = -1;
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
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine("Press any key to return to menu...");
                            Console.ReadKey(true);
                            Console.Clear();
                            DisplayMenu(menuItems, selectedIndex);
                            lastSelectedIndex = -1;
                        }
                    }
                }
                else if (key == ConsoleKey.Escape)
                {
                    Console.Clear();
                    Console.ForegroundColor= ConsoleColor.Magenta;
                    Console.WriteLine("Exiting...");
                    break;
                }
            }

            Console.CursorVisible = true;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Program Ended. Press any key...");
            Console.ReadKey();
        }

        static void DisplayMenu(string[] items, int selectedIndex)
        {

            int windowwidth = 60;
            int windowheight = 15;

            int x = (Console.WindowWidth-windowwidth)/2;
            int y = (Console.WindowHeight - windowheight) / 2;

            for (int i = 0; i < windowheight; i++)

            {

                Console.SetCursorPosition(x, y + i+2);
                Console.ForegroundColor = ConsoleColor.Magenta;
                if (i == 0)

                    
                    Console.Write("╔" + new string('═', windowwidth - 2) + "╗");

                else if (i == windowheight - 1)

                    Console.Write("╚" + new string('═', windowwidth - 2) + "╝");

                else

                    Console.Write("║" + new string(' ', windowwidth - 2) + "║");

            }



            //Console.ForegroundColor = ConsoleColor.Green;
            //Console.WriteLine("=== Patient Management System ===");
            //Console.ResetColor();


            //for (int i = 0; i < items.Length; i++)
            //{

            //    if (i == selectedIndex)
            //    {
            //        Console.ForegroundColor = ConsoleColor.Blue;
            //        Console.BackgroundColor = ConsoleColor.Cyan;
            //        Console.WriteLine($">> {i + 1}. {items[i]}");
            //        Console.ResetColor();

            //    }
            //    else
            //    {
            //        Console.WriteLine($"   {i + 1}. {items[i]}");
            //    } 
            //}
            //Console.ForegroundColor = ConsoleColor.Yellow;
            //Console.WriteLine("Use ↑ ↓ arrows or 1-4 keys. Press Enter to select, Esc to exit.");

            //Console.Clear();
                int windowWidth = Console.WindowWidth;
                int windowHeight = Console.WindowHeight;

                string title = "=== Patient Management System ===";
                int boxWidth = 50;
                int boxHeight = items.Length + 6; 
                int startX = (windowWidth - boxWidth) / 2;
                int startY = (windowHeight - boxHeight) / 2;

                Console.SetCursorPosition(startX, startY);
                Console.ForegroundColor = ConsoleColor.Red;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(startX, startY + 1);
                Console.SetCursorPosition(startX + (boxWidth - title.Length) / 2, startY + 1);
                Console.ForegroundColor =(ConsoleColor) ConsoleColor.Green;
                Console.Write(title);
                Console.SetCursorPosition(startX + boxWidth - 1, startY + 5);

                Console.SetCursorPosition(startX, startY + 2);

                for (int i = 0; i < items.Length; i++)
                {
                    Console.SetCursorPosition(startX, startY + 3 + i);
                    if (i == selectedIndex)
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.BackgroundColor = ConsoleColor.Cyan;
                        Console.Write($">> {i + 1}. {items[i]}");
                        Console.ResetColor();
                    }
                    else
                    {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write($"   {i + 1}. {items[i]}");
                    }
                Console.ForegroundColor = ConsoleColor.Red;
                }

                string instruction = "Use ↑ ↓ or 1-4. Enter=Select, Esc=Exit.";
                Console.SetCursorPosition(startX + (boxWidth - instruction.Length) / 2, startY + 4 + items.Length);
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine(instruction);
                Console.ResetColor();
            

        }
    }
}