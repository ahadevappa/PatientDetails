using PatientDetails.Patients_Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace PatientDetails
{
    internal class Num
    {
        public void opn(int selected)
        {
            Operation rg =new Operation();
            switch (selected)
            {
                case 1:
                    rg.register();
                    break;

                case 2:
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Enter Patient ID:");
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    string pid = Console.ReadLine();
                    rg.logIN(pid);
                    break;

                case 3:
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Enter Patient ID or Patient Name:");
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    string name = Console.ReadLine();

                    if (int.TryParse(name, out int id))
                    {
                        rg.search(id);
                        break;
                    }
                    else
                    {
                        rg.search(name);
                        break;
                    }

                case 4:
                    
                    Console.WriteLine("Exiting...");
                    break;

                default:
                    Console.WriteLine("Choose valid option");
                    break;

            }


        }
    }
}
