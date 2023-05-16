using CRUD_Tugas_MCC.Controller;
using CRUD_Tugas_MCC.Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD_Tugas_MCC.View
{
    public class EducationView
    {
        private EducationController _education = new EducationController();
        
        public void Output(List<Education> educations)
        {
            foreach (var data in educations)
            {
                Console.WriteLine($"\n ");
                Console.WriteLine($"Id            :{data.Id}");
                Console.WriteLine($"Major         :{data.Major}");
                Console.WriteLine($"Degree        :{data.Degree}");
                Console.WriteLine($"GPA           : {data.GPA}");
                Console.WriteLine($"Id university :{data.IdUniversity}");
            }
        }
        public void Output(Education education1)
        {
            Console.WriteLine($"\n");
            Console.WriteLine($"Id            :{education1.Id}");
            Console.WriteLine($"Major         :{education1.Major}");
            Console.WriteLine($"Degree        :{education1.Degree}");
            Console.WriteLine($"GPA           : {education1.GPA}");
            Console.WriteLine($"Id university :{education1.IdUniversity}");
        }
        public void Insert()
        {

            Console.WriteLine("*********************INSERT EDUCATION***********************");
            Console.Write("Masukkan Major         : ");
            string major = Console.ReadLine();
            Console.Write("Masukkan Degree        : ");
            string degree = Console.ReadLine();
            Console.Write("Masukkan GPA           : ");
            string gpa = Console.ReadLine();
            Console.Write("Masukkan ID University : ");
            int universityId = Convert.ToInt32(Console.ReadLine());

            Education education1 = new Education(major, degree, gpa, universityId);

            _education.insert(education1);
        }
        public void Update()
        {
            Console.WriteLine("*********************UPDATE EDUCATION***********************");
            Console.Write("Masukkan ID         : ");
            int id = Convert.ToInt32(Console.ReadLine());
            Console.Write("Masukkan Major         : ");
            string major = Console.ReadLine();
            Console.Write("Masukkan Degree        : ");
            string degree = Console.ReadLine();
            Console.Write("Masukkan GPA           : ");
            string gpa = Console.ReadLine();
            Console.Write("Masukkan ID University : ");
            int universityId = Convert.ToInt32(Console.ReadLine());
            Education education1 = new Education(id, major, degree, gpa, universityId);

            _education.Update(education1);
        }
        public void Delete()
        {
            Console.WriteLine("*********************DELETE EDUCATION***********************");
            Console.Write("Masukkan Id : ");
            int id = Convert.ToInt32(Console.ReadLine());
            _education.Delete(id);
        }
    }
}
