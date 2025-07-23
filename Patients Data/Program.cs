using Newtonsoft.Json;
using PatientDetails;
using System;
using System.Security.Cryptography;
public class PatientsMain

{
    public static void Main(string[] args)
    {
        Patients p = new Patients();
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("Enter a Patient id:");

        int pid = Convert.ToInt32(Console.ReadLine());
        Varifiacation.varify(pid);

        Patient.CheckDetails(pid);

    }
}
