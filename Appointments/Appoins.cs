using Newtonsoft.Json;
using PatientDetails;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientDetails
{
    public class Varifiacation
    {
        public static void varify(string eid)
        {
            Appintments ap=new Appintments();
            Patients p = new Patients();
            string Appoint = Environment.GetEnvironmentVariable("Appoints");
            string file=File.ReadAllText(Appoint);

            List<Appintments> date = JsonConvert.DeserializeObject<List<Appintments>>(file);
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
                    Console.WriteLine("The Patient Name :" + list[i].pname);
                    //Console.WriteLine("The Patient Phone :" + list[i].phone);
                    Console.WriteLine("Enter your dieses:");
                    ap.dieses=Console.ReadLine();
                    Console.WriteLine("Enter Date:");
                    ap.date = Console.ReadLine();

                    date.Add(ap);
                    string appoint=JsonConvert.SerializeObject(date, Formatting.Indented);
                    File.WriteAllText(Appoint, appoint);

                }

            }
        }
    }
}
