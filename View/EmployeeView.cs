using CRUD_Tugas_MCC.Model;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD_Tugas_MCC.View
{
    public class EmployeeView
    {        
        public void Output(List<Employee> employees)
        {
            foreach (var data in employees)
            {
                Console.WriteLine("\n");
                Console.WriteLine($"NIK         : {data.NIK}");
                Console.WriteLine($"FulName     : {data.FirstName} {data.LastName}");
                Console.WriteLine($"Birthdate   : {data.Birthdate.ToString("dd MMMM yyyy", CultureInfo.CreateSpecificCulture("id-ID"))}");
                Console.WriteLine($"Gender      : {data.Gender}");
                Console.WriteLine($"Hiring Date : {data.HiringDate.ToString("dd MMMM yyyy", CultureInfo.CreateSpecificCulture("id-ID"))}");
                Console.WriteLine($"Email       : {data.Email}");
                Console.WriteLine($"Phone Number: {data.PhoneNumber}");
            }
        }
        public void Output(Employee data)
        {
            Console.WriteLine($"NIK         : {data.NIK}");
            Console.WriteLine($"FulName     : {data.FirstName} {data.LastName}");
            Console.WriteLine($"Birthdate   : {data.Birthdate.ToString("dd MMMM yyyy", CultureInfo.CreateSpecificCulture("id-ID"))}");
            Console.WriteLine($"Gender      : {data.Gender}");
            Console.WriteLine($"Hiring Date : {data.HiringDate.ToString("dd MMMM yyyy", CultureInfo.CreateSpecificCulture("id-ID"))}");
            Console.WriteLine($"Email       : {data.Email}");
            Console.WriteLine($"Phone Number: {data.PhoneNumber}");
        }

       
    }
}
