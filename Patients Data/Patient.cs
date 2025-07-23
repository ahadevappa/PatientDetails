using Newtonsoft.Json;
using PatientDetails;
using System.Security.Cryptography;

class Patient
{
    public static void CheckDetails(int eid)
    {
        Patients p = new Patients();
        string JsonDB = Environment.GetEnvironmentVariable("storePatient");
        string details = File.ReadAllText(JsonDB);
        List<Patients> list = JsonConvert.DeserializeObject<List<Patients>>(details);
        bool isfound = false;
        for (int i = 0; i < list.Count; i++)
        {
            if (eid == list[i].pid)
            {
                isfound = true;
                //Console.WriteLine("The Patient id : " + list[i].pid);
                //Console.WriteLine("The Patient Name :" + list[i].pname);
                //Console.WriteLine("The Patient Phone :" + list[i].phone);
            }
        }

        if (!isfound)
        {
            {   
                    Console.WriteLine("Your not register please enter your details:");
                    List<Patients> list1 = new List<Patients>();
                    if (File.Exists(JsonDB))
                    {
                        string data = File.ReadAllText(JsonDB);
                        list1 = JsonConvert.DeserializeObject<List<Patients>>(data);
                        p.pid = list1.Max(a => a.pid) + 1;
                    }

                    Console.WriteLine("Enter Patient Name:");
                    string name = Console.ReadLine();

                    while (string.IsNullOrWhiteSpace(name))
                    {
                        Console.WriteLine("Enter valid Patient Name:");
                        name = Console.ReadLine();


                    }
                    p.pname = name;

                    string phoneString;
                    long phone;

                    while (true)
                    {
                        Console.WriteLine("Enter patient phone number:");
                        phoneString = Console.ReadLine();


                        if (string.IsNullOrWhiteSpace(phoneString) || phoneString.Length != 10)
                        {
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


                    list.Add(p);

                    string srt = JsonConvert.SerializeObject(list, Formatting.Indented);
                    File.WriteAllText(JsonDB, srt);
                    Console.WriteLine("Details added successfully.....");
                
                Varifiacation.varify(eid);
            }
        }
    }
}