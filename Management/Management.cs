using PatientDetails;
using PatientDetails.Patients_Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using Microsoft.Data.SqlClient;
using System.Data.SqlTypes;

namespace PatientDetails
{
    class Management
    {
        public static void Main(string[] args)
        {
            Run run = new Run();
            run.run();
        
        }
    }
}
