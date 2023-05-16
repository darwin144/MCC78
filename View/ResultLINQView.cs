using CRUD_Tugas_MCC.Model;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD_Tugas_MCC.View
{
    public class ResultLINQView
    {
        public void Output(List<LINQResult> listLINQResult) {
            int i = 1;
            Console.WriteLine($"Total Employee:  {listLINQResult.Count()}");
            foreach (var data in listLINQResult) {
                    Console.WriteLine($"\nData {i} ");
                    Console.WriteLine($"NIK         : {data.NIK}");
                    Console.WriteLine($"FulName     : {data.Fullname}");
                    Console.WriteLine($"Birthdate   : {data.Birthdate.ToString("dd MMMM yyyy", CultureInfo.CreateSpecificCulture("id-ID"))}");
                    Console.WriteLine($"Gender      : {data.Gender}");
                    Console.WriteLine($"Hiring Date : {data.HiringDate.ToString("dd MMMM yyyy", CultureInfo.CreateSpecificCulture("id-ID"))}");
                    Console.WriteLine($"Email       : {data.Email}");
                    Console.WriteLine($"Phone Number: {data.PhoneNumber}");
                    Console.WriteLine($"Major       : {data.Major}");
                    Console.WriteLine($"Degree      : {data.Degree}");
                    Console.WriteLine($"GPA         : {data.GPA}");
                    Console.WriteLine($"Nama Universitas  : {data.UniversityName}");
                    i += 1;
                
            }
        }
    }
}
