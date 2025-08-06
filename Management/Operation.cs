using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace PatientDetails.Patients_Data
{
    public class Operation
    {

        public void register()
        {
            
            Patients p = new Patients();

            string JsonDB = Environment.GetEnvironmentVariable("storePatient");
            string details = File.ReadAllText(JsonDB);
            List<Patients> list1 = JsonConvert.DeserializeObject<List<Patients>>(details);
            String id = list1.Max(a => a.pid);
                int iid=1+ int.Parse(id);
                p.pid=iid.ToString();
            
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Enter Patient Name:");
            Console.ForegroundColor = ConsoleColor.Cyan;
            string name = Console.ReadLine();

            while (string.IsNullOrWhiteSpace(name))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Enter valid Patient Name:");
                Console.ForegroundColor = ConsoleColor.Cyan;
                name = Console.ReadLine();


            }
            p.pname = name;

            string phoneString;
            long phone;

            while (true)
            {
                Console.WriteLine("Enter patient phone number:");
                Console.ForegroundColor = ConsoleColor.Cyan;
                phoneString = Console.ReadLine();


                if (string.IsNullOrWhiteSpace(phoneString) || phoneString.Length != 10)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("enter valid number.");
                    continue;
                }


                if (long.TryParse(phoneString, out phone))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Enter only numbers (no letters or symbols).");
                }
            }

            Console.WriteLine("Patient phone is: " + phone);




            p.phone = phone.ToString();


            list1.Add(p);

            string srt = JsonConvert.SerializeObject(list1, Formatting.Indented);
            File.WriteAllText(JsonDB, srt);
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("Details added successfully.....");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Your Patient ID is:"+ p.pid);
        }

        public void logIN(string pid)
        {

            Appintments ap = new Appintments();
            Patients p = new Patients();
            string Appoint = Environment.GetEnvironmentVariable("Appoints");
            string file = File.ReadAllText(Appoint);

            List<Appintments> date = JsonConvert.DeserializeObject<List<Appintments>>(file);
            string JsonDB = Environment.GetEnvironmentVariable("storePatient");
            string details = File.ReadAllText(JsonDB);
            List<Patients> list = JsonConvert.DeserializeObject<List<Patients>>(details);
            bool isfound = false;
            for (int i = 0; i < list.Count; i++)
            {


                if (pid == list[i].pid)
                {
                    isfound = true;
                    //Console.WriteLine("The Patient id : " + list[i].pid);
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine("The Patient Name :" + list[i].pname);
                    //Console.WriteLine("The Patient Phone :" + list[i].phone);
                    Console.WriteLine("Enter your disease:");
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    ap.disease = Console.ReadLine();
                    Console.WriteLine("Enter Date:");
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    ap.date = Console.ReadLine();
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine("Your appointment request sent successfuly.");

                    date.Add(ap);
                    string appoint = JsonConvert.SerializeObject(date, Formatting.Indented);
                    File.WriteAllText(Appoint, appoint);



                }
            }
                    if (!isfound)
                    {
                        Console.ForegroundColor= ConsoleColor.Red;
                        Console.WriteLine("Your not Register yet please register first!.");
                        register();
                    }

                
            
        }
    public void search(string pid)
        {
            string Appoint = Environment.GetEnvironmentVariable("Appoints");
            string file = File.ReadAllText(Appoint);

            List<Appintments> date = JsonConvert.DeserializeObject<List<Appintments>>(file);
            string JsonDB = Environment.GetEnvironmentVariable("storePatient");
            string details = File.ReadAllText(JsonDB);
            List<Patients> list = JsonConvert.DeserializeObject<List<Patients>>(details);

            bool isfound = false;
            for (int i = 0; i < list.Count; i++)
            {
                if ( pid == list[i].pname)
                {
                    isfound = true;
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("The Patient id : " + list[i].pid);
                    Console.WriteLine("The Patient Name :" + list[i].pname);
                    Console.WriteLine("The Patient Phone :" + list[i].phone);
                }
            }
            if (!isfound)
            {
                Console.ForegroundColor= ConsoleColor.Red;
                Console.WriteLine("Your not Register yet please register first!.");
                register();
            }
        } 
        public void search(int pid)
        {
            string Appoint = Environment.GetEnvironmentVariable("Appoints");
            string file = File.ReadAllText(Appoint);

            List<Appintments> date = JsonConvert.DeserializeObject<List<Appintments>>(file);
            string JsonDB = Environment.GetEnvironmentVariable("storePatient");
            string details = File.ReadAllText(JsonDB);
            List<Patients> list = JsonConvert.DeserializeObject<List<Patients>>(details);

            bool isfound = false;
            for (int i = 0; i < list.Count; i++)
            {
                if (pid ==int.Parse (list[i].pid))
                {
                    isfound = true;
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("The Patient id : " + list[i].pid);
                    Console.WriteLine("The Patient Name :" + list[i].pname);
                    Console.WriteLine("The Patient Phone :" + list[i].phone);
                }
            }
            if (!isfound)
            {
                Console.ForegroundColor= ConsoleColor.Red;
                Console.WriteLine("Your not Register yet please register first!.");
                register();
            }
        }
    }
}