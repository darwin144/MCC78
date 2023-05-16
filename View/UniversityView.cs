using CRUD_Tugas_MCC.Controller;
using CRUD_Tugas_MCC.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD_Tugas_MCC.View
{
    public class UniversityView
    {
        UniversityController controlUniversity = new UniversityController();
        public void Output(List<University> universities) {
            foreach (var data in universities) {
                Console.WriteLine($"Id : {data.IdUniversity}");
                Console.WriteLine($"Name : {data.Name}");
            }        
        }
        public void Output(University university) {
            Console.WriteLine($"Id : {university.IdUniversity}");
            Console.WriteLine($"Name : {university.Name}");
        }

        public void Input() {
           
            Console.WriteLine("*********************INSERT UNIVERSITY***********************");
            Console.WriteLine("Masukkan Nama University : ");
            string nama = Console.ReadLine();
            //var university = new University(nama);
            controlUniversity.insert(nama);
            //university.Insert(university);
        }
        public void Update() {
            Console.WriteLine("*********************UPDATE UNIVERSITY***********************");
            Console.WriteLine("Masukkan Id : ");
            int  id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Masukkan Nama University : ");
            
            string nama = Console.ReadLine();
            controlUniversity.Update(id,nama);
        }
        public void Delete() {
            Console.WriteLine("*********************DELETE UNIVERSITY***********************");
            Console.WriteLine("Masukkan Id : ");
            int id = Convert.ToInt32(Console.ReadLine());
            controlUniversity.Delete(id);
        }
    }
}
